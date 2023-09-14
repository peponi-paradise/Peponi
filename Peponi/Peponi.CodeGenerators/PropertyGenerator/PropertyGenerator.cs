using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Reflection;

namespace Peponi.CodeGenerators.PropertyGenerator;

[Generator]
public sealed partial class PropertyGenerator : IIncrementalGenerator
{
    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        var syntaxProvider = context.SyntaxProvider.CreateSyntaxProvider(
            predicate: static (s, _) => IsValidTarget(s),
            transform: static (context, _) => GetPropertyTarget(context))
                 .Where(static target => target is not null);

        context.RegisterSourceOutput(syntaxProvider, static (productionContext, target) => Execute(productionContext, target));
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

    private static PropertyTarget? GetPropertyTarget(GeneratorSyntaxContext context)
    {
        INamedTypeSymbol? typeSymbol;
        AttributeData? attributeData;
        PropertyType type;

        typeSymbol = context.Node switch
        {
            ClassDeclarationSyntax clx => context.SemanticModel.GetDeclaredSymbol(clx),
            RecordDeclarationSyntax rlx => context.SemanticModel.GetDeclaredSymbol(rlx),
            StructDeclarationSyntax slx => context.SemanticModel.GetDeclaredSymbol(slx),
            _ => null
        };
        if (typeSymbol is null) return null;

        attributeData = typeSymbol?.GetAttributes().FirstOrDefault(x => x.AttributeClass?.ToDisplayString() == "Peponi.CodeGenerators.PropertyAttribute");
        if (attributeData == null)
        {
            attributeData = typeSymbol?.GetAttributes().FirstOrDefault(x => x.AttributeClass?.ToDisplayString() == "Peponi.CodeGenerators.NotifyPropertyAttribute");
            if (attributeData == null) return null;
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

        return new PropertyTarget(
            fieldSymbol.Name,
            GetPropertyName(fieldSymbol.Name),
            fieldSymbol.Type.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat.AddMiscellaneousOptions(SymbolDisplayMiscellaneousOptions.IncludeNullableReferenceTypeModifier)),
            fieldSymbol.IsStatic,
            fieldSymbol.IsReadOnly,
            type,
            methodName,
            methodArgs
            );
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