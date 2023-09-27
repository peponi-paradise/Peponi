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

        NotifyType notifyType = NotifyType.Notify;
        string? customPropertyName = null;
        AttributeData? attributeData = Creater.GetAttribute(fieldSymbol, "Peponi.CodeGenerators.PropertyAttribute");
        if (attributeData is not null)
        {
            foreach (var arg in attributeData.NamedArguments)
            {
                if (arg.Key == "CustomName") customPropertyName = (string)arg.Value.Value!;
                else if (arg.Key == "NotifyType") notifyType = (NotifyType)arg.Value.Value!;
            }
        }
        else return (null, null)!;

        // Get custom method call information

        List<PropertyMethodCallTarget> methodTargets = new();

        var methodsAttr = Creater.GetAttributes(fieldSymbol, "Peponi.CodeGenerators.MethodCallAttribute");

        if (methodsAttr != null && methodsAttr.Count() > 0)
        {
            foreach (var attr in methodsAttr)
            {
                var methodName = Creater.GetConstructorArgumentString(attr, 0);

                if (methodName is not null and { Length: > 0 })
                {
                    PropertyMethodCallTarget addTarget = new(PropertyMethodSection.Setter, methodName, "");

                    foreach (var arg in attr.NamedArguments)
                    {
                        if (arg.Key == "Section") addTarget.Section = (PropertyMethodSection)arg.Value.Value!;
                        else if (arg.Key == "Args") addTarget.MethodArgs = (string)arg.Value.Value!;
                    }

                    if (!string.IsNullOrWhiteSpace(addTarget.MethodName)) methodTargets.Add(addTarget);
                }
            }
        }

        List<CanExecuteChangedTarget> canExecuteChangedTargets = new();

        var canExecuteAttr = Creater.GetAttributes(fieldSymbol, "Peponi.CodeGenerators.RaiseCanExecuteChangedAttribute");

        if (canExecuteAttr != null && canExecuteAttr.Count() > 0)
        {
            foreach (var attr in canExecuteAttr)
            {
                var commandName = Creater.GetConstructorArgumentString(attr, 0);
                if (commandName is not null && commandName.Length > 0)
                {
                    canExecuteChangedTargets.Add(new(commandName));
                }
            }
        }

        List<RaisePropertyChangedTarget> raisePropertyChangedTargets = new();

        var propertyChangedAttr = Creater.GetAttributes(fieldSymbol, "Peponi.CodeGenerators.RaisePropertyChangedAttribute");

        if (propertyChangedAttr != null && propertyChangedAttr.Count() > 0)
        {
            foreach (var attr in propertyChangedAttr)
            {
                var propertyName = Creater.GetConstructorArgumentString(attr, 0);
                if (propertyName is not null && propertyName.Length > 0)
                {
                    raisePropertyChangedTargets.Add(new(propertyName));
                }
            }
        }

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
        var propertyTarget = new PropertyTarget(
            fieldSymbol.Name,
            customPropertyName ?? Creater.GetPropertyName(fieldSymbol.Name),
            fieldSymbol.Type.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat.AddMiscellaneousOptions(SymbolDisplayMiscellaneousOptions.IncludeNullableReferenceTypeModifier)),
            fieldSymbol.IsReadOnly,
            fieldSymbol.IsStatic,
            notifyType,
            methodTargets,
            canExecuteChangedTargets,
            raisePropertyChangedTargets
            );

        return (objectTarget, propertyTarget);
    }
}