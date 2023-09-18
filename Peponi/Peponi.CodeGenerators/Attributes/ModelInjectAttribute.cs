namespace Peponi.CodeGenerators;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, AllowMultiple = false, Inherited = false)]
public class ModelInjectAttribute : Attribute
{
    public Type ModelType { get; set; }
    public NotifyType PropertyNotifyType { get; set; } = NotifyType.None;

    public ModelInjectAttribute(Type modelType)
    {
        ModelType = modelType;
    }
}