using Microsoft.CodeAnalysis;

namespace Peponi.SourceGenerators.SemanticTarget;

internal static partial class Creater
{
    internal static IFieldSymbol? GetFieldSymbol(GeneratorSyntaxContext context)
    {
        return (IFieldSymbol?)context.SemanticModel.GetDeclaredSymbol(context.Node);
    }

    internal static IMethodSymbol? GetMethodSymbol(GeneratorSyntaxContext context)
    {
        return (IMethodSymbol?)context.SemanticModel.GetDeclaredSymbol(context.Node);
    }

    internal static IEnumerable<AttributeData>? GetAttributes(IFieldSymbol? fieldSymbol, string attributeFullName)
    {
        return fieldSymbol?.GetAttributes().Where(x => Inspector.CheckAttribute(x, attributeFullName));
    }

    internal static string? GetConstructorArgumentString(AttributeData attributeData, int index)
    {
        if (attributeData.ConstructorArguments.Length < index + 1) return null;
        return attributeData.ConstructorArguments[index].Value?.ToString();
    }

    internal static TypedConstant? GetConstructorArgument(AttributeData attributeData, int index)
    {
        if (attributeData.ConstructorArguments.Length < index + 1) return null;
        return attributeData.ConstructorArguments[index];
    }

    internal static string? GetNamedArgumentString(AttributeData attributeData, int index)
    {
        if (attributeData.NamedArguments.Length < index + 1) return null;
        return attributeData.NamedArguments[index].Value.Value?.ToString();
    }

    internal static TypedConstant? GetNamedArgument(AttributeData attributeData, int index)
    {
        if (attributeData.NamedArguments.Length < index + 1) return null;
        return attributeData.NamedArguments[index].Value;
    }

    internal static string GetPropertyName(string identifier, Modifier modifier = Modifier.Public)
    {
        if (modifier == Modifier.Public)
        {
            if (identifier.Contains('_'))
            {
                if (identifier.Length > 2 && char.IsLower(identifier[0]) && identifier[1] == '_')
                {
                    return $"{identifier[2].ToString().ToUpper()}{identifier.Substring(3)}";
                }
                else if (identifier[0] == '_' && char.IsLetter(identifier[1]))
                {
                    return $"{identifier[1].ToString().ToUpper()}{identifier.Substring(2)}";
                }
                else return identifier.Replace("_", "");
            }
            else
            {
                if (char.IsLower(identifier[0]))
                {
                    return $"{identifier[0].ToString().ToUpper()}{identifier.Substring(1)}";
                }
                else
                {
                    return identifier.ToUpper();
                }
            }
        }
        else if (modifier == Modifier.Private || modifier == Modifier.Protected || modifier == Modifier.Internal)
        {
            string rtnString = identifier.Clone().ToString();

            if (rtnString.IsAllUpper())
            {
                rtnString = rtnString.ToLower();
            }
            else if (rtnString[0] == '_')
            {
                // Temp remove
                rtnString = rtnString.Substring(1);
            }
            if (char.IsUpper(rtnString[0]))
            {
                rtnString = rtnString[0].ToString().ToLower() + rtnString.Substring(1);
            }

            return $"_{rtnString}";
        }
        else return identifier;
    }

    private static bool IsAllUpper(this string input)
    {
        for (int i = 0; i < input.Length; i++)
        {
            if (char.IsLetter(input[i]) && !char.IsUpper(input[i]))
                return false;
        }
        return true;
    }
}