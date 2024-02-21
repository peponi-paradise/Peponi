using Microsoft.CodeAnalysis;

#pragma warning disable RS2008

namespace Peponi.SourceGenerators.GrpcGenerator;

internal static class GrpcClientErrors
{
    internal static readonly DiagnosticDescriptor CouldNotFindTypeObject = new DiagnosticDescriptor(
       id: "PNGCE001",
       title: "Object declaration error",
       messageFormat: "Could not find proper object",
       category: "gRPC Client",
       defaultSeverity: DiagnosticSeverity.Error,
       isEnabledByDefault: true,
       description: "Supported objects are - class, record, struct.",
       helpLinkUri: "https://github.com/peponi-paradise/Peponi/blob/Release/Peponi.SourceGenerators/Peponi.SourceGenerators/Docs/GrpcClientGenerator.Errors.md");

    internal static readonly DiagnosticDescriptor CouldNotFindTypeModifier = new DiagnosticDescriptor(
       id: "PNGCE002",
       title: "Object declaration error",
       messageFormat: "Could not find proper modifier",
       category: "gRPC Client",
       defaultSeverity: DiagnosticSeverity.Error,
       isEnabledByDefault: true,
       description: "Supported modifiers are - public, protected, internal, private.",
       helpLinkUri: "https://github.com/peponi-paradise/Peponi/blob/Release/Peponi.SourceGenerators/Peponi.SourceGenerators/Docs/GrpcClientGenerator.Errors.md");

    internal static readonly DiagnosticDescriptor NoProtobufFound = new DiagnosticDescriptor(
       id: "PNGCE010",
       title: "No protobuf found error",
       messageFormat: "Could not find protobuf files",
       category: "gRPC Client",
       defaultSeverity: DiagnosticSeverity.Error,
       isEnabledByDefault: true,
       description: "Check ProtoRootPath and extension - '*.proto'.",
       helpLinkUri: "https://github.com/peponi-paradise/Peponi/blob/Release/Peponi.SourceGenerators/Peponi.SourceGenerators/Docs/GrpcClientGenerator.Errors.md");

    internal static readonly DiagnosticDescriptor ProtobufResolve = new DiagnosticDescriptor(
       id: "PNGCE020",
       title: "Resolving protobuf error",
       messageFormat: "Could not resolve protobuf files",
       category: "gRPC Client",
       defaultSeverity: DiagnosticSeverity.Error,
       isEnabledByDefault: true,
       description: $"Exception has been raised while resolving protobuf files.",
       helpLinkUri: "https://github.com/peponi-paradise/Peponi/blob/Release/Peponi.SourceGenerators/Peponi.SourceGenerators/Docs/GrpcClientGenerator.Errors.md");
}