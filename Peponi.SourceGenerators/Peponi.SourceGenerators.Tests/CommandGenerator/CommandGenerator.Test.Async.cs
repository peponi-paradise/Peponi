namespace Peponi.SourceGenerators.Tests.CommandGenerator;

[TestClass]
public class CommandTestAsync
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
    private async Task Test()
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
        public ICommandBase TestCommand => _testCommand ??= new CommandBase(async () => { await Test(); });
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
    private async Task Test()
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
        public ICommandBase MyCommand => _testCommand ??= new CommandBase(async () => { await Test(); });
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
    private async Task Test()
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
        public ICommandBase TestCommand => _testCommand ??= new CommandBase(async () => { await Test(); }, CanExe);
    }
}"));
    }

    [TestMethod]
    public void CustomNameWithCanExecute()
    {
        Assert.IsTrue(CommandCompare.CompareCode(
@"using Peponi.SourceGenerators;

namespace GeneratorTest;

public partial class CodeTest
{
    [Command(CustomName = ""MyCommand"", CanExecute = ""CanExe"")]
    private async Task Test()
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
        public ICommandBase MyCommand => _testCommand ??= new CommandBase(async () => { await Test(); }, CanExe);
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
    private async Task Test(int a)
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
        public ICommandBase TestCommand => _testCommand ??= new CommandBase<int>(async x => await Test(x));
    }
}"));
    }

    [TestMethod]
    public void InputParamWithCustomName()
    {
        Assert.IsTrue(CommandCompare.CompareCode(
@"using Peponi.SourceGenerators;

namespace GeneratorTest;

public partial class CodeTest
{
    [Command(CustomName = ""MyCommand"")]
    private async Task Test(int a)
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
        public ICommandBase MyCommand => _testCommand ??= new CommandBase<int>(async x => await Test(x));
    }
}"));
    }

    [TestMethod]
    public void InputParamWithCanExecute()
    {
        Assert.IsTrue(CommandCompare.CompareCode(
@"using Peponi.SourceGenerators;

namespace GeneratorTest;

public partial class CodeTest
{
    [Command(CanExecute = ""CanExe"")]
    private async Task Test(int a)
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
        private CommandBase<int>? _testCommand;

        /// <summary>
        /// Auto generated method by Peponi.SourceGenerators
        /// </summary>
        public ICommandBase TestCommand => _testCommand ??= new CommandBase<int>(async x => await Test(x), _ => CanExe());
    }
}"));
    }

    [TestMethod]
    public void InputParamWithCanExecuteWithMatchedParam()
    {
        Assert.IsTrue(CommandCompare.CompareCode(
@"using Peponi.SourceGenerators;

namespace GeneratorTest;

public partial class CodeTest
{
    [Command(CanExecute = ""CanExe"")]
    private async Task Test(int a)
    {
        return;
    }

    private bool CanExe(int a)
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
        private CommandBase<int>? _testCommand;

        /// <summary>
        /// Auto generated method by Peponi.SourceGenerators
        /// </summary>
        public ICommandBase TestCommand => _testCommand ??= new CommandBase<int>(async x => await Test(x), CanExe);
    }
}"));
    }

    [TestMethod]
    public void InputParamWithCustomNameWithCanExecute()
    {
        Assert.IsTrue(CommandCompare.CompareCode(
@"using Peponi.SourceGenerators;

namespace GeneratorTest;

public partial class CodeTest
{
    [Command(CustomName = ""MyCommand"", CanExecute = ""CanExe"")]
    private async Task Test(int a)
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
        private CommandBase<int>? _testCommand;

        /// <summary>
        /// Auto generated method by Peponi.SourceGenerators
        /// </summary>
        public ICommandBase MyCommand => _testCommand ??= new CommandBase<int>(async x => await Test(x), _ => CanExe());
    }
}"));
    }

    [TestMethod]
    public void CustomTypeParam()
    {
        Assert.IsTrue(CommandCompare.CompareCode(
@"using Peponi.SourceGenerators;

namespace GeneratorTest;

public record ParamRecord
{
    public int A;
}

public partial class CodeTest
{
    [Command]
    private async Task Test(ParamRecord a)
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
        private CommandBase<global::GeneratorTest.ParamRecord>? _testCommand;

        /// <summary>
        /// Auto generated method by Peponi.SourceGenerators
        /// </summary>
        public ICommandBase TestCommand => _testCommand ??= new CommandBase<global::GeneratorTest.ParamRecord>(async x => await Test(x));
    }
}"));
    }
}