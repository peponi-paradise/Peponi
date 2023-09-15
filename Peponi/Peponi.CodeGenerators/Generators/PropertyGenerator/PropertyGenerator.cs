using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Peponi.CodeGenerators.SemanticTarget;
using System.Collections.Immutable;

namespace Peponi.CodeGenerators.PropertyGenerator;

[Generator]
public sealed partial class PropertyGenerator : IIncrementalGenerator
{
    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        var syntaxProvider = context.SyntaxProvider.CreateSyntaxProvider(
            predicate: static (s, _) => IsValidTarget(s),
            transform: static (context, _) => GetPropertyTarget(context))
                 .Where(static item => item.PropertyTarget is not null);

        IncrementalValuesProvider<(ObjectDeclarationTarget ObjectTarget, ImmutableArray<PropertyTarget> PropertyTarget)> propertyInfos =
            syntaxProvider.GroupBy(static item => item.Left, static item => item.Right);

        context.RegisterSourceOutput(propertyInfos, static (productionContext, Info) => Execute(productionContext, Info.ObjectTarget, Info.PropertyTarget));
    }

    private static bool IsValidTarget(SyntaxNode node)
    {
        return node is VariableDeclaratorSyntax
        {
            Parent: VariableDeclarationSyntax
            {
                Parent: FieldDeclarationSyntax
                {
                    Parent: ClassDeclarationSyntax or RecordDeclarationSyntax or StructDeclarationSyntax, AttributeLists.Count: > 0
                }
            }
        };
    }

    private static (ObjectDeclarationTarget ObjectTarget, PropertyTarget PropertyTarget) GetPropertyTarget(GeneratorSyntaxContext context)
    {
        INamedTypeSymbol? typeSymbol;
        AttributeData? attributeData;
        ObjectType objectType = ObjectType.Class;
        string? customName = null;
        NotifyType type = NotifyType.None;

        var symbol = context.SemanticModel.GetDeclaredSymbol(context.Node)!;
        typeSymbol = symbol.ContainingType;

        if (typeSymbol.IsAbstract)
        {
            if (typeSymbol.IsSealed && typeSymbol.IsStatic) return (null, null)!;
        }
        if (objectType is ObjectType.Record or ObjectType.Struct)
        {
            if (typeSymbol.IsStatic) return (null, null)!;
        }

        if (typeSymbol.TypeKind == TypeKind.Class && typeSymbol.IsRecord) objectType = ObjectType.Record;
        else if (typeSymbol.TypeKind == TypeKind.Class) objectType = ObjectType.Class;
        else if (typeSymbol.TypeKind == TypeKind.Struct) objectType = ObjectType.Struct;
        else return (null, null)!;

        attributeData = symbol?.GetAttributes().FirstOrDefault(x => x.AttributeClass?.ToDisplayString() == "Peponi.CodeGenerators.PropertyAttribute");
        if (attributeData != null)
        {
            if (attributeData.NamedArguments.Length > 0) customName = attributeData.NamedArguments[0].Value.Value?.ToString();
            type = NotifyType.None;
        }
        else if (attributeData == null)
        {
            attributeData = symbol?.GetAttributes().FirstOrDefault(x => x.AttributeClass?.ToDisplayString() == "Peponi.CodeGenerators.NotifyPropertyAttribute");
            if (attributeData == null) return (null, null)!;
            else
            {
                if (attributeData.NamedArguments.Length > 0) customName = attributeData.NamedArguments[0].Value.Value?.ToString();
                type = NotifyType.Notify;
            }
        }

        // Generate property target
        var fieldSyntax = (FieldDeclarationSyntax)context.Node.Parent!.Parent!;
        var fieldSymbol = (IFieldSymbol)symbol!;
        List<PropertyMethodTarget> methodTargets = new();

        var methodsAttr = symbol?.GetAttributes().Where(x => x.AttributeClass?.ToDisplayString() == "Peponi.CodeGenerators.PropertyMethodAttribute");

        if (methodsAttr != null && methodsAttr.Count() > 0)
        {
            foreach (var attr in methodsAttr)
            {
                var methodName = attr.ConstructorArguments.FirstOrDefault().Value?.ToString();

                if (methodName is { Length: > 0 })
                {
                    PropertyMethodTarget addTarget = new(PropertyMethodSection.Setter, methodName, string.Empty);

                    foreach (var arg in attr.NamedArguments)
                    {
                        if (arg.Key == "Section") addTarget.Section = (PropertyMethodSection)arg.Value.Value!;
                        else if (arg.Key == "Args") addTarget.MethodArgs = (string)arg.Value.Value!;
                    }
                    if (!string.IsNullOrWhiteSpace(addTarget.MethodName)) methodTargets.Add(addTarget);
                }
            }
        }

        var propertyTarget = new PropertyTarget(
            fieldSymbol.Name,
            customName ?? Field.GetPropertyName(fieldSymbol.Name),
            fieldSymbol.Type.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat.AddMiscellaneousOptions(SymbolDisplayMiscellaneousOptions.IncludeNullableReferenceTypeModifier)),
            fieldSymbol.IsStatic,
            fieldSymbol.IsReadOnly,
            type,
            methodTargets
            );
        var objectTarget = new ObjectDeclarationTarget(
            typeSymbol.Name,
            typeSymbol.DeclaredAccessibility switch
            {
                Accessibility.Public => "public",
                Accessibility.Protected => "protected",
                Accessibility.Internal => "internal",
                Accessibility.Private => "private",
                _ => ""
            },
            typeSymbol.ContainingNamespace.ToDisplayString(),
            objectType,
            NotifyType.None,
            typeSymbol.IsStatic,
            typeSymbol.IsSealed,
            typeSymbol.IsAbstract
            );

        return (objectTarget, propertyTarget);
    }
}

