using Microsoft.CodeAnalysis;
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
        var typeSymbol = Creater.GetTypeSymbol(context);
        if (typeSymbol is null) return (null, null)!;

        var fieldSymbol = Creater.GetFieldSymbol(context);
        if (fieldSymbol is null) return (null, null)!;

        ObjectType? objectType = Creater.GetObjectType(typeSymbol);
        if (objectType is null) return (null, null)!;

        NotifyType notifyType;
        string? customPropertyName;
        AttributeData? attributeData = Creater.GetAttribute(fieldSymbol, "Peponi.CodeGenerators.PropertyAttribute");
        if (attributeData is not null)
        {
            notifyType = NotifyType.None;
            customPropertyName = Creater.GetNamedArgument(attributeData, 0);
        }
        else
        {
            attributeData = Creater.GetAttribute(fieldSymbol, "Peponi.CodeGenerators.NotifyPropertyAttribute");
            if (attributeData is not null)
            {
                notifyType = NotifyType.Notify;
                customPropertyName = Creater.GetNamedArgument(attributeData, 0);
            }
            else return (null, null)!;
        }

        // Get custom method call information

        List<PropertyMethodTarget> methodTargets = new();

        var methodsAttr = Creater.GetAttributes(fieldSymbol, "Peponi.CodeGenerators.PropertyMethodAttribute");

        if (methodsAttr != null && methodsAttr.Count() > 0)
        {
            foreach (var attr in methodsAttr)
            {
                var methodName = Creater.GetConstructorArgument(attr, 0);

                if (methodName is not null and { Length: > 0 })
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
            customPropertyName ?? Creater.GetPropertyName(fieldSymbol.Name),
            fieldSymbol.Type.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat.AddMiscellaneousOptions(SymbolDisplayMiscellaneousOptions.IncludeNullableReferenceTypeModifier)),
            fieldSymbol.IsStatic,
            fieldSymbol.IsReadOnly,
            notifyType,
            methodTargets
            );
        var objectTarget = new ObjectDeclarationTarget(
            typeSymbol.Name,
            Creater.GetAccessibilityString(typeSymbol.DeclaredAccessibility),
            typeSymbol.ContainingNamespace.ToDisplayString(),
            (ObjectType)objectType,
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