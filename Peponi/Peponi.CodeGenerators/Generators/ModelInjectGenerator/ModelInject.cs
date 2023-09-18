using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Peponi.CodeGenerators.SemanticTarget;

namespace Peponi.CodeGenerators.ModelInjectGenerator;

[Generator]
public sealed partial class ModelInjectGenerator : IIncrementalGenerator
{
    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        var syntaxProvider = context.SyntaxProvider.CreateSyntaxProvider(
            predicate: static (s, _) => IsValidTarget(s),
            transform: static (context, _) => GetModelInjectTarget(context))
                 .Where(static target => target.InjectTarget is not null);

        context.RegisterSourceOutput(syntaxProvider, static (productionContext, target) => Execute(productionContext, target));
    }

    private static bool IsValidTarget(SyntaxNode node) => node is ClassDeclarationSyntax or RecordDeclarationSyntax or StructDeclarationSyntax { AttributeLists: { Count: > 0 } };

    private static (ObjectDeclarationTarget ObjectTarget, ModelInjectTarget InjectTarget, List<PropertyTarget> PropertyTarget) GetModelInjectTarget(GeneratorSyntaxContext context)
    {
        var objectSymbol = Creater.GetTypeSymbol(context);
        if (objectSymbol is null) return (null, null, null)!;

        AttributeData? attributeData = Creater.GetAttribute(objectSymbol, "Peponi.CodeGenerators.ModelInjectAttribute");
        if (attributeData is null) return (null, null, null)!;

        ObjectType? objectType = Creater.GetObjectType(objectSymbol);
        if (objectType is null) return (null, null, null)!;

        var modifier = Creater.GetAccessibilityString(objectSymbol.DeclaredAccessibility);
        if (string.IsNullOrEmpty(modifier)) return (null, null, null)!;

        var modelInfo = Creater.GetModelInfo(attributeData);
        if (modelInfo is null) return (null, null, null)!;

        return (new ObjectDeclarationTarget(
            objectSymbol!.Name,
            modifier,
            objectSymbol.ContainingNamespace.ToDisplayString(),
            (ObjectType)objectType!,
            NotifyType.Notify,
            objectSymbol.IsStatic!,
            objectSymbol.IsSealed,
            objectSymbol.IsAbstract
            ),
            modelInfo?.ModelInfo,
            modelInfo?.PropertyTarget
            )!;
    }
}