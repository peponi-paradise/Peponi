using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Peponi.SourceGenerators.Diagnostics;
using Peponi.SourceGenerators.SemanticTarget;
using System.Collections.Immutable;

namespace Peponi.SourceGenerators.CommandGenerator;

[Generator]
public sealed partial class CommandGenerator : IIncrementalGenerator
{
    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        var syntaxProvider = context.SyntaxProvider.CreateSyntaxProvider(
                predicate: static (s, _) => IsValidTarget(s),
                transform: static (context, _) => GetMethodTarget(context));

        var errorInfos = syntaxProvider.Where(static item => item.Error is not null);
        context.RegisterSourceOutput(errorInfos, static (productionContext, target) => DiagnosticMapper.Report(productionContext, target.Error));

        IncrementalValuesProvider<(ObjectDeclarationTarget ObjectTarget, ImmutableArray<MethodTarget> PropertyTarget)> methodInfos =
            syntaxProvider.Where(static item => item.Target.ObjectTarget is not null && item.Target.MethodTarget is not null).GroupBy(static item => item.Left.ObjectTarget, static item => item.Left.MethodTarget);
        context.RegisterSourceOutput(methodInfos, static (productionContext, target) => Execute(productionContext, target));
    }

    private static bool IsValidTarget(SyntaxNode node) => node is MethodDeclarationSyntax { AttributeLists: { Count: > 0 } };

    private static ((ObjectDeclarationTarget ObjectTarget, MethodTarget MethodTarget) Target, Diagnostic Error) GetMethodTarget(GeneratorSyntaxContext context)
    {
        string? customMethodName = null;
        CanExecuteTarget? canTarget = null;

        var methodSymbol = Creater.GetMethodSymbol(context);
        if (methodSymbol is null) return ((null, null)!, null)!;

        AttributeData? attributeData = Creater.GetAttribute(methodSymbol, "Peponi.SourceGenerators.CommandAttribute");
        if (attributeData is null) return ((null, null)!, null)!;
        else
        {
            var typeSymbol = Creater.GetTypeSymbol(context);
            if (typeSymbol is null) return ((null, null)!, DiagnosticMapper.Create(CommandErrors.CouldNotFindTypeSymbol));

            ObjectType? objectType = Creater.GetObjectType(typeSymbol);
            if (objectType is null) return ((null, null)!, DiagnosticMapper.Create(typeSymbol, CommandErrors.CouldNotFindTypeObject));

            var modifier = Creater.GetAccessibilityString(typeSymbol.DeclaredAccessibility);
            if (string.IsNullOrEmpty(modifier)) return ((null, null)!, DiagnosticMapper.Create(typeSymbol, CommandErrors.CouldNotFindTypeModifier))!;

            if (methodSymbol.ReturnType.Name != "Task" && methodSymbol.ReturnType.Name != "Void") return ((null, null)!, DiagnosticMapper.Create(methodSymbol, CommandErrors.MethodReturnType));
            string methodParameterType = methodSymbol.Parameters.Any() ? methodSymbol.Parameters.First().Type.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat.AddMiscellaneousOptions(SymbolDisplayMiscellaneousOptions.IncludeNullableReferenceTypeModifier)) : string.Empty;

            string? canExecuteName = null;
            string? canExecuteParameterType = null;
            IMethodSymbol? canExecuteSymbol = null;
            foreach (var arg in attributeData.NamedArguments)
            {
                if (arg.Key == "CustomName") customMethodName = (string)arg.Value.Value!;
                else if (arg.Key == "CanExecute")
                {
                    canExecuteName = (string)arg.Value.Value!;
                    if (!string.IsNullOrWhiteSpace(canExecuteName))
                    {
                        canExecuteSymbol = typeSymbol.GetMembers().OfType<IMethodSymbol>().FirstOrDefault(x => x.Name == canExecuteName);
                        if (canExecuteSymbol is not null)
                        {
                            if (canExecuteSymbol!.IsAsync || canExecuteSymbol.ReturnType.Name == "Task") return ((null, null)!, DiagnosticMapper.Create(methodSymbol, CommandErrors.CanExecuteReturnType));
                            canExecuteParameterType = canExecuteSymbol.Parameters.Any() ? canExecuteSymbol.Parameters.First().Type.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat.AddMiscellaneousOptions(SymbolDisplayMiscellaneousOptions.IncludeNullableReferenceTypeModifier)) : string.Empty;

                            if ((string.IsNullOrWhiteSpace(methodParameterType) && !string.IsNullOrWhiteSpace(canExecuteParameterType)) ||
                                ((!string.IsNullOrWhiteSpace(methodParameterType) && !string.IsNullOrWhiteSpace(canExecuteParameterType)) && (methodParameterType != canExecuteParameterType)))
                            {
                                return ((null, null)!, DiagnosticMapper.Create(methodSymbol, CommandErrors.CanExecuteParameterType));
                            }
                        }
                    }
                }
            }
            if (!string.IsNullOrWhiteSpace(canExecuteName))
            {
                canTarget = new CanExecuteTarget(canExecuteName!, canExecuteParameterType!);
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
            var methodTarget = new MethodTarget(methodSymbol.Name, methodParameterType, methodSymbol.IsAsync || methodSymbol.ReturnType.Name == "Task", canTarget) { CustomMethodName = customMethodName };

            return ((objectTarget, methodTarget), null)!;
        }
    }
}