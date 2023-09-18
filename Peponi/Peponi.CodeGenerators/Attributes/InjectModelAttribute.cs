namespace Peponi.CodeGenerators;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, AllowMultiple = true, Inherited = false)]
public class InjectModelAttribute : Attribute
{
    public Type ModelType { get; set; }
    public string? ModelName { get; set; }
    public NotifyType PropertyNotifyType { get; set; } = NotifyType.None;

    public InjectModelAttribute(Type modelType)
    {
        ModelType = modelType;
    }
}