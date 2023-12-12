using System.ComponentModel;

namespace Peponi.SourceGenerators;

/// <summary>
/// This is an attribute for raising <see cref="INotifyPropertyChanged.PropertyChanged"/> for other property<br/>
/// <see cref="PropertyAttribute"/> is required to use this attribute<br/>
/// Generated property will call <see cref="INotifyPropertyChanged.PropertyChanged"/> at setter
/// <para>
/// <code>
/// // Input
/// [Property]
/// [RaisePropertyChanged("TestParam")]
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
///             OnPropertyChanged(nameof(TestParam));
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
public class RaisePropertyChangedAttribute : Attribute
{
    /// <summary>
    /// Property's name that will be raised
    /// </summary>
    public string PropertyName { get; set; }

    public RaisePropertyChangedAttribute(string propertyName)
    {
        PropertyName = propertyName;
    }
}