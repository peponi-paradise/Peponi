namespace Peponi.CodeGenerators.SourceWriter;

internal static partial class SourceWriterExtension
{
    internal static void WriteUsing(this CodeBuilder builder)
    {
        builder.AppendLine("using System.ComponentModel;");
        builder.NewLine();
    }
}