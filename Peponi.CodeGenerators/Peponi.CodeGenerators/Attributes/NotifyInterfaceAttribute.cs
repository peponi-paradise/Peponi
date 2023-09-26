namespace Peponi.CodeGenerators;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, AllowMultiple = false, Inherited = false)]
public class NotifyInterfaceAttribute : Attribute
{
    public NotifyInterfaceAttribute()
    {
    }
}