namespace Peponi.CodeGenerators.SourceText;

internal static partial class SourceTextExtension
{
    internal static void WriteNullable(this CodeBuilder builder)
    {
        builder.AppendLine("#nullable enable");
        builder.AppendLine("");
    }
}