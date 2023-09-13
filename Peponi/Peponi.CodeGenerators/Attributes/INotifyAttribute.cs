using System;

namespace Peponi.CodeGenerators;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, AllowMultiple = false, Inherited = false)]
public class INotifyAttribute : Attribute
{
    public INotifyAttribute()
    {
    }
}