internal static class IncrementalValuesProviderExtensions
{
    /// <summary>
    /// Groups items in a given <see cref="IncrementalValuesProvider{TValue}"/> sequence by a specified key.
    /// </summary>
    /// <typeparam name="TLeft">The type of left items in each tuple.</typeparam>
    /// <typeparam name="TRight">The type of right items in each tuple.</typeparam>
    /// <typeparam name="TKey">The type of resulting key elements.</typeparam>
    /// <typeparam name="TElement">The type of resulting projected elements.</typeparam>
    /// <param name="source">The input <see cref="IncrementalValuesProvider{TValues}"/> instance.</param>
    /// <param name="keySelector">The key selection <see cref="Func{T, TResult}"/>.</param>
    /// <param name="elementSelector">The element selection <see cref="Func{T, TResult}"/>.</param>
    /// <returns>An <see cref="IncrementalValuesProvider{TValues}"/> with the grouped results.</returns>
    public static IncrementalValuesProvider<(TKey Key, ImmutableArray<TElement> Right)> GroupBy<TLeft, TRight, TKey, TElement>(
        this IncrementalValuesProvider<(TLeft Left, TRight Right)> source,
        Func<(TLeft Left, TRight Right), TKey> keySelector,
        Func<(TLeft Left, TRight Right), TElement> elementSelector)
        where TLeft : IEquatable<TLeft>
        where TRight : IEquatable<TRight>
        where TKey : IEquatable<TKey>
        where TElement : IEquatable<TElement>
    {
        return source.Collect().SelectMany((item, token) =>
        {
            Dictionary<TKey, ImmutableArray<TElement>.Builder> map = new();

            foreach ((TLeft, TRight) pair in item)
            {
                TKey key = keySelector(pair);
                TElement element = elementSelector(pair);

                if (!map.TryGetValue(key, out ImmutableArray<TElement>.Builder builder))
                {
                    builder = ImmutableArray.CreateBuilder<TElement>();

                    map.Add(key, builder);
                }

                builder.Add(element);
            }

            token.ThrowIfCancellationRequested();

            ImmutableArray<(TKey Key, ImmutableArray<TElement> Elements)>.Builder result =
                ImmutableArray.CreateBuilder<(TKey, ImmutableArray<TElement>)>();

            foreach (KeyValuePair<TKey, ImmutableArray<TElement>.Builder> entry in map)
            {
                result.Add((entry.Key, entry.Value.ToImmutable()));
            }

            return result;
        });
    }
}