using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Peponi.CodeGenerators.SemanticTarget;
using System.Collections.Immutable;

namespace Peponi.CodeGenerators.InjectGenerator;

[Generator]
public sealed partial class InjectGenerator : IIncrementalGenerator
{
    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        var syntaxProvider = context.SyntaxProvider.CreateSyntaxProvider(
            predicate: static (s, _) => IsValidTarget(s),
            transform: static (context, _) => GetInjectTarget(context))
                 .Where(static target => target.ObjectTarget is not null && target.InjectTarget.Count() > 0);

        IncrementalValuesProvider<(ObjectDeclarationTarget ObjectTarget, ImmutableArray<ImmutableArray<InjectTarget>> InjectTargets)> injectInfos =
           syntaxProvider.GroupBy(static item => item.Left, static item => item.Right);

        context.RegisterSourceOutput(injectInfos, static (productionContext, target) => Execute(productionContext, target));
    }

    private static bool IsValidTarget(SyntaxNode node) => node is ClassDeclarationSyntax or RecordDeclarationSyntax or StructDeclarationSyntax { AttributeLists: { Count: > 0 } };

    private static (ObjectDeclarationTarget ObjectTarget, ImmutableArray<InjectTarget> InjectTarget) GetInjectTarget(GeneratorSyntaxContext context)
    {
        var objectSymbol = Creater.GetTypeSymbol(context);
        if (objectSymbol is null) return (null, default)!;

        ObjectType? objectType = Creater.GetObjectType(objectSymbol);
        if (objectType is null) return (null, default)!;

        var modifier = Creater.GetAccessibilityString(objectSymbol.DeclaredAccessibility);
        if (string.IsNullOrEmpty(modifier)) return (null, default)!;

        var attributeDatas = Creater.GetAttributes(objectSymbol, "Peponi.CodeGenerators.InjectAttribute");
        if (attributeDatas is null) return (null, default)!;

        List<InjectTarget> injectTargets = new();
        foreach (var attr in attributeDatas)
        {
            var info = Creater.GetInjectTarget(attr);
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