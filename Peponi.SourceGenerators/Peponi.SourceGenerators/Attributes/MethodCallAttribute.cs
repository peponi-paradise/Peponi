namespace Peponi.SourceGenerators;

/// <summary>
/// Inject methods on getter or setter of property<br/>
/// <see cref="PropertyAttribute"/> is required to use this attribute
/// <para>
/// <code>
/// // input
/// public partial class CodeTest
/// {
///     [Property]
///     [MethodCall("MyMethod", Section = PropertySection.Getter, Args = "TestBool, FieldA")]
///     [MethodCall("OtherMethod", Args = "TestBool, FieldB")]
///     private bool _testBool = false;
/// }
/// </code>
/// <code>
/// // Generated
/// public partial class CodeTest
/// {
///     public bool TestBool
///     {
///         get
///         {
///             MyMethod(TestBool, FieldA);
///             return _testBool;
///         }
///         set
///         {
///             if(_testBool != value)
///             {
///                 _testBool = value;
///                 OnPropertyChanged(nameof(TestBool));
///                 OnTestBoolChanged();
///                 OtherMethod(TestBool, FieldB);
///             }
///         }
///     }
///
///     partial void OnTestBoolChanged();
/// }
/// </code>
/// </para>
/// </summary>
/// <remarks>
/// <see href="https://github.com/peponi-paradise/Peponi/tree/Release/Peponi.SourceGenerators"/>
/// </remarks>
[AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
public class MethodCallAttribute : Attribute
{
    /// <summary>
    /// Determine where is method<br/>
    /// <see cref="PropertySection.Setter"/> is default
    /// </summary>
    public PropertySection Section { get; set; } = PropertySection.Setter;

    /// <summary>
    /// Name of method
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// Sets arguments of the method
    /// </summary>
    public string? Args { get; set; }

    public MethodCallAttribute(string name)
    {
        Name = name;
    }
}