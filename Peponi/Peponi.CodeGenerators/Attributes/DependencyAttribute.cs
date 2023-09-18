namespace Peponi.CodeGenerators;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, AllowMultiple = false, Inherited = false)]
public class DependencyAttribute : Attribute
{
    public Type Type { get; set; }
    public string? Name { get; set; }
    public NotifyType NotifyType { get; set; } = NotifyType.None;

    public DependencyAttribute(Type type)
    {
        Type = type;
    }
}