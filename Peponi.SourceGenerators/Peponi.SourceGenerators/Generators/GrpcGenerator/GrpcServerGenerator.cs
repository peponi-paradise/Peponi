using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Peponi.SourceGenerators.Diagnostics;
using Peponi.SourceGenerators.SemanticTarget;

namespace Peponi.SourceGenerators.GrpcGenerator;

[Generator]
public sealed partial class GrpcServerGenerator : IIncrementalGenerator
{
    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        var syntaxProvider = context.SyntaxProvider.CreateSyntaxProvider(
            predicate: static (s, _) => IsValidTarget(s),
            transform: static (context, _) => GetGrpcClientTarget(context));

        var errorInfos = syntaxProvider.Where(static item => item.Error is not null);
        context.RegisterSourceOutput(errorInfos, static (productionContext, target) => DiagnosticMapper.Report(productionContext, target.Error!));

        //var targetInfos = syntaxProvider.Where(static item => item.Target.ObjectTarget is not null && item.Target.ProtobufTarget is not null);
        //context.RegisterSourceOutput(targetInfos, static (productionContext, targetInfo) => Execute(productionContext, targetInfo.Target.ObjectTarget, targetInfo.Target.ProtobufTarget));
        //context.RegisterSourceOutput()
    }

    private static bool IsValidTarget(SyntaxNode node) => node is ClassDeclarationSyntax { AttributeLists: { Count: > 0 } };

    private static (GrpcServerInfo Info, Diagnostic Error) GetGrpcClientTarget(GeneratorSyntaxContext context)
    {
        var typeSymbol = Creater.GetTypeSymbol(context);
        if (typeSymbol is null) return ((null, default)!, null)!;

        AttributeData? attributeData = Creater.GetAttribute(typeSymbol, "Peponi.SourceGenerators.GrpcClientAttribute");
        if (attributeData is null) return ((null, default)!, null)!;
        else
        {
            ObjectType? objectType = Creater.GetObjectType(typeSymbol);
            if (objectType is null)
            {
                // return (null, DiagnosticMapper.Create(typeSymbol, CouldNotFindTypeObject));
                return ((null, default)!, null)!;
            }

            var modifier = Creater.GetAccessibilityString(typeSymbol.DeclaredAccessibility);
            if (string.IsNullOrEmpty(modifier))
            {
                // return (null, DiagnosticMapper.Create(typeSymbol, CouldNotFindTypeModifier));
                return ((null, default)!, null)!;
            }

            GrpcClientMode clientMode = (GrpcClientMode)Creater.GetConstructorArgument(attributeData, 0)?.Value!;
            string remote = Creater.GetConstructorArgumentString(attributeData, 1)!;
            string protoRootPath = Creater.GetConstructorArgumentString(attributeData, 2)!;

            // Read protos

            ProtobufInfo protobufTarget = new(clientMode, remote, new());

            try
            {
                DirectoryInfo dirInfo = new(protoRootPath);

                foreach (var file in dirInfo.EnumerateFiles("*", SearchOption.AllDirectories))
                {
                    if (Path.GetExtension(file.FullName).ToLower() == ".proto")
                    {
                        var textDatas = File.ReadAllLines(file.FullName);

                        bool packageDetected = false;
                        bool csNamespaceDetected = false;
                        string packageName = string.Empty;
                        string csNamespace = string.Empty;
                        List<string> serviceNames = new();

                        foreach (var textData in textDatas)
                        {
                            if (textData.StartsWith("package"))
                            {
                                packageDetected = true;
                                packageName = textData.Split(' ')[1].Split(';')[0];
                                packageName = GetPascalCase(packageName);
                            }
                            else if (textData.StartsWith("option csharp_namespace ="))
                            {
                                csNamespaceDetected = true;
                                csNamespace = textData.Split('=')[1].Split(' ')[1].Split(';')[0].Split('"')[1];
                            }
                            else if (textData.StartsWith("service"))
                            {
                                serviceNames.Add(textData.Split(' ')[1].Split('{')[0]);
                            }
                        }

                        string finalNamespace = string.Empty;
                        if (csNamespaceDetected) finalNamespace = csNamespace;
                        else if (packageDetected) finalNamespace = packageName;

                        if (!string.IsNullOrWhiteSpace(finalNamespace) && serviceNames.Count > 0)
                        {
                            if (protobufTarget.ProtobufDatas.FindIndex(x => x.Namespace == finalNamespace) is var index && index != -1)
                            {
                                protobufTarget.ProtobufDatas[index].ServiceNames.AddRange(serviceNames);
                            }
                            else
                            {
                                protobufTarget.ProtobufDatas.Add(new(finalNamespace, serviceNames));
                            }
                        }
                    }
                }

                if (protobufTarget.ProtobufDatas.Count == 0)
                {
                    // return ((null, default)!, DiagnosticMapper.Create(typeSymbol, NoProtobufFoundError));
                    return ((null, default)!, null)!;
                }
            }
            catch
            {
                //return ((null, default)!, DiagnosticMapper.Create(typeSymbol, ProtobufResolveError));
                return ((null, default)!, null)!;
            }

            return ((new ObjectDeclarationTarget(
                typeSymbol!.Name,
                modifier,
                typeSymbol.ContainingNamespace.ToDisplayString(),
                (ObjectType)objectType!,
                NotifyType.None,
                typeSymbol.IsStatic!,
                typeSymbol.IsSealed,
                typeSymbol.IsAbstract
                ), protobufTarget), null)!;

            string GetPascalCase(string input)
            {
                if (char.IsLower(input[0])) return char.ToUpper(input[0]) + input.Substring(1);
                else return input;
            }
        }
    }
}

