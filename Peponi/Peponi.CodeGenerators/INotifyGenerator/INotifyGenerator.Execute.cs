using Microsoft.CodeAnalysis;
using Peponi.CodeGenerators.SourceText;

namespace Peponi.CodeGenerators.INotifyGenerator;

public sealed partial class INotifyGenerator
{
    private static void Execute(SourceProductionContext context, INotifyTarget? target)
    {
        if (target == null) return;

        var codeFileName = $"{target.NamespaceName}.{target.TypeName}.INotify.g.cs";

        var codeBuilder = new CodeBuilder();

        codeBuilder.WriteHeader();

        codeBuilder.WriteNullable();

        codeBuilder.WriteUsing();

        codeBuilder.WriteNamespace(target.NamespaceName);

        codeBuilder.Indent++;

        codeBuilder.WriteType(target.TypeModifier, target.IsStatic, target.IsClass, target.TypeName);

        codeBuilder.Indent++;
    }
}