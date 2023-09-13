namespace Peponi.CodeGenerators.INotifyGenerator;

internal class INotifyTarget : IEquatable<INotifyTarget?>
{
    public string TypeName;
    public string TypeModifier;
    public bool IsStatic;
    public string NamespaceName;
    public bool IsClass;

    public INotifyTarget(string typeName, string typeModifier, bool isStatic, string namespaceName, bool isClass)
    {
        TypeName = typeName;
        TypeModifier = typeModifier;
        IsStatic = isStatic;
        NamespaceName = namespaceName;
        IsClass = isClass;
    }

    public override bool Equals(object? other)
    {
        return Equals(other as INotifyTarget);
    }

    public bool Equals(INotifyTarget? other)
    {
        return other is not null && TypeName == other.TypeName &&
            TypeModifier == other.TypeModifier && IsStatic == other.IsStatic &&
            NamespaceName == other.NamespaceName && IsClass == other.IsClass;
    }

    public override int GetHashCode()
    {
        return 3453551 +
            EqualityComparer<string>.Default.GetHashCode(TypeName) +
             EqualityComparer<string>.Default.GetHashCode(TypeModifier) +
             EqualityComparer<bool>.Default.GetHashCode(IsStatic) +
             EqualityComparer<string>.Default.GetHashCode(NamespaceName) +
             EqualityComparer<bool>.Default.GetHashCode(IsClass);
    }
}