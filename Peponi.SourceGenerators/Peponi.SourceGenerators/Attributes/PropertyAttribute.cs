namespace Peponi.SourceGenerators;

[AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = false)]
public class PropertyAttribute : Attribute
{
    public string? CustomName { get; set; }
    public NotifyType NotifyType { get; set; } = NotifyType.Notify;

    public PropertyAttribute()
    {
    }
}