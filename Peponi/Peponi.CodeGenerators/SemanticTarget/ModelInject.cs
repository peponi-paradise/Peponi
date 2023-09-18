namespace Peponi.CodeGenerators.SemanticTarget;

internal class ModelInjectTarget : IEquatable<ModelInjectTarget?>
{
    public string TypeName;
    public bool IsStatic;
    public NotifyType NotifyType;

    public ModelInjectTarget(string typeName, bool isStatic, NotifyType notifyType)
    {
        TypeName = typeName;
        IsStatic = isStatic;
        NotifyType = notifyType;
    }

    public override bool Equals(object? other)
    {
        return Equals(other as ModelInjectTarget);
    }

    public bool Equals(ModelInjectTarget? other)
    {
        return other is not null && TypeName == other.TypeName &&
            IsStatic == other.IsStatic &&
            NotifyType == other.NotifyType;
    }

    public override int GetHashCode()
    {
        return 3539 +
             EqualityComparer<string>.Default.GetHashCode(TypeName) +
             EqualityComparer<bool>.Default.GetHashCode(IsStatic) +
             EqualityComparer<NotifyType>.Default.GetHashCode(NotifyType);
    }
}