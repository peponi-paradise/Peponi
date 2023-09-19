using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Peponi.CodeGenerators.SemanticTarget;

internal static partial class Creater
{
    internal static INamedTypeSymbol? GetTypeSymbol(GeneratorSyntaxContext context)
    {
        if (context.Node is ClassDeclarationSyntax or RecordDeclarationSyntax or StructDeclarationSyntax)
        {
            return (INamedTypeSymbol?)context.SemanticModel.GetDeclaredSymbol(context.Node);
        }
        else if (context.Node is MethodDeclarationSyntax)
        {
            return context.SemanticModel.GetDeclaredSymbol(context.Node)?.ContainingType;
        }
        else if (context.Node.Parent!.Parent is FieldDeclarationSyntax)
        {
            return context.SemanticModel.GetDeclaredSymbol(context.Node)?.ContainingType;
        }
        else return null;
    }

    internal static AttributeData? GetAttribute(ISymbol? typeSymbol, string attributeFullName)
    {
        return typeSymbol?.GetAttributes().FirstOrDefault(x => Inspector.CheckAttribute(x, attributeFullName));
    }

    internal static IEnumerable<AttributeData>? GetAttributes(ISymbol? typeSymbol, string attributeFullName)
    {
        return typeSymbol?.GetAttributes().Where(x => Inspector.CheckAttribute(x, attributeFullName));
    }

    internal static ObjectType? GetObjectType(INamedTypeSymbol typeSymbol)
    {
        if (typeSymbol.TypeKind == TypeKind.Class && typeSymbol.IsRecord) return ObjectType.Record;
        else if (typeSymbol.TypeKind == TypeKind.Class) return ObjectType.Class;
        else if (typeSymbol.TypeKind == TypeKind.Struct) return ObjectType.Struct;
        else return null;
    }

    internal static string GetObjectName(string typeName, Modifier modifier = Modifier.Public)
    {
        if (modifier == Modifier.Public)
        {
            string rtnString = typeName.Clone().ToString();

            if (rtnString[0] == '_')
            {
                rtnString = typeName.Substring(1);
            }

            if (char.IsLower(rtnString[0]))
            {
                rtnString = rtnString[0].ToString().ToUpper() + rtnString.Substring(1);
            }

            return rtnString;
        }
        else if (modifier == Modifier.Private || modifier == Modifier.Protected || modifier == Modifier.Internal)
        {
            string rtnString = typeName.Clone().ToString();

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
        else return typeName;
    }

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

    internal static string GetAccessibilityString(Modifier modifier)
    {
        return modifier switch
        {
            Modifier.Public => "public",
            Modifier.Protected => "protected",
            Modifier.Internal => "internal",
            Modifier.Private => "private",
            _ => ""
        };
    }

    internal static InjectDependencyTarget? GetDependencyInfo(AttributeData attributeData)
    {
        var modelType = GetConstructorArgument(attributeData, 0);
        if (modelType?.Value is null) return null;

        InjectDependencyTarget? target = null;

        if (modelType.Value.Value is INamedTypeSymbol symbol && symbol.IsStatic == false)
        {
            string namespaceName = symbol.ContainingNamespace.ToDisplayString();
            string typeName = symbol.Name;
            string customName = string.Empty;
            Modifier modifier = Modifier.Public;

            foreach (var arg in attributeData.NamedArguments)
            {
                if (arg.Key == "Name") customName = (string)arg.Value.Value!;
                else if (arg.Key == "Modifier") modifier = (Modifier)arg.Value.Value!;
            }
            target = new(namespaceName, typeName, customName, modifier);
        }
        return target;
    }
}