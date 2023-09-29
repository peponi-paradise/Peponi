namespace Peponi.SourceGenerators;

[AttributeUsage(AttributeTargets.Field, AllowMultiple = true, Inherited = false)]
public class RaiseCanExecuteChangedAttribute : Attribute
{
    public string CommandName { get; set; }

    public RaiseCanExecuteChangedAttribute(string commandName)
    {
        CommandName = commandName;
    }
}