using Microsoft.CodeAnalysis;

namespace Peponi.SourceGenerators.SemanticTarget;

internal static partial class Inspector
{
    internal static bool CheckAttribute(AttributeData attributeData, string attributeFullName)
    {
        return attributeData != null && attributeData.AttributeClass?.ToDisplayString() == attributeFullName;
    }
}