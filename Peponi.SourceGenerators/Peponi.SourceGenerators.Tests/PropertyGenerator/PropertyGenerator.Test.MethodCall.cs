namespace Peponi.SourceGenerators.Tests.PropertyGenerator;

[TestClass]
public class PropertyTestMethodCall
{
    [TestMethod]
    public void PropertyWithMethodCallSetter()
    {
        Assert.IsTrue(PropertyCompare.CompareCode(
@"using Peponi.SourceGenerators;

namespace GeneratorTest;

public partial class CodeTest
{
    [Property]
    [MethodCall(""MyMethod"")]
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
            get
            {
                return _testBool;
            }
            set
            {
                if(_testBool != value)
                {
                    _testBool = value;
                    OnPropertyChanged(nameof(TestBool));
                    OnTestBoolChanged();
                    MyMethod();
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
    public void PropertyWithMethodCallGetter()
    {
        Assert.IsTrue(PropertyCompare.CompareCode(
@"using Peponi.SourceGenerators;

namespace GeneratorTest;

public partial class CodeTest
{
    [Property]
    [MethodCall(""MyMethod"", Section = PropertySection.Getter)]
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
            get
            {
                MyMethod();
                return _testBool;
            }
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
    public void PropertyWithMethodCallWithArgs()
    {
        Assert.IsTrue(PropertyCompare.CompareCode(
@"using Peponi.SourceGenerators;

namespace GeneratorTest;

public partial class CodeTest
{
    [Property]
    [MethodCall(""MyMethod"", Args = ""TestBool, FieldA"")]
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
            get
            {
                return _testBool;
            }
            set
            {
                if(_testBool != value)
                {
                    _testBool = value;
                    OnPropertyChanged(nameof(TestBool));
                    OnTestBoolChanged();
                    MyMethod(TestBool, FieldA);
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
    public void PropertyWithMultiMethodCallSetter()
    {
        Assert.IsTrue(PropertyCompare.CompareCode(
@"using Peponi.SourceGenerators;

namespace GeneratorTest;

public partial class CodeTest
{
    [Property]
    [MethodCall(""MyMethod"")]
    [MethodCall(""OtherMethod"")]
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
            get
            {
                return _testBool;
            }
            set
            {
                if(_testBool != value)
                {
                    _testBool = value;
                    OnPropertyChanged(nameof(TestBool));
                    OnTestBoolChanged();
                    MyMethod();
                    OtherMethod();
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
    public void PropertyWithMultiMethodCallGetter()
    {
        Assert.IsTrue(PropertyCompare.CompareCode(
@"using Peponi.SourceGenerators;

namespace GeneratorTest;

public partial class CodeTest
{
    [Property]
    [MethodCall(""MyMethod"", Section = PropertySection.Getter)]
    [MethodCall(""OtherMethod"", Section = PropertySection.Getter)]
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
            get
            {
                MyMethod();
                OtherMethod();
                return _testBool;
            }
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
    public void PropertyWithMultiMethodCallComplex()
    {
        Assert.IsTrue(PropertyCompare.CompareCode(
@"using Peponi.SourceGenerators;

namespace GeneratorTest;

public partial class CodeTest
{
    [Property]
    [MethodCall(""MyMethod"", Section = PropertySection.Getter)]
    [MethodCall(""OtherMethod"")]
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
            get
            {
                MyMethod();
                return _testBool;
            }
            set
            {
                if(_testBool != value)
                {
                    _testBool = value;
                    OnPropertyChanged(nameof(TestBool));
                    OnTestBoolChanged();
                    OtherMethod();
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
    public void PropertyWithMultiMethodCallComplexWithArgs()
    {
        Assert.IsTrue(PropertyCompare.CompareCode(
@"using Peponi.SourceGenerators;

namespace GeneratorTest;

public partial class CodeTest
{
    [Property]
    [MethodCall(""MyMethod"", Section = PropertySection.Getter, Args = ""TestBool, FieldA"")]
    [MethodCall(""OtherMethod"", Args = ""TestBool, FieldB"")]
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
                    OnPropertyChanged(nameof(TestBool));
                    OnTestBoolChanged();
                    OtherMethod(TestBool, FieldB);
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
}