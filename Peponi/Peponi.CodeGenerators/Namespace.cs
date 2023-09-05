using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Peponi.CodeGenerators;

internal static class Namespace
{
    internal static string GetNamespace(ClassDeclarationSyntax cls)
    {
        return string.Join(".", cls.Ancestors().OfType<BaseNamespaceDeclarationSyntax>().Reverse().Select(_ => _.Name));
    }
}