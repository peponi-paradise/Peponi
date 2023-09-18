using Microsoft.CodeAnalysis;

namespace Peponi.CodeGenerators.SemanticTarget;

internal static partial class Creater
{
    internal static IFieldSymbol? GetFieldSymbol(GeneratorSyntaxContext context)
    {
        return (IFieldSymbol?)context.SemanticModel.GetDeclaredSymbol(context.Node);
    }

    internal static IEnumerable<AttributeData>? GetAttributes(IFieldSymbol? fieldSymbol, string attributeFullName)
    {
        return fieldSymbol?.GetAttributes().Where(x => Inspector.CheckAttribute(x, attributeFullName));
    }

    internal static string? GetConstructorArgumentString(AttributeData attributeData, int index)
    {
        if (attributeData.ConstructorArguments.Length < index + 1) return null;
        return attributeData.ConstructorArguments[index].Value?.ToString();
    }

    internal static TypedConstant? GetConstructorArgument(AttributeData attributeData, int index)
    {
        if (attributeData.ConstructorArguments.Length < index + 1) return null;
        return attributeData.ConstructorArguments[index];
    }

    internal static string? GetNamedArgumentString(AttributeData attributeData, int index)
    {
        if (attributeData.NamedArguments.Length < index + 1) return null;
        return attributeData.NamedArguments[index].Value.Value?.ToString();
    }

    internal static TypedConstant? GetNamedArgument(AttributeData attributeData, int index)
    {
        if (attributeData.NamedArguments.Length < index + 1) return null;
        return attributeData.NamedArguments[index].Value;
    }

    internal static string GetPropertyName(string identifier)
    {
        string rtnString = identifier.Clone().ToString();

        if (rtnString[0] == '_')
        {
            rtnString = identifier.Substring(1);
        }

        if (char.IsLower(rtnString[0]))
        {
            rtnString = rtnString[0].ToString().ToUpper() + rtnString.Substring(1);
        }
        else if (char.IsUpper(rtnString[0]))
        {
            rtnString = rtnString.ToUpper();
        }

        return rtnString;
    }

    internal static (ModelInjectTarget? ModelInfo, List<PropertyTarget>? PropertyTarget)? GetModelInfo(AttributeData attributeData)
    {
        var modelType = GetConstructorArgument(attributeData, 0);
        if (modelType?.Value is null) return null;

        ModelInjectTarget? modelTarget = null;
        List<PropertyTarget> rtns = new();

        if (modelType.Value.Value is INamedTypeSymbol model)
        {
            string modelName = $"{model}";
            bool isStatic = model.IsStatic;
            var argument = GetNamedArgument(attributeData, 0);
            NotifyType notifyType = argument == null ? NotifyType.None : (NotifyType)argument?.Value!;

            modelTarget = new(modelName, isStatic, notifyType);

            List<ISymbol> members = new(model.GetMembers());
            while (model.BaseType is not null)
            {
                members.InsertRange(0, model.BaseType.GetMembers());
                model = model.BaseType;
            }
            foreach (var member in members)
            {
                if (member is IFieldSymbol fieldSymbol)
                {
                    rtns.Add(new PropertyTarget(
                                     fieldSymbol.Name,
                                     GetPropertyName(fieldSymbol.Name),
                                     fieldSymbol.Type.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat.AddMiscellaneousOptions(SymbolDisplayMiscellaneousOptions.IncludeNullableReferenceTypeModifier)),
                                     fieldSymbol.IsReadOnly,
                                     notifyType,
                                     new()));
                }
                else if (member is IMethodSymbol { MethodKind: MethodKind.PropertyGet } methodSymbol)
                {
                    var propertySymbol = (IPropertySymbol?)methodSymbol.AssociatedSymbol;
                    if (propertySymbol is not null)
                    {
                        rtns.Add(new PropertyTarget(
                                         propertySymbol.Name,
                                         GetPropertyName(propertySymbol.Name),
                                         propertySymbol.Type.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat.AddMiscellaneousOptions(SymbolDisplayMiscellaneousOptions.IncludeNullableReferenceTypeModifier)),
                                         propertySymbol.IsReadOnly,
                                         notifyType,
                                         new()));
                    }
                }
            }
        }

        return (modelTarget, rtns);
    }
}