using Microsoft.CodeAnalysis;

namespace Peponi.CodeGenerators.SemanticTarget;

internal static partial class Creater
{
    internal static IFieldSymbol? GetFieldSymbol(GeneratorSyntaxContext context)
    {
        return (IFieldSymbol?)context.SemanticModel.GetDeclaredSymbol(context.Node);
    }

    internal static IMethodSymbol? GetMethodSymbol(GeneratorSyntaxContext context)
    {
        return (IMethodSymbol?)context.SemanticModel.GetDeclaredSymbol(context.Node);
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

    internal static string GetPropertyName(string identifier, Modifier modifier = Modifier.Public)
    {
        if (modifier == Modifier.Public)
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
        else if (modifier == Modifier.Private || modifier == Modifier.Protected || modifier == Modifier.Internal)
        {
            string rtnString = identifier.Clone().ToString();

            if (rtnString.IsAllUpper())
            {
                rtnString = rtnString.ToLower();
            }
            else if (rtnString[0] == '_')
            {
                // Temp remove
                rtnString = rtnString.Substring(1);
            }
            if (char.IsUpper(rtnString[0]))
            {
                rtnString = rtnString[0].ToString().ToLower() + rtnString.Substring(1);
            }

            return $"_{rtnString}";
        }
        else return identifier;
    }

    internal static InjectModelTarget? GetModelInfo(AttributeData attributeData)
    {
        var modelType = GetConstructorArgument(attributeData, 0);
        if (modelType?.Value is null) return null;

        InjectModelTarget? modelTarget = null;
        List<PropertyTarget> rtns = new();

        if (modelType.Value.Value is INamedTypeSymbol model)
        {
            string namespaceName = model.ContainingNamespace.ToDisplayString();
            string modelName = model.Name;
            string customName = string.Empty;
            bool isStatic = model.IsStatic;
            NotifyType notifyType = NotifyType.None;
            for (int i = 0; i < attributeData.NamedArguments.Length; i++)
            {
                var argument = GetNamedArgument(attributeData, i);
                // Enum catched by int
                if (argument is not null && argument?.Value!.GetType() == typeof(int))
                {
                    notifyType = (NotifyType)argument?.Value!;
                }
                else if (argument is not null && argument?.Value!.GetType() == typeof(string))
                {
                    customName = (string)argument?.Value!;
                }
            }

            List<ISymbol> members = new(model.GetMembers());
            while (model.BaseType is not null)
            {
                members.InsertRange(0, model.BaseType.GetMembers());
                model = model.BaseType;
            }
            foreach (var member in members)
            {
                // Base object의 오만가지 다 끼어들 수 있어 public 제한
                if (member is IFieldSymbol fieldSymbol && member.DeclaredAccessibility == Accessibility.Public)
                {
                    rtns.Add(new PropertyTarget(
                                     fieldSymbol.Name,
                                     GetPropertyName(fieldSymbol.Name),
                                     fieldSymbol.Type.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat.AddMiscellaneousOptions(SymbolDisplayMiscellaneousOptions.IncludeNullableReferenceTypeModifier)),
                                     fieldSymbol.IsReadOnly,
                                     fieldSymbol.IsStatic,
                                     notifyType,
                                     new(), new(), new()));
                }
                else if (member is IMethodSymbol { MethodKind: MethodKind.PropertyGet } methodSymbol && member.DeclaredAccessibility == Accessibility.Public)
                {
                    var propertySymbol = (IPropertySymbol?)methodSymbol.AssociatedSymbol;
                    if (propertySymbol is not null)
                    {
                        rtns.Add(new PropertyTarget(
                                         propertySymbol.Name,
                                         GetPropertyName(propertySymbol.Name),
                                         propertySymbol.Type.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat.AddMiscellaneousOptions(SymbolDisplayMiscellaneousOptions.IncludeNullableReferenceTypeModifier)),
                                         propertySymbol.IsReadOnly,
                                         propertySymbol.IsStatic,
                                         notifyType,
                                         new(), new(), new()));
                    }
                }
            }
            modelTarget = new(namespaceName, modelName, customName, isStatic, notifyType, rtns);
        }

        return modelTarget;
    }

    internal static InjectTarget? GetInjectTarget(AttributeData attributeData)
    {
        var modelType = GetConstructorArgument(attributeData, 0);
        if (modelType?.Value is null) return null;

        InjectTarget? target = null;

        if (modelType?.Value is INamedTypeSymbol symbol)
        {
            // Type info

            string fullTypeName = symbol.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat.AddMiscellaneousOptions(SymbolDisplayMiscellaneousOptions.IncludeNullableReferenceTypeModifier));
            string customName = string.Empty;
            bool isStatic = symbol.IsStatic;
            Modifier typeModifier = Modifier.Public;
            NotifyType propertyNotifyMode = NotifyType.Notify;
            InjectionType injectionMode = (InjectionType)GetConstructorArgument(attributeData, 1)?.Value!;

            foreach (var arg in attributeData.NamedArguments)
            {
                if (arg.Key == "CustomName") customName = (string)arg.Value.Value!;
                else if (arg.Key == "TypeModifier") typeModifier = (Modifier)arg.Value.Value!;
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
                                         GetPropertyName(fieldSymbol.Name),
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
                                             GetPropertyName(propertySymbol.Name),
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
        return target;
    }

    private static bool IsAllUpper(this string input)
    {
        for (int i = 0; i < input.Length; i++)
        {
            if (char.IsLetter(input[i]) && !char.IsUpper(input[i]))
                return false;
        }
        return true;
    }
}