using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using Peponi.SourceGenerators.SemanticTarget;
using Peponi.SourceGenerators.SourceWriter;
using System.Text;

namespace Peponi.SourceGenerators.GrpcGenerator;

public sealed partial class GrpcClientGenerator
{
    private static void Execute(SourceProductionContext context, ObjectDeclarationTarget objectTarget, ProtobufInfo propertyTarget)
    {
        if (objectTarget == null) return;
        else if (propertyTarget == null || propertyTarget.ProtobufDatas.Count == 0) return;

        var codeFileName = $"{objectTarget.NamespaceName}.{objectTarget.TypeName}.GrpcClient.g.cs";

        var codeBuilder = new CodeBuilder();

        codeBuilder.WriteHeaderComment();

        codeBuilder.WriteNullable();

        codeBuilder.WriteGrpcClientUsings(propertyTarget);

        codeBuilder.WriteNamespace(objectTarget.NamespaceName);

        codeBuilder.Indent++;

        codeBuilder.WriteNotifyObjectType(objectTarget);

        codeBuilder.Indent++;

        codeBuilder.WriteGrpcClientMembers(propertyTarget);

        while (codeBuilder.Indent > 0)
        {
            codeBuilder.Indent--;
            if (codeBuilder.Indent != 0) codeBuilder.AppendLine("}");
            else codeBuilder.Append("}");
        }

        context.AddSource(codeFileName, SourceText.From(codeBuilder.ToString(), Encoding.UTF8));
    }
}