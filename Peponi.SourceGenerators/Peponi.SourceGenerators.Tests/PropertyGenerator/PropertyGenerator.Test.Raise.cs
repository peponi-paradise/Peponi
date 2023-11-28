namespace Peponi.SourceGenerators.Tests.PropertyGenerator;

[TestClass]
public class PropertyTestRaise
{
    [TestMethod]
    public void PropertyWithRaiseCanExecuteChanged()
    {
        Assert.IsTrue(PropertyCompare.CompareCode(
@"using Peponi.SourceGenerators;

namespace GeneratorTest;

public partial class CodeTest
{
    [Property]
    [RaiseCanExecuteChanged(""TestCommand"")]
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
                    TestCommand.RaiseCanExecuteChanged();
                }
            }
        }

        /// <summary>
        /// Auto generated method by Peponi.SourceGenerators
        /// </summary>
        private partial void OnTestBoolChanged();
    }
}"));
    }

    [TestMethod]
    public void PropertyWithRaisePropertyChanged()
    {
        Assert.IsTrue(PropertyCompare.CompareCode(
@"using Peponi.SourceGenerators;

namespace GeneratorTest;

public partial class CodeTest
{
    [Property]
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
                    OnPropertyChanged(nameof(TestParam));
                }
            }
        }

        /// <summary>
        /// Auto generated method by Peponi.SourceGenerators
        /// </summary>
        private partial void OnTestBoolChanged();
    }
}"));
    }
}