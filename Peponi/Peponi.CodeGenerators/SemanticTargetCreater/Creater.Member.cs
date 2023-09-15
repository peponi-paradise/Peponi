using Microsoft.CodeAnalysis;

namespace Peponi.CodeGenerators.SemanticTarget;

internal static partial class Creater
{
    internal static string GetAccessibilityString(Accessibility accessibility)
    {
        return accessibility switch
        {
            Accessibility.Public => "public",
            Accessibility.Protected => "protected",
            Accessibility.Internal => "internal",
            Accessibility.Private => "private",
            _ => ""
        };
    }
}