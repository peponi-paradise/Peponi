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
    public string Name { get; }
    public string? Args { get; set; }

    public PropertyMethodAttribute(string name)
    {
        Name = name;
    }
}