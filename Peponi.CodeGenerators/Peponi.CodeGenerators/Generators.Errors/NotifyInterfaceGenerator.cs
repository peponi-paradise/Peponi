﻿using Microsoft.CodeAnalysis;

#pragma warning disable RS2008

namespace Peponi.CodeGenerators.NotifyInterfaceGenerator;

internal static class NotifyInterfaceErrors
{
    internal static readonly DiagnosticDescriptor CouldNotFindTypeObject = new DiagnosticDescriptor(
       id: "PNNTI001",
       title: "Object declaration error",
       messageFormat: "Could not find proper object",
       category: "NotifyInterface",
       defaultSeverity: DiagnosticSeverity.Error,
       isEnabledByDefault: true,
       description: "Supported objects are - class, record, struct.");

    internal static readonly DiagnosticDescriptor CouldNotFindTypeModifier = new DiagnosticDescriptor(
       id: "PNNTI002",
       title: "Object declaration error",
       messageFormat: "Could not find proper modifier",
       category: "NotifyInterface",
       defaultSeverity: DiagnosticSeverity.Error,
       isEnabledByDefault: true,
       description: "Supported modifiers are - public, protected, internal, private.");
}