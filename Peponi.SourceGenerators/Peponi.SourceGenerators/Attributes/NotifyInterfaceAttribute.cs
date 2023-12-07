using System.ComponentModel;

namespace Peponi.SourceGenerators;

/// <summary>
/// This is an attribute that creating <see cref="INotifyPropertyChanged"/> automatically<br/>
/// Supports <see langword="class"/>, <see langword="record"/>, <see langword="struct"/>
/// <para>
/// <code>
/// // Input
/// [NotifyInterface]
/// public partial class CodeTest
/// {
/// }
/// </code>
/// <code>
/// // Generated
/// public partial class CodeTest : INotifyPropertyChanged
/// {
///     public event PropertyChangedEventHandler? PropertyChanged;
///
///     protected virtual void OnPropertyChanged(PropertyChangedEventArgs e)
///     {
///         PropertyChanged?.Invoke(this, e);
///     }
///
///     protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
///     {
///         OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
///     }
/// }
/// </code>
/// </para>
/// </summary>
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, AllowMultiple = false, Inherited = false)]
public class NotifyInterfaceAttribute : Attribute
{
    public NotifyInterfaceAttribute()
    {
    }
}