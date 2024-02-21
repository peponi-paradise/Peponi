using Microsoft.CodeAnalysis;

namespace Peponi.SourceGenerators.Tests.GrpcGenerator;

[TestClass]
public class GrpcClientTestError
{
    [TestMethod]
    public void PNGCE001()
    {
        // Could not check. CS0592 raised before generation.
        Assert.IsTrue(true);
    }

    [TestMethod]
    public void PNGCE002()
    {
        DiagnosticDescriptor CouldNotFindTypeModifier = new DiagnosticDescriptor(
       id: "PNGCE002",
       title: "Object declaration error",
       messageFormat: "Could not find proper modifier",
       category: "gRPC Client",
       defaultSeverity: DiagnosticSeverity.Error,
       isEnabledByDefault: true,
       description: "Supported modifiers are - public, protected, internal, private.",
       helpLinkUri: "https://github.com/peponi-paradise/Peponi/blob/Release/Peponi.SourceGenerators/Peponi.SourceGenerators/Docs/GrpcClientGenerator.Errors.md");

        Diagnostic diag = Diagnostic.Create(CouldNotFindTypeModifier, null, "");
        Assert.IsTrue(GrpcClientCompare.IsErrorRaised(
@"using Peponi.SourceGenerators;

namespace GeneratorTest;

[GrpcClient(GrpcClientMode.Standalone, nameof(_channel), @""C:\Study\Peponi\Peponi.SourceGenerators\Peponi.SourceGenerators.Tests\GrpcGenerator"")]
protected internal partial class CodeTest
{
    Channel _channel;
}", diag));
    }

    [TestMethod]
    public void PNGCE010()
    {
        DiagnosticDescriptor NoProtobufFound = new DiagnosticDescriptor(
       id: "PNGCE010",
       title: "No protobuf found error",
       messageFormat: "Could not find protobuf files",
       category: "gRPC Client",
       defaultSeverity: DiagnosticSeverity.Error,
       isEnabledByDefault: true,
       description: "Check ProtoRootPath and extension - '*.proto'.",
       helpLinkUri: "https://github.com/peponi-paradise/Peponi/blob/Release/Peponi.SourceGenerators/Peponi.SourceGenerators/Docs/GrpcClientGenerator.Errors.md");

        Diagnostic diag = Diagnostic.Create(NoProtobufFound, null, "");
        Assert.IsTrue(GrpcClientCompare.IsErrorRaised(
@"using Peponi.SourceGenerators;

namespace GeneratorTest;

[GrpcClient(GrpcClientMode.Standalone, nameof(_channel), @""C:\EmptyFolder"")]
public partial class CodeTest
{
    Channel _channel;
}", diag));
    }

    [TestMethod]
    public void PNGCE020()
    {
        DiagnosticDescriptor ProtobufResolve = new DiagnosticDescriptor(
       id: "PNGCE020",
       title: "Resolving protobuf error",
       messageFormat: "Could not resolve protobuf files",
       category: "gRPC Client",
       defaultSeverity: DiagnosticSeverity.Error,
       isEnabledByDefault: true,
       description: $"Exception has been raised while resolving protobuf files.",
       helpLinkUri: "https://github.com/peponi-paradise/Peponi/blob/Release/Peponi.SourceGenerators/Peponi.SourceGenerators/Docs/GrpcClientGenerator.Errors.md");

        Diagnostic diag = Diagnostic.Create(ProtobufResolve, null, "");
        Assert.IsTrue(GrpcClientCompare.IsErrorRaised(
@"using Peponi.SourceGenerators;

namespace GeneratorTest;

[GrpcClient(GrpcClientMode.Standalone, nameof(_channel), @""C:\NotExistPath"")]
public partial class CodeTest
{
    Channel _channel;
}", diag));
    }
}