namespace Peponi.SourceGenerators.Tests.PropertyGenerator;

[TestClass]
public class PropertyTest
{
    [TestMethod]
    public void PropertyBase()
    {
        Assert.IsTrue(PropertyCompare.CompareCode(
@"using Peponi.SourceGenerators;

namespace GeneratorTest;

public partial class CodeTest
{
    [Property]
    private bool _testBool = false;
}",
@"// Auto generated code by Peponi.SourceGenerators
// Github : https://github.com/peponi-paradise/Peponi
// Blog : https://peponi-paradise.tistory.com

#nullable enable

namespace GeneratorTest
{
    public partial class CodeTest
    {
        /// <summary>
        /// Auto generated property by Peponi.SourceGenerators
        /// </summary>
        public bool TestBool
        {
            get => _testBool;
            set
            {
                if(_testBool != value)
                {
                    _testBool = value;
                    OnPropertyChanged(nameof(TestBool));
                    OnTestBoolChanged();
                }
            }
        }

        /// <summary>
        /// Auto generated method by Peponi.SourceGenerators
        /// </summary>
        partial void OnTestBoolChanged();
    }
}"));
    }

    [TestMethod]
    public void PropertyWithCustomName()
    {
        Assert.IsTrue(PropertyCompare.CompareCode(
@"using Peponi.SourceGenerators;

namespace GeneratorTest;

public partial class CodeTest
{
    [Property(CustomName = ""MyProp"")]
    private bool _testBool = false;
}",
@"// Auto generated code by Peponi.SourceGenerators
// Github : https://github.com/peponi-paradise/Peponi
// Blog : https://peponi-paradise.tistory.com

#nullable enable

namespace GeneratorTest
{
    public partial class CodeTest
    {
        /// <summary>
        /// Auto generated property by Peponi.SourceGenerators
        /// </summary>
        public bool MyProp
        {
            get => _testBool;
            set
            {
                if(_testBool != value)
                {
                    _testBool = value;
                    OnPropertyChanged(nameof(MyProp));
                    OnMyPropChanged();
                }
            }
        }

        /// <summary>
        /// Auto generated method by Peponi.SourceGenerators
        /// </summary>
        partial void OnMyPropChanged();
    }
}"));
    }

    [TestMethod]
    public void PropertyWithoutNotify()
    {
        Assert.IsTrue(PropertyCompare.CompareCode(
@"using Peponi.SourceGenerators;

namespace GeneratorTest;

public partial class CodeTest
{
    [Property(NotifyType = NotifyType.None)]
    private bool _testBool = false;
}",
@"// Auto generated code by Peponi.SourceGenerators
// Github : https://github.com/peponi-paradise/Peponi
// Blog : https://peponi-paradise.tistory.com

#nullable enable

namespace GeneratorTest
{
    public partial class CodeTest
    {
        /// <summary>
        /// Auto generated property by Peponi.SourceGenerators
        /// </summary>
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

        /// <summary>
        /// Auto generated method by Peponi.SourceGenerators
        /// </summary>
        partial void OnTestBoolChanged();
    }
}"));
    }

    [TestMethod]
    public void PropertyWithCustomNameAndWithoutNotify()
    {
        Assert.IsTrue(PropertyCompare.CompareCode(
@"using Peponi.SourceGenerators;

namespace GeneratorTest;

public partial class CodeTest
{
    [Property(CustomName = ""MyProp"", NotifyType = NotifyType.None)]
    private bool _testBool = false;
}",
@"// Auto generated code by Peponi.SourceGenerators
// Github : https://github.com/peponi-paradise/Peponi
// Blog : https://peponi-paradise.tistory.com

#nullable enable

namespace GeneratorTest
{
    public partial class CodeTest
    {
        /// <summary>
        /// Auto generated property by Peponi.SourceGenerators
        /// </summary>
        public bool MyProp
        {
            get => _testBool;
            set
            {
                if(_testBool != value)
                {
                    _testBool = value;
                    OnMyPropChanged();
                }
            }
        }

        /// <summary>
        /// Auto generated method by Peponi.SourceGenerators
        /// </summary>
        partial void OnMyPropChanged();
    }
}"));
    }

    [TestMethod]
    public void PropertyTotalTest()
    {
        Assert.IsTrue(PropertyCompare.CompareCode(
@"using Peponi.SourceGenerators;

namespace GeneratorTest;

public partial class CodeTest
{
    [Property(CustomName = ""MyProp"", NotifyType = NotifyType.None)]
    [MethodCall(""MyMethod"", Section = PropertySection.Getter, Args = ""TestBool, FieldA"")]
    [MethodCall(""OtherMethod"", Args = ""TestBool, FieldB"")]
    [RaiseCanExecuteChanged(""TestCommand"")]
    [RaisePropertyChanged(""TestParam"")]
    private bool _testBool = false;
}",
@"// Auto generated code by Peponi.SourceGenerators
// Github : https://github.com/peponi-paradise/Peponi
// Blog : https://peponi-paradise.tistory.com

#nullable enable

namespace GeneratorTest
{
    public partial class CodeTest
    {
        /// <summary>
        /// Auto generated property by Peponi.SourceGenerators
        /// </summary>
        public bool MyProp
        {
            get
            {
                MyMethod(TestBool, FieldA);
                return _testBool;
            }
            set
            {
                if(_testBool != value)
                {
                    _testBool = value;
                    OnMyPropChanged();
                    OtherMethod(TestBool, FieldB);
                    TestCommand.RaiseCanExecuteChanged();
                    OnPropertyChanged(nameof(TestParam));
                }
            }
        }

        /// <summary>
        /// Auto generated method by Peponi.SourceGenerators
        /// </summary>
        partial void OnMyPropChanged();
    }
}"));
    }
}