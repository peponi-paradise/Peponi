using Microsoft.CodeAnalysis;

namespace Peponi.CodeGenerators.SemanticTarget;

internal static partial class Inspector
{
    internal static bool IsValidNotifyObject(INamedTypeSymbol? symbol)
    {
        if (symbol is null) return false;
        if (symbol.IsAbstract)
        {
            if (symbol.IsSealed && symbol.IsStatic) return false;
        }
        if (symbol.IsRecord || symbol.IsValueType)
        {
            if (symbol.IsStatic) return false;
        }
        return true;
    }
}