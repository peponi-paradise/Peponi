namespace Peponi.SourceGenerators.Tests.GrpcGenerator;

#nullable disable

[TestClass]
public class GrpcServerTestClass
{
    [TestMethod]
    public void Standalone()
    {
        string compare =
@"using Peponi.SourceGenerators;
using ServerContext;

namespace GeneratorTest
{
    [GrpcServer(GrpcServerMode.Standalone)]
    public class CodeTest : HelloWorld.HelloWorldBase
    {
    }
}

namespace ServerContext
{
    public class HelloWorld
    {
        public static void BindService()
        {
        }

        public class HelloWorldBase
        {
        }
    }
}";
        string expected =
@"// Auto generated code by Peponi.SourceGenerators
// Github : https://github.com/peponi-paradise/Peponi
// Blog : https://peponi-paradise.tistory.com

using Grpc.Core;

namespace Peponi.SourceGenerators.Grpc;

public static partial class GrpcServerMapper
{
    /// <summary>
    /// Auto generated method by Peponi.SourceGenerators
    /// </summary>
    public static List<ServerServiceDefinition> GetStandaloneServices()
    {
        List<ServerServiceDefinition> rtns = new();
        rtns.Add(global::ServerContext.HelloWorld.BindService(new global::GeneratorTest.CodeTest()));
        return rtns;
    }
}";
        Assert.IsTrue(GrpcServerCompare.CompareCode(compare, expected));
    }

    [TestMethod]
    public void ClientFactory()
    {
        string compare =
@"using Peponi.SourceGenerators;
using ServerContext;

namespace GeneratorTest
{
    [GrpcServer(GrpcServerMode.ClientFactory)]
    public class CodeTest : HelloWorld.HelloWorldBase
    {
    }
}

namespace ServerContext
{
    public class HelloWorld
    {
        public static void BindService()
        {
        }

        public class HelloWorldBase
        {
        }
    }
}";
        string expected =
@"// Auto generated code by Peponi.SourceGenerators
// Github : https://github.com/peponi-paradise/Peponi
// Blog : https://peponi-paradise.tistory.com

using Microsoft.AspNetCore.Routing;

namespace Peponi.SourceGenerators.Grpc;

public static partial class GrpcServerMapper
{
    /// <summary>
    /// Auto generated method by Peponi.SourceGenerators
    /// </summary>
    public static IEndpointRouteBuilder MapClientFactoryServices(IEndpointRouteBuilder builder)
    {
        builder.MapGrpcService<global::GeneratorTest.CodeTest>();
        return builder;
    }
}";
        Assert.IsTrue(GrpcServerCompare.CompareCode(compare, expected));
    }
}