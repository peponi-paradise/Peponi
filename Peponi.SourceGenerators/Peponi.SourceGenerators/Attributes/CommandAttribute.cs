using System.Windows.Input;

namespace Peponi.SourceGenerators;

/// <summary>
/// Use this attribute for generating <see cref="ICommand"/> members<br/>
/// Partial type declaration is required for using this attribute<br/>
/// Generated method's name has "Command" suffix
/// <para>
/// Input and generated code looks like followings:
/// <code>
/// // Input
/// public partial class CodeTest
/// {
///    [Command]
///    private void Test()
///    {
///        return;
///    }
/// }
/// </code>
/// <code>
/// // Generated
/// public partial class CodeTest
/// {
///     private CommandBase? _testCommand;
///
///     public ICommandBase TestCommand => _testCommand ??= new CommandBase(Test);
/// }
/// </code>
/// <code>
/// // Input
/// public partial class CodeTest
/// {
///     [Command]
///     private async Task Test()
///     {
///         return;
///     }
/// }
/// </code>
/// <code>
/// // Generated
/// public partial class CodeTest
/// {
///     private CommandBase? _testCommand;
///
///     public ICommandBase TestCommand => _testCommand ??= new CommandBase(async () => { await Test(); });
/// }
/// </code>
/// </para>
/// </summary>
[AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
public class CommandAttribute : Attribute
{
    /// <summary>
    /// Sets the name of command<br/>
    /// Basically, generated backing member's name is target method's name with "Command" suffix
    /// <para>
    /// Input and generated code looks like followings:
    /// <code>
    /// // Input
    /// public partial class CodeTest
    /// {
    ///     [Command(CustomName = "MyCommand")]
    ///     private void Test()
    ///     {
    ///         return;
    ///     }
    /// }
    /// </code>
    /// <code>
    /// // Generated
    /// public partial class CodeTest
    /// {
    ///     private CommandBase? _testCommand;
    ///
    ///     public ICommandBase MyCommand => _testCommand ??= new CommandBase(Test);
    /// }
    /// </code>
    /// </para>
    /// </summary>
    public string? CustomName { get; set; }

    /// <summary>
    /// Sets the name of member that will be invoked to check whether command could executed<br/>
    /// The member have to return <see cref="bool"/> value
    /// <para>
    /// Input and generated code looks like followings:
    /// <code>
    /// // Input
    /// public partial class CodeTest
    /// {
    ///     [Command(CanExecute = ""CanExe"")]
    ///     private void Test()
    ///     {
    ///         return;
    ///     }
    ///
    ///     private bool CanExe()
    ///     {
    ///         return true;
    ///     }
    /// }
    /// </code>
    /// <code>
    /// // Generated
    /// public partial class CodeTest
    /// {
    ///     private CommandBase? _testCommand;
    ///
    ///     public ICommandBase TestCommand => _testCommand ??= new CommandBase(Test, CanExe);
    /// }
    /// </code>
    /// </para>
    /// </summary>
    public string? CanExecute { get; set; }
}