// 테스트 했던 코드

//namespace ConsoleApp2;

//internal class Program
//{
//    private static void Main(string[] args)
//    {
//        DirectoryInfo info = new DirectoryInfo($@"C:\Source\Project\SECFDCSW\SECFDCSW\Protos\");

//        Console.WriteLine("File Scan......");

//        foreach (var file in info.EnumerateFiles())
//        {
//            Console.WriteLine(file.FullName);
//        }

//        ConsoleDivider();

//        Console.WriteLine("Read Data.......");

//        foreach (var file in info.EnumerateFiles())
//        {
//            Console.WriteLine(File.ReadAllText(file.FullName));
//        }

//        ConsoleDivider();

//        Console.WriteLine("Extracting Data....");

//        Console.WriteLine();

//        foreach (var file in info.EnumerateFiles())
//        {
//            Console.WriteLine($"Current file is : {file.Name}");
//            Console.WriteLine();

//            var textDatas = File.ReadAllLines(file.FullName);

//            foreach (var textData in textDatas)
//            {
//                if (textData.StartsWith("package"))
//                {
//                    Console.WriteLine($"Package detected : {textData.Split(' ')[1].Split(';')[0]}");
//                }
//                else if (textData.StartsWith("option csharp_namespace ="))
//                {
//                    Console.WriteLine($"!! C# namespace detected : {textData.Split('=')[1].Split(' ')[1].Split(';')[0].Split('"')[1]}");
//                }
//                else if (textData.StartsWith("service"))
//                {
//                    Console.WriteLine($"Service detected : {textData.Split(' ')[1].Split('{')[0]}");
//                }
//            }
//            Console.WriteLine();
//        }

//        ConsoleDivider();

//        Console.WriteLine("Generating into C# classes.........");
//        Console.WriteLine();

//        foreach (var file in info.EnumerateFiles())
//        {
//            Console.WriteLine($"Current file is : {file.Name}");
//            Console.WriteLine();

//            var textDatas = File.ReadAllLines(file.FullName);

//            bool packageDetected = false;
//            bool csNamespaceDetected = false;
//            bool serviceDetected = false;
//            string packageName = string.Empty;
//            string csNamespace = string.Empty;
//            string serviceName = string.Empty;

//            foreach (var textData in textDatas)
//            {
//                if (textData.StartsWith("package"))
//                {
//                    packageDetected = true;
//                    packageName = textData.Split(' ')[1].Split(';')[0];
//                    packageName = GetPascalCase(packageName);
//                }
//                else if (textData.StartsWith("option csharp_namespace ="))
//                {
//                    csNamespaceDetected = true;
//                    csNamespace = textData.Split('=')[1].Split(' ')[1].Split(';')[0].Split('"')[1];
//                }
//                else if (textData.StartsWith("service"))
//                {
//                    serviceDetected = true;
//                    serviceName = textData.Split(' ')[1].Split('{')[0];
//                }
//            }

