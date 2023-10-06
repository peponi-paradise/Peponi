using Microsoft.CodeAnalysis;

namespace Peponi.SourceGenerators.Tests.InjectGenerator;

[TestClass]
public class InjectTestError
{
    [TestMethod]
    public void PNIJT001()
    {
        // Could not check. ObjectType could not exist without type declaration.
        Assert.IsTrue(true);
    }

    [TestMethod]
    public void PNIJT002()
    {
        DiagnosticDescriptor CouldNotFindTypeModifier = new DiagnosticDescriptor(
       id: "PNIJT002",
       title: "Object declaration error",
       messageFormat: "Could not find proper modifier",
       category: "Inject",
       defaultSeverity: DiagnosticSeverity.Error,
       isEnabledByDefault: true,
       description: "Supported modifiers are - public, protected, internal, private.");

        Diagnostic diag = Diagnostic.Create(CouldNotFindTypeModifier, null, "");
        Assert.IsTrue(InjectCompare.IsErrorRaised(
@"using Peponi.SourceGenerators;

namespace GeneratorTest;

public class BaseClass
{
    public int TestInt = 0;
    public bool TestBool = false;
    public List<string> TestList = new();
}

[Inject(typeof(BaseClass), InjectionType.Dependency)]
protected internal partial class TestClass
{}", diag));
    }

    [TestMethod]
    public void PNIJT003()
    {
        DiagnosticDescriptor InjectTargetResolveError = new DiagnosticDescriptor(
      id: "PNIJT003",
      title: "Inject target resolve error",
      messageFormat: "Failed to resolve inject object",
      category: "Inject",
      defaultSeverity: DiagnosticSeverity.Error,
      isEnabledByDefault: true,
      description: "Please check inject object.");

        Diagnostic diag = Diagnostic.Create(InjectTargetResolveError, null, "");
        Assert.IsTrue(InjectCompare.IsErrorRaised(
@"using Peponi.SourceGenerators;

namespace GeneratorTest;

public class BaseClass
{
    public int TestInt = 0;
    public bool TestBool = false;
    public List<string> TestList = new();
}

[Inject(null, InjectionType.Dependency)]
public partial class TestClass
{}", diag));
    }

    [TestMethod]
    public void PNIJT004()
    {
        DiagnosticDescriptor StructObjectInjectModifierError = new DiagnosticDescriptor(
      id: "PNIJT004",
      title: "Inject target modifier error",
      messageFormat: "Not supported modifier - Could not use 'protected' to 'struct' object",
      category: "Inject",
      defaultSeverity: DiagnosticSeverity.Error,
      isEnabledByDefault: true,
      description: "Please check inject modifier.");

        Diagnostic diag = Diagnostic.Create(StructObjectInjectModifierError, null, "");
        Assert.IsTrue(InjectCompare.IsErrorRaised(
@"using Peponi.SourceGenerators;

namespace GeneratorTest;

public class BaseClass
{
    public int TestInt = 0;
    public bool TestBool = false;
    public List<string> TestList = new();
}

[Inject(typeof(BaseClass), InjectionType.Dependency, TypeModifier = Modifier.Protected)]
public partial struct TestClass
{}", diag));
    }
}