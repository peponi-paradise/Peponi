using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using Peponi.CodeGenerators.SemanticTarget;
using Peponi.CodeGenerators.SourceWriter;
using System.Text;

namespace Peponi.CodeGenerators.NotifyInterfaceGenerator;

public sealed partial class NotifyInterfaceGenerator
{
    private static void Execute(SourceProductionContext context, ObjectDeclarationTarget? target)
    {
        if (target == null) return;

        var codeFileName = $"{target.NamespaceName}.{target.TypeName}.INotify.g.cs";

        var codeBuilder = new CodeBuilder();

        codeBuilder.WriteHeader();

        codeBuilder.WriteNullable();

        codeBuilder.WriteUsing(target);

        codeBuilder.WriteNamespace(target.NamespaceName);

        codeBuilder.Indent++;

        codeBuilder.WriteObjectType(target);

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