//            string finalNamespace = string.Empty;
//            if (csNamespaceDetected) finalNamespace = csNamespace;
//            else if (packageDetected) finalNamespace = packageName;
//            if (serviceDetected)
//            {
//                Console.WriteLine($"using {finalNamespace};");
//                Console.WriteLine($"namespace Test;");
//                Console.WriteLine($"public partial class TestClass");
//                Console.WriteLine("{");
//                Console.WriteLine($"    private bool CreateServiceStub()");
//                Console.WriteLine("    {");
//                Console.WriteLine($"        {serviceName} = new {serviceName}.{serviceName}Client(RPCChannel);");
//                Console.WriteLine("    }");
//                Console.WriteLine("}");
//            }

//            ConsoleDivider();
//        }

//        Console.WriteLine("Test for fully created C# class.........");
//        Console.WriteLine();

//        List<ProtobufInfo> protos = new();

//        foreach (var file in info.EnumerateFiles())
//        {
//            if (Path.GetExtension(file.FullName).ToLower() == ".proto")
//            {
//                var textDatas = File.ReadAllLines(file.FullName);

//                bool packageDetected = false;
//                bool csNamespaceDetected = false;
//                string packageName = string.Empty;
//                string csNamespace = string.Empty;
//                List<string> serviceNames = new();

//                foreach (var textData in textDatas)
//                {
//                    if (textData.StartsWith("package"))
//                    {
//                        packageDetected = true;
//                        packageName = textData.Split(' ')[1].Split(';')[0];
//                        packageName = GetPascalCase(packageName);
//                    }
//                    else if (textData.StartsWith("option csharp_namespace ="))
//                    {
//                        csNamespaceDetected = true;
//                        csNamespace = textData.Split('=')[1].Split(' ')[1].Split(';')[0].Split('"')[1];
//                    }
//                    else if (textData.StartsWith("service"))
//                    {
//                        serviceNames.Add(textData.Split(' ')[1].Split('{')[0]);
//                    }
//                }

//                string finalNamespace = string.Empty;
//                if (csNamespaceDetected) finalNamespace = csNamespace;
//                else if (packageDetected) finalNamespace = packageName;

//                if (!string.IsNullOrWhiteSpace(finalNamespace) && serviceNames.Count > 0)
//                {
//                    if (protos.FindIndex(x => x.Namespace == finalNamespace) is var index && index != -1)
//                    {
//                        protos[index].ServiceNames.AddRange(serviceNames);
//                    }
//                    else
//                    {
//                        ProtobufInfo protobufInfo = new();
//                        protobufInfo.Namespace = finalNamespace;
//                        protobufInfo.ServiceNames = serviceNames;
//                        protos.Add(protobufInfo);
//                    }
//                }
//            }
//        }

//        WriteClass(protos);
//    }

//    private static void ConsoleDivider()
//    {
//        Console.WriteLine();
//        Console.WriteLine("-----------------------------------------------------------------");
//        Console.WriteLine();
//    }

//    private static string GetPascalCase(string input)
//    {
//        if (char.IsLower(input[0])) return char.ToUpper(input[0]) + input.Substring(1);
//        else return input;
//    }

//    private static void WriteClass(List<ProtobufInfo> infos)
//    {
//        while (true)
//        {
//            Console.WriteLine();
//            Console.WriteLine("Press 'N' to stop. Else, continue operation.");
//            var key = Console.ReadLine();
//            if (key != null && key.ToLower().Contains('n')) break;

//            Console.WriteLine();
//            Console.WriteLine("Input gRPC Type - [1] Client, [2] Server");
//            if (int.TryParse(Console.ReadLine(), out var gRPCType))
//            {
//                switch (gRPCType)
//                {
//                    case 1:
//                        Console.WriteLine();
//                        Console.WriteLine("Configure Client type - [1] Standalone, [2] Client factory");
//                        if (int.TryParse(Console.ReadLine(), out var clientType))
//                        {
//                            switch (clientType)
//                            {
//                                case 1:
//                                    WriteStandalone(infos);
//                                    break;

