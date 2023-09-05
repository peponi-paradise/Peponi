using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Text;
using System.Text;

namespace Peponi.CodeGenerators.Class;

[Generator]
public class PDataClassSrcGenerator : ISourceGenerator
{
    public const string PDataClassAttribute = @"
namespace Peponi.CodeGenerators.Class
{
    [System.AttributeUsage(System.AttributeTargets.Class)]
    public class PDataClassAttribute : System.Attribute
    {
    }
}";

    public void Initialize(GeneratorInitializationContext context)
    {
        context.RegisterForPostInitialization((ctx) =>
        {
            ctx.AddSource("PDataClassAttribute.g.cs", SourceText.From(PDataClassAttribute, Encoding.UTF8));
        });

        context.RegisterForSyntaxNotifications(() => new PDataClassSyntaxReceiver());
    }

    public void Execute(GeneratorExecutionContext context)
    {
        PDataClassSyntaxReceiver? receiver = context.SyntaxReceiver as PDataClassSyntaxReceiver;

        if (receiver == null || receiver.PDataClasses.Count == 0)
        {
            return;
        }

        foreach (var syntax in receiver.PDataClasses)
        {
            List<FieldInfo> fields = Field.GetFields(context.Compilation, syntax);
            if (fields.Count == 0)
            {
                continue;
            }

            string src = GenerateSource(Namespace.GetNamespace(syntax), syntax.Identifier.ValueText, fields);

            context.AddSource($"{syntax.Identifier.ValueText}.peponi.g.cs", SourceText.From(src, Encoding.UTF8));
        }
    }

    private string GenerateSource(string namespaceName, string className, List<FieldInfo> fields)
    {
        CodeBuilder.CodeBuilder sb = new();

        bool hasNamespace = string.IsNullOrEmpty(namespaceName) == false;

        sb.AppendLine("using System.ComponentModel;");

        if (hasNamespace)
        {
            sb.AppendLine($"namespace {namespaceName}");
            sb.AppendLine("{");
        }

        using (sb.Indent(hasNamespace))
        {
            sb.AppendLine(@$"partial class {className} : INotifyPropertyChanged");
            sb.AppendLine("{");
            using (sb.Indent())
            {
                sb.AppendLine("public event PropertyChangedEventHandler? PropertyChanged;");
                foreach (var field in fields)
                {
                    sb.AppendLine($"public {field.TypeName} {Field.GetFieldName(field.Identifier)} {{ get => {field.Identifier}; set {{ {field.Identifier} = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof({field.Identifier})));}}}}");
                }
                sb.Append($"public {className}(", true);
                int count = 0;
                foreach (var field in fields)
                {
                    sb.Append($"{(count == 0 ? "" : ", ")}{field.TypeName} {field.Identifier}");
                    count++;
                }
                sb.AppendLine(")", false);

                sb.AppendLine("{");

                using (sb.Indent())
                {
                    foreach (var field in fields)
                    {
                        sb.AppendLine($"this.{field.Identifier} = {field.Identifier};");
                    }
                }

                sb.AppendLine("}");

                sb.Append("public void Deconstruct (", true);
                count = 0;
                foreach (var field in fields)
                {
                    sb.Append($"{(count == 0 ? "" : ", ")}out {field.TypeName} {field.Identifier}");
                    count++;
                }
                sb.AppendLine(")", false);
                sb.AppendLine("{");
                using (sb.Indent())
                {
                    foreach (var field in fields)
                    {
                        sb.AppendLine($"{field.Identifier} = this.{field.Identifier};");
                    }
                }
                sb.AppendLine("}");
            }

            sb.AppendLine("}");
        }

        if (hasNamespace)
        {
            sb.AppendLine("}");
        }

        return sb.ToString();
    }
}

internal class PDataClassSyntaxReceiver : ISyntaxReceiver
{
    public List<ClassDeclarationSyntax> PDataClasses = new List<ClassDeclarationSyntax>();

    public void OnVisitSyntaxNode(SyntaxNode syntaxNode)
    {
        if (syntaxNode is not ClassDeclarationSyntax cds)
        {
            return;
        }

        var node = syntaxNode as ClassDeclarationSyntax;

        foreach (var item in cds.AttributeLists)
        {
            foreach (var attr in item.Attributes)
            {
                string attrName = attr.Name.ToString();

                switch (attrName)
                {
                    case "PDataClass":
                    case "System.PDataClass":
                    case "PDataClassAttribute":
                    case "System.PDataClassAttribute":
                        if (node!.Modifiers.Any(Microsoft.CodeAnalysis.CSharp.SyntaxKind.PartialKeyword)) PDataClasses.Add(cds);
                        return;
                }
            }
        }
    }
}