using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using Peponi.CodeGenerators.SemanticTarget;
using Peponi.CodeGenerators.SourceWriter;
using System.Collections.Immutable;
using System.Text;

namespace Peponi.CodeGenerators.PropertyGenerator;

public sealed partial class PropertyGenerator
{
    private static void Execute(SourceProductionContext context, ObjectDeclarationTarget objectTarget, ImmutableArray<PropertyTarget> propertyTarget)
    {
        if (objectTarget == null) return;
        else if (propertyTarget == null) return;

        var codeFileName = $"{objectTarget.NamespaceName}.{objectTarget.TypeName}.Property.g.cs";

        var codeBuilder = new CodeBuilder();

        codeBuilder.WriteHeaderComment();

        codeBuilder.WriteNullable();

        codeBuilder.WriteNamespace(objectTarget.NamespaceName);

        codeBuilder.Indent++;

        codeBuilder.WriteNotifyObjectType(objectTarget);

        codeBuilder.Indent++;

        codeBuilder.WriteProperties(propertyTarget);

        while (codeBuilder.Indent > 0)
        {
            codeBuilder.Indent--;
            if (codeBuilder.Indent != 0) codeBuilder.AppendLine("}");
            else codeBuilder.Append("}");
        }

        context.AddSource(codeFileName, SourceText.From(codeBuilder.ToString(), Encoding.UTF8));
    }
}