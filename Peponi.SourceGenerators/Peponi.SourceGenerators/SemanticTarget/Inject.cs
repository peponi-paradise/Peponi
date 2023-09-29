namespace Peponi.SourceGenerators.SemanticTarget;

internal class InjectTarget : IEquatable<InjectTarget?>
{
    public string FullTypeName;
    public string CustomName;
    public bool IsStatic;
    public Modifier TypeModifier;
    public NotifyType PropertyNotifyMode;
    public InjectionType InjectionMode;
    public List<PropertyTarget> Properties;

    public InjectTarget(string fullTypeName, string customName, bool isStatic,
        Modifier typeModifier, NotifyType propertyNotify, InjectionType injectionMode,
        List<PropertyTarget> properties)
    {
        FullTypeName = fullTypeName;
        CustomName = customName;
        IsStatic = isStatic;
        TypeModifier = typeModifier;
        PropertyNotifyMode = propertyNotify;
        InjectionMode = injectionMode;
        Properties = properties;
    }

    public override bool Equals(object? other)
    {
        return Equals(other as InjectTarget);
    }

    public bool Equals(InjectTarget? other)
    {
        return other is not null &&
            FullTypeName == other.FullTypeName &&
            CustomName == other.CustomName &&
            IsStatic == other.IsStatic &&
            TypeModifier == other.TypeModifier &&
            PropertyNotifyMode == other.PropertyNotifyMode &&
            InjectionMode == other.InjectionMode &&
            Properties == other.Properties;
    }

    public override int GetHashCode()
    {
        return 3539 +
             EqualityComparer<string>.Default.GetHashCode(FullTypeName) +
             EqualityComparer<string>.Default.GetHashCode(CustomName) +
             EqualityComparer<bool>.Default.GetHashCode(IsStatic) +
             EqualityComparer<Modifier>.Default.GetHashCode(TypeModifier) +
             EqualityComparer<NotifyType>.Default.GetHashCode(PropertyNotifyMode) +
             EqualityComparer<InjectionType>.Default.GetHashCode(InjectionMode) +
             EqualityComparer<List<PropertyTarget>>.Default.GetHashCode(Properties);
    }
}