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
        if (attributeDatas is null || attributeDatas.Count() == 0) return ((null, default)!, null)!;

        ObjectType? objectType = Creater.GetObjectType(typeSymbol);
        if (objectType is null) return ((null, default)!, DiagnosticMapper.Create(typeSymbol, InjectErrors.CouldNotFindTypeObject))!;

        var modifier = Creater.GetAccessibilityString(typeSymbol.DeclaredAccessibility);
        if (string.IsNullOrEmpty(modifier)) return ((null, default)!, DiagnosticMapper.Create(typeSymbol, InjectErrors.CouldNotFindTypeModifier))!;

        List<InjectTarget> injectTargets = new();
        foreach (var attributeData in attributeDatas)
        {
            var modelType = Creater.GetConstructorArgument(attributeData, 0);
            if (modelType?.Value is null) return ((null, default)!, DiagnosticMapper.Create(typeSymbol, InjectErrors.InjectTargetResolveError))!;

            InjectTarget? target = null;

            if (modelType?.Value is INamedTypeSymbol symbol)
            {
                // Type info

                string fullTypeName = symbol.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat.AddMiscellaneousOptions(SymbolDisplayMiscellaneousOptions.IncludeNullableReferenceTypeModifier));
                string customName = string.Empty;
                bool isStatic = symbol.IsStatic;
                Modifier typeModifier = Modifier.Public;
                NotifyType propertyNotifyMode = NotifyType.Notify;
                InjectionType injectionMode = (InjectionType)Creater.GetConstructorArgument(attributeData, 1)?.Value!;

                foreach (var arg in attributeData.NamedArguments)
                {
                    if (arg.Key == "CustomName") customName = (string)arg.Value.Value!;
                    else if (arg.Key == "Modifier")
                    {
                        typeModifier = (Modifier)arg.Value.Value!;
                        if (typeModifier == Modifier.Protected && objectType == ObjectType.Struct) return ((null, default)!, DiagnosticMapper.Create(typeSymbol, InjectErrors.StructObjectInjectModifierError))!;
                    }
                    else if (arg.Key == "PropertyNotifyMode") propertyNotifyMode = (NotifyType)arg.Value.Value!;
                }

                // Property info

                List<PropertyTarget> properties = new();

                if (injectionMode == InjectionType.Model || injectionMode == (InjectionType.Dependency | InjectionType.Model))
                {
                    List<ISymbol> members = new(symbol.GetMembers());
                    while (symbol.BaseType is not null)
                    {
                        members.InsertRange(0, symbol.BaseType.GetMembers());
                        symbol = symbol.BaseType;
                    }
                    foreach (var member in members)
                    {
                        // Base object의 오만가지 다 끼어들 수 있어 public 제한
                        if (member is IFieldSymbol fieldSymbol && member.DeclaredAccessibility == Accessibility.Public)
                        {
                            properties.Add(new PropertyTarget(
                                             fieldSymbol.Name,
                                             fieldSymbol.Name,
                                             fieldSymbol.Type.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat.AddMiscellaneousOptions(SymbolDisplayMiscellaneousOptions.IncludeNullableReferenceTypeModifier)),
                                             fieldSymbol.IsReadOnly,
                                             fieldSymbol.IsStatic,
                                             propertyNotifyMode,
                                             new(), new(), new()));
                        }
                        else if (member is IMethodSymbol { MethodKind: MethodKind.PropertyGet } methodSymbol && member.DeclaredAccessibility == Accessibility.Public)
                        {
                            var propertySymbol = (IPropertySymbol?)methodSymbol.AssociatedSymbol;
                            if (propertySymbol is not null)
                            {
                                properties.Add(new PropertyTarget(
                                                 propertySymbol.Name,
                                                 propertySymbol.Name,
                                                 propertySymbol.Type.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat.AddMiscellaneousOptions(SymbolDisplayMiscellaneousOptions.IncludeNullableReferenceTypeModifier)),
                                                 propertySymbol.IsReadOnly,
                                                 propertySymbol.IsStatic,
                                                 propertyNotifyMode,
                                                 new(), new(), new()));
                            }
                        }
                    }
                }
                target = new(fullTypeName, customName, isStatic, typeModifier, propertyNotifyMode, injectionMode, properties);
            }

            if (target is not null) injectTargets.Add(target);
            else return ((null, default)!, DiagnosticMapper.Create(typeSymbol, InjectErrors.InjectTargetResolveError))!;
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