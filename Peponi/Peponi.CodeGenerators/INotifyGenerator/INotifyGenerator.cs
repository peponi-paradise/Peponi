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

    private static bool IsClassOrStruct(SyntaxNode node) => node is ClassDeclarationSyntax { AttributeLists: { Count: > 0 } } or StructDeclarationSyntax { AttributeLists: { Count: > 0 } };

    private static INotifyTarget? GetNotifyTarget(GeneratorSyntaxContext context)
    {
        INamedTypeSymbol? typeSymbol;
        bool isClass = false;

        if (context.Node is ClassDeclarationSyntax clx)
        {
            isClass = true;
            typeSymbol = context.SemanticModel.GetDeclaredSymbol(clx);
        }
        else
        {
            typeSymbol = context.SemanticModel.GetDeclaredSymbol((StructDeclarationSyntax)context.Node);
        }

        if (typeSymbol == null) return null;

        return new INotifyTarget(
            typeSymbol.Name,
            typeSymbol.DeclaredAccessibility switch
            {
                Accessibility.Public => "public",
                Accessibility.Protected => "protected",
                Accessibility.Internal => "internal",
                Accessibility.Private => "private",
                _ => ""
            },
            typeSymbol.IsStatic,
            typeSymbol.ContainingNamespace.ToDisplayString(),
            isClass
            );
    }
}