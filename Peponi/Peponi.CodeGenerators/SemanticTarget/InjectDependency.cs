namespace Peponi.CodeGenerators.SemanticTarget;

internal class InjectDependencyTarget : IEquatable<InjectDependencyTarget?>
{
    public string NamespaceName;
    public string TypeName;
    public string CustomName;
    public Modifier Modifier;

    public InjectDependencyTarget(string namespaceName, string typeName, string customName, Modifier modifier)
    {
        NamespaceName = namespaceName;
        TypeName = typeName;
        CustomName = customName;
        Modifier = modifier;
    }

    public override bool Equals(object? other)
    {
        return Equals(other as InjectDependencyTarget);
    }

    public bool Equals(InjectDependencyTarget? other)
    {
        return other is not null && NamespaceName == other.NamespaceName &&
            TypeName == other.TypeName && CustomName == other.CustomName &&
            Modifier == other.Modifier;
    }

    public override int GetHashCode()
    {
        return 5003 +
                EqualityComparer<string>.Default.GetHashCode(NamespaceName) +
                EqualityComparer<string>.Default.GetHashCode(TypeName) +
                EqualityComparer<string>.Default.GetHashCode(CustomName) +
                EqualityComparer<Modifier>.Default.GetHashCode(Modifier);
    }
}