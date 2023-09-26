namespace Peponi.CodeGenerators.SourceWriter;

internal static partial class SourceWriterExtension
{
    internal static void WriteNullable(this CodeBuilder builder)
    {
        builder.AppendLine("#nullable enable");
        builder.NewLine();
    }

    internal static void WriteNullableDisable(this CodeBuilder builder)
    {
        builder.AppendLine("#nullable disable");
        builder.NewLine();
    }
}