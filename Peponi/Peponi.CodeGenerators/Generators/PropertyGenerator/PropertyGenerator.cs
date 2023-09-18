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
            customPropertyName = Creater.GetNamedArgumentString(attributeData, 0);
        }
        else
        {
            attributeData = Creater.GetAttribute(fieldSymbol, "Peponi.CodeGenerators.NotifyPropertyAttribute");
            if (attributeData is not null)
            {
                notifyType = NotifyType.Notify;
                customPropertyName = Creater.GetNamedArgumentString(attributeData, 0);
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
                var methodName = Creater.GetConstructorArgumentString(attr, 0);

                if (methodName is not null and { Length: > 0 })
                {
                    PropertyMethodTarget addTarget = new(PropertyMethodSection.Setter, methodName, "");

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