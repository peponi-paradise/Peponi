using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using Peponi.CodeGenerators.SemanticTarget;
using Peponi.CodeGenerators.SourceWriter;
using System.Collections.Immutable;
using System.Text;

namespace Peponi.CodeGenerators.CommandGenerator;

public sealed partial class CommandGenerator
{
    private static void Execute(SourceProductionContext context, (ObjectDeclarationTarget ObjectTarget, ImmutableArray<MethodTarget> MethodTarget) target)
    {
        if (target.ObjectTarget is null || target.MethodTarget.Count() == 0) return;

        var codeFileName = $"{target.ObjectTarget.NamespaceName}.{target.ObjectTarget.TypeName}.Command.g.cs";

        var codeBuilder = new CodeBuilder();

        codeBuilder.WriteHeaderComment();

        codeBuilder.WriteCommandUsing(target.ObjectTarget);

        codeBuilder.WriteNullable();

        codeBuilder.WriteNamespace(target.ObjectTarget.NamespaceName);

        codeBuilder.Indent++;

        codeBuilder.WriteNotifyObjectType(target.ObjectTarget);

        codeBuilder.Indent++;

        codeBuilder.WriteCommandMembers(target.MethodTarget);

        while (codeBuilder.Indent > 0)
        {
            codeBuilder.Indent--;
            if (codeBuilder.Indent != 0) codeBuilder.AppendLine("}");
            else codeBuilder.Append("}");
        }

        context.AddSource(codeFileName, SourceText.From(codeBuilder.ToString(), Encoding.UTF8));
    }
}