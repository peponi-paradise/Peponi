using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Peponi.CodeGenerators.INotifyGenerator;
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
        PropertyType type;

        var symbol = context.SemanticModel.GetDeclaredSymbol(context.Node);
        File.WriteAllText(@$"C:\temp\prop.txt", $"{symbol.ContainingType.TypeKind}");

        switch (context.Node)
        {
            case ClassDeclarationSyntax classDeclaration:
                typeSymbol = context.SemanticModel.GetDeclaredSymbol(classDeclaration);
                objectType = ObjectType.Class;
                break;

            case RecordDeclarationSyntax recordDeclaration:
                typeSymbol = context.SemanticModel.GetDeclaredSymbol(recordDeclaration);
                objectType = ObjectType.Record;
                break;

            case StructDeclarationSyntax structDeclaration:
                typeSymbol = context.SemanticModel.GetDeclaredSymbol(structDeclaration);
                objectType = ObjectType.Struct;
                break;

            default:
                return (null, null);
        }
        if (typeSymbol is null) return (null, null);

        attributeData = typeSymbol?.GetAttributes().FirstOrDefault(x => x.AttributeClass?.ToDisplayString() == "Peponi.CodeGenerators.PropertyAttribute");
        if (attributeData == null)
        {
            attributeData = typeSymbol?.GetAttributes().FirstOrDefault(x => x.AttributeClass?.ToDisplayString() == "Peponi.CodeGenerators.NotifyPropertyAttribute");
            if (attributeData == null) return (null, null);
            else type = PropertyType.NotifyProperty;
        }
        else type = PropertyType.Property;

        // Generate property target
        var fieldSyntax = (FieldDeclarationSyntax)context.Node.Parent!.Parent!;
        var fieldSymbol = (IFieldSymbol)context.SemanticModel.GetDeclaredSymbol(fieldSyntax)!;
        string methodName = string.Empty;
        string methodArgs = string.Empty;
        foreach (var arg in attributeData!.NamedArguments)
        {
            if (arg.Key == "CallMethodName")
            {
                methodName = arg.Value.Value?.ToString()!;
            }
            else if (arg.Key == "CallMethodArgs")
            {
                methodArgs = arg.Value.Value?.ToString()!;
            }
        }

        var propertyTarget = new PropertyTarget(
            fieldSymbol.Name,
            GetPropertyName(fieldSymbol.Name),
            fieldSymbol.Type.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat.AddMiscellaneousOptions(SymbolDisplayMiscellaneousOptions.IncludeNullableReferenceTypeModifier)),
            fieldSymbol.IsStatic,
            fieldSymbol.IsReadOnly,
            type,
            methodName,
            methodArgs
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
            typeSymbol.IsStatic,
            typeSymbol.IsSealed
            );

        return (objectTarget, propertyTarget);
    }

    private static string GetPropertyName(string identifier)
    {
        string rtnString = string.Empty;

        if (identifier[0] == '_')
        {
            rtnString = identifier.Substring(1);
        }

        if (char.IsLower(identifier[0]))
        {
            rtnString = identifier[0].ToString().ToUpper() + identifier.Substring(1);
        }

        if (char.IsUpper(identifier[0]))
        {
            rtnString = identifier.ToUpper();
        }

        return rtnString;
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