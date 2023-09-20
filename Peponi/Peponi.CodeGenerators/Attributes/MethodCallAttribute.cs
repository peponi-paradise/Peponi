namespace Peponi.CodeGenerators;

[AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
public class MethodCallAttribute : Attribute
{
    public PropertyMethodSection Section { get; set; } = PropertyMethodSection.Setter;
    public string Name { get; }
    public string? Args { get; set; }

    public MethodCallAttribute(string name)
    {
        Name = name;
    }
}