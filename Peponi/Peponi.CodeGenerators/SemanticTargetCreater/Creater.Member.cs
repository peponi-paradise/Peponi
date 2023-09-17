using Microsoft.CodeAnalysis;

namespace Peponi.CodeGenerators.SemanticTarget;

internal static partial class Creater
{
    internal static IFieldSymbol? GetFieldSymbol(GeneratorSyntaxContext context)
    {
        return (IFieldSymbol?)context.SemanticModel.GetDeclaredSymbol(context.Node);
    }

    internal static IEnumerable<AttributeData>? GetAttributes(IFieldSymbol? fieldSymbol, string attributeFullName)
    {
        return fieldSymbol?.GetAttributes().Where(x => Inspector.CheckAttribute(x, attributeFullName));
    }

    internal static string? GetConstructorArgument(AttributeData attributeData, int index)
    {
        if (attributeData.ConstructorArguments.Length < index + 1) return null;
        return attributeData.ConstructorArguments[index].Value?.ToString();
    }

    internal static string? GetNamedArgument(AttributeData attributeData, int index)
    {
        if (attributeData.NamedArguments.Length < index + 1) return null;
        return attributeData.NamedArguments[index].Value.Value?.ToString();
    }

    internal static string GetPropertyName(string identifier)
    {
        string rtnString = identifier.Clone().ToString();

        if (rtnString[0] == '_')
        {
            rtnString = identifier.Substring(1);
        }

        if (char.IsLower(rtnString[0]))
        {
            rtnString = rtnString[0].ToString().ToUpper() + rtnString.Substring(1);
        }
        else if (char.IsUpper(rtnString[0]))
        {
            rtnString = rtnString.ToUpper();
        }

        return rtnString;
    }
}