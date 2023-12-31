﻿using Peponi.SourceGenerators.SemanticTarget;
using System.Collections.Immutable;

namespace Peponi.SourceGenerators.SourceWriter;

internal static partial class SourceWriterExtension
{
    internal static void WriteNotifyInterfaceMembers(this CodeBuilder builder, ObjectDeclarationTarget target)
    {
        builder.AppendLine("/// <inheritdoc cref=\"INotifyPropertyChanged.PropertyChanged\"/>");
        builder.AppendLine("public event PropertyChangedEventHandler? PropertyChanged;");
        builder.NewLine();
        builder.AppendLine("/// <summary>");
        builder.AppendLine("/// Raises the <see cref=\"PropertyChanged\"/> event");
        builder.AppendLine("/// </summary>");
        builder.AppendLine("/// <param name=\"e\">A <see cref=\"PropertyChangedEventArgs\"/> that contains the name of the changed property.</param>");
        if (!target.IsSealed) builder.Append("protected ", true);
        else builder.Append("private ", true);
        if (!target.IsSealed) builder.Append("virtual ");
        builder.AppendLine("void OnPropertyChanged(PropertyChangedEventArgs e)", false);
        builder.AppendLine("{");
        builder.Indent++;
        builder.AppendLine("PropertyChanged?.Invoke(this, e);");
        builder.Indent--;
        builder.AppendLine("}");
        builder.NewLine();
        builder.AppendLine("/// <summary>");
        builder.AppendLine("/// Raises the <see cref=\"PropertyChanged\"/> event.");
        builder.AppendLine("/// </summary>");
        builder.AppendLine("/// <param name=\"propertyName\">(optional) The name of the property that changed.</param>");
        if (!target.IsSealed) builder.Append("protected ", true);
        else builder.Append("private ", true);
        builder.AppendLine("void OnPropertyChanged([CallerMemberName] string? propertyName = null)", false);
        builder.AppendLine("{");
        builder.Indent++;
        builder.AppendLine("OnPropertyChanged(new PropertyChangedEventArgs(propertyName));");
        builder.Indent--;
        builder.AppendLine("}");
    }

    internal static void WriteProperties(this CodeBuilder builder, ImmutableArray<PropertyTarget> propertyTargets)
    {
        foreach (var property in propertyTargets)
        {
            builder.WritePropertyComment();
            builder.Append("public ", true);
            builder.Append($"{property.Type} ");
            builder.Append($"{property.PropertyName}");
            builder.NewLine();
            builder.AppendLine("{");
            builder.Indent++;
            if (property.PropertyMethods == null || property.PropertyMethods.Count == 0)
            {
                builder.AppendLine($"get => {property.FieldName};");
            }
            else if (property.PropertyMethods != null && property.PropertyMethods.Count > 0)
            {
                builder.AppendLine("get");
                builder.AppendLine("{");
                builder.Indent++;
                foreach (var method in property.PropertyMethods)
                {
                    if (method.Section == PropertySection.Getter)
                    {
                        builder.AppendLine($"{method.MethodName}({method.MethodArgs});");
                    }
                }
                builder.AppendLine($"return {property.FieldName};");
                builder.Indent--;
                builder.AppendLine("}");
            }
            if (property.IsReadOnly == false)
            {
                builder.AppendLine("set");
                builder.AppendLine("{");
                builder.Indent++;
                builder.AppendLine($"if({property.FieldName} != value)");
                builder.AppendLine("{");
                builder.Indent++;
                builder.AppendLine($"{property.FieldName} = value;");
                if (property.NotifyType == NotifyType.Notify)
                {
                    builder.AppendLine($"OnPropertyChanged(nameof({property.PropertyName}));");
                }
                builder.AppendLine($"On{property.PropertyName}Changed();");
                if (property.PropertyMethods != null && property.PropertyMethods.Count > 0)
                {
                    foreach (var method in property.PropertyMethods)
                    {
                        if (method.Section == PropertySection.Setter)
                        {
                            builder.AppendLine($"{method.MethodName}({method.MethodArgs});");
                        }
                    }
                }
                if (property.CanExecuteChangedTargets != null && property.CanExecuteChangedTargets.Count > 0)
                {
                    foreach (var target in property.CanExecuteChangedTargets)
                    {
                        builder.AppendLine($"{target.CommandName}.RaiseCanExecuteChanged();");
                    }
                }
                if (property.RaisePropertyChangedTargets != null && property.RaisePropertyChangedTargets.Count > 0)
                {
                    foreach (var target in property.RaisePropertyChangedTargets)
                    {
                        builder.AppendLine($"OnPropertyChanged(nameof({target.PropertyName}));");
                    }
                }
                for (int i = 0; i < 2; i++)
                {
                    builder.Indent--;
                    builder.AppendLine("}");
                }
            }
            builder.Indent--;
            builder.AppendLine("}");
            builder.NewLine();
        }

        for (int i = 0; i < propertyTargets.Length; i++)
        {
            if (propertyTargets[i].IsReadOnly == false)
            {
                builder.WriteMethodComment();
                builder.AppendLine($"partial void On{propertyTargets[i].PropertyName}Changed();");
            }
        }
    }

