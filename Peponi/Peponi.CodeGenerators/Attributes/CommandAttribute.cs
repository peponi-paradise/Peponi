namespace Peponi.CodeGenerators;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
public class CommandAttribute : Attribute
{
    public string? CanExecute { get; set; }
    public string? CommandName { get; set; }
}