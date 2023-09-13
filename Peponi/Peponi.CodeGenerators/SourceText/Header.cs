namespace Peponi.CodeGenerators.SourceText;

internal static partial class SourceTextExtension
{
    internal static void WriteHeader(this CodeBuilder builder)
    {
        builder.AppendLine("// Auto generated code by Peponi.CodeGenerators");
        builder.AppendLine("// Github : https://github.com/peponi-paradise/Peponi");
        builder.AppendLine("// Blog : https://peponi-paradise.tistory.com");
        builder.AppendLine("");
    }
}