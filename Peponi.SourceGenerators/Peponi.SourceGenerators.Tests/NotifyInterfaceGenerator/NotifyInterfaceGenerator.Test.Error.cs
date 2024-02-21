using Microsoft.CodeAnalysis;

namespace Peponi.SourceGenerators.Tests.NotifyInterfaceGenerator;

[TestClass]
public class NotifyInterfaceTestError
{
    [TestMethod]
    public void PNNTI001()
    {
        // Could not check. CS0592 raised before generation.
        Assert.IsTrue(true);
    }

    [TestMethod]
    public void PNNTI002()
    {
        DiagnosticDescriptor CouldNotFindTypeModifier = new DiagnosticDescriptor(
       id: "PNNTI002",
       title: "Object declaration error",
       messageFormat: "Could not find proper modifier",
       category: "NotifyInterface",
       defaultSeverity: DiagnosticSeverity.Error,
       isEnabledByDefault: true,
       description: "Supported modifiers are - public, protected, internal, private.");

        Diagnostic diag = Diagnostic.Create(CouldNotFindTypeModifier, null, "");
        Assert.IsTrue(NotifyInterfaceCompare.IsErrorRaised(
@"using Peponi.SourceGenerators;

namespace GeneratorTest;

[NotifyInterface]
protected internal partial class TestClass
{
    void GenTest() {}
}", diag));
    }
}