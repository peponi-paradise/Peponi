using Peponi.SourceGenerators.SemanticTarget;

namespace Peponi.SourceGenerators.SourceWriter;

internal static partial class SourceWriterExtension
{
    internal static void WriteUsing(this CodeBuilder builder, ObjectDeclarationTarget target)
    {
        if (target.NotifyType == NotifyType.Notify)
        {
            builder.AppendLine("using System.ComponentModel;");
            builder.AppendLine("using System.Runtime.CompilerServices;");
        }
        if (target.ObjectType == ObjectType.Struct) builder.AppendLine("using System.Runtime.InteropServices;");
        builder.NewLine();
    }

    internal static void WriteCommandUsing(this CodeBuilder builder, ObjectDeclarationTarget target)
    {
        builder.AppendLine("using Peponi.SourceGenerators.Commands;");
        builder.NewLine();
    }
}