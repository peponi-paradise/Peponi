using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using Peponi.SourceGenerators.SemanticTarget;
using Peponi.SourceGenerators.SourceWriter;
using System.Collections.Immutable;
using System.Text;

namespace Peponi.SourceGenerators.InjectGenerator;

public sealed partial class InjectGenerator
{
    private static void Execute(SourceProductionContext context, (ObjectDeclarationTarget ObjectTarget, ImmutableArray<ImmutableArray<InjectTarget>> InjectTargets) createTarget)
    {
        if (createTarget.ObjectTarget is null || createTarget.InjectTargets.Count() == 0) return;

        var codeFileName = $"{createTarget.ObjectTarget.NamespaceName}.{createTarget.ObjectTarget.TypeName}.Inject.g.cs";

        var codeBuilder = new CodeBuilder();

        codeBuilder.WriteHeaderComment();

        codeBuilder.WriteNullableDisable();

        codeBuilder.WriteNamespace(createTarget.ObjectTarget.NamespaceName);

        codeBuilder.Indent++;

        codeBuilder.WriteNotifyObjectType(createTarget.ObjectTarget);

        codeBuilder.Indent++;

        codeBuilder.WriteInjectMembers(createTarget.ObjectTarget, createTarget.InjectTargets);

        while (codeBuilder.Indent > 0)
        {
            codeBuilder.Indent--;
            if (codeBuilder.Indent != 0) codeBuilder.AppendLine("}");
            else codeBuilder.Append("}");
        }

        context.AddSource(codeFileName, SourceText.From(codeBuilder.ToString(), Encoding.UTF8));
    }
}