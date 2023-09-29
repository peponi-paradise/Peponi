using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Peponi.SourceGenerators.Diagnostics;
using Peponi.SourceGenerators.SemanticTarget;
using System.Collections.Immutable;

namespace Peponi.SourceGenerators.InjectGenerator;

[Generator]
public sealed partial class InjectGenerator : IIncrementalGenerator
{
    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        var syntaxProvider = context.SyntaxProvider.CreateSyntaxProvider(
            predicate: static (s, _) => IsValidTarget(s),
            transform: static (context, _) => GetInjectTarget(context));

        var errorInfos = syntaxProvider.Where(static item => item.Error is not null);
        context.RegisterSourceOutput(errorInfos, static (productionContext, target) => DiagnosticMapper.Report(productionContext, target.Error));

        IncrementalValuesProvider<(ObjectDeclarationTarget ObjectTarget, ImmutableArray<ImmutableArray<InjectTarget>> InjectTargets)> injectInfos =
           syntaxProvider.Where(static item => item.Target.ObjectTarget is not null && item.Target.InjectTarget.Length > 0).GroupBy(static item => item.Left.ObjectTarget, static item => item.Left.InjectTarget);

        context.RegisterSourceOutput(injectInfos, static (productionContext, target) => Execute(productionContext, target));
    }

    private static bool IsValidTarget(SyntaxNode node) => node is ClassDeclarationSyntax or RecordDeclarationSyntax or StructDeclarationSyntax { AttributeLists: { Count: > 0 } };

    private static ((ObjectDeclarationTarget ObjectTarget, ImmutableArray<InjectTarget> InjectTarget) Target, Diagnostic Error) GetInjectTarget(GeneratorSyntaxContext context)
    {
        var typeSymbol = Creater.GetTypeSymbol(context);
        if (typeSymbol is null) return ((null, default)!, null)!;

        var attributeDatas = Creater.GetAttributes(typeSymbol, "Peponi.SourceGenerators.InjectAttribute");
        if (attributeDatas is null) return ((null, default)!, null)!;

        ObjectType? objectType = Creater.GetObjectType(typeSymbol);
        if (objectType is null) return ((null, default)!, DiagnosticMapper.Create(typeSymbol, InjectErrors.CouldNotFindTypeObject))!;

        var modifier = Creater.GetAccessibilityString(typeSymbol.DeclaredAccessibility);
        if (string.IsNullOrEmpty(modifier)) return ((null, default)!, DiagnosticMapper.Create(typeSymbol, InjectErrors.CouldNotFindTypeModifier))!;

        List<InjectTarget> injectTargets = new();
        foreach (var attr in attributeDatas)
        {
            var info = Creater.GetInjectTarget(attr);
            if (info is null) return ((null, default)!, DiagnosticMapper.Create(typeSymbol, InjectErrors.InjectTargetResolveError))!;

            injectTargets.Add(info);
        }

        return ((new ObjectDeclarationTarget(
            typeSymbol!.Name,
            modifier,
            typeSymbol.ContainingNamespace.ToDisplayString(),
            (ObjectType)objectType!,
            NotifyType.None,
            typeSymbol.IsStatic!,
            typeSymbol.IsSealed,
            typeSymbol.IsAbstract
            ),
            injectTargets.ToImmutableArray())!, null)!;
    }
}