﻿using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Peponi.CodeGenerators.SemanticTarget;
using System.Collections.Immutable;
using System.Reflection;

namespace Peponi.CodeGenerators.CommandGenerator;

[Generator]
public sealed partial class CommandGenerator : IIncrementalGenerator
{
    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        var syntaxProvider = context.SyntaxProvider.CreateSyntaxProvider(
            predicate: static (s, _) => IsValidTarget(s),
            transform: static (context, _) => GetMethodTarget(context))
                 .Where(static target => target.MethodTarget is not null);

        IncrementalValuesProvider<(ObjectDeclarationTarget ObjectTarget, ImmutableArray<MethodTarget> PropertyTarget)> methodInfos =
            syntaxProvider.GroupBy(static item => item.Left, static item => item.Right);

        context.RegisterSourceOutput(methodInfos, static (productionContext, target) => Execute(productionContext, target));
    }

    private static bool IsValidTarget(SyntaxNode node) => node is MethodDeclarationSyntax { AttributeLists: { Count: > 0 } };

    private static (ObjectDeclarationTarget ObjectTarget, MethodTarget MethodTarget) GetMethodTarget(GeneratorSyntaxContext context)
    {
        var typeSymbol = Creater.GetTypeSymbol(context);
        if (typeSymbol is null) return (null, null)!;

        ObjectType? objectType = Creater.GetObjectType(typeSymbol);
        if (objectType is null) return (null, null)!;

        var modifier = Creater.GetAccessibilityString(typeSymbol.DeclaredAccessibility);
        if (string.IsNullOrEmpty(modifier)) return (null, null)!;

        var methodSymbol = Creater.GetMethodSymbol(context);
        if (methodSymbol is null) return (null, null)!;

        string? canExecuteName;
        CanExecuteTarget? canTarget = null;
        AttributeData? attributeData = Creater.GetAttribute(methodSymbol, "Peponi.CodeGenerators.CommandAttribute");
        if (attributeData is null) return (null, null)!;
        else
        {
            canExecuteName = Creater.GetNamedArgumentString(attributeData, 0) ?? "";
            if (!string.IsNullOrWhiteSpace(canExecuteName))
            {
                var canExecuteSymbol = typeSymbol.GetMembers().OfType<IMethodSymbol>().FirstOrDefault(x => x.Name == canExecuteName);
                if (canExecuteSymbol is not null)
                {
                    canTarget = new CanExecuteTarget(canExecuteName, canExecuteSymbol.Parameters.Any(), canExecuteSymbol.IsAsync && canExecuteSymbol.ReturnType.Name.Contains("Task"));
                }
            }
        }

        var objectTarget = new ObjectDeclarationTarget(
            typeSymbol!.Name,
            modifier,
            typeSymbol.ContainingNamespace.ToDisplayString(),
            (ObjectType)objectType!,
            NotifyType.None,
            typeSymbol.IsStatic!,
            typeSymbol.IsSealed,
            typeSymbol.IsAbstract
            );
        var methodTarget = new MethodTarget(methodSymbol.Name, methodSymbol.Parameters.Any(), methodSymbol.IsAsync && methodSymbol.ReturnType.Name.Contains("Task"), canTarget);

        return (objectTarget, methodTarget);
    }
}