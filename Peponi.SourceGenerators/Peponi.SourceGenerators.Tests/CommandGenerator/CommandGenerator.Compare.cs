using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis;

namespace Peponi.SourceGenerators.Tests.CommandGenerator;

internal static class CommandCompare
{
    private static readonly PortableExecutableReference[] _assemblyReferences;

    static CommandCompare()
    {
        _assemblyReferences = AppDomain.CurrentDomain.GetAssemblies()
               .Where(a => !a.IsDynamic)
               .Select(a => MetadataReference.CreateFromFile(a.Location))
               .ToArray();
    }

    internal static bool CompareCode(string testCode, string expected)
    {
        var generatedCompilation = CSharpCompilation.Create("GeneratorTest",
                                                                           new[] { CSharpSyntaxTree.ParseText(testCode) },
                                                                           _assemblyReferences,
                                                                           new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary));
        SourceGenerators.CommandGenerator.CommandGenerator generator = new();
        GeneratorDriver driver = CSharpGeneratorDriver.Create(generator);

        driver = driver.RunGeneratorsAndUpdateCompilation(generatedCompilation, out var compilationOutput, out var diagnostics);
        var result = driver.GetRunResult().Results[0];

        bool exist = result.GeneratedSources.Any(x => x.SourceText.ToString() == expected);

        return exist;
    }
}