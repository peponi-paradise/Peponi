namespace Peponi.CodeGenerators.SourceText;

internal static partial class SourceTextExtension
{
    internal static void WriteUsing(this CodeBuilder builder)
    {
        builder.AppendLine("using System.ComponentModel;");
        builder.AppendLine("");
    }
}