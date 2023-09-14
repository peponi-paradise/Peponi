namespace Peponi.CodeGenerators.Tests.PropertyGenerator;

[TestClass]
public class Property
{
    [TestMethod]
    public void CodeGenTest()
    {
        Assert.IsTrue(PropertyCompare.CompareCode(
@"using Peponi.CodeGenerators;

namespace CodeGeneratorTest;

public static sealed partial record CodeTest
{
    [Property]
    private bool _testBool = false;
}", ""));
    }
}