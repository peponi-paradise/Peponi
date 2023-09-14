using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using Peponi.CodeGenerators.SourceWriter;
using System.Text;

namespace Peponi.CodeGenerators.INotifyGenerator;

public sealed partial class INotifyGenerator
{
    private static void Execute(SourceProductionContext context, ObjectDeclarationTarget? target)
    {
        if (target == null) return;

        var codeFileName = $"{target.NamespaceName}.{target.TypeName}.INotify.g.cs";

        var codeBuilder = new CodeBuilder();

        codeBuilder.WriteHeader();

        codeBuilder.WriteNullable();

        codeBuilder.WriteUsing();

        codeBuilder.WriteNamespace(target.NamespaceName);

        codeBuilder.Indent++;

        codeBuilder.WriteINotifyType(target.TypeModifier, target.TypeName, target.ObjectType, target.IsStatic, target.IsSealed);

        codeBuilder.Indent++;

        codeBuilder.WriteINotifyContents();

        while (codeBuilder.Indent > 0)
        {
            codeBuilder.Indent--;
            if (codeBuilder.Indent != 0) codeBuilder.AppendLine("}");
            else codeBuilder.Append("}");
        }

        context.AddSource(codeFileName, SourceText.From(codeBuilder.ToString(), Encoding.UTF8));
    }
}