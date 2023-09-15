using Peponi.CodeGenerators.SemanticTarget;
using System.Collections.Immutable;

namespace Peponi.CodeGenerators.SourceWriter;

internal static partial class SourceWriterExtension
{
    internal static void WriteINotifyMembers(this CodeBuilder builder, ObjectDeclarationTarget target)
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
            builder.Append("public ", true);
            if (property.IsStatic) builder.Append("static ");
            builder.Append($"{property.Type} ");
            builder.Append($"{property.PropertyName}");
            builder.NewLine();
            builder.AppendLine("{");
            builder.Indent++;
            builder.AppendLine($"get => {property.FieldName};");
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
                //if (!string.IsNullOrWhiteSpace(property.CallMethodName))
                //{
                //    builder.AppendLine($"{property.CallMethodName}({property.CallMethodArgs})");
                //}
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
                builder.AppendLine($"partial void On{propertyTargets[i].PropertyName}Changed();");
            }
        }
    }
}