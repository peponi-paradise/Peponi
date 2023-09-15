namespace Peponi.CodeGenerators;

[AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = false)]
public class NotifyPropertyAttribute : Attribute
{
    public NotifyPropertyAttribute()
    {
    }
}