    internal static void WriteInjectMembers(this CodeBuilder builder, ObjectDeclarationTarget objectTarget, ImmutableArray<ImmutableArray<InjectTarget>> injectTargets)
    {
        List<(string InjectTypeName, string InjectObjectName)> dependencyAdded = new();

        foreach (var targets in injectTargets)
        {
            foreach (var target in targets)
            {
                // Inject object

                string injectObjectName = target.FullTypeName.Split('.').Last().Replace("?", "");
                injectObjectName = string.IsNullOrWhiteSpace(target.CustomName) ? Creater.GetObjectName(injectObjectName, target.Modifier) : target.CustomName;
                if (!target.IsStatic)
                {
                    builder.WriteMemberComment();
                    builder.AppendLine($"{Creater.GetAccessibilityString(target.Modifier)} {target.FullTypeName} {injectObjectName};");
                    builder.NewLine();

                    if (target.InjectionMode == InjectionType.Dependency || target.InjectionMode == (InjectionType.Dependency | InjectionType.Model))
                    {
                        dependencyAdded.Add(($"{target.FullTypeName}", injectObjectName));
                    }
                }

                // Property

                foreach (var property in target.Properties)
                {
                    string getSetWriteName = $"{injectObjectName}.{property.FieldName}";
                    if (target.IsStatic || property.IsStatic)
                    {
                        getSetWriteName = $"{target.FullTypeName}.{property.FieldName}";
                    }

                    builder.WritePropertyComment();
                    builder.AppendLine($"public {property.Type} {property.PropertyName}");
                    builder.AppendLine("{");
                    builder.Indent++;
                    if (property.PropertyMethods == null || property.PropertyMethods.Count == 0)
                    {
                        builder.AppendLine($"get => {getSetWriteName};");
                    }
                    else if (property.PropertyMethods != null && property.PropertyMethods.Count > 0)
                    {
                        builder.AppendLine("get");
                        builder.AppendLine("{");
                        builder.Indent++;

                        foreach (var method in property.PropertyMethods)
                        {
                            if (method.Section == PropertySection.Getter)
                            {
                                builder.AppendLine($"{method.MethodName}({method.MethodArgs});");
                            }
                        }

                        builder.AppendLine($"return {getSetWriteName};");

                        builder.Indent--;
                        builder.AppendLine("}");
                    }
                    if (property.IsReadOnly == false)
                    {
                        builder.AppendLine("set");
                        builder.AppendLine("{");
                        builder.Indent++;
                        builder.AppendLine($"if({getSetWriteName} != value)");
                        builder.AppendLine("{");
                        builder.Indent++;
                        builder.AppendLine($"{getSetWriteName} = value;");
                        if (property.NotifyType == NotifyType.Notify)
                        {
                            builder.AppendLine($"OnPropertyChanged(nameof({property.PropertyName}));");
                        }
                        builder.AppendLine($"On{property.PropertyName}Changed();");
                        if (property.PropertyMethods != null && property.PropertyMethods.Count > 0)
                        {
                            foreach (var method in property.PropertyMethods)
                            {
                                if (method.Section == PropertySection.Setter)
                                {
                                    builder.AppendLine($"{method.MethodName}({method.MethodArgs});");
                                }
                            }
                        }
                        for (int i = 0; i < 2; i++)
                        {
                            builder.Indent--;
                            builder.AppendLine("}");
                        }
                    }
                    builder.Indent--;
                    builder.AppendLine("}");
                    builder.NewLine();
                }

                for (int i = 0; i < target.Properties.Count; i++)
                {
                    if (target.Properties[i].IsReadOnly == false)
                    {
                        builder.WriteMethodComment();
                        builder.AppendLine($"partial void On{target.Properties[i].PropertyName}Changed();");
                        if (i != target.Properties.Count - 1) builder.NewLine();
                        else if (dependencyAdded.Count > 0 || targets.Last() != target) builder.NewLine();
                    }
                }
            }
        }

        if (dependencyAdded.Count > 0)
        {
            // ctor
            builder.WriteMethodComment();
            builder.Append($"public ", true);
            builder.Append(objectTarget.TypeName);
            List<string> injectItems = new();
            foreach (var item in dependencyAdded) injectItems.Add($"{item.InjectTypeName} {item.InjectObjectName}");
            string injectString = string.Join(", ", injectItems);
            builder.Append($"({injectString})");
            builder.NewLine();
            builder.AppendLine("{");
            builder.Indent++;
            foreach (var inject in dependencyAdded)
            {
                builder.AppendLine($"this.{inject.InjectObjectName} = {inject.InjectObjectName};");
            }
            builder.Indent--;
            builder.AppendLine("}");
        }
    }

