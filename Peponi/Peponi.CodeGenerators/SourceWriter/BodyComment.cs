namespace Peponi.CodeGenerators.SourceWriter;

internal static partial class SourceWriterExtension
{
    internal static void WriteMemberComment(this CodeBuilder builder)
    {
        builder.AppendLine("/// <summary>");
        builder.AppendLine("/// Auto generated member by Peponi.CodeGenerators");
        builder.AppendLine("/// </summary>");
    }

    internal static void WritePropertyComment(this CodeBuilder builder)
    {
        builder.AppendLine("/// <summary>");
        builder.AppendLine("/// Auto generated property by Peponi.CodeGenerators");
        builder.AppendLine("/// </summary>");
    }

    internal static void WriteMethodComment(this CodeBuilder builder)
    {
        builder.AppendLine("/// <summary>");
        builder.AppendLine("/// Auto generated method by Peponi.CodeGenerators");
        builder.AppendLine("/// </summary>");
    }
}