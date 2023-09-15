#nullable enable

namespace Peponi.CodeGenerators;

public enum PropertyMethodSection
{
    Setter,
    Getter
}

[AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
public class PropertyMethodAttribute : Attribute
{
    public PropertyMethodSection Section { get; set; } = PropertyMethodSection.Setter;
    public string MethodName { get; }
    public string? MethodArgs { get; set; }

    public PropertyMethodAttribute(string methodName)
    {
        MethodName = methodName;
    }
}