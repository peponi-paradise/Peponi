namespace Peponi.CodeGenerators;

[AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = false)]
public class PropertyAttribute : Attribute
{
    public string? PropertyName { get; set; }
    public NotifyType NotifyType { get; set; } = NotifyType.Notify;

    public PropertyAttribute()
    {
    }
}