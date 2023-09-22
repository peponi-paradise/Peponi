namespace Peponi.CodeGenerators;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
public class CommandAttribute : Attribute
{
    public string? CustomName { get; set; }
    public string? CanExecute { get; set; }
    public string? CanExecuteArgument { get; set; }
}