using Microsoft.CodeAnalysis;

#pragma warning disable RS2008

namespace Peponi.SourceGenerators.CommandGenerator;

internal static class CommandErrors
{
    internal static readonly DiagnosticDescriptor CouldNotFindTypeSymbol = new DiagnosticDescriptor(
       id: "PNCMD001",
       title: "Type symbol error",
       messageFormat: "Could not find type symbol",
       category: "Command",
       defaultSeverity: DiagnosticSeverity.Error,
       isEnabledByDefault: true,
       description: "Could not find proper type symbol. Please check type declaration.",
       helpLinkUri: "https://github.com/peponi-paradise/Peponi/blob/Release/Peponi.SourceGenerators/Peponi.SourceGenerators/Docs/CommandGenerator.Errors.md");

    internal static readonly DiagnosticDescriptor CouldNotFindTypeObject = new DiagnosticDescriptor(
       id: "PNCMD002",
       title: "Object declaration error",
       messageFormat: "Could not find proper object",
       category: "Command",
       defaultSeverity: DiagnosticSeverity.Error,
       isEnabledByDefault: true,
       description: "Supported objects are - class, record, struct.",
       helpLinkUri: "https://github.com/peponi-paradise/Peponi/blob/Release/Peponi.SourceGenerators/Peponi.SourceGenerators/Docs/CommandGenerator.Errors.md");

    internal static readonly DiagnosticDescriptor CouldNotFindTypeModifier = new DiagnosticDescriptor(
       id: "PNCMD003",
       title: "Object declaration error",
       messageFormat: "Could not find proper modifier",
       category: "Command",
       defaultSeverity: DiagnosticSeverity.Error,
       isEnabledByDefault: true,
       description: "Supported modifiers are - public, protected, internal, private.",
       helpLinkUri: "https://github.com/peponi-paradise/Peponi/blob/Release/Peponi.SourceGenerators/Peponi.SourceGenerators/Docs/CommandGenerator.Errors.md");

    internal static readonly DiagnosticDescriptor MethodReturnType = new DiagnosticDescriptor(
       id: "PNCMD010",
       title: "Method return type error",
       messageFormat: "Not supported return type",
       category: "Command",
       defaultSeverity: DiagnosticSeverity.Error,
       isEnabledByDefault: true,
       description: "Supported return types are - void, Task, Task<T>.",
       helpLinkUri: "https://github.com/peponi-paradise/Peponi/blob/Release/Peponi.SourceGenerators/Peponi.SourceGenerators/Docs/CommandGenerator.Errors.md");

    internal static readonly DiagnosticDescriptor CanExecuteReturnType = new DiagnosticDescriptor(
       id: "PNCMD020",
       title: "CanExecute return type error",
       messageFormat: "Not supported CanExecute return type",
       category: "Command",
       defaultSeverity: DiagnosticSeverity.Error,
       isEnabledByDefault: true,
       description: "Supported return type is boolean.",
       helpLinkUri: "https://github.com/peponi-paradise/Peponi/blob/Release/Peponi.SourceGenerators/Peponi.SourceGenerators/Docs/CommandGenerator.Errors.md");

    internal static readonly DiagnosticDescriptor CanExecuteParameterType = new DiagnosticDescriptor(
       id: "PNCMD021",
       title: "CanExecute parameter type error",
       messageFormat: "Not supported CanExecute parameter type",
       category: "Command",
       defaultSeverity: DiagnosticSeverity.Error,
       isEnabledByDefault: true,
       description: "Parameter type should be void or matched with command parameter.",
       helpLinkUri: "https://github.com/peponi-paradise/Peponi/blob/Release/Peponi.SourceGenerators/Peponi.SourceGenerators/Docs/CommandGenerator.Errors.md");
}