//                                case 2:
//                                    WriteClientFactory(infos);
//                                    break;
//                            }
//                        }
//                        break;

//                    case 2:
//                        Console.WriteLine();
//                        Console.WriteLine("Configure Server type - [1] Grpc.Core, [2] ASP.NET Core");
//                        if (int.TryParse(Console.ReadLine(), out var serverType))
//                        {
//                            switch (serverType)
//                            {
//                                case 1:
//                                    WriteGRPCCoreServer();
//                                    break;

//                                case 2:
//                                    WriteASPNETServer();
//                                    break;
//                            }
//                        }
//                        break;
//                }
//            }
//        }
//    }

//    private static void WriteStandalone(List<ProtobufInfo> infos)
//    {
//        Console.WriteLine();
//        Console.WriteLine("Input gRPC channel name");
//        var channelName = Console.ReadLine();

//        ConsoleDivider();

//        Console.WriteLine("Generated Standalone gRPC Client code");

//        ConsoleDivider();

//        Console.WriteLine("using Grpc.Core;");
//        foreach (ProtobufInfo info in infos)
//        {
//            Console.WriteLine($"using {info.Namespace};");
//        }
//        Console.WriteLine();

//        Console.WriteLine($"namespace Test;");
//        Console.WriteLine();

//        Console.WriteLine($"public partial class TestClass");
//        Console.WriteLine("{");

//        Console.WriteLine($"    private Channel {channelName};");
//        Console.WriteLine();

//        foreach (ProtobufInfo info in infos)
//        {
//            foreach (var service in info.ServiceNames)
//            {
//                Console.WriteLine($"    private {service}.{service}Client {service};");
//            }
//        }
//        Console.WriteLine();

//        Console.WriteLine($"    private bool CreateServices()");
//        Console.WriteLine("    {");
//        Console.WriteLine("        bool rtn = true;");
//        Console.WriteLine("        try");
//        Console.WriteLine("        {");
//        foreach (ProtobufInfo info in infos)
//        {
//            foreach (var service in info.ServiceNames)
//            {
//                Console.WriteLine($"            {service} = new {service}.{service}Client({channelName});");
//            }
//        }
//        Console.WriteLine("        }");
//        Console.WriteLine("        catch (Exception e)");
//        Console.WriteLine("        {");
//        Console.WriteLine("            rtn = false;");
//        Console.WriteLine("        }");
//        Console.WriteLine("        return rtn;");
//        Console.WriteLine("    }");

//        Console.WriteLine("}");

//        ConsoleDivider();
//    }

//    private static void WriteClientFactory(List<ProtobufInfo> infos)
//    {
//        Console.WriteLine();
//        Console.WriteLine("Input gRPC Uri");
//        var uri = Console.ReadLine();

//        ConsoleDivider();

//        Console.WriteLine("Generated Client factory gRPC Client code");

//        ConsoleDivider();

//        Console.WriteLine("using Microsoft.Extensions.DependencyInjection;");
//        foreach (ProtobufInfo info in infos)
//        {
//            Console.WriteLine($"using {info.Namespace};");
//        }
//        Console.WriteLine();

//        Console.WriteLine($"namespace Test;");
//        Console.WriteLine();

//        Console.WriteLine($"public partial class TestClass");
//        Console.WriteLine("{");

//        Console.WriteLine($"    private IServiceCollection AddClientsFactory(IServiceCollection services)");
//        Console.WriteLine("    {");
//        Console.WriteLine("        services");
//        foreach (ProtobufInfo info in infos)
//        {
//            foreach (var service in info.ServiceNames)
//            {
//                Console.WriteLine($"        .AddGrpcClient<{service}.{service}Client>(o => {{ o.Address = new Uri(\"{uri}\"); }})");
//            }
//        }
//        Console.WriteLine("        ;");
//        Console.WriteLine("        return services;");
//        Console.WriteLine("    }");

//        Console.WriteLine("}");

//        ConsoleDivider();
//    }

//    private static void WriteGRPCCoreServer()
//    {
//        // community toolkit property generator 마지막 부분 참고해서 만들면 가능할 것으로 보임
//        // https://github.com/grpc/grpc/blob/v1.46.x/examples/csharp/Helloworld/GreeterServer/Program.cs

