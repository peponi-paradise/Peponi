namespace Peponi.CodeGenerators.SemanticTarget;

internal class PropertyTarget : IEquatable<PropertyTarget?>
{
    public string FieldName;
    public string PropertyName;
    public string Type;
    public bool IsStatic;
    public bool IsReadOnly;
    public NotifyType NotifyType;
    public List<string> CallMethodName;
    public List<string> CallMethodArgs;

    public PropertyTarget(string fieldName, string propertyName, string type, bool isStatic, bool isReadOnly, NotifyType notifyType, List<string> callMethodName, List<string> callMethodArgs)
    {
        FieldName = fieldName;
        PropertyName = propertyName;
        Type = type;
        IsStatic = isStatic;
        IsReadOnly = isReadOnly;
        NotifyType = notifyType;
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
            Type == other.Type && IsStatic == other.IsStatic && IsReadOnly == other.IsReadOnly && NotifyType == other.NotifyType &&
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
            EqualityComparer<NotifyType>.Default.GetHashCode(NotifyType) +
            EqualityComparer<List<string>>.Default.GetHashCode(CallMethodName) +
            EqualityComparer<List<string>>.Default.GetHashCode(CallMethodArgs);
    }
}