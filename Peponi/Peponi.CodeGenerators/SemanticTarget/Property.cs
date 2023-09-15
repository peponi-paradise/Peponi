namespace Peponi.CodeGenerators.SemanticTarget;

internal class PropertyTarget : IEquatable<PropertyTarget?>
{
    public string FieldName;
    public string PropertyName;
    public string Type;
    public bool IsStatic;
    public bool IsReadOnly;
    public NotifyType NotifyType;
    public List<PropertyMethodTarget> PropertyMethods;

    public PropertyTarget(string fieldName, string propertyName, string type, bool isStatic, bool isReadOnly, NotifyType notifyType, List<PropertyMethodTarget> propertyMethods)
    {
        FieldName = fieldName;
        PropertyName = propertyName;
        Type = type;
        IsStatic = isStatic;
        IsReadOnly = isReadOnly;
        NotifyType = notifyType;
        PropertyMethods = propertyMethods;
    }

    public override bool Equals(object? obj)
    {
        return Equals(obj as PropertyTarget);
    }

    public bool Equals(PropertyTarget? other)
    {
        return other is not null && FieldName == other.FieldName && PropertyName == other.PropertyName &&
            Type == other.Type && IsStatic == other.IsStatic && IsReadOnly == other.IsReadOnly && NotifyType == other.NotifyType &&
            PropertyMethods == other.PropertyMethods;
    }

    public override int GetHashCode()
    {
        return 24247 +
            EqualityComparer<string>.Default.GetHashCode(FieldName) +
            EqualityComparer<string>.Default.GetHashCode(PropertyName) +
            EqualityComparer<string>.Default.GetHashCode(Type) +
            EqualityComparer<bool>.Default.GetHashCode(IsStatic) +
            EqualityComparer<bool>.Default.GetHashCode(IsReadOnly) +
            EqualityComparer<NotifyType>.Default.GetHashCode(NotifyType) +
            EqualityComparer<List<PropertyMethodTarget>>.Default.GetHashCode(PropertyMethods);
    }
}

internal class PropertyMethodTarget : IEquatable<PropertyMethodTarget?>
{
    public PropertyMethodSection Section;
    public string MethodName;
    public string MethodArgs;

    public PropertyMethodTarget(PropertyMethodSection section, string methodName, string methodArgs)
    {
        Section = section;
        MethodName = methodName;
        MethodArgs = methodArgs;
    }

    public override bool Equals(object? obj)
    {
        return Equals(obj as PropertyMethodTarget);
    }

    public bool Equals(PropertyMethodTarget? other)
    {
        return other is not null && Section == other.Section && MethodName == other.MethodName && MethodArgs == other.MethodArgs;
    }

    public override int GetHashCode()
    {
        return 94559 +
           EqualityComparer<PropertyMethodSection>.Default.GetHashCode(Section) +
           EqualityComparer<string>.Default.GetHashCode(MethodName) +
           EqualityComparer<string>.Default.GetHashCode(MethodArgs);
    }
}