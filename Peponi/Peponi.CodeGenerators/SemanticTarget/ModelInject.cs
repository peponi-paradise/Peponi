namespace Peponi.CodeGenerators.SemanticTarget;

internal class ModelInjectTarget : IEquatable<ModelInjectTarget?>
{
    public string NamespaceName;
    public string TypeName;
    public string CustomName;
    public bool IsStatic;
    public NotifyType NotifyType;
    public List<PropertyTarget> Properties;

    public ModelInjectTarget(string namespaceName, string typeName, string customName, bool isStatic, NotifyType notifyType, List<PropertyTarget> properties)
    {
        NamespaceName = namespaceName;
        TypeName = typeName;
        CustomName = customName;
        IsStatic = isStatic;
        NotifyType = notifyType;
        Properties = properties;
    }

    public override bool Equals(object? other)
    {
        return Equals(other as ModelInjectTarget);
    }

    public bool Equals(ModelInjectTarget? other)
    {
        return other is not null && NamespaceName == other.NamespaceName &&
            TypeName == other.TypeName &&
            CustomName == other.CustomName &&
            IsStatic == other.IsStatic &&
            NotifyType == other.NotifyType &&
            Properties == other.Properties;
    }

    public override int GetHashCode()
    {
        return 3539 +
             EqualityComparer<string>.Default.GetHashCode(NamespaceName) +
             EqualityComparer<string>.Default.GetHashCode(TypeName) +
             EqualityComparer<string>.Default.GetHashCode(CustomName) +
             EqualityComparer<bool>.Default.GetHashCode(IsStatic) +
             EqualityComparer<NotifyType>.Default.GetHashCode(NotifyType) +
             EqualityComparer<List<PropertyTarget>>.Default.GetHashCode(Properties);
    }
}