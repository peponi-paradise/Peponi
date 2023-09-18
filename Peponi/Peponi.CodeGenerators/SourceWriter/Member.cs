﻿using Peponi.CodeGenerators.SemanticTarget;
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

    internal static void WriteModelInjectMembers(this CodeBuilder builder, ModelInjectTarget injectTarget, List<PropertyTarget> propertyTargets)
    {
        if (injectTarget.IsStatic == false)
        {
            builder.AppendLine("/// <summary>");
            builder.AppendLine("/// Auto generated model by Peponi.CodeGenerators");
            builder.AppendLine("/// </summary>");
            builder.AppendLine($"protected {injectTarget.TypeName} Model {{ get; set; }}");
            builder.NewLine();
        }

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
                if (injectTarget.IsStatic == false) builder.AppendLine($"get => Model.{property.FieldName};");
                else builder.AppendLine($"get => {injectTarget.TypeName}.{property.FieldName};");
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

                if (injectTarget.IsStatic == false) builder.AppendLine($"return Model.{property.FieldName};");
                else builder.AppendLine($"return {injectTarget.TypeName}.{property.FieldName};");

                builder.Indent--;
                builder.AppendLine("}");
            }
            if (property.IsReadOnly == false)
            {
                builder.AppendLine("set");
                builder.AppendLine("{");
                builder.Indent++;
                if (injectTarget.IsStatic == false) builder.AppendLine($"if(Model.{property.FieldName} != value)");
                else builder.AppendLine($"if({injectTarget.TypeName}.{property.FieldName} != value)");
                builder.AppendLine("{");
                builder.Indent++;
                if (injectTarget.IsStatic == false) builder.AppendLine($"Model.{property.FieldName} = value;");
                else builder.AppendLine($"{injectTarget.TypeName}.{property.FieldName} = value;");
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

        for (int i = 0; i < propertyTargets.Count; i++)
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
}