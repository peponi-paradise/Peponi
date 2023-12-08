namespace Peponi.SourceGenerators;

/// <summary>
/// This attribute creates a property using given field as backing field<br/>
/// By default, Notify type is <see cref="NotifyType.Notify"/>
/// <para>
/// <code>
/// // Input
/// [Property]
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
///         }
///     }
/// }
///
/// partial void OnTestBoolChanged();
/// </code>
/// </para>
/// </summary>
/// <remarks>
/// Generated properties use the UpperCamelCase as name format<br/>
/// </remarks>
[AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = false)]
public class PropertyAttribute : Attribute
{
    /// <summary>
    /// Sets the custom name of property
    /// <para>
    /// <code>
    /// // Input
    /// [Property(CustomName = "MyProp")]
    /// private bool _testBool = false;
    /// </code>
    /// <code>
    /// // Generated
    /// public bool MyProp
    /// {
    ///     get => _testBool;
    ///     set
    ///     {
    ///         if(_testBool != value)
    ///         {
    ///             _testBool = value;
    ///             OnPropertyChanged(nameof(MyProp));
    ///             OnMyPropChanged();
    ///         }
    ///     }
    /// }
    ///
    /// partial void OnMyPropChanged();
    /// </code>
    /// </para>
    /// </summary>
    public string? CustomName { get; set; }

    /// <summary>
    /// Sets the property's notification type
    /// <para>
    /// <code>
    /// // Input
    /// [Property(NotifyType = NotifyType.None)]
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
    ///             OnTestBoolChanged();
    ///         }
    ///     }
    /// }
    ///
    /// partial void OnTestBoolChanged();
    /// </code>
    /// </para>
    /// </summary>
    public NotifyType NotifyType { get; set; } = NotifyType.Notify;

    public PropertyAttribute()
    {
    }
}