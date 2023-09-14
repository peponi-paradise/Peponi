using Peponi.CodeGenerators.PropertyGenerator;

namespace Peponi.CodeGenerators;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, AllowMultiple = false, Inherited = false)]
public class ModelInjectAttribute : Attribute
{
    public Type? ModelType = null;
    public PropertyType InjectType = PropertyType.Property;

    public ModelInjectAttribute(Type modelType)
    {
        ModelType = modelType;
    }

    public ModelInjectAttribute(Type modelType, PropertyType injectType)
    {
        ModelType = modelType;
        InjectType = injectType;
    }
}