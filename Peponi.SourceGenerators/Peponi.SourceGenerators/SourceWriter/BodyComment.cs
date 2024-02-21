namespace Peponi.SourceGenerators.SourceWriter;

internal static partial class SourceWriterExtension
{
    internal static void WriteMemberComment(this CodeBuilder builder)
    {
        builder.AppendLine("/// <summary>");
        builder.AppendLine("/// Auto generated member by Peponi.SourceGenerators");
        builder.AppendLine("/// </summary>");
    }

    internal static void WritePropertyComment(this CodeBuilder builder)
    {
        builder.AppendLine("/// <summary>");
        builder.AppendLine("/// Auto generated property by Peponi.SourceGenerators");
        builder.AppendLine("/// </summary>");
    }

    internal static void WriteMethodComment(this CodeBuilder builder)
    {
        builder.AppendLine("/// <summary>");
        builder.AppendLine("/// Auto generated method by Peponi.SourceGenerators");
        builder.AppendLine("/// </summary>");
    }
}