using Microsoft.CodeAnalysis;

namespace Peponi.CodeGenerators.SemanticTarget;

internal class ObjectDeclarationTarget : IEquatable<ObjectDeclarationTarget?>
{
    public string TypeName;
    public string TypeModifier;
    public string NamespaceName;
    public ObjectType ObjectType;
    public NotifyType NotifyType;
    public bool IsStatic;
    public bool IsSealed;
    public bool IsAbstract;

    public ObjectDeclarationTarget(string typeName, string typeModifier, string namespaceName, ObjectType objectType, NotifyType notifyType, bool isStatic, bool isSealed, bool isAbstract)
    {
        TypeName = typeName;
        TypeModifier = typeModifier;
        NamespaceName = namespaceName;
        ObjectType = objectType;
        NotifyType = notifyType;
        IsStatic = isStatic;
        IsSealed = isSealed;
        IsAbstract = isAbstract;
    }

    public override bool Equals(object? other)
    {
        return Equals(other as ObjectDeclarationTarget);
    }

    public bool Equals(ObjectDeclarationTarget? other)
    {
        return other is not null && TypeName == other.TypeName &&
            TypeModifier == other.TypeModifier && NamespaceName == other.NamespaceName &&
            ObjectType == other.ObjectType && NotifyType == other.NotifyType &&
            IsStatic == other.IsStatic && IsSealed == other.IsSealed && IsAbstract == other.IsAbstract;
    }

    public override int GetHashCode()
    {
        return 3453551 +
             EqualityComparer<string>.Default.GetHashCode(TypeName) +
             EqualityComparer<string>.Default.GetHashCode(TypeModifier) +
             EqualityComparer<string>.Default.GetHashCode(NamespaceName) +
             EqualityComparer<ObjectType>.Default.GetHashCode(ObjectType) +
             EqualityComparer<NotifyType>.Default.GetHashCode(NotifyType) +
             EqualityComparer<bool>.Default.GetHashCode(IsStatic) +
             EqualityComparer<bool>.Default.GetHashCode(IsSealed) +
             EqualityComparer<bool>.Default.GetHashCode(IsAbstract);
    }
}