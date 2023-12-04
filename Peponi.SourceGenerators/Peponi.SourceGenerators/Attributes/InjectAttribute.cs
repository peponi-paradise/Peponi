namespace Peponi.SourceGenerators;

/// <summary>
/// Use this attribute for injecting members by the selected object<br/>
/// Partial type declaration is required for using this attribute<br/>
/// Using multiple attributes is allowed<br/>
/// Class, record, struct types are supported
/// <para>
/// Input and generated code looks like followings:
/// <code>
/// // Input
/// public class BaseClass
/// {
///     public int TestIng = 0;
///     public bool TestBool = false;
///     public List&lt;string&gt; TestList = new();
/// }
///
/// [Inject(typeof(BaseClass), InjectionType.Dependency)]
/// public partial class CodeTest
/// {
/// }
/// </code>
/// <code>
/// // Generated
/// public partial class CodeTest
/// {
///     public global::GeneratorTest.BaseClass BaseClass;
///
///     public CodeTest(global::GeneratorTest.BaseClass BaseClass)
///     {
///         this.BaseClass = BaseClass;
///     }
/// }
/// </code>
/// </para>
/// </summary>
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, AllowMultiple = true, Inherited = false)]
public class InjectAttribute : Attribute
{
    /// <summary>
    /// Sets the type will be injected<br/>
    /// Class, record, struct types are supported
    /// </summary>
    public Type Type { get; set; }

    /// <summary>
    /// Sets the injecting mode<br/>
    /// Supports -<br/>
    /// <see cref="InjectionType.Dependency"/><br/>
    /// <see cref="InjectionType.Model"/><br/>
    /// <see cref="InjectionType.Dependency"/> | <see cref="InjectionType.Model"/>
    /// <para>
    /// <code>
    /// // Input
    /// public class BaseClass
    /// {
    ///     public int TestInt = 0;
    ///     public bool TestBool = false;
    /// }
    /// [Inject(typeof(BaseClass), InjectionType.Dependency | InjectionType.Model)]
    /// public partial class CodeTest
    /// {
    /// }
    /// </code>
    /// <code>
    /// // Output
    /// public partial class CodeTest
    /// {
    ///     public global::GeneratorTest.BaseClass BaseClass;
    ///
    ///     public int TestInt
    ///     {
    ///         get => BaseClass.TestInt;
    ///         set
    ///         {
    ///             if(BaseClass.TestInt != value)
    ///             {
    ///                 BaseClass.TestInt = value;
    ///                 OnPropertyChanged(nameof(TestInt));
    ///                 OnTestIntChanged();
    ///             }
    ///         }
    ///     }
    ///
    ///     public bool TestBool
    ///     {
    ///         get => BaseClass.TestBool;
    ///         set
    ///         {
    ///             if(BaseClass.TestBool != value)
    ///             {
    ///                 BaseClass.TestBool = value;
    ///                 OnPropertyChanged(nameof(TestBool));
    ///                 OnTestBoolChanged();
    ///             }
    ///         }
    ///     }
    ///
    ///     partial void OnTestIntChanged();
    ///     partial void OnTestBoolChanged();
    ///
    ///     public CodeTest(global::GeneratorTest.BaseClass BaseClass)
    ///     {
    ///         this.BaseClass = BaseClass;
    ///     }
    /// }
    /// </code>
    /// </para>
    /// </summary>
    public InjectionType InjectionMode { get; set; } = InjectionType.Dependency | InjectionType.Model;

    public string? CustomName { get; set; }
    public Modifier TypeModifier { get; set; } = Modifier.Public;
    public NotifyType PropertyNotifyMode { get; set; } = NotifyType.Notify;

    public InjectAttribute(Type type, InjectionType injectionMode)
    {
        Type = type;
        InjectionMode = injectionMode;
    }
}