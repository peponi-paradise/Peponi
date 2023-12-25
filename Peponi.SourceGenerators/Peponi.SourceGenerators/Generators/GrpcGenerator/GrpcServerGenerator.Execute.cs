using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using Peponi.SourceGenerators.SemanticTarget;
using Peponi.SourceGenerators.SourceWriter;
using System.Text;

namespace Peponi.SourceGenerators.GrpcGenerator;

public sealed partial class GrpcServerGenerator
{
    private void BeginExecute(CodeBuilder builder)
    {
        builder.WriteHeaderComment();

        builder.AppendLine("namespace Peponi.SourceGenerators.Grpc;");
        builder.NewLine();

        builder.AppendLine("public static class GrpcServerMapper");
        builder.AppendLine("{");
        builder.Indent++;

        builder.AppendLine("public static List<ServerServiceDefinition> MapGrpcServices()");
        builder.AppendLine("{");
        builder.Indent++;
        builder.AppendLine("List<ServerServiceDefinition> rtns = new();");
    }

    private void Execute(GrpcServerInfo info, CodeBuilder builder)
    {
        builder.AppendLine($"rtns.Add({info.ServiceNamespace}::{info.ServiceBaseFullName}.BindService(new {info.ServiceNamespace}::{info.ServiceFullName}()));");
    }

    private void EndExecute(SourceProductionContext context, CodeBuilder builder)
    {
        builder.AppendLine("return rtns;");
        while (builder.Indent > 0)
        {
            builder.Indent--;
            if (builder.Indent != 0) builder.AppendLine("}");
            else builder.Append("}");
        }

        context.AddSource("GrpcServerMapper.GrpcServer.cs", SourceText.From(builder.ToString(), Encoding.UTF8));
    }
}