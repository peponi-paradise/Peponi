namespace Peponi.SourceGenerators.Tests.CommandGenerator;

[TestClass]
public class Command
{
    [TestMethod]
    public void CommandBase()
    {
        Assert.IsTrue(CommandCompare.CompareCode(
@"using Peponi.SourceGenerators;

namespace GeneratorTest;

public partial class CodeTest
{
    [Command]
    private void Test()
    {
        return;
    }
}",
@"// Auto generated code by Peponi.SourceGenerators
// Github : https://github.com/peponi-paradise/Peponi
// Blog : https://peponi-paradise.tistory.com

using Peponi.SourceGenerators.Commands;

#nullable enable

namespace GeneratorTest
{
    public partial class CodeTest
    {
        private CommandBase? _testCommand;

        /// <summary>
        /// Auto generated method by Peponi.SourceGenerators
        /// </summary>
        public ICommandBase TestCommand => _testCommand ??= new CommandBase(Test);
    }
}"));
    }

    [TestMethod]
    public void CustomName()
    {
        Assert.IsTrue(CommandCompare.CompareCode(
@"using Peponi.SourceGenerators;

namespace GeneratorTest;

public partial class CodeTest
{
    [Command(CustomName = ""MyCommand"")]
    private void Test()
    {
        return;
    }
}",
@"// Auto generated code by Peponi.SourceGenerators
// Github : https://github.com/peponi-paradise/Peponi
// Blog : https://peponi-paradise.tistory.com

using Peponi.SourceGenerators.Commands;

#nullable enable

namespace GeneratorTest
{
    public partial class CodeTest
    {
        private CommandBase? _testCommand;

        /// <summary>
        /// Auto generated method by Peponi.SourceGenerators
        /// </summary>
        public ICommandBase MyCommand => _testCommand ??= new CommandBase(Test);
    }
}"));
    }

    [TestMethod]
    public void CanExecute()
    {
        Assert.IsTrue(CommandCompare.CompareCode(
@"using Peponi.SourceGenerators;

namespace GeneratorTest;

public partial class CodeTest
{
    [Command(CanExecute = ""CanExe"")]
    private void Test()
    {
        return;
    }

    private bool CanExe()
    {
        return true;
    }
}",
@"// Auto generated code by Peponi.SourceGenerators
// Github : https://github.com/peponi-paradise/Peponi
// Blog : https://peponi-paradise.tistory.com

using Peponi.SourceGenerators.Commands;

#nullable enable

namespace GeneratorTest
{
    public partial class CodeTest
    {
        private CommandBase? _testCommand;

        /// <summary>
        /// Auto generated method by Peponi.SourceGenerators
        /// </summary>
        public ICommandBase TestCommand => _testCommand ??= new CommandBase(Test, CanExe);
    }
}"));
    }

    [TestMethod]
    public void CustomNameAndCanExecute()
    {
        Assert.IsTrue(CommandCompare.CompareCode(
@"using Peponi.SourceGenerators;

namespace GeneratorTest;

public partial class CodeTest
{
    [Command(CustomName = ""MyCommand"", CanExecute = ""CanExe"")]
    private void Test()
    {
        return;
    }

    private bool CanExe()
    {
        return true;
    }
}",
@"// Auto generated code by Peponi.SourceGenerators
// Github : https://github.com/peponi-paradise/Peponi
// Blog : https://peponi-paradise.tistory.com

using Peponi.SourceGenerators.Commands;

#nullable enable

namespace GeneratorTest
{
    public partial class CodeTest
    {
        private CommandBase? _testCommand;

        /// <summary>
        /// Auto generated method by Peponi.SourceGenerators
        /// </summary>
        public ICommandBase MyCommand => _testCommand ??= new CommandBase(Test, CanExe);
    }
}"));
    }

    [TestMethod]
    public void InputParam()
    {
        Assert.IsTrue(CommandCompare.CompareCode(
@"using Peponi.SourceGenerators;

namespace GeneratorTest;

public partial class CodeTest
{
    [Command]
    private void Test(int a)
    {
        return;
    }
}",
@"// Auto generated code by Peponi.SourceGenerators
// Github : https://github.com/peponi-paradise/Peponi
// Blog : https://peponi-paradise.tistory.com

using Peponi.SourceGenerators.Commands;

#nullable enable

namespace GeneratorTest
{
    public partial class CodeTest
    {
        private CommandBase<int>? _testCommand;

        /// <summary>
        /// Auto generated method by Peponi.SourceGenerators
        /// </summary>
        public ICommandBase TestCommand => _testCommand ??= new CommandBase<int>(Test);
    }
}"));
    }
}