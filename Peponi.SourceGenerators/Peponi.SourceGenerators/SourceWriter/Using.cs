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

    internal static void WriteGrpcClientUsings(this CodeBuilder builder, ProtobufInfo info)
    {
        if (info.ClientMode == GrpcClientMode.Standalone) builder.AppendLine("using Grpc.Core;");
        else builder.AppendLine("using Microsoft.Extensions.DependencyInjection;");

        foreach (var data in info.ProtobufDatas)
        {
            builder.AppendLine($"using {data.Namespace};");
        }
        builder.NewLine();
    }
}