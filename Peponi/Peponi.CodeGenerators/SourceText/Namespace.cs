namespace Peponi.CodeGenerators.SourceText;

internal static partial class SourceTextExtension
{
    internal static void WriteNamespace(this CodeBuilder builder, string namespaceName)
    {
        builder.AppendLine($"namespace {namespaceName}");
        builder.AppendLine("");
        builder.Append("{");
        builder.AppendLine("");
    }
}