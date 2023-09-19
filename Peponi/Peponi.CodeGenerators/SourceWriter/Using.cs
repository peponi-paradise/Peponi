using Peponi.CodeGenerators.SemanticTarget;

namespace Peponi.CodeGenerators.SourceWriter;

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
        builder.AppendLine("using Peponi.CodeGenerators.Commands;");
        builder.NewLine();
    }
}