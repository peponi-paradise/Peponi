using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using Peponi.CodeGenerators.SemanticTarget;
using Peponi.CodeGenerators.SourceWriter;
using System.Text;

namespace Peponi.CodeGenerators.ModelInjectGenerator;

public sealed partial class ModelInjectGenerator
{
    private static void Execute(SourceProductionContext context, (ObjectDeclarationTarget ObjectTarget, ModelInjectTarget InjectTarget, List<PropertyTarget> PropertyTarget) target)
    {
        if (target.ObjectTarget is null || target.InjectTarget is null || target.PropertyTarget is null) return;

        var codeFileName = $"{target.ObjectTarget.NamespaceName}.{target.ObjectTarget.TypeName}.ModelInject.g.cs";

        var codeBuilder = new CodeBuilder();

        codeBuilder.WriteHeader();

        codeBuilder.WriteNullable();

        codeBuilder.WriteNamespace(target.ObjectTarget.NamespaceName);

        codeBuilder.Indent++;

        codeBuilder.WriteModelInjectType(target.ObjectTarget);

        codeBuilder.Indent++;

        codeBuilder.WriteModelInjectMembers(target.InjectTarget, target.PropertyTarget);

        while (codeBuilder.Indent > 0)
        {
            codeBuilder.Indent--;
            if (codeBuilder.Indent != 0) codeBuilder.AppendLine("}");
            else codeBuilder.Append("}");
        }

        context.AddSource(codeFileName, SourceText.From(codeBuilder.ToString(), Encoding.UTF8));
    }
}