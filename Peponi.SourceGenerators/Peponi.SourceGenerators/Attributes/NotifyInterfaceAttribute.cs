namespace Peponi.SourceGenerators;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, AllowMultiple = false, Inherited = false)]
public class NotifyInterfaceAttribute : Attribute
{
    public NotifyInterfaceAttribute()
    {
    }
}