using TestNamespace;

namespace Peponi.SourceGenerators.Tests.InjectGenerator;

#nullable disable

//[NotifyInterface]
//[Inject(typeof(MyModel), InjectionType.Dependency | InjectionType.Model)]
//[Inject(typeof(MyStruct), InjectionType.Dependency | InjectionType.Model, CustomName = "TestStr")]
//[Inject(typeof(TestStaticModel), InjectionType.Dependency | InjectionType.Model, CustomName = "asdasdasdasd", PropertyNotifyMode = NotifyType.None)]
//public partial class TestClass
//{
//    [Property]
//    private int? AAAa = 0;

//    private void Testsdasd()
//    {
//        AAAA = 1;
//        Console.WriteLine(AAAA);
//    }
//}