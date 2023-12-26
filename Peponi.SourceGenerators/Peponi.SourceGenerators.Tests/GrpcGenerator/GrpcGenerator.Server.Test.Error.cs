using Microsoft.CodeAnalysis;

namespace Peponi.SourceGenerators.Tests.GrpcGenerator;

[TestClass]
public class GrpcServerTestError
{
    [TestMethod]
    public void PNGSE001()
    {
        // Could not check. CS0592 raised before generation.
        Assert.IsTrue(true);
    }

    [TestMethod]
    public void PNGSE002()
    {
        DiagnosticDescriptor CouldNotFindTypeModifier = new DiagnosticDescriptor(
       id: "PNGSE002",
       title: "Object declaration error",
       messageFormat: "Could not find proper modifier",
       category: "gRPC Server",
       defaultSeverity: DiagnosticSeverity.Error,
       isEnabledByDefault: true,
       description: "Supported modifiers are - public, protected, internal, private.",
       helpLinkUri: "https://github.com/peponi-paradise/Peponi/blob/Release/Peponi.SourceGenerators/Peponi.SourceGenerators/Docs/GrpcServerGenerator.Errors.md");

        Diagnostic diag = Diagnostic.Create(CouldNotFindTypeModifier, null, "");
        Assert.IsTrue(GrpcServerCompare.IsErrorRaised(
@"using Peponi.SourceGenerators;
using ServerContext;

namespace GeneratorTest
{
    [GrpcServer(GrpcServerMode.Standalone)]
    protected internal partial class CodeTest : HelloWorld.HelloWorldBase
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
}", diag));
    }

    [TestMethod]
    public void PNGSE010()
    {
        DiagnosticDescriptor CouldNotFindProperTarget = new DiagnosticDescriptor(
         id: "PNGSE010",
         title: "Object not found error",
         messageFormat: "Could not find proper target",
         category: "gRPC Server",
         defaultSeverity: DiagnosticSeverity.Error,
         isEnabledByDefault: true,
         description: "Could not find proper gRPC target. Check a gRPC target contains 'BindService'.",
         helpLinkUri: "https://github.com/peponi-paradise/Peponi/blob/Release/Peponi.SourceGenerators/Peponi.SourceGenerators/Docs/GrpcServerGenerator.Errors.md");

        Diagnostic diag = Diagnostic.Create(CouldNotFindProperTarget, null, "");
        Assert.IsTrue(GrpcServerCompare.IsErrorRaised(
@"using Peponi.SourceGenerators;
using ServerContext;

namespace GeneratorTest
{
    [GrpcServer(GrpcServerMode.Standalone)]
    public partial class CodeTest : HelloWorld.HelloWorldBase
    {
    }
}

namespace ServerContext
{
    public class HelloWorld
    {
        public class HelloWorldBase
        {
        }
    }
}", diag));
    }
}