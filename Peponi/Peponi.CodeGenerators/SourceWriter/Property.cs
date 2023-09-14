using Peponi.CodeGenerators.INotifyGenerator;
using Peponi.CodeGenerators.PropertyGenerator;
using System.Collections.Immutable;

namespace Peponi.CodeGenerators.SourceWriter;

internal static partial class SourceWriterExtension
{
    internal static void WriteType(this CodeBuilder builder, ObjectDeclarationTarget target)
    {
        builder.Append($"{target.TypeModifier} ", true);
        if (target.IsStatic) builder.Append("static ");
        if (target.IsSealed) builder.Append("sealed ");
        builder.Append("partial ");
        if (target.ObjectType == ObjectType.Class) builder.Append("class ");
        else if (target.ObjectType == ObjectType.Record) builder.Append("record ");
        else builder.Append("struct ");
        builder.Append(target.TypeName);
        builder.NewLine();
        builder.AppendLine("{");
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
                if (property.PropertyType == PropertyType.NotifyProperty)
                {
                    builder.AppendLine($"OnPropertyChanged(nameof({property.PropertyName});");
                }
                builder.AppendLine($"On{property.PropertyName}Changed();");
                if (!string.IsNullOrWhiteSpace(property.CallMethodName))
                {
                    builder.AppendLine($"{property.CallMethodName}({property.CallMethodArgs})");
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
            builder.AppendLine($"partial void On{property.PropertyName}Changed();");
        }
    }
}