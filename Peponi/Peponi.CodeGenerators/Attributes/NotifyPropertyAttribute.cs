namespace Peponi.CodeGenerators;

[AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = false)]
public class NotifyPropertyAttribute : Attribute
{
    public string? Name { get; set; }

    public NotifyPropertyAttribute()
    {
    }
}