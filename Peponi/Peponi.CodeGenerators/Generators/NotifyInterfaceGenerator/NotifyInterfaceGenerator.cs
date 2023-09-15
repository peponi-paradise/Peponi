using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Peponi.CodeGenerators.SemanticTarget;

namespace Peponi.CodeGenerators.NotifyInterfaceGenerator;

[Generator]
public sealed partial class NotifyInterfaceGenerator : IIncrementalGenerator
{
    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        var syntaxProvider = context.SyntaxProvider.CreateSyntaxProvider(
            predicate: static (s, _) => IsValidTarget(s),
            transform: static (context, _) => GetNotifyTarget(context))
                 .Where(static target => target is not null);

        context.RegisterSourceOutput(syntaxProvider, static (productionContext, target) => Execute(productionContext, target));
    }

    private static bool IsValidTarget(SyntaxNode node) => node is ClassDeclarationSyntax or RecordDeclarationSyntax or StructDeclarationSyntax { AttributeLists: { Count: > 0 } };

    private static ObjectDeclarationTarget? GetNotifyTarget(GeneratorSyntaxContext context)
    {
        INamedTypeSymbol? typeSymbol = (INamedTypeSymbol)Creater.GetTypeSymbol(context);
        AttributeData? attributeData = typeSymbol?.GetAttributes().FirstOrDefault(x => x.AttributeClass?.ToDisplayString() == "Peponi.CodeGenerators.NotifyInterfaceAttribute");
        ObjectType? objectType = Creater.GetObjectType(context);

        if (typeSymbol is null || attributeData is null || !Inspector.IsValidNotifyObject(typeSymbol)) return null;

        var modifier = Creater.GetAccessibilityString(typeSymbol.DeclaredAccessibility);
        if (string.IsNullOrEmpty(modifier)) return null;

        return new ObjectDeclarationTarget(
            typeSymbol!.Name,
            modifier,
            typeSymbol.ContainingNamespace.ToDisplayString(),
            (ObjectType)objectType!,
            NotifyType.Notify,
            typeSymbol.IsStatic!,
            typeSymbol.IsSealed,
            typeSymbol.IsAbstract
            );
    }
}