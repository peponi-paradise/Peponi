namespace Peponi.SourceGenerators;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, AllowMultiple = true, Inherited = false)]
public class InjectAttribute : Attribute
{
    public Type Type { get; set; }
    public string? CustomName { get; set; }
    public Modifier TypeModifier { get; set; } = Modifier.Public;
    public NotifyType PropertyNotifyMode { get; set; } = NotifyType.Notify;
    public InjectionType InjectionMode { get; set; } = InjectionType.Dependency | InjectionType.Model;

    public InjectAttribute(Type type, InjectionType injectionMode)
    {
        Type = type;
        InjectionMode = injectionMode;
    }
}