//        List<string> services = new();
//        while (true)
//        {
//            Console.WriteLine();
//            Console.WriteLine("Input service name to mapped : this will be changed into attribute, Write empty line for break");
//            if (services.Count != 0) Console.WriteLine($"Registered services : {string.Join(",", services)}");
//            var service = Console.ReadLine();
//            if (string.IsNullOrWhiteSpace(service)) break;
//            else services.Add(service);
//        }

//        ConsoleDivider();

//        Console.WriteLine("Generated Grpc.Core gRPC Server mapping code");

//        ConsoleDivider();

//        Console.WriteLine("using Grpc.Core;");

//        foreach (var service in services)
//        {
//            Console.WriteLine($"using {service}Namespace;");
//        }
//        Console.WriteLine();
//        Console.WriteLine("namespace Peponi.SourceGenerators.Grpc;");
//        Console.WriteLine();
//        Console.WriteLine("public static class GrpcServerMapper");
//        Console.WriteLine("{");
//        Console.WriteLine("    public static List<ServerServiceDefinition> MapGrpcServices()");
//        Console.WriteLine("    {");
//        Console.WriteLine("        List<ServerServiceDefinition> rtns = new();");
//        foreach (var service in services)
//        {
//            Console.WriteLine($"        rtns.Add({service}TopBase.BindService(new {service}()));");
//        }
//        Console.WriteLine("        return rtns;");
//        Console.WriteLine("    }");
//        Console.WriteLine("}");

//        /* 서버 코드는 다음과 같이 구성됨
//    internal class Program
//    {
//        private static void Main(string[] args)
//        {
//            var server = new Server()
//            {
//                Ports = { new ServerPort("localhost", 9091, ServerCredentials.Insecure) }
//            };
//            GetServices().ForEach(server.Services.Add);

//            server.Start();

//            Console.WriteLine("Now started server. Listening on the port : 9091");
//            Console.ReadLine();
//        }

//        private static List<ServerServiceDefinition> GetServices()
//        {
//            List<ServerServiceDefinition> rtns = new();
//            rtns.Add(HelloWorldCommunication.BindService(new HelloWorldCommunicationService()));
//            return rtns;
//        }
//    }

//    internal class HelloWorldCommunicationService : HelloWorldCommunication.HelloWorldCommunicationBase
//    {
//        public override Task<CommunicationMessage> HelloRequest(CommunicationMessage request, ServerCallContext context)
//        {
//            return Task.FromResult(new CommunicationMessage
//            {
//                Sender = "Server : 9091",
//                Message = "Hello world from server"
//            });
//        }
//    }
//         */
//    }

//    private static void WriteASPNETServer()
//    {
//        // community toolkit property generator 마지막 부분 참고해서 만들면 가능할 것으로 보임
//        List<string> services = new();
//        while (true)
//        {
//            Console.WriteLine();
//            Console.WriteLine("Input service name to mapped : this will be changed into attribute, Write empty line for break");
//            if (services.Count != 0) Console.WriteLine($"Registered services : {string.Join(",", services)}");
//            var service = Console.ReadLine();
//            if (string.IsNullOrWhiteSpace(service)) break;
//            else services.Add(service);
//        }

//        ConsoleDivider();

//        Console.WriteLine("Generated ASP.NET Core gRPC Server mapping code");

//        ConsoleDivider();

//        Console.WriteLine("using Microsoft.AspNetCore.Routing;");

//        foreach (var service in services)
//        {
//            Console.WriteLine($"using {service}Namespace;");
//        }
//        Console.WriteLine();
//        Console.WriteLine("namespace Peponi.SourceGenerators.Grpc;");
//        Console.WriteLine();
//        Console.WriteLine("public static class GrpcServerMapper");
//        Console.WriteLine("{");
//        Console.WriteLine("    public static IEndpointRouteBuilder MapGrpcServices(IEndpointRouteBuilder builder)");
//        Console.WriteLine("    {");
//        foreach (var service in services)
//        {
//            Console.WriteLine($"        builder.MapGrpcService<{service}>();");
//        }
//        Console.WriteLine("        return builder;");
//        Console.WriteLine("    }");
//        Console.WriteLine("}");
//    }
//}