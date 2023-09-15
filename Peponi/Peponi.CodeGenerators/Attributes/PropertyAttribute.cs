namespace Peponi.CodeGenerators;

[AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = false)]
public class PropertyAttribute : Attribute
{
    public string? Name { get; set; }

    public PropertyAttribute()
    {
    }
}