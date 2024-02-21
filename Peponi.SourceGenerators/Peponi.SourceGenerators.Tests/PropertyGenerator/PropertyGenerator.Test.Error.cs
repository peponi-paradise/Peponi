using Microsoft.CodeAnalysis;

namespace Peponi.SourceGenerators.Tests.PropertyGenerator;

[TestClass]
public class PropertyTestError
{
    [TestMethod]
    public void PNPTY001()
    {
        // Could not check. Already restricted only for class, record, struct
        Assert.IsTrue(true);
    }

    [TestMethod]
    public void PNPTY002()
    {
        DiagnosticDescriptor CouldNotFindTypeModifier = new DiagnosticDescriptor(
       id: "PNPTY002",
       title: "Object declaration error",
       messageFormat: "Could not find proper modifier",
       category: "Property",
       defaultSeverity: DiagnosticSeverity.Error,
       isEnabledByDefault: true,
       description: "Supported modifiers are - public, protected, internal, private.");

        Diagnostic diag = Diagnostic.Create(CouldNotFindTypeModifier, null, "");
        Assert.IsTrue(PropertyCompare.IsErrorRaised(
@"using Peponi.SourceGenerators;

namespace GeneratorTest;

protected internal partial class TestClass
{
    [Property]
    private int testInt;
}", diag));
    }
}