using Microsoft.CodeAnalysis;

#pragma warning disable RS2008

namespace Peponi.SourceGenerators.NotifyInterfaceGenerator;

internal static class NotifyInterfaceErrors
{
    internal static readonly DiagnosticDescriptor CouldNotFindTypeObject = new DiagnosticDescriptor(
       id: "PNNTI001",
       title: "Object declaration error",
       messageFormat: "Could not find proper object",
       category: "NotifyInterface",
       defaultSeverity: DiagnosticSeverity.Error,
       isEnabledByDefault: true,
       description: "Supported objects are - class, record, struct.",
       helpLinkUri: "https://github.com/peponi-paradise/Peponi/blob/Release/Peponi.SourceGenerators/Peponi.SourceGenerators/Docs/NotifyInterfaceGenerator.Errors.md");

    internal static readonly DiagnosticDescriptor CouldNotFindTypeModifier = new DiagnosticDescriptor(
       id: "PNNTI002",
       title: "Object declaration error",
       messageFormat: "Could not find proper modifier",
       category: "NotifyInterface",
       defaultSeverity: DiagnosticSeverity.Error,
       isEnabledByDefault: true,
       description: "Supported modifiers are - public, protected, internal, private.",
       helpLinkUri: "https://github.com/peponi-paradise/Peponi/blob/Release/Peponi.SourceGenerators/Peponi.SourceGenerators/Docs/NotifyInterfaceGenerator.Errors.md");
}