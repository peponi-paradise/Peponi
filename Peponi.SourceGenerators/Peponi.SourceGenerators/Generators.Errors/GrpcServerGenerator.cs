using Microsoft.CodeAnalysis;

#pragma warning disable RS2008

namespace Peponi.SourceGenerators.GrpcGenerator;

internal static class GrpcServerErrors
{
    internal static readonly DiagnosticDescriptor CouldNotFindTypeObject = new DiagnosticDescriptor(
       id: "PNGSE001",
       title: "Object declaration error",
       messageFormat: "Could not find proper object",
       category: "gRPC Server",
       defaultSeverity: DiagnosticSeverity.Error,
       isEnabledByDefault: true,
       description: "Supported objects are - class, record, struct.",
       helpLinkUri: "https://github.com/peponi-paradise/Peponi/blob/Release/Peponi.SourceGenerators/Peponi.SourceGenerators/Docs/GrpcServerGenerator.Errors.md");

    internal static readonly DiagnosticDescriptor CouldNotFindTypeModifier = new DiagnosticDescriptor(
       id: "PNGSE002",
       title: "Object declaration error",
       messageFormat: "Could not find proper modifier",
       category: "gRPC Server",
       defaultSeverity: DiagnosticSeverity.Error,
       isEnabledByDefault: true,
       description: "Supported modifiers are - public, protected, internal, private.",
       helpLinkUri: "https://github.com/peponi-paradise/Peponi/blob/Release/Peponi.SourceGenerators/Peponi.SourceGenerators/Docs/GrpcServerGenerator.Errors.md");

    internal static readonly DiagnosticDescriptor CouldNotFindProperTarget = new DiagnosticDescriptor(
       id: "PNGSE010",
       title: "Object not found error",
       messageFormat: "Could not find proper target",
       category: "gRPC Server",
       defaultSeverity: DiagnosticSeverity.Error,
       isEnabledByDefault: true,
       description: "Could not find proper gRPC target. Check a gRPC target contains 'BindService'.",
       helpLinkUri: "https://github.com/peponi-paradise/Peponi/blob/Release/Peponi.SourceGenerators/Peponi.SourceGenerators/Docs/GrpcServerGenerator.Errors.md");
}