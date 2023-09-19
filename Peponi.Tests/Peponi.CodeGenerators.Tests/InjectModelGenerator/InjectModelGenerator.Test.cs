using TestNamespace;

namespace Peponi.CodeGenerators.Tests.InjectModelGenerator
{
    [TestClass]
    public class InjectModel
    {
        [TestMethod]
        public void InjectSimpleModelWithoutNotify()
        {
            Assert.IsTrue(InjectModelCompare.CompareCode(
    @"using TestNamespace;
using Peponi.CodeGenerators;

namespace Peponi.CodeGenerators.Tests.InjectModelGenerator;

[InjectModel(typeof(MyModel))]
public partial class CodeTest
{
}",
    @"// Auto generated code by Peponi.CodeGenerators
// Github : https://github.com/peponi-paradise/Peponi
// Blog : https://peponi-paradise.tistory.com

#nullable enable

namespace Peponi.CodeGenerators.Tests.InjectModelGenerator
{
    public partial class CodeTest
    {
        /// <summary>
        /// Auto generated model by Peponi.CodeGenerators
        /// </summary>
        protected TestNamespace.MyModel MyModel;

        /// <summary>
        /// Auto generated property by Peponi.CodeGenerators
        /// </summary>
        public int Aaa
        {
            get => MyModel._aaa;
            set
            {
                if(MyModel._aaa != value)
                {
                    MyModel._aaa = value;
                    OnAaaChanged();
                }
            }
        }

        /// <summary>
        /// Auto generated method by Peponi.CodeGenerators
        /// </summary>
        partial void OnAaaChanged();
    }
}"));
        }

        [TestMethod]
        public void InjectSimpleModelWithNotify()
        {
            Assert.IsTrue(InjectModelCompare.CompareCode(
@"using TestNamespace;
using Peponi.CodeGenerators;

namespace Peponi.CodeGenerators.Tests.InjectModelGenerator;

[InjectModel(typeof(MyModel), PropertyNotifyType=NotifyType.Notify)]
public partial class CodeTest
{
}",
    @"// Auto generated code by Peponi.CodeGenerators
// Github : https://github.com/peponi-paradise/Peponi
// Blog : https://peponi-paradise.tistory.com

#nullable enable

namespace Peponi.CodeGenerators.Tests.InjectModelGenerator
{
    public partial class CodeTest
    {
        /// <summary>
        /// Auto generated model by Peponi.CodeGenerators
        /// </summary>
        protected TestNamespace.MyModel MyModelModel { get; set; }

        /// <summary>
        /// Auto generated property by Peponi.CodeGenerators
        /// </summary>
        public int Aaa
        {
            get => MyModelModel._aaa;
            set
            {
                if(MyModelModel._aaa != value)
                {
                    MyModelModel._aaa = value;
                    OnPropertyChanged(nameof(Aaa));
                    OnAaaChanged();
                }
            }
        }

        /// <summary>
        /// Auto generated method by Peponi.CodeGenerators
        /// </summary>
        partial void OnAaaChanged();
    }
}"));
        }

        [TestMethod]
        public void InjectSimpleStaticModelWithoutNotify()
        {
            Assert.IsTrue(InjectModelCompare.CompareCode(
@"using TestNamespace;
using Peponi.CodeGenerators;

namespace Peponi.CodeGenerators.Tests.InjectModelGenerator;

[InjectModel(typeof(TestStaticModel))]
public partial class CodeTest
{
}",
    @"// Auto generated code by Peponi.CodeGenerators
// Github : https://github.com/peponi-paradise/Peponi
// Blog : https://peponi-paradise.tistory.com

#nullable enable

namespace Peponi.CodeGenerators.Tests.InjectModelGenerator
{
    public partial class CodeTest
    {
        /// <summary>
        /// Auto generated property by Peponi.CodeGenerators
        /// </summary>
        public double Double
        {
            get => TestNamespace.TestStaticModel._double;
            set
            {
                if(TestNamespace.TestStaticModel._double != value)
                {
                    TestNamespace.TestStaticModel._double = value;
                    OnDoubleChanged();
                }
            }
        }

        /// <summary>
        /// Auto generated method by Peponi.CodeGenerators
        /// </summary>
        partial void OnDoubleChanged();
    }
}"));
        }

        [TestMethod]
        public void InjectSimpleStaticModelWithNotify()
        {
            Assert.IsTrue(InjectModelCompare.CompareCode(
@"using TestNamespace;
using Peponi.CodeGenerators;

namespace Peponi.CodeGenerators.Tests.InjectModelGenerator;

[InjectModel(typeof(TestStaticModel), PropertyNotifyType=NotifyType.Notify)]
public partial class CodeTest
{
}",
    @"// Auto generated code by Peponi.CodeGenerators
// Github : https://github.com/peponi-paradise/Peponi
// Blog : https://peponi-paradise.tistory.com

#nullable enable

namespace Peponi.CodeGenerators.Tests.InjectModelGenerator
{
    public partial class CodeTest
    {
        /// <summary>
        /// Auto generated property by Peponi.CodeGenerators
        /// </summary>
        public double Double
        {
            get => TestNamespace.TestStaticModel._double;
            set
            {
                if(TestNamespace.TestStaticModel._double != value)
                {
                    TestNamespace.TestStaticModel._double = value;
                    OnPropertyChanged(nameof(Double));
                    OnDoubleChanged();
                }
            }
        }

        /// <summary>
        /// Auto generated method by Peponi.CodeGenerators
        /// </summary>
        partial void OnDoubleChanged();
    }
}"));
        }

        [TestMethod]
        public void InjectComplicatedModelWithNotify()
        {
            Assert.IsTrue(InjectModelCompare.CompareCode(
@"using TestNamespace;
using Peponi.CodeGenerators;

namespace Peponi.CodeGenerators.Tests.InjectModelGenerator;

[InjectModel(typeof(MyModel), ModelName = ""TESTMODEL"")]
[InjectModel(typeof(TestStaticModel), PropertyNotifyType = NotifyType.Notify)]
public partial class CodeTest
{
}
", ""));
        }
    }

    [NotifyInterface]
    [InjectModel(typeof(MyModel), ModelName = "TESTMODEL")]
    [InjectModel(typeof(TestStaticModel), PropertyNotifyType = NotifyType.Notify)]
    [InjectModel(typeof(MyStruct))]
    public partial class CodeTest
    {
    }
}