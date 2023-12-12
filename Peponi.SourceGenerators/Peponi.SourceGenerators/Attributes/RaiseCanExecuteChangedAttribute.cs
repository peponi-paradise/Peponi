using Peponi.SourceGenerators.Commands;

namespace Peponi.SourceGenerators;

/// <summary>
/// This is an attribute for raising whether certain command could execute or not<br/>
/// <see cref="PropertyAttribute"/> is required to use this attribute<br/>
/// Generated property will call <see cref="ICommandBase.RaiseCanExecuteChanged"/> at setter
/// <para>
/// <code>
/// // Input
/// [Property]
/// [RaiseCanExecuteChanged("TestCommand")]
/// private bool _testBool = false;
/// </code>
/// <code>
/// // Generated
/// public bool TestBool
/// {
///     get => _testBool;
///     set
///     {
///         if(_testBool != value)
///         {
///             _testBool = value;
///             OnPropertyChanged(nameof(TestBool));
///             OnTestBoolChanged();
///             TestCommand.RaiseCanExecuteChanged();
///         }
///     }
/// }
///
/// partial void OnTestBoolChanged();
/// </code>
/// </para>
/// </summary>
/// <remarks>
/// <see href="주소 넣어야 함"/>
/// </remarks>
[AttributeUsage(AttributeTargets.Field, AllowMultiple = true, Inherited = false)]
public class RaiseCanExecuteChangedAttribute : Attribute
{
    /// <summary>
    /// Command's name that will be raised
    /// </summary>
    public string CommandName { get; set; }

    public RaiseCanExecuteChangedAttribute(string commandName)
    {
        CommandName = commandName;
    }
}