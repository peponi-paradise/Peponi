using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Peponi.CodeGenerators.INotifyGenerator;

[Generator]
public sealed partial class INotifyGenerator : IIncrementalGenerator
{
    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        var syntaxProvider = context.SyntaxProvider.CreateSyntaxProvider(
            predicate: static (s, _) => IsClassOrStruct(s),
            transform: static (context, _) => GetNotifyTarget(context))
                 .Where(static target => target is not null);

        context.RegisterSourceOutput(syntaxProvider, static (productionContext, target) => Execute(productionContext, target));
    }

    private static bool IsClassOrStruct(SyntaxNode node) => node is ClassDeclarationSyntax or RecordDeclarationSyntax or StructDeclarationSyntax { AttributeLists: { Count: > 0 } };

    private static ObjectDeclarationTarget? GetNotifyTarget(GeneratorSyntaxContext context)
    {
        INamedTypeSymbol? typeSymbol;
        AttributeData? attributeData;
        ObjectType objectType = ObjectType.Class;

        switch (context.Node)
        {
            case ClassDeclarationSyntax classDeclaration:
                typeSymbol = context.SemanticModel.GetDeclaredSymbol(classDeclaration);
                objectType = ObjectType.Class;
                break;

            case RecordDeclarationSyntax recordDeclaration:
                typeSymbol = context.SemanticModel.GetDeclaredSymbol(recordDeclaration);
                objectType = ObjectType.Record;
                break;

            case StructDeclarationSyntax structDeclaration:
                typeSymbol = context.SemanticModel.GetDeclaredSymbol(structDeclaration);
                objectType = ObjectType.Struct;
                break;

            default:
                return null;
        }

        attributeData = typeSymbol?.GetAttributes().FirstOrDefault(x => x.AttributeClass?.ToDisplayString() == "Peponi.CodeGenerators.INotifyAttribute");

        if (typeSymbol is null || attributeData is null) return null;

        return new ObjectDeclarationTarget(
            typeSymbol.Name,
            typeSymbol.DeclaredAccessibility switch
            {
                Accessibility.Public => "public",
                Accessibility.Protected => "protected",
                Accessibility.Internal => "internal",
                Accessibility.Private => "private",
                _ => ""
            },
            typeSymbol.ContainingNamespace.ToDisplayString(),
            objectType,
            typeSymbol.IsStatic,
            typeSymbol.IsSealed
            );
    }
}