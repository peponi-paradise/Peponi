using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

namespace Peponi.SourceGenerators.Tests.GrpcGenerator;

internal static class GrpcClientCompare
{
    private static readonly PortableExecutableReference[] _assemblyReferences;

    static GrpcClientCompare()
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
        SourceGenerators.GrpcGenerator.GrpcClientGenerator generator = new();
        GeneratorDriver driver = CSharpGeneratorDriver.Create(generator);

        driver = driver.RunGeneratorsAndUpdateCompilation(generatedCompilation, out var compilationOutput, out var diagnostics);
        var result = driver.GetRunResult().Results[0];

        bool exist = result.GeneratedSources.Any(x => x.SourceText.ToString() == expected);

        return exist;
    }

    internal static bool IsErrorRaised(string testCode, Diagnostic expected)
    {
        var generatedCompilation = CSharpCompilation.Create("GeneratorTest",
                                                                           new[] { CSharpSyntaxTree.ParseText(testCode) },
                                                                           _assemblyReferences,
                                                                           new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary));
        SourceGenerators.GrpcGenerator.GrpcClientGenerator generator = new();
        GeneratorDriver driver = CSharpGeneratorDriver.Create(generator);

        driver = driver.RunGeneratorsAndUpdateCompilation(generatedCompilation, out var compilationOutput, out var diagnostics);
        var result = driver.GetRunResult().Diagnostics;

        bool exist = result.Any(x => x.Id == expected.Id && x.Severity == expected.Severity);

        return exist;
    }
}

internal static class GrpcServerCompare
{
    private static readonly PortableExecutableReference[] _assemblyReferences;

    static GrpcServerCompare()
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
        SourceGenerators.GrpcGenerator.GrpcServerGenerator generator = new();
        GeneratorDriver driver = CSharpGeneratorDriver.Create(generator);

        driver = driver.RunGeneratorsAndUpdateCompilation(generatedCompilation, out var compilationOutput, out var diagnostics);
        var result = driver.GetRunResult().Results[0];

        bool exist = result.GeneratedSources.Any(x => x.SourceText.ToString() == expected);

        return exist;
    }

    internal static bool IsErrorRaised(string testCode, Diagnostic expected)
    {
        var generatedCompilation = CSharpCompilation.Create("GeneratorTest",
                                                                           new[] { CSharpSyntaxTree.ParseText(testCode) },
                                                                           _assemblyReferences,
                                                                           new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary));
        SourceGenerators.GrpcGenerator.GrpcServerGenerator generator = new();
        GeneratorDriver driver = CSharpGeneratorDriver.Create(generator);

        driver = driver.RunGeneratorsAndUpdateCompilation(generatedCompilation, out var compilationOutput, out var diagnostics);
        var result = driver.GetRunResult().Diagnostics;

        bool exist = result.Any(x => x.Id == expected.Id && x.Severity == expected.Severity);

        return exist;
    }
}