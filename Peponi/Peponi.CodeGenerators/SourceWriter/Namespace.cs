namespace Peponi.CodeGenerators.SourceWriter;

internal static partial class SourceWriterExtension
{
    internal static void WriteNamespace(this CodeBuilder builder, string namespaceName)
    {
        builder.AppendLine($"namespace {namespaceName}");
        builder.Append("{");
        builder.NewLine();
    }
}