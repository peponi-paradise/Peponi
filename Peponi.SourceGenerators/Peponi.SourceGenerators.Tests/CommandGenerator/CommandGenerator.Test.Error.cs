using Microsoft.CodeAnalysis;

namespace Peponi.SourceGenerators.Tests.CommandGenerator;

[TestClass]
public class CommandTestError
{
    [TestMethod]
    public void PNCMD002()
    {
        DiagnosticDescriptor CouldNotFindTypeObject = new DiagnosticDescriptor(
       id: "PNCMD002",
       title: "Object declaration error",
       messageFormat: "Could not find proper object",
       category: "Command",
       defaultSeverity: DiagnosticSeverity.Error,
       isEnabledByDefault: true,
       description: "Supported objects are - class, record, struct.");

        Diagnostic diag = Diagnostic.Create(CouldNotFindTypeObject, null, "");
        Assert.IsTrue(CommandCompare.IsErrorRaised(
@"using Peponi.SourceGenerators;

namespace GeneratorTest;

public partial interface ITest
{
    [Command]
    void GenTest() {}
}", diag));
    }

    [TestMethod]
    public void PNCMD003()
    {
        DiagnosticDescriptor CouldNotFindTypeModifier = new DiagnosticDescriptor(
       id: "PNCMD003",
       title: "Object declaration error",
       messageFormat: "Could not find proper modifier",
       category: "Command",
       defaultSeverity: DiagnosticSeverity.Error,
       isEnabledByDefault: true,
       description: "Supported modifiers are - public, protected, internal, private.");

        Diagnostic diag = Diagnostic.Create(CouldNotFindTypeModifier, null, "");
        Assert.IsTrue(CommandCompare.IsErrorRaised(
@"using Peponi.SourceGenerators;

namespace GeneratorTest;

protected internal partial class TestClass
{
    [Command]
    void GenTest() {}
}", diag));
    }

    [TestMethod]
    public void PNCMD010()
    {
        DiagnosticDescriptor MethodReturnType = new DiagnosticDescriptor(
       id: "PNCMD010",
       title: "Method return type error",
       messageFormat: "Not supported return type",
       category: "Command",
       defaultSeverity: DiagnosticSeverity.Error,
       isEnabledByDefault: true,
       description: "Supported return types are - void, Task, Task<T>.");

        Diagnostic diag = Diagnostic.Create(MethodReturnType, null, "");
        Assert.IsTrue(CommandCompare.IsErrorRaised(
@"using Peponi.SourceGenerators;

namespace GeneratorTest;

public partial class TestClass
{
    [Command]
    int GenTest() {}
}", diag));
    }

    [TestMethod]
    public void PNCMD020()
    {
        DiagnosticDescriptor CanExecuteReturnType = new DiagnosticDescriptor(
       id: "PNCMD020",
       title: "CanExecute return type error",
       messageFormat: "Not supported CanExecute return type",
       category: "Command",
       defaultSeverity: DiagnosticSeverity.Error,
       isEnabledByDefault: true,
       description: "Supported return type is boolean.");

        Diagnostic diag = Diagnostic.Create(CanExecuteReturnType, null, "");
        Assert.IsTrue(CommandCompare.IsErrorRaised(
@"using Peponi.SourceGenerators;

namespace GeneratorTest;

public partial class TestClass
{
    [Command(CanExecute = ""CanExe"")]
    void GenTest() {}

    int CanExe()
    {
        return 0;
    }
}", diag));
    }

    [TestMethod]
    public void PNCMD021()
    {
        DiagnosticDescriptor CanExecuteParameterType = new DiagnosticDescriptor(
       id: "PNCMD021",
       title: "CanExecute parameter type error",
       messageFormat: "Not supported CanExecute parameter type",
       category: "Command",
       defaultSeverity: DiagnosticSeverity.Error,
       isEnabledByDefault: true,
       description: "Parameter type should be void or matched with command parameter.");

        Diagnostic diag = Diagnostic.Create(CanExecuteParameterType, null, "");
        Assert.IsTrue(CommandCompare.IsErrorRaised(
@"using Peponi.SourceGenerators;

namespace GeneratorTest;

public partial class TestClass
{
    [Command(CanExecute = ""CanExe"")]
    void GenTest() {}

    bool CanExe(int a)
    {
        return false;
    }
}", diag));
    }
}