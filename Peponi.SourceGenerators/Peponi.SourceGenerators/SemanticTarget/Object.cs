namespace Peponi.SourceGenerators.SemanticTarget;

internal class ObjectDeclarationTarget : IEquatable<ObjectDeclarationTarget?>
{
    public string TypeName;
    public string Modifier;
    public string NamespaceName;
    public ObjectType ObjectType;
    public NotifyType NotifyType;
    public bool IsStatic;
    public bool IsSealed;
    public bool IsAbstract;

    public ObjectDeclarationTarget(string typeName, string modifier, string namespaceName, ObjectType objectType, NotifyType notifyType, bool isStatic, bool isSealed, bool isAbstract)
    {
        TypeName = typeName;
        Modifier = modifier;
        NamespaceName = namespaceName;
        ObjectType = objectType;
        NotifyType = notifyType;
        IsStatic = isStatic;
        IsSealed = isSealed;
        IsAbstract = isAbstract;
    }

    public override bool Equals(object? obj)
    {
        return Equals(obj as ObjectDeclarationTarget);
    }

    public bool Equals(ObjectDeclarationTarget? other)
    {
        return other is not null &&
               TypeName == other.TypeName &&
               Modifier == other.Modifier &&
               NamespaceName == other.NamespaceName &&
               ObjectType == other.ObjectType &&
               NotifyType == other.NotifyType &&
               IsStatic == other.IsStatic &&
               IsSealed == other.IsSealed &&
               IsAbstract == other.IsAbstract;
    }

    public override int GetHashCode()
    {
        int hashCode = -478015754;
        hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(TypeName);
        hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Modifier);
        hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(NamespaceName);
        hashCode = hashCode * -1521134295 + ObjectType.GetHashCode();
        hashCode = hashCode * -1521134295 + NotifyType.GetHashCode();
        hashCode = hashCode * -1521134295 + IsStatic.GetHashCode();
        hashCode = hashCode * -1521134295 + IsSealed.GetHashCode();
        hashCode = hashCode * -1521134295 + IsAbstract.GetHashCode();
        return hashCode;
    }
}