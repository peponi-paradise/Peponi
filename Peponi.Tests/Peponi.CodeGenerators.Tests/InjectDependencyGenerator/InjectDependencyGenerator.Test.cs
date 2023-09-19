using TestNamespace;

namespace Peponi.CodeGenerators.Tests.InjectDependencyGenerator
{
    [InjectDependency(typeof(MyModel), Modifier = Modifier.Internal)]
    [InjectDependency(typeof(MyStruct), Name = "TestStruct")]
    public partial class DepTest
    {
    }

    [InjectDependency(typeof(MyModel), Modifier = Modifier.Internal)]
    [InjectDependency(typeof(MyStruct), Name = "TestStruct")]
    [InjectDependency(typeof(MyModel), Modifier = Modifier.Public, Name = "Model2")]
    public partial class DepTest2
    {
    }
}