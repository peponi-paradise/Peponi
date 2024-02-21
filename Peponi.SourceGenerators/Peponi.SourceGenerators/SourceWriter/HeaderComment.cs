namespace Peponi.SourceGenerators.SourceWriter;

internal static partial class SourceWriterExtension
{
    internal static void WriteHeaderComment(this CodeBuilder builder)
    {
        builder.AppendLine("// Auto generated code by Peponi.SourceGenerators");
        builder.AppendLine("// Github : https://github.com/peponi-paradise/Peponi");
        builder.AppendLine("// Blog : https://peponi-paradise.tistory.com");
        builder.NewLine();
    }
}