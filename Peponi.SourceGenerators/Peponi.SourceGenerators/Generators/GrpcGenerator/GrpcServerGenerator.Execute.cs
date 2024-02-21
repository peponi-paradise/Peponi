using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using Peponi.SourceGenerators.SemanticTarget;
using Peponi.SourceGenerators.SourceWriter;
using System.Collections.Immutable;
using System.Text;

namespace Peponi.SourceGenerators.GrpcGenerator;

public sealed partial class GrpcServerGenerator
{
    private static void ExecuteCore(SourceProductionContext context, ImmutableArray<(GrpcServerInfo ServerInfo, Diagnostic Error)> targetInfos)
    {
        var gRPCCoreInfos = targetInfos.Where(x => x.ServerInfo.ServerMode == GrpcServerMode.Standalone).Select(x => x.ServerInfo).ToList();
        var ASPInfos = targetInfos.Where(x => x.ServerInfo.ServerMode == GrpcServerMode.ClientFactory).Select(x => x.ServerInfo).ToList();

        if (gRPCCoreInfos.Any()) ExecuteGrpc(context, gRPCCoreInfos);
        if (ASPInfos.Any()) ExecuteASP(context, ASPInfos);
    }

    private static void ExecuteGrpc(SourceProductionContext context, List<GrpcServerInfo> infos)
    {
        CodeBuilder builder = new();
        builder.WriteHeaderComment();

        builder.AppendLine("using Grpc.Core;");
        builder.NewLine();

        builder.AppendLine("namespace Peponi.SourceGenerators.Grpc;");
        builder.NewLine();

        builder.AppendLine("public static partial class GrpcServerMapper");
        builder.AppendLine("{");
        builder.Indent++;

        builder.WriteMethodComment();

        builder.AppendLine("public static List<ServerServiceDefinition> GetStandaloneServices()");
        builder.AppendLine("{");
        builder.Indent++;
        builder.AppendLine("List<ServerServiceDefinition> rtns = new();");

        foreach (var info in infos)
        {
            builder.AppendLine($"rtns.Add(global::{info.ServiceBaseNamespace}.{info.ServiceBaseFullName}.BindService(new global::{info.ServiceNamespace}.{info.ServiceFullName}()));");
        }

        builder.AppendLine("return rtns;");
        builder.CloseAllIndents();

        context.AddSource("GrpcServerMapper.GrpcCore.cs", SourceText.From(builder.ToString(), Encoding.UTF8));
    }

    private static void ExecuteASP(SourceProductionContext context, List<GrpcServerInfo> infos)
    {
        CodeBuilder builder = new();
        builder.WriteHeaderComment();

        builder.AppendLine("using Microsoft.AspNetCore.Routing;");
        builder.NewLine();

        builder.AppendLine("namespace Peponi.SourceGenerators.Grpc;");
        builder.NewLine();

        builder.AppendLine("public static partial class GrpcServerMapper");
        builder.AppendLine("{");
        builder.Indent++;

        builder.WriteMethodComment();

        builder.AppendLine("public static IEndpointRouteBuilder MapClientFactoryServices(IEndpointRouteBuilder builder)");
        builder.AppendLine("{");
        builder.Indent++;

        foreach (var info in infos)
        {
            builder.AppendLine($"builder.MapGrpcService<global::{info.ServiceNamespace}.{info.ServiceFullName}>();");
        }

        builder.AppendLine("return builder;");
        builder.CloseAllIndents();

        context.AddSource("GrpcServerMapper.ASP.Net.cs", SourceText.From(builder.ToString(), Encoding.UTF8));
    }
}