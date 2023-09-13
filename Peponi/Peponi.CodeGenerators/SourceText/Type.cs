namespace Peponi.CodeGenerators.SourceText;

internal static partial class SourceTextExtension
{
    internal static void WriteType(this CodeBuilder builder, string modifier, bool isStatic, bool isClass, string name)
    {
        builder.Append(modifier);
        builder.Append(" ");
        if (isStatic) builder.Append("static ");
        builder.Append("partial ");
        if (isClass) builder.Append("class ");
        else builder.Append("struct ");
        builder.Append(name);
        builder.Append(" : INotifyPropertyChanged, INotifyPropertyChanging");
        builder.AppendLine("", false);
        builder.AppendLine("{");
    }
}