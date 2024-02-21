using Microsoft.CodeAnalysis;

namespace Peponi.SourceGenerators.Diagnostics;

internal static class DiagnosticMapper
{
    internal static Diagnostic Create(DiagnosticDescriptor descriptor)
    {
        return Diagnostic.Create(descriptor, null, "");
    }

    internal static Diagnostic Create(INamedTypeSymbol typeSymbol, DiagnosticDescriptor descriptor)
    {
        return Diagnostic.Create(descriptor, typeSymbol.Locations[0], typeSymbol.Name);
    }

    internal static Diagnostic Create(IMethodSymbol methodSymbol, DiagnosticDescriptor descriptor)
    {
        return Diagnostic.Create(descriptor, methodSymbol.Locations[0], methodSymbol.Name);
    }

    internal static void Report(SourceProductionContext context, Diagnostic error)
    {
        context.ReportDiagnostic(error);
    }
}