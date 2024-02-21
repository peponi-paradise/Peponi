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
/// <remarks>
/// <see href="https://github.com/peponi-paradise/Peponi/tree/Release/Peponi.SourceGenerators"/>
/// </remarks>
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
    /// // Generated
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

    /// <summary>
    /// Sets the name of injecting target<br/>
    /// Basically, generated member's name is same as injecting target
    /// <para>
    /// <code>
    /// // Input
    /// public class BaseClass
    /// {
    ///     public int TestInt = 0;
    ///     public bool TestBool = false;
    /// }
    ///
    /// [Inject(typeof(BaseClass), InjectionType.Dependency, CustomName = "InjectClass")]
    /// public partial class CodeTest
    /// {
    /// }
    /// </code>
    /// <code>
    /// // Generated
    /// public partial class CodeTest
    /// {
    ///     public global::GeneratorTest.BaseClass InjectClass;
    ///
    ///     public CodeTest(global::GeneratorTest.BaseClass InjectClass)
    ///     {
    ///         this.InjectClass = InjectClass;
    ///     }
    /// }
    /// </code>
    /// </para>
    /// </summary>
    public string? CustomName { get; set; }

    /// <summary>
    /// Sets the modifier of injecting target<br/>
    /// <para>
    /// <code>
    /// // Input
    /// public class BaseClass
    /// {
    ///     public int TestInt = 0;
    ///     public bool TestBool = false;
    /// }
    ///
    /// [Inject(typeof(BaseClass), InjectionType.Dependency, Modifier = Modifier.Protected)]
    /// public partial class CodeTest
    /// {
    /// }
    /// </code>
    /// <code>
    /// // Generated
    /// public partial class CodeTest
    /// {
    ///     protected global::GeneratorTest.BaseClass _baseClass;
    ///
    ///     public CodeTest(global::GeneratorTest.BaseClass _baseClass)
    ///     {
    ///         this._baseClass = _baseClass;
    ///     }
    /// }
    /// </code>
    /// </para>
    /// </summary>
    public Modifier Modifier { get; set; } = Modifier.Public;

    /// <summary>
    /// Sets the notify mode of injected target's member<br/>
    /// This is valid for <see cref="InjectionType.Model"/>
    /// <para>
    /// <code>
    /// // Input
    /// public class BaseClass
    /// {
    ///     public int TestInt = 0;
    ///     public bool TestBool = false;
    /// }
    ///
    /// [Inject(typeof(BaseClass), InjectionType.Model, PropertyNotifyMode = NotifyType.None)]
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
    ///     public int TestInt
    ///     {
    ///         get => BaseClass.TestInt;
    ///         set
    ///         {
    ///             if(BaseClass.TestInt != value)
    ///             {
    ///                 BaseClass.TestInt = value;
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
    ///                 OnTestBoolChanged();
    ///             }
    ///         }
    ///     }
    ///
    ///     partial void OnTestIntChanged();
    ///     partial void OnTestBoolChanged();
    /// }
    /// </code>
    /// </para>
    /// </summary>
    public NotifyType PropertyNotifyMode { get; set; } = NotifyType.Notify;

    public InjectAttribute(Type type, InjectionType injectionMode)
    {
        Type = type;
        InjectionMode = injectionMode;
    }
}