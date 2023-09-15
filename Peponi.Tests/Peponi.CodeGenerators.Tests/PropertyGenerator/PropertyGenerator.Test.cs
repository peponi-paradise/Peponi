namespace Peponi.CodeGenerators.Tests.PropertyGenerator;

[TestClass]
public class Property
{
    [TestMethod]
    public void SimpleCodeGenTest()
    {
        Assert.IsTrue(PropertyCompare.CompareCode(
@"using Peponi.CodeGenerators;

namespace CodeGeneratorTest;

public partial class CodeTest
{
    [Property]
    private bool _testBool = false;
}",
@"// Auto generated code by Peponi.CodeGenerators
// Github : https://github.com/peponi-paradise/Peponi
// Blog : https://peponi-paradise.tistory.com

#nullable enable

namespace CodeGeneratorTest
{
    public partial class CodeTest
    {
        public bool TestBool
        {
            get => _testBool;
            set
            {
                if(_testBool != value)
                {
                    _testBool = value;
                    OnTestBoolChanged();
                }
            }
        }

        partial void OnTestBoolChanged();
    }
}"));
    }

    [TestMethod]
    public void CodeGenTest()
    {
        Assert.IsTrue(PropertyCompare.CompareCode(
@"using Peponi.CodeGenerators;

namespace CodeGeneratorTest;

public sealed partial record CodeTest
{
    [Property]
    private bool _testBool = false;

    [NotifyProperty]
    private int? testInt = 0;

    [NotifyProperty]
    private readonly double TestDouble = 1.2;
}",
@"// Auto generated code by Peponi.CodeGenerators
// Github : https://github.com/peponi-paradise/Peponi
// Blog : https://peponi-paradise.tistory.com

#nullable enable

namespace CodeGeneratorTest
{
    public sealed partial record CodeTest
    {
        public bool TestBool
        {
            get => _testBool;
            set
            {
                if(_testBool != value)
                {
                    _testBool = value;
                    OnTestBoolChanged();
                }
            }
        }

        public int? TestInt
        {
            get => testInt;
            set
            {
                if(testInt != value)
                {
                    testInt = value;
                    OnPropertyChanged(nameof(TestInt));
                    OnTestIntChanged();
                }
            }
        }

        public double TESTDOUBLE
        {
            get => TestDouble;
        }

        partial void OnTestBoolChanged();
        partial void OnTestIntChanged();
    }
}"));
    }

    [TestMethod]
    public void CodeGenTestWithPropertyMethod()
    {
        Assert.IsTrue(PropertyCompare.CompareCode(
@"using Peponi.CodeGenerators;

namespace CodeGeneratorTest;

public partial class CodeTest
{
    [PropertyMethod(""MyMethod"", Section = PropertyMethodSection.Getter, MethodArgs = ""Args1,Args2"")]
    [PropertyMethod(""MyMethod2"")]
    [Property(Name = ""Test"")]
    private bool _testBool = false;
}",
@"// Auto generated code by Peponi.CodeGenerators
// Github : https://github.com/peponi-paradise/Peponi
// Blog : https://peponi-paradise.tistory.com

#nullable enable

namespace CodeGeneratorTest
{
    public partial class CodeTest
    {
        public bool Test
        {
            get
            {
                MyMethod(Args1,Args2);
                return _testBool;
            }
            set
            {
                if(_testBool != value)
                {
                    _testBool = value;
                    OnTestChanged();
                    MyMethod2();
                }
            }
        }

        partial void OnTestChanged();
    }
}"));
    }
}