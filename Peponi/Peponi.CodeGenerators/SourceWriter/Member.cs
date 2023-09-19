using Peponi.CodeGenerators.SemanticTarget;
using System.Collections.Immutable;

namespace Peponi.CodeGenerators.SourceWriter;

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
            builder.AppendLine("/// <summary>");
            builder.AppendLine("/// Auto generated property by Peponi.CodeGenerators");
            builder.AppendLine("/// </summary>");
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
                    if (method.Section == PropertyMethodSection.Getter)
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
                        if (method.Section == PropertyMethodSection.Setter)
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

        for (int i = 0; i < propertyTargets.Length; i++)
        {
            if (propertyTargets[i].IsReadOnly == false)
            {
                builder.AppendLine("/// <summary>");
                builder.AppendLine("/// Auto generated method by Peponi.CodeGenerators");
                builder.AppendLine("/// </summary>");
                builder.AppendLine($"partial void On{propertyTargets[i].PropertyName}Changed();");
            }
        }
    }

    internal static void WriteInjectModelMembers(this CodeBuilder builder, ImmutableArray<InjectModelTarget> injectTarget)
    {
        bool isFirst = true;
        foreach (var inject in injectTarget)
        {
            if (isFirst) isFirst = false;
            else builder.NewLine();

            if (inject.IsStatic == false)
            {
                string modelName = inject.TypeName.EndsWith("Model") ? inject.TypeName : $"{inject.TypeName}Model";
                builder.AppendLine("/// <summary>");
                builder.AppendLine("/// Auto generated model by Peponi.CodeGenerators");
                builder.AppendLine("/// </summary>");
                if (string.IsNullOrEmpty(inject.CustomName)) builder.AppendLine($"protected {inject.NamespaceName}.{inject.TypeName} {modelName};");
                else builder.AppendLine($"protected {inject.NamespaceName}.{inject.TypeName} {inject.CustomName};");
                builder.NewLine();
            }

            foreach (var property in inject.Properties)
            {
                string getSetWriteName;
                if (inject.IsStatic == false && property.IsStatic == false)
                {
                    if (string.IsNullOrEmpty(inject.CustomName)) getSetWriteName = inject.TypeName.EndsWith("Model") ? $"{inject.TypeName}.{property.FieldName}" : $"{inject.TypeName}Model.{property.FieldName}";
                    else getSetWriteName = $"{inject.CustomName}.{property.FieldName}";
                }
                else getSetWriteName = $"{inject.NamespaceName}.{inject.TypeName}.{property.FieldName}";

                builder.AppendLine("/// <summary>");
                builder.AppendLine("/// Auto generated property by Peponi.CodeGenerators");
                builder.AppendLine("/// </summary>");
                builder.Append("public ", true);
                builder.Append($"{property.Type} ");
                builder.Append($"{property.PropertyName}");
                builder.NewLine();
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
                        if (method.Section == PropertyMethodSection.Getter)
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
                            if (method.Section == PropertyMethodSection.Setter)
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

            for (int i = 0; i < inject.Properties.Count; i++)
            {
                if (inject.Properties[i].IsReadOnly == false)
                {
                    builder.AppendLine("/// <summary>");
                    builder.AppendLine("/// Auto generated method by Peponi.CodeGenerators");
                    builder.AppendLine("/// </summary>");
                    builder.AppendLine($"partial void On{inject.Properties[i].PropertyName}Changed();");
                }
            }
        }
    }

    internal static void WriteDependencyMembers(this CodeBuilder builder, ObjectDeclarationTarget target, ImmutableArray<InjectDependencyTarget> dependencies)
    {
        List<(string TypeName, string FieldName)> dependencyAdded = new();
        foreach (var inject in dependencies)
        {
            builder.AppendLine("/// <summary>");
            builder.AppendLine("/// Auto generated member by Peponi.CodeGenerators");
            builder.AppendLine("/// </summary>");
            if (string.IsNullOrEmpty(inject.CustomName))
            {
                builder.AppendLine($"{Creater.GetAccessibilityString(inject.Modifier)} {inject.NamespaceName}.{inject.TypeName} {Creater.GetObjectName(inject.TypeName, inject.Modifier)};");
                dependencyAdded.Add(($"{inject.NamespaceName}.{inject.TypeName}", Creater.GetObjectName(inject.TypeName, inject.Modifier)));
            }
            else
            {
                builder.AppendLine($"{Creater.GetAccessibilityString(inject.Modifier)} {inject.NamespaceName}.{inject.TypeName} {inject.CustomName};");
                dependencyAdded.Add(($"{inject.NamespaceName}.{inject.TypeName}", inject.CustomName));
            }
            builder.NewLine();
        }

        builder.AppendLine("/// <summary>");
        builder.AppendLine("/// Auto generated method by Peponi.CodeGenerators");
        builder.AppendLine("/// </summary>");
        builder.Append($"public ", true);
        builder.Append(target.TypeName);
        string injectString = string.Empty;
        foreach (var item in dependencyAdded)
        {
            injectString += $"{item.TypeName} {item.FieldName},";
        }
        if (dependencyAdded.Count > 0) injectString = injectString.Remove(injectString.Length - 1, 1);
        builder.Append($"({injectString})");
        builder.NewLine();
        builder.AppendLine("{");
        builder.Indent++;
        foreach (var inject in dependencyAdded)
        {
            builder.AppendLine($"this.{inject.FieldName} = {inject.FieldName};");
        }
        builder.Indent--;
        builder.AppendLine("}");
    }

    internal static void WriteCommandMembers(this CodeBuilder builder, ImmutableArray<MethodTarget> methods)
    {
        foreach (var method in methods)
        {
            string commandBaseName = "CommandBase";
            if (!string.IsNullOrWhiteSpace(method.Parameter)) commandBaseName += $"<{method.Parameter}>?";
            else commandBaseName += "?";

            builder.AppendLine($"private {commandBaseName.Clone()} {Creater.GetObjectName(method.Name, Modifier.Private)}Command;");
            builder.NewLine();
            commandBaseName = commandBaseName.Remove(commandBaseName.Length - 1, 1);

            builder.AppendLine("/// <summary>");
            builder.AppendLine("/// Auto generated method by Peponi.CodeGenerators");
            builder.AppendLine("/// </summary>");
            builder.Append($"public ", true);
            builder.Append($"ICommandBase {method.Name}Command => {Creater.GetObjectName(method.Name, Modifier.Private)}Command ??= new {commandBaseName}(");
            string action = GetMethodDesc(method);
            string func = method.CanExecuteTarget != null ? GetMethodDesc(method.CanExecuteTarget) : "";
            if (!string.IsNullOrEmpty(func)) builder.AppendLine($"{action}, {func});", false);
            else builder.AppendLine($"{action});", false);
        }

        string GetMethodDesc(MethodBase method)
        {
            return (method.Parameter, method.IsAsync) switch
            {
                ({ Length: > 0 }, true) => $"async x => await {method.Name}(x)",
                ({ Length: > 0 }, false) => $"{method.Name}",
                ({ Length: < 1 }, true) => $"async () => {{ await {method.Name}(); }}",
                ({ Length: < 1 }, false) => $"{method.Name}"
            };
        }
    }
}