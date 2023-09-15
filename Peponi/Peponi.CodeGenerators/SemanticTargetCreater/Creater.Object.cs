using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Peponi.CodeGenerators.SemanticTarget;

internal static partial class Creater
{
    internal static ISymbol GetTypeSymbol(GeneratorSyntaxContext context)
    {
        return context.Node switch
        {
            ClassDeclarationSyntax clx => context.SemanticModel.GetDeclaredSymbol(clx)!,
            RecordDeclarationSyntax rlx => context.SemanticModel.GetDeclaredSymbol(rlx)!,
            StructDeclarationSyntax slx => context.SemanticModel.GetDeclaredSymbol(slx)!,
            FieldDeclarationSyntax flx => context.SemanticModel.GetDeclaredSymbol(flx)!,
            _ => null!
        };
    }

    internal static ObjectType? GetObjectType(GeneratorSyntaxContext context)
    {
        return context.Node switch
        {
            ClassDeclarationSyntax => ObjectType.Class,
            RecordDeclarationSyntax => ObjectType.Record,
            StructDeclarationSyntax => ObjectType.Struct,
            _ => null
        };
    }
}