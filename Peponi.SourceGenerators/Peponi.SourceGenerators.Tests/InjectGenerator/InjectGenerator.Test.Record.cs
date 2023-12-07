namespace Peponi.SourceGenerators.Tests.InjectGenerator;

#nullable disable

[TestClass]
public class InjectTestRecord
{
    [TestMethod]
    public void RecordWithDependency()
    {
        Assert.IsTrue(InjectCompare.CompareCode(
@"using Peponi.SourceGenerators;

namespace GeneratorTest;

public class BaseClass
{
    public int TestInt = 0;
    public bool TestBool = false;
    public List<string> TestList = new();
}

[Inject(typeof(BaseClass), InjectionType.Dependency)]
public partial record CodeTest
{
}",
@"// Auto generated code by Peponi.SourceGenerators
// Github : https://github.com/peponi-paradise/Peponi
// Blog : https://peponi-paradise.tistory.com

#nullable disable

namespace GeneratorTest
{
    public partial record CodeTest
    {
        /// <summary>
        /// Auto generated member by Peponi.SourceGenerators
        /// </summary>
        public global::GeneratorTest.BaseClass BaseClass;

        /// <summary>
        /// Auto generated method by Peponi.SourceGenerators
        /// </summary>
        public CodeTest(global::GeneratorTest.BaseClass BaseClass)
        {
            this.BaseClass = BaseClass;
        }
    }
}"));
    }

    [TestMethod]
    public void RecordWithModel()
    {
        Assert.IsTrue(InjectCompare.CompareCode(
@"using Peponi.SourceGenerators;

namespace GeneratorTest;

public class BaseClass
{
    public int TestInt = 0;
    public bool TestBool = false;
    public List<string> TestList = new();
}

[Inject(typeof(BaseClass), InjectionType.Model)]
public partial record CodeTest
{
}",
@"// Auto generated code by Peponi.SourceGenerators
// Github : https://github.com/peponi-paradise/Peponi
// Blog : https://peponi-paradise.tistory.com

#nullable disable

namespace GeneratorTest
{
    public partial record CodeTest
    {
        /// <summary>
        /// Auto generated member by Peponi.SourceGenerators
        /// </summary>
        public global::GeneratorTest.BaseClass BaseClass;

        /// <summary>
        /// Auto generated property by Peponi.SourceGenerators
        /// </summary>
        public int TestInt
        {
            get => BaseClass.TestInt;
            set
            {
                if(BaseClass.TestInt != value)
                {
                    BaseClass.TestInt = value;
                    OnPropertyChanged(nameof(TestInt));
                    OnTestIntChanged();
                }
            }
        }

        /// <summary>
        /// Auto generated property by Peponi.SourceGenerators
        /// </summary>
        public bool TestBool
        {
            get => BaseClass.TestBool;
            set
            {
                if(BaseClass.TestBool != value)
                {
                    BaseClass.TestBool = value;
                    OnPropertyChanged(nameof(TestBool));
                    OnTestBoolChanged();
                }
            }
        }

        /// <summary>
        /// Auto generated property by Peponi.SourceGenerators
        /// </summary>
        public List<string> TestList
        {
            get => BaseClass.TestList;
            set
            {
                if(BaseClass.TestList != value)
                {
                    BaseClass.TestList = value;
                    OnPropertyChanged(nameof(TestList));
                    OnTestListChanged();
                }
            }
        }

        /// <summary>
        /// Auto generated method by Peponi.SourceGenerators
        /// </summary>
        partial void OnTestIntChanged();

        /// <summary>
        /// Auto generated method by Peponi.SourceGenerators
        /// </summary>
        partial void OnTestBoolChanged();

        /// <summary>
        /// Auto generated method by Peponi.SourceGenerators
        /// </summary>
        partial void OnTestListChanged();
    }
}"));
    }

    [TestMethod]
    public void RecordWithDependencyAndModel()
    {
        Assert.IsTrue(InjectCompare.CompareCode(
@"using Peponi.SourceGenerators;

namespace GeneratorTest;

public class BaseClass
{
    public int TestInt = 0;
    public bool TestBool = false;
    public List<string> TestList = new();
}

[Inject(typeof(BaseClass), InjectionType.Dependency | InjectionType.Model)]
public partial record CodeTest
{
}",
@"// Auto generated code by Peponi.SourceGenerators
// Github : https://github.com/peponi-paradise/Peponi
// Blog : https://peponi-paradise.tistory.com

#nullable disable

namespace GeneratorTest
{
    public partial record CodeTest
    {
        /// <summary>
        /// Auto generated member by Peponi.SourceGenerators
        /// </summary>
        public global::GeneratorTest.BaseClass BaseClass;

        /// <summary>
        /// Auto generated property by Peponi.SourceGenerators
        /// </summary>
        public int TestInt
        {
            get => BaseClass.TestInt;
            set
            {
                if(BaseClass.TestInt != value)
                {
                    BaseClass.TestInt = value;
                    OnPropertyChanged(nameof(TestInt));
                    OnTestIntChanged();
                }
            }
        }

        /// <summary>
        /// Auto generated property by Peponi.SourceGenerators
        /// </summary>
        public bool TestBool
        {
            get => BaseClass.TestBool;
            set
            {
                if(BaseClass.TestBool != value)
                {
                    BaseClass.TestBool = value;
                    OnPropertyChanged(nameof(TestBool));
                    OnTestBoolChanged();
                }
            }
        }

        /// <summary>
        /// Auto generated property by Peponi.SourceGenerators
        /// </summary>
        public List<string> TestList
        {
            get => BaseClass.TestList;
            set
            {
                if(BaseClass.TestList != value)
                {
                    BaseClass.TestList = value;
                    OnPropertyChanged(nameof(TestList));
                    OnTestListChanged();
                }
            }
        }

        /// <summary>
        /// Auto generated method by Peponi.SourceGenerators
        /// </summary>
        partial void OnTestIntChanged();

        /// <summary>
        /// Auto generated method by Peponi.SourceGenerators
        /// </summary>
        partial void OnTestBoolChanged();

        /// <summary>
        /// Auto generated method by Peponi.SourceGenerators
        /// </summary>
        partial void OnTestListChanged();

        /// <summary>
        /// Auto generated method by Peponi.SourceGenerators
        /// </summary>
        public CodeTest(global::GeneratorTest.BaseClass BaseClass)
        {
            this.BaseClass = BaseClass;
        }
    }
}"));
    }

    [TestMethod]
    public void RecordWithCustomName()
    {
        Assert.IsTrue(InjectCompare.CompareCode(
@"using Peponi.SourceGenerators;

namespace GeneratorTest;

public class BaseClass
{
    public int TestInt = 0;
    public bool TestBool = false;
    public List<string> TestList = new();
}

[Inject(typeof(BaseClass), InjectionType.Dependency, CustomName = ""InjectClass"")]
public partial record CodeTest
{
}",
@"// Auto generated code by Peponi.SourceGenerators
// Github : https://github.com/peponi-paradise/Peponi
// Blog : https://peponi-paradise.tistory.com

#nullable disable

namespace GeneratorTest
{
    public partial record CodeTest
    {
        /// <summary>
        /// Auto generated member by Peponi.SourceGenerators
        /// </summary>
        public global::GeneratorTest.BaseClass InjectClass;

        /// <summary>
        /// Auto generated method by Peponi.SourceGenerators
        /// </summary>
        public CodeTest(global::GeneratorTest.BaseClass InjectClass)
        {
            this.InjectClass = InjectClass;
        }
    }
}"));
    }

    [TestMethod]
    public void RecordWithModifier()
    {
        Assert.IsTrue(InjectCompare.CompareCode(
@"using Peponi.SourceGenerators;

namespace GeneratorTest;

public class BaseClass
{
    public int TestInt = 0;
    public bool TestBool = false;
    public List<string> TestList = new();
}

[Inject(typeof(BaseClass), InjectionType.Dependency, Modifier = Modifier.Protected)]
public partial record CodeTest
{
}",
@"// Auto generated code by Peponi.SourceGenerators
// Github : https://github.com/peponi-paradise/Peponi
// Blog : https://peponi-paradise.tistory.com

#nullable disable

namespace GeneratorTest
{
    public partial record CodeTest
    {
        /// <summary>
        /// Auto generated member by Peponi.SourceGenerators
        /// </summary>
        protected global::GeneratorTest.BaseClass _baseClass;

        /// <summary>
        /// Auto generated method by Peponi.SourceGenerators
        /// </summary>
        public CodeTest(global::GeneratorTest.BaseClass _baseClass)
        {
            this._baseClass = _baseClass;
        }
    }
}"));
    }

    [TestMethod]
    public void RecordWithModelWithNotifyNone()
    {
        Assert.IsTrue(InjectCompare.CompareCode(
@"using Peponi.SourceGenerators;

namespace GeneratorTest;

public class BaseClass
{
    public int TestInt = 0;
    public bool TestBool = false;
    public List<string> TestList = new();
}

[Inject(typeof(BaseClass), InjectionType.Model, PropertyNotifyMode = NotifyType.None)]
public partial record CodeTest
{
}",
@"// Auto generated code by Peponi.SourceGenerators
// Github : https://github.com/peponi-paradise/Peponi
// Blog : https://peponi-paradise.tistory.com

#nullable disable

namespace GeneratorTest
{
    public partial record CodeTest
    {
        /// <summary>
        /// Auto generated member by Peponi.SourceGenerators
        /// </summary>
        public global::GeneratorTest.BaseClass BaseClass;

        /// <summary>
        /// Auto generated property by Peponi.SourceGenerators
        /// </summary>
        public int TestInt
        {
            get => BaseClass.TestInt;
            set
            {
                if(BaseClass.TestInt != value)
                {
                    BaseClass.TestInt = value;
                    OnTestIntChanged();
                }
            }
        }

        /// <summary>
        /// Auto generated property by Peponi.SourceGenerators
        /// </summary>
        public bool TestBool
        {
            get => BaseClass.TestBool;
            set
            {
                if(BaseClass.TestBool != value)
                {
                    BaseClass.TestBool = value;
                    OnTestBoolChanged();
                }
            }
        }

        /// <summary>
        /// Auto generated property by Peponi.SourceGenerators
        /// </summary>
        public List<string> TestList
        {
            get => BaseClass.TestList;
            set
            {
                if(BaseClass.TestList != value)
                {
                    BaseClass.TestList = value;
                    OnTestListChanged();
                }
            }
        }

        /// <summary>
        /// Auto generated method by Peponi.SourceGenerators
        /// </summary>
        partial void OnTestIntChanged();

        /// <summary>
        /// Auto generated method by Peponi.SourceGenerators
        /// </summary>
        partial void OnTestBoolChanged();

        /// <summary>
        /// Auto generated method by Peponi.SourceGenerators
        /// </summary>
        partial void OnTestListChanged();
    }
}"));
    }

    [TestMethod]
    public void RecordWithMultiDependency()
    {
        Assert.IsTrue(InjectCompare.CompareCode(
@"using Peponi.SourceGenerators;

namespace GeneratorTest;

public class BaseClassA
{
    public int TestInt = 0;
    public bool TestBool = false;
    public List<string> TestList = new();
}

public class BaseClassB
{
    public float TestFloat = 0;
    public string TestString = string.Empty;
    public Dictionary<string, string> TestDic = new();
}

[Inject(typeof(BaseClassA), InjectionType.Dependency)]
[Inject(typeof(BaseClassB), InjectionType.Dependency)]
public partial record CodeTest
{
}",
@"// Auto generated code by Peponi.SourceGenerators
// Github : https://github.com/peponi-paradise/Peponi
// Blog : https://peponi-paradise.tistory.com

#nullable disable

namespace GeneratorTest
{
    public partial record CodeTest
    {
        /// <summary>
        /// Auto generated member by Peponi.SourceGenerators
        /// </summary>
        public global::GeneratorTest.BaseClassA BaseClassA;

        /// <summary>
        /// Auto generated member by Peponi.SourceGenerators
        /// </summary>
        public global::GeneratorTest.BaseClassB BaseClassB;

        /// <summary>
        /// Auto generated method by Peponi.SourceGenerators
        /// </summary>
        public CodeTest(global::GeneratorTest.BaseClassA BaseClassA, global::GeneratorTest.BaseClassB BaseClassB)
        {
            this.BaseClassA = BaseClassA;
            this.BaseClassB = BaseClassB;
        }
    }
}"));
    }

    [TestMethod]
    public void RecordWithMultiModel()
    {
        Assert.IsTrue(InjectCompare.CompareCode(
@"using Peponi.SourceGenerators;

namespace GeneratorTest;

public class BaseClassA
{
    public int TestInt = 0;
    public bool TestBool = false;
    public List<string> TestList = new();
}

public class BaseClassB
{
    public float TestFloat = 0;
    public string TestString = string.Empty;
    public Dictionary<string, string> TestDic = new();
}

[Inject(typeof(BaseClassA), InjectionType.Model)]
[Inject(typeof(BaseClassB), InjectionType.Model)]
public partial record CodeTest
{
}",
@"// Auto generated code by Peponi.SourceGenerators
// Github : https://github.com/peponi-paradise/Peponi
// Blog : https://peponi-paradise.tistory.com

#nullable disable

namespace GeneratorTest
{
    public partial record CodeTest
    {
        /// <summary>
        /// Auto generated member by Peponi.SourceGenerators
        /// </summary>
        public global::GeneratorTest.BaseClassA BaseClassA;

        /// <summary>
        /// Auto generated property by Peponi.SourceGenerators
        /// </summary>
        public int TestInt
        {
            get => BaseClassA.TestInt;
            set
            {
                if(BaseClassA.TestInt != value)
                {
                    BaseClassA.TestInt = value;
                    OnPropertyChanged(nameof(TestInt));
                    OnTestIntChanged();
                }
            }
        }

        /// <summary>
        /// Auto generated property by Peponi.SourceGenerators
        /// </summary>
        public bool TestBool
        {
            get => BaseClassA.TestBool;
            set
            {
                if(BaseClassA.TestBool != value)
                {
                    BaseClassA.TestBool = value;
                    OnPropertyChanged(nameof(TestBool));
                    OnTestBoolChanged();
                }
            }
        }

        /// <summary>
        /// Auto generated property by Peponi.SourceGenerators
        /// </summary>
        public List<string> TestList
        {
            get => BaseClassA.TestList;
            set
            {
                if(BaseClassA.TestList != value)
                {
                    BaseClassA.TestList = value;
                    OnPropertyChanged(nameof(TestList));
                    OnTestListChanged();
                }
            }
        }

        /// <summary>
        /// Auto generated method by Peponi.SourceGenerators
        /// </summary>
        partial void OnTestIntChanged();

        /// <summary>
        /// Auto generated method by Peponi.SourceGenerators
        /// </summary>
        partial void OnTestBoolChanged();

        /// <summary>
        /// Auto generated method by Peponi.SourceGenerators
        /// </summary>
        partial void OnTestListChanged();

        /// <summary>
        /// Auto generated member by Peponi.SourceGenerators
        /// </summary>
        public global::GeneratorTest.BaseClassB BaseClassB;

        /// <summary>
        /// Auto generated property by Peponi.SourceGenerators
        /// </summary>
        public float TestFloat
        {
            get => BaseClassB.TestFloat;
            set
            {
                if(BaseClassB.TestFloat != value)
                {
                    BaseClassB.TestFloat = value;
                    OnPropertyChanged(nameof(TestFloat));
                    OnTestFloatChanged();
                }
            }
        }

        /// <summary>
        /// Auto generated property by Peponi.SourceGenerators
        /// </summary>
        public string TestString
        {
            get => BaseClassB.TestString;
            set
            {
                if(BaseClassB.TestString != value)
                {
                    BaseClassB.TestString = value;
                    OnPropertyChanged(nameof(TestString));
                    OnTestStringChanged();
                }
            }
        }

        /// <summary>
        /// Auto generated property by Peponi.SourceGenerators
        /// </summary>
        public Dictionary<string, string> TestDic
        {
            get => BaseClassB.TestDic;
            set
            {
                if(BaseClassB.TestDic != value)
                {
                    BaseClassB.TestDic = value;
                    OnPropertyChanged(nameof(TestDic));
                    OnTestDicChanged();
                }
            }
        }

        /// <summary>
        /// Auto generated method by Peponi.SourceGenerators
        /// </summary>
        partial void OnTestFloatChanged();

        /// <summary>
        /// Auto generated method by Peponi.SourceGenerators
        /// </summary>
        partial void OnTestStringChanged();

        /// <summary>
        /// Auto generated method by Peponi.SourceGenerators
        /// </summary>
        partial void OnTestDicChanged();
    }
}"));
    }

    [TestMethod]
    public void RecordTotalTest()
    {
        Assert.IsTrue(InjectCompare.CompareCode(
@"using Peponi.SourceGenerators;

namespace GeneratorTest;

public class BaseClass
{
    public int TestInt = 0;
    public bool TestBool = false;
    public List<string> TestList = new();
}

public record BaseRecord
{
    public float TestFloat = 0;
    public string TestString = string.Empty;
    public Dictionary<string, string> TestDic = new();
}

public struct BaseStruct
{
    public double TestDouble;
    public char TestChar;
    public long TestLong;
}

[Inject(typeof(BaseClass), InjectionType.Dependency | InjectionType.Model, CustomName = ""ChangedClassName"")]
[Inject(typeof(BaseRecord), InjectionType.Dependency | InjectionType.Model, CustomName = ""ChangedRecord"", Modifier = Modifier.Internal)]
[Inject(typeof(BaseStruct), InjectionType.Dependency | InjectionType.Model, CustomName = ""ChangedStruct"", Modifier = Modifier.Protected, PropertyNotifyMode = NotifyType.None)]
public partial record CodeTest
{
}",
@"// Auto generated code by Peponi.SourceGenerators
// Github : https://github.com/peponi-paradise/Peponi
// Blog : https://peponi-paradise.tistory.com

#nullable disable

namespace GeneratorTest
{
    public partial record CodeTest
    {
        /// <summary>
        /// Auto generated member by Peponi.SourceGenerators
        /// </summary>
        public global::GeneratorTest.BaseClass ChangedClassName;

        /// <summary>
        /// Auto generated property by Peponi.SourceGenerators
        /// </summary>
        public int TestInt
        {
            get => ChangedClassName.TestInt;
            set
            {
                if(ChangedClassName.TestInt != value)
                {
                    ChangedClassName.TestInt = value;
                    OnPropertyChanged(nameof(TestInt));
                    OnTestIntChanged();
                }
            }
        }

        /// <summary>
        /// Auto generated property by Peponi.SourceGenerators
        /// </summary>
        public bool TestBool
        {
            get => ChangedClassName.TestBool;
            set
            {
                if(ChangedClassName.TestBool != value)
                {
                    ChangedClassName.TestBool = value;
                    OnPropertyChanged(nameof(TestBool));
                    OnTestBoolChanged();
                }
            }
        }

        /// <summary>
        /// Auto generated property by Peponi.SourceGenerators
        /// </summary>
        public List<string> TestList
        {
            get => ChangedClassName.TestList;
            set
            {
                if(ChangedClassName.TestList != value)
                {
                    ChangedClassName.TestList = value;
                    OnPropertyChanged(nameof(TestList));
                    OnTestListChanged();
                }
            }
        }

        /// <summary>
        /// Auto generated method by Peponi.SourceGenerators
        /// </summary>
        partial void OnTestIntChanged();

        /// <summary>
        /// Auto generated method by Peponi.SourceGenerators
        /// </summary>
        partial void OnTestBoolChanged();

        /// <summary>
        /// Auto generated method by Peponi.SourceGenerators
        /// </summary>
        partial void OnTestListChanged();

        /// <summary>
        /// Auto generated member by Peponi.SourceGenerators
        /// </summary>
        internal global::GeneratorTest.BaseRecord ChangedRecord;

        /// <summary>
        /// Auto generated property by Peponi.SourceGenerators
        /// </summary>
        public float TestFloat
        {
            get => ChangedRecord.TestFloat;
            set
            {
                if(ChangedRecord.TestFloat != value)
                {
                    ChangedRecord.TestFloat = value;
                    OnPropertyChanged(nameof(TestFloat));
                    OnTestFloatChanged();
                }
            }
        }

        /// <summary>
        /// Auto generated property by Peponi.SourceGenerators
        /// </summary>
        public string TestString
        {
            get => ChangedRecord.TestString;
            set
            {
                if(ChangedRecord.TestString != value)
                {
                    ChangedRecord.TestString = value;
                    OnPropertyChanged(nameof(TestString));
                    OnTestStringChanged();
                }
            }
        }

        /// <summary>
        /// Auto generated property by Peponi.SourceGenerators
        /// </summary>
        public Dictionary<string, string> TestDic
        {
            get => ChangedRecord.TestDic;
            set
            {
                if(ChangedRecord.TestDic != value)
                {
                    ChangedRecord.TestDic = value;
                    OnPropertyChanged(nameof(TestDic));
                    OnTestDicChanged();
                }
            }
        }

        /// <summary>
        /// Auto generated method by Peponi.SourceGenerators
        /// </summary>
        partial void OnTestFloatChanged();

        /// <summary>
        /// Auto generated method by Peponi.SourceGenerators
        /// </summary>
        partial void OnTestStringChanged();

        /// <summary>
        /// Auto generated method by Peponi.SourceGenerators
        /// </summary>
        partial void OnTestDicChanged();

        /// <summary>
        /// Auto generated member by Peponi.SourceGenerators
        /// </summary>
        protected global::GeneratorTest.BaseStruct ChangedStruct;

        /// <summary>
        /// Auto generated property by Peponi.SourceGenerators
        /// </summary>
        public double TestDouble
        {
            get => ChangedStruct.TestDouble;
            set
            {
                if(ChangedStruct.TestDouble != value)
                {
                    ChangedStruct.TestDouble = value;
                    OnTestDoubleChanged();
                }
            }
        }

        /// <summary>
        /// Auto generated property by Peponi.SourceGenerators
        /// </summary>
        public char TestChar
        {
            get => ChangedStruct.TestChar;
            set
            {
                if(ChangedStruct.TestChar != value)
                {
                    ChangedStruct.TestChar = value;
                    OnTestCharChanged();
                }
            }
        }

        /// <summary>
        /// Auto generated property by Peponi.SourceGenerators
        /// </summary>
        public long TestLong
        {
            get => ChangedStruct.TestLong;
            set
            {
                if(ChangedStruct.TestLong != value)
                {
                    ChangedStruct.TestLong = value;
                    OnTestLongChanged();
                }
            }
        }

        /// <summary>
        /// Auto generated method by Peponi.SourceGenerators
        /// </summary>
        partial void OnTestDoubleChanged();

        /// <summary>
        /// Auto generated method by Peponi.SourceGenerators
        /// </summary>
        partial void OnTestCharChanged();

        /// <summary>
        /// Auto generated method by Peponi.SourceGenerators
        /// </summary>
        partial void OnTestLongChanged();

        /// <summary>
        /// Auto generated method by Peponi.SourceGenerators
        /// </summary>
        public CodeTest(global::GeneratorTest.BaseClass ChangedClassName, global::GeneratorTest.BaseRecord ChangedRecord, global::GeneratorTest.BaseStruct ChangedStruct)
        {
            this.ChangedClassName = ChangedClassName;
            this.ChangedRecord = ChangedRecord;
            this.ChangedStruct = ChangedStruct;
        }
    }
}"));
    }
}