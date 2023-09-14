namespace Peponi.CodeGenerators.PropertyGenerator;

public enum PropertyType
{
    Property,
    NotifyProperty,
}

internal class PropertyTarget : IEquatable<PropertyTarget?>
{
    public string FieldName;
    public string PropertyName;
    public string Type;
    public bool IsStatic;
    public bool IsReadOnly;
    public PropertyType PropertyType;
    public string CallMethodName;
    public string CallMethodArgs;

    public PropertyTarget(string fieldName, string propertyName, string type, bool isStatic, bool isReadOnly, PropertyType propertyType, string callMethodName, string callMethodArgs)
    {
        FieldName = fieldName;
        PropertyName = propertyName;
        Type = type;
        IsStatic = isStatic;
        IsReadOnly = isReadOnly;
        PropertyType = propertyType;
        CallMethodName = callMethodName;
        CallMethodArgs = callMethodArgs;
    }

    public override bool Equals(object? obj)
    {
        return Equals(obj as PropertyTarget);
    }

    public bool Equals(PropertyTarget? other)
    {
        return other is not null && FieldName == other.FieldName && PropertyName == other.PropertyName &&
            Type == other.Type && IsStatic == other.IsStatic && IsReadOnly == other.IsReadOnly && PropertyType == other.PropertyType &&
            CallMethodName == other.CallMethodName && CallMethodArgs == other.CallMethodArgs;
    }

    public override int GetHashCode()
    {
        return 24247 +
            EqualityComparer<string>.Default.GetHashCode(FieldName) +
            EqualityComparer<string>.Default.GetHashCode(PropertyName) +
            EqualityComparer<string>.Default.GetHashCode(Type) +
            EqualityComparer<bool>.Default.GetHashCode(IsStatic) +
            EqualityComparer<bool>.Default.GetHashCode(IsReadOnly) +
            EqualityComparer<PropertyType>.Default.GetHashCode(PropertyType) +
            EqualityComparer<string>.Default.GetHashCode(CallMethodName) +
            EqualityComparer<string>.Default.GetHashCode(CallMethodArgs);
    }
}