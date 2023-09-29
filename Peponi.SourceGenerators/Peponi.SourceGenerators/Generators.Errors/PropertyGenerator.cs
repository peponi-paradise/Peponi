using Microsoft.CodeAnalysis;

#pragma warning disable RS2008

namespace Peponi.SourceGenerators.PropertyGenerator;

internal static class PropertyErrors
{
    internal static readonly DiagnosticDescriptor CouldNotFindTypeObject = new DiagnosticDescriptor(
       id: "PNPTY001",
       title: "Object declaration error",
       messageFormat: "Could not find proper object",
       category: "Property",
       defaultSeverity: DiagnosticSeverity.Error,
       isEnabledByDefault: true,
       description: "Supported objects are - class, record, struct.");

    internal static readonly DiagnosticDescriptor CouldNotFindTypeModifier = new DiagnosticDescriptor(
       id: "PNPTY002",
       title: "Object declaration error",
       messageFormat: "Could not find proper modifier",
       category: "Property",
       defaultSeverity: DiagnosticSeverity.Error,
       isEnabledByDefault: true,
       description: "Supported modifiers are - public, protected, internal, private.");
}