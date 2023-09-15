using Peponi.CodeGenerators.SemanticTarget;

namespace Peponi.CodeGenerators;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, AllowMultiple = false, Inherited = false)]
public class ModelInjectAttribute : Attribute
{
    public Type? ModelType = null;
    public NotifyType PropertyNotifyType = NotifyType.None;

    public ModelInjectAttribute(Type modelType)
    {
        ModelType = modelType;
    }

    public ModelInjectAttribute(Type modelType, NotifyType propertyNotifyType)
    {
        ModelType = modelType;
        PropertyNotifyType = propertyNotifyType;
    }
}