using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using Peponi.SourceGenerators.SemanticTarget;
using Peponi.SourceGenerators.SourceWriter;
using System.Text;

namespace Peponi.SourceGenerators.NotifyInterfaceGenerator;

public sealed partial class NotifyInterfaceGenerator
{
    private static void Execute(SourceProductionContext context, ObjectDeclarationTarget? target)
    {
        if (target == null) return;

        var codeFileName = $"{target.NamespaceName}.{target.TypeName}.INotify.g.cs";

        var codeBuilder = new CodeBuilder();

        codeBuilder.WriteHeaderComment();

        codeBuilder.WriteNullable();

        codeBuilder.WriteUsing(target);

        codeBuilder.WriteNamespace(target.NamespaceName);

        codeBuilder.Indent++;

        codeBuilder.WriteNotifyObjectType(target);

        codeBuilder.Indent++;

        codeBuilder.WriteNotifyInterfaceMembers(target);

        while (codeBuilder.Indent > 0)
        {
            codeBuilder.Indent--;
            if (codeBuilder.Indent != 0) codeBuilder.AppendLine("}");
            else codeBuilder.Append("}");
        }

        context.AddSource(codeFileName, SourceText.From(codeBuilder.ToString(), Encoding.UTF8));
    }
}