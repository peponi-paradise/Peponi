using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

namespace Peponi.CodeGenerators.Tests.ModelInjectGenerator;

internal static class ModelInjectCompare
{
    private static readonly PortableExecutableReference[] _assemblyReferences;

    static ModelInjectCompare()
    {
        _assemblyReferences = AppDomain.CurrentDomain.GetAssemblies()
               .Where(a => !a.IsDynamic)
               .Select(a => MetadataReference.CreateFromFile(a.Location))
               .ToArray();
    }

    internal static bool CompareCode(string testCode, string expected)
    {
        var generatedCompilation = CSharpCompilation.Create("Peponi.CodeGenerators.Testing",
                                                                           new[] { CSharpSyntaxTree.ParseText(testCode) },
                                                                           _assemblyReferences,
                                                                           new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary));
        CodeGenerators.ModelInjectGenerator.ModelInjectGenerator generator = new();
        GeneratorDriver driver = CSharpGeneratorDriver.Create(generator);

        driver = driver.RunGeneratorsAndUpdateCompilation(generatedCompilation, out var compilationOutput, out var diagnostics);
        var result = driver.GetRunResult().Results[0];

        bool exist = result.GeneratedSources.Any(x => x.SourceText.ToString() == expected);

        return exist;
    }
}