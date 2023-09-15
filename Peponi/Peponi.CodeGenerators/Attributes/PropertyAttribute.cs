namespace Peponi.CodeGenerators;

[AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = false)]
public class PropertyAttribute : Attribute
{
    public PropertyAttribute()
    {
    }
}