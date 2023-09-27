using Microsoft.CodeAnalysis;

namespace Peponi.CodeGenerators.SemanticTarget;

internal static partial class Inspector
{
    internal static bool CheckAttribute(AttributeData attributeData, string attributeFullName)
    {
        return attributeData != null && attributeData.AttributeClass?.ToDisplayString() == attributeFullName;
    }
}