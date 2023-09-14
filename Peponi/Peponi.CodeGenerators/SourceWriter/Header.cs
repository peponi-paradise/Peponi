namespace Peponi.CodeGenerators.SourceWriter;

internal static partial class SourceWriterExtension
{
    internal static void WriteHeader(this CodeBuilder builder)
    {
        builder.AppendLine("// Auto generated code by Peponi.CodeGenerators");
        builder.AppendLine("// Github : https://github.com/peponi-paradise/Peponi");
        builder.AppendLine("// Blog : https://peponi-paradise.tistory.com");
        builder.NewLine();
    }
}