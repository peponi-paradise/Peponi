using Microsoft.CodeAnalysis;

#pragma warning disable RS2008

namespace Peponi.SourceGenerators.InjectGenerator;

internal static class InjectErrors
{
    internal static readonly DiagnosticDescriptor CouldNotFindTypeObject = new DiagnosticDescriptor(
       id: "PNIJT001",
       title: "Object declaration error",
       messageFormat: "Could not find proper object",
       category: "Inject",
       defaultSeverity: DiagnosticSeverity.Error,
       isEnabledByDefault: true,
       description: "Supported objects are - class, record, struct.",
       helpLinkUri: "https://github.com/peponi-paradise/Peponi/blob/Release/Peponi.SourceGenerators/Peponi.SourceGenerators/Docs/InjectGenerator.Errors.md");

    internal static readonly DiagnosticDescriptor CouldNotFindTypeModifier = new DiagnosticDescriptor(
       id: "PNIJT002",
       title: "Object declaration error",
       messageFormat: "Could not find proper modifier",
       category: "Inject",
       defaultSeverity: DiagnosticSeverity.Error,
       isEnabledByDefault: true,
       description: "Supported modifiers are - public, protected, internal, private.",
       helpLinkUri: "https://github.com/peponi-paradise/Peponi/blob/Release/Peponi.SourceGenerators/Peponi.SourceGenerators/Docs/InjectGenerator.Errors.md");

    internal static readonly DiagnosticDescriptor InjectTargetResolveError = new DiagnosticDescriptor(
       id: "PNIJT003",
       title: "Inject target resolve error",
       messageFormat: "Failed to resolve inject object",
       category: "Inject",
       defaultSeverity: DiagnosticSeverity.Error,
       isEnabledByDefault: true,
       description: "Please check inject object.",
       helpLinkUri: "https://github.com/peponi-paradise/Peponi/blob/Release/Peponi.SourceGenerators/Peponi.SourceGenerators/Docs/InjectGenerator.Errors.md");

    internal static readonly DiagnosticDescriptor StructObjectInjectModifierError = new DiagnosticDescriptor(
       id: "PNIJT004",
       title: "Inject target modifier error",
       messageFormat: "Not supported modifier - Could not use 'protected' to 'struct' object",
       category: "Inject",
       defaultSeverity: DiagnosticSeverity.Error,
       isEnabledByDefault: true,
       description: "Please check inject modifier.",
       helpLinkUri: "https://github.com/peponi-paradise/Peponi/blob/Release/Peponi.SourceGenerators/Peponi.SourceGenerators/Docs/InjectGenerator.Errors.md");
}