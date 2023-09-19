namespace Peponi.CodeGenerators;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, AllowMultiple = true, Inherited = false)]
public class InjectDependencyAttribute : Attribute
{
    public Type Type { get; set; }
    public string? Name { get; set; }
    public Modifier Modifier { get; set; } = Modifier.Public;

    public InjectDependencyAttribute(Type type)
    {
        Type = type;
    }
}