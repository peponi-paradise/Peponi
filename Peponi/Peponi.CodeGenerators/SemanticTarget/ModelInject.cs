namespace Peponi.CodeGenerators.SemanticTarget;

internal class ModelInjectTarget : IEquatable<ModelInjectTarget?>
{
    public string TypeName;
    public string TypeModifier;
    public string NamespaceName;
    public bool IsClass;
    public bool IsStatic;
    public bool IsSealed;
    public Type ModelType;
    public NotifyType NotifyType;

    public ModelInjectTarget(string typeName, string typeModifier, string namespaceName, bool isClass, bool isStatic, bool isSealed, Type modelType, NotifyType notifyType)
    {
        TypeName = typeName;
        TypeModifier = typeModifier;
        NamespaceName = namespaceName;
        IsClass = isClass;
        IsStatic = isStatic;
        IsSealed = isSealed;
        ModelType = modelType;
        NotifyType = notifyType;
    }

    public override bool Equals(object? other)
    {
        return Equals(other as ModelInjectTarget);
    }

    public bool Equals(ModelInjectTarget? other)
    {
        return other is not null && TypeName == other.TypeName &&
            TypeModifier == other.TypeModifier && NamespaceName == other.NamespaceName &&
            IsClass == other.IsClass && IsStatic == other.IsStatic && IsSealed == other.IsSealed &&
            ModelType == other.ModelType && NotifyType == other.NotifyType;
    }

    public override int GetHashCode()
    {
        return 3453551 +
             EqualityComparer<string>.Default.GetHashCode(TypeName) +
             EqualityComparer<string>.Default.GetHashCode(TypeModifier) +
             EqualityComparer<string>.Default.GetHashCode(NamespaceName) +
             EqualityComparer<bool>.Default.GetHashCode(IsClass) +
             EqualityComparer<bool>.Default.GetHashCode(IsStatic) +
             EqualityComparer<bool>.Default.GetHashCode(IsSealed) +
             EqualityComparer<Type>.Default.GetHashCode(ModelType) +
             EqualityComparer<NotifyType>.Default.GetHashCode(NotifyType);
    }
}