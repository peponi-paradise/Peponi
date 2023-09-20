namespace Peponi.CodeGenerators;

[AttributeUsage(AttributeTargets.Field, AllowMultiple = true, Inherited = false)]
public class RaisePropertyChangedAttribute : Attribute
{
    public string PropertyName { get; set; }

    public RaisePropertyChangedAttribute(string propertyName)
    {
        PropertyName = propertyName;
    }
}