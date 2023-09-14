namespace Peponi.CodeGenerators.INotifyGenerator;

public enum ObjectType
{
    Class,
    Record,
    Struct
}

internal class ObjectDeclarationTarget : IEquatable<ObjectDeclarationTarget?>
{
    public string TypeName;
    public string TypeModifier;
    public string NamespaceName;
    public ObjectType ObjectType;
    public bool IsStatic;
    public bool IsSealed;

    public ObjectDeclarationTarget(string typeName, string typeModifier, string namespaceName, ObjectType objectType, bool isStatic, bool isSealed)
    {
        TypeName = typeName;
        TypeModifier = typeModifier;
        NamespaceName = namespaceName;
        ObjectType = objectType;
        IsStatic = isStatic;
        IsSealed = isSealed;
    }

    public override bool Equals(object? other)
    {
        return Equals(other as ObjectDeclarationTarget);
    }

    public bool Equals(ObjectDeclarationTarget? other)
    {
        return other is not null && TypeName == other.TypeName &&
            TypeModifier == other.TypeModifier && NamespaceName == other.NamespaceName &&
            ObjectType == other.ObjectType && IsStatic == other.IsStatic && IsSealed == other.IsSealed;
    }

    public override int GetHashCode()
    {
        return 3453551 +
             EqualityComparer<string>.Default.GetHashCode(TypeName) +
             EqualityComparer<string>.Default.GetHashCode(TypeModifier) +
             EqualityComparer<string>.Default.GetHashCode(NamespaceName) +
             EqualityComparer<ObjectType>.Default.GetHashCode(ObjectType) +
             EqualityComparer<bool>.Default.GetHashCode(IsStatic) +
             EqualityComparer<bool>.Default.GetHashCode(IsSealed);
    }
}