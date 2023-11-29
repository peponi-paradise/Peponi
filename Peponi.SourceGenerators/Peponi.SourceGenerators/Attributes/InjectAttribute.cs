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