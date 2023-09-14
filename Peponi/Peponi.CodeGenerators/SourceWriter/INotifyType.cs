using Peponi.CodeGenerators.INotifyGenerator;

namespace Peponi.CodeGenerators.SourceWriter;

internal static partial class SourceWriterExtension
{
    internal static void WriteINotifyType(this CodeBuilder builder, string modifier, string name, ObjectType objectType, bool isStatic, bool isSealed)
    {
        builder.Append($"{modifier} ", true);
        if (isStatic) builder.Append("static ");
        if (isSealed) builder.Append("sealed ");
        builder.Append("partial ");
        if (objectType == ObjectType.Class) builder.Append("class ");
        else if (objectType == ObjectType.Record) builder.Append("record ");
        else builder.Append("struct ");
        builder.Append(name);
        builder.Append(" : INotifyPropertyChanged");
        builder.NewLine();
        builder.AppendLine("{");
    }

    internal static void WriteINotifyContents(this CodeBuilder builder)
    {
        builder.AppendLine("/// <inheritdoc cref=\"INotifyPropertyChanged.PropertyChanged\"/>");
        builder.AppendLine("public event PropertyChangedEventHandler? PropertyChanged;");
        builder.NewLine();
        builder.AppendLine("/// <summary>");
        builder.AppendLine("/// Raises the <see cref=\"PropertyChanged\"/> event");
        builder.AppendLine("/// </summary>");
        builder.AppendLine("/// <param name=\"e\">A <see cref=\"PropertyChangedEventArgs\"/> that contains the name of the changed property.</param>");
        builder.AppendLine("protected virtual void OnPropertyChanged(PropertyChangedEventArgs e)");
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
        builder.AppendLine("protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)");
        builder.AppendLine("{");
        builder.Indent++;
        builder.AppendLine("OnPropertyChanged(new PropertyChangedEventArgs(propertyName));");
        builder.Indent--;
        builder.AppendLine("}");
    }
}