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