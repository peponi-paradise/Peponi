namespace Peponi.SourceGenerators.SemanticTarget;

internal class InjectTarget : IEquatable<InjectTarget?>
{
    public string FullTypeName;
    public string CustomName;
    public bool IsStatic;
    public Modifier Modifier;
    public NotifyType PropertyNotifyMode;
    public InjectionType InjectionMode;
    public List<PropertyTarget> Properties;

    public InjectTarget(string fullTypeName, string customName, bool isStatic,
        Modifier modifier, NotifyType propertyNotify, InjectionType injectionMode,
        List<PropertyTarget> properties)
    {
        FullTypeName = fullTypeName;
        CustomName = customName;
        IsStatic = isStatic;
        Modifier = modifier;
        PropertyNotifyMode = propertyNotify;
        InjectionMode = injectionMode;
        Properties = properties;
    }

    public override bool Equals(object? obj)
    {
        return Equals(obj as InjectTarget);
    }

    public bool Equals(InjectTarget? other)
    {
        return other is not null &&
               FullTypeName == other.FullTypeName &&
               CustomName == other.CustomName &&
               IsStatic == other.IsStatic &&
               Modifier == other.Modifier &&
               PropertyNotifyMode == other.PropertyNotifyMode &&
               InjectionMode == other.InjectionMode &&
               EqualityComparer<List<PropertyTarget>>.Default.Equals(Properties, other.Properties);
    }

    public override int GetHashCode()
    {
        int hashCode = 183440594;
        hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(FullTypeName);
        hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(CustomName);
        hashCode = hashCode * -1521134295 + IsStatic.GetHashCode();
        hashCode = hashCode * -1521134295 + Modifier.GetHashCode();
        hashCode = hashCode * -1521134295 + PropertyNotifyMode.GetHashCode();
        hashCode = hashCode * -1521134295 + InjectionMode.GetHashCode();
        hashCode = hashCode * -1521134295 + EqualityComparer<List<PropertyTarget>>.Default.GetHashCode(Properties);
        return hashCode;
    }
}