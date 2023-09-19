using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using Peponi.CodeGenerators.SemanticTarget;
using Peponi.CodeGenerators.SourceWriter;
using System.Collections.Immutable;
using System.Text;

namespace Peponi.CodeGenerators.InjectModelGenerator;

public sealed partial class InjectModelGenerator
{
    private static void Execute(SourceProductionContext context, (ObjectDeclarationTarget ObjectTarget, ImmutableArray<InjectModelTarget> InjectTarget) target)
    {
        if (target.ObjectTarget is null || target.InjectTarget.Count() == 0) return;

        var codeFileName = $"{target.ObjectTarget.NamespaceName}.{target.ObjectTarget.TypeName}.InjectModel.g.cs";

        var codeBuilder = new CodeBuilder();

        codeBuilder.WriteHeader();

        codeBuilder.WriteNullable();

        codeBuilder.WriteNamespace(target.ObjectTarget.NamespaceName);

        codeBuilder.Indent++;

        codeBuilder.WriteNotifyObjectType(target.ObjectTarget);

        codeBuilder.Indent++;

        codeBuilder.WriteInjectModelMembers(target.InjectTarget);

        while (codeBuilder.Indent > 0)
        {
            codeBuilder.Indent--;
            if (codeBuilder.Indent != 0) codeBuilder.AppendLine("}");
            else codeBuilder.Append("}");
        }

        context.AddSource(codeFileName, SourceText.From(codeBuilder.ToString(), Encoding.UTF8));
    }
}