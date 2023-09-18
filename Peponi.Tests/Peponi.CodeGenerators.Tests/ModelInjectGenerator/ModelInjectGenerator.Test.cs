namespace TestNamespace
{
    public class MyModel
    {
        public int _aaa = 0;
    }

    public static class TestStaticModel
    {
        public static double _double = 12;
    }
}

namespace Peponi.CodeGenerators.Tests.ModelInjectGenerator
{
    [TestClass]
    public class ModelInject
    {
        [TestMethod]
        public void SimpleModelInjectWithoutNotify()
        {
            Assert.IsTrue(ModelInjectCompare.CompareCode(
    @"using TestNamespace;
using Peponi.CodeGenerators;

namespace Peponi.CodeGenerators.Tests.ModelInjectGenerator;

[ModelInject(typeof(MyModel))]
public partial class CodeTest
{
}",
    @"// Auto generated code by Peponi.CodeGenerators
// Github : https://github.com/peponi-paradise/Peponi
// Blog : https://peponi-paradise.tistory.com

#nullable enable

namespace Peponi.CodeGenerators.Tests.ModelInjectGenerator
{
    public partial class CodeTest
    {
        /// <summary>
        /// Auto generated model by Peponi.CodeGenerators
        /// </summary>
        protected TestNamespace.MyModel Model { get; set; }

        /// <summary>
        /// Auto generated property by Peponi.CodeGenerators
        /// </summary>
        public int Aaa
        {
            get => Model._aaa;
            set
            {
                if(Model._aaa != value)
                {
                    Model._aaa = value;
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
        public void SimpleModelInjectWithNotify()
        {
            Assert.IsTrue(ModelInjectCompare.CompareCode(
@"using TestNamespace;
using Peponi.CodeGenerators;

namespace Peponi.CodeGenerators.Tests.ModelInjectGenerator;

[ModelInject(typeof(MyModel), PropertyNotifyType=NotifyType.Notify)]
public partial class CodeTest
{
}",
    @"// Auto generated code by Peponi.CodeGenerators
// Github : https://github.com/peponi-paradise/Peponi
// Blog : https://peponi-paradise.tistory.com

#nullable enable

namespace Peponi.CodeGenerators.Tests.ModelInjectGenerator
{
    public partial class CodeTest
    {
        /// <summary>
        /// Auto generated model by Peponi.CodeGenerators
        /// </summary>
        protected TestNamespace.MyModel Model { get; set; }

        /// <summary>
        /// Auto generated property by Peponi.CodeGenerators
        /// </summary>
        public int Aaa
        {
            get => Model._aaa;
            set
            {
                if(Model._aaa != value)
                {
                    Model._aaa = value;
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
        public void SimpleStaticModelInjectWithoutNotify()
        {
            Assert.IsTrue(ModelInjectCompare.CompareCode(
@"using TestNamespace;
using Peponi.CodeGenerators;

namespace Peponi.CodeGenerators.Tests.ModelInjectGenerator;

[ModelInject(typeof(TestStaticModel))]
public partial class CodeTest
{
}",
    @"// Auto generated code by Peponi.CodeGenerators
// Github : https://github.com/peponi-paradise/Peponi
// Blog : https://peponi-paradise.tistory.com

#nullable enable

namespace Peponi.CodeGenerators.Tests.ModelInjectGenerator
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
        public void SimpleStaticModelInjectWithNotify()
        {
            Assert.IsTrue(ModelInjectCompare.CompareCode(
@"using TestNamespace;
using Peponi.CodeGenerators;

namespace Peponi.CodeGenerators.Tests.ModelInjectGenerator;

[ModelInject(typeof(TestStaticModel), PropertyNotifyType=NotifyType.Notify)]
public partial class CodeTest
{
}",
    @"// Auto generated code by Peponi.CodeGenerators
// Github : https://github.com/peponi-paradise/Peponi
// Blog : https://peponi-paradise.tistory.com

#nullable enable

namespace Peponi.CodeGenerators.Tests.ModelInjectGenerator
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
    }
}