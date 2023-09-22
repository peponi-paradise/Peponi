using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Peponi.CodeGenerators.SemanticTarget;
using System.Collections.Immutable;

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
        if (methodSymbol.ReturnType.Name != "Task" && methodSymbol.ReturnType.Name != "Void") return (null, null)!;
        string methodParameterName = methodSymbol.Parameters.Any() ? methodSymbol.Parameters.First().Type.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat.AddMiscellaneousOptions(SymbolDisplayMiscellaneousOptions.IncludeNullableReferenceTypeModifier)) : string.Empty;

        string? customMethodName = null;
        string? canExecuteName;
        CanExecuteTarget? canTarget = null;
        AttributeData? attributeData = Creater.GetAttribute(methodSymbol, "Peponi.CodeGenerators.CommandAttribute");
        if (attributeData is null) return (null, null)!;
        else
        {
            foreach (var arg in attributeData.NamedArguments)
            {
                if (arg.Key == "CanExecute")
                {
                    canExecuteName = (string)arg.Value.Value!;
                    if (!string.IsNullOrWhiteSpace(canExecuteName))
                    {
                        var canExecuteSymbol = typeSymbol.GetMembers().OfType<IMethodSymbol>().FirstOrDefault(x => x.Name == canExecuteName);
                        if (canExecuteSymbol is not null)
                        {
                            // 파라미터 확인해서 canExecute는 원래 파라미터 타입하고 다르게 가져갈 수 있게 하자. attribute, canTarget 모두 변경 필요
                            string parameterName = canExecuteSymbol.Parameters.Any() ? canExecuteSymbol.Parameters.First().Type.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat.AddMiscellaneousOptions(SymbolDisplayMiscellaneousOptions.IncludeNullableReferenceTypeModifier)) : string.Empty;

                            canTarget = new CanExecuteTarget(canExecuteName, methodParameterName, canExecuteSymbol.IsAsync || canExecuteSymbol.ReturnType.Name == "Task");
                        }
                    }
                }
                else if (arg.Key == "CommandName") customMethodName = (string)arg.Value.Value!;
            }
        }
        if (canTarget is not null)
        {
            if (canTarget.Parameter != methodParameterName) return (null, null)!;
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
        var methodTarget = new MethodTarget(methodSymbol.Name, methodParameterName, methodSymbol.IsAsync || methodSymbol.ReturnType.Name == "Task", canTarget) { CustomMethodName = customMethodName };

        return (objectTarget, methodTarget);
    }
}