    internal static void WriteCommandMembers(this CodeBuilder builder, ImmutableArray<MethodTarget> methods)
    {
        foreach (var method in methods)
        {
            string commandBaseName = "CommandBase";
            if (!string.IsNullOrWhiteSpace(method.ParameterType)) commandBaseName += $"<{method.ParameterType}>?";
            else commandBaseName += "?";

            string commandName = string.IsNullOrWhiteSpace(method.CustomMethodName) ? $"{method.Name}Command" : method.CustomMethodName!;

            builder.AppendLine($"private {commandBaseName.Clone()} {Creater.GetObjectName(method.Name, Modifier.Private)}Command;");
            builder.NewLine();
            commandBaseName = commandBaseName.Remove(commandBaseName.Length - 1, 1);

            builder.WriteMethodComment();
            builder.Append($"public ", true);
            builder.Append($"ICommandBase {commandName} => {Creater.GetObjectName(method.Name, Modifier.Private)}Command ??= new {commandBaseName}(");
            string action = GetMethodDesc(method);
            string func = method.CanExecuteTarget != null ? GetCanMethodDesc(method) : "";
            if (!string.IsNullOrEmpty(func)) builder.AppendLine($"{action}, {func});", false);
            else builder.AppendLine($"{action});", false);
        }

        string GetMethodDesc(MethodTarget method)
        {
            return (method.ParameterType, method.IsAsync) switch
            {
                ({ Length: > 0 }, true) => $"async x => await {method.Name}(x)",
                ({ Length: > 0 }, false) => $"{method.Name}",
                ({ Length: < 1 }, true) => $"async () => {{ await {method.Name}(); }}",
                ({ Length: < 1 }, false) => $"{method.Name}"
            };
        }

        string GetCanMethodDesc(MethodTarget method)
        {
            if (method.ParameterType == method.CanExecuteTarget?.ParameterType) return method.CanExecuteTarget.Name;
            else if (method.ParameterType.Length > 0)
            {
                if (method.CanExecuteTarget?.ParameterType.Length < 1) return $"_ => {method.CanExecuteTarget.Name}()";
            }
            // 여기까지 들어오면 앞의 코드에 문제 있음. 에러 내보내야 함
            return string.Empty;
        }
    }

    internal static void WriteGrpcClientMembers(this CodeBuilder builder, ProtobufInfo info)
    {
        if (info.ClientMode == GrpcClientMode.Standalone) WriteStandalone();
        else WriteClientFactory();

        void WriteStandalone()
        {
            // Write members
            foreach (var data in info.ProtobufDatas)
            {
                foreach (var service in data.ServiceNames)
                {
                    builder.WriteMemberComment();
                    builder.AppendLine($"private {service}.{service}Client _{service};");
                }
            }

            builder.NewLine();

            // Write method
            builder.WriteMethodComment();
            builder.AppendLine("private bool CreateServices()");
            builder.AppendLine("{");
            builder.Indent++;
            builder.AppendLine("bool rtn = true;");
            builder.AppendLine("try");
            builder.AppendLine("{");
            builder.Indent++;
            foreach (var data in info.ProtobufDatas)
            {
                foreach (var service in data.ServiceNames)
                {
                    builder.AppendLine($"_{service} = new {service}.{service}Client({info.Remote});");
                }
            }
            builder.Indent--;
            builder.AppendLine("}");
            builder.AppendLine("catch");
            builder.AppendLine("{");
            builder.Indent++;
            builder.AppendLine("rtn = false;");
            builder.Indent--;
            builder.AppendLine("}");
            builder.AppendLine("return rtn;");
            builder.Indent--;
            builder.AppendLine("}");
        }

        void WriteClientFactory()
        {
            // Write method
            builder.WriteMethodComment();
            builder.AppendLine("private IServiceCollection AddClientsFactory(IServiceCollection services)");
            builder.AppendLine("{");
            builder.Indent++;
            builder.AppendLine("services");
            foreach (var data in info.ProtobufDatas)
            {
                foreach (var service in data.ServiceNames)
                {
                    builder.AppendLine($".AddGrpcClient<{service}.{service}Client>(o => {{ o.Address = new Uri(\"{info.Remote}\"); }})");
                }
            }
            builder.AppendLine(";");
            builder.AppendLine("return services;");
            builder.Indent--;
            builder.AppendLine("}");
        }
    }
}