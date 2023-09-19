using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Peponi.CodeGenerators.SemanticTarget;
using System.Collections.Immutable;

namespace Peponi.CodeGenerators.InjectDependencyGenerator;

[Generator]
public sealed partial class InjectDependencyGenerator : IIncrementalGenerator
{
    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        var syntaxProvider = context.SyntaxProvider.CreateSyntaxProvider(
            predicate: static (s, _) => IsValidTarget(s),
            transform: static (context, _) => GetInjectDependencyTarget(context))
                 .Where(static target => target.ObjectTarget is not null && target.InjectTarget.Count() > 0);

        IncrementalValuesProvider<(ObjectDeclarationTarget ObjectTarget, ImmutableArray<ImmutableArray<InjectDependencyTarget>> InjectTarget)> propertyInfos =
           syntaxProvider.GroupBy(static item => item.Left, static item => item.Right);

        context.RegisterSourceOutput(syntaxProvider, static (productionContext, target) => Execute(productionContext, target));
    }

    private static bool IsValidTarget(SyntaxNode node) => node is ClassDeclarationSyntax or RecordDeclarationSyntax or StructDeclarationSyntax { AttributeLists: { Count: > 0 } };

    private static (ObjectDeclarationTarget ObjectTarget, ImmutableArray<InjectDependencyTarget> InjectTarget) GetInjectDependencyTarget(GeneratorSyntaxContext context)
    {
        var objectSymbol = Creater.GetTypeSymbol(context);
        if (objectSymbol is null) return (null, default)!;

        ObjectType? objectType = Creater.GetObjectType(objectSymbol);
        if (objectType is null) return (null, default)!;

        var modifier = Creater.GetAccessibilityString(objectSymbol.DeclaredAccessibility);
        if (string.IsNullOrEmpty(modifier)) return (null, default)!;

        var attributeDatas = Creater.GetAttributes(objectSymbol, "Peponi.CodeGenerators.InjectDependencyAttribute");
        if (attributeDatas is null) return (null, default)!;

        List<InjectDependencyTarget> injectTargets = new();
        foreach (var attr in attributeDatas)
        {
            var info = Creater.GetDependencyInfo(attr);
            if (info is null) return (null, default)!;

            injectTargets.Add(info);
        }

        return (new ObjectDeclarationTarget(
            objectSymbol!.Name,
            modifier,
            objectSymbol.ContainingNamespace.ToDisplayString(),
            (ObjectType)objectType!,
            NotifyType.None,
            objectSymbol.IsStatic!,
            objectSymbol.IsSealed,
            objectSymbol.IsAbstract
            ),
            injectTargets.ToImmutableArray())!;
    }
}