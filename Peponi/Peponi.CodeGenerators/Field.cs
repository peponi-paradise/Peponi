using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis;

namespace Peponi.CodeGenerators;

internal struct FieldInfo
{
    public string Identifier;
    public string TypeName;
}

internal static class Field
{
    internal static string GetFieldName(string identifier)
    {
        string rtnString = string.Empty;

        if (identifier[0] == '_')
        {
            rtnString = identifier.Substring(1);
        }

        if (char.IsLower(identifier[0]))
        {
            rtnString = identifier[0].ToString().ToUpper() + identifier.Substring(1);
        }

        if (char.IsUpper(identifier[0]))
        {
            rtnString = identifier.ToUpper();
        }

        return rtnString;
    }

    internal static List<FieldInfo> GetFields(Compilation compilation, ClassDeclarationSyntax cls)
    {
        List<FieldInfo> fields = new List<FieldInfo>();

        var model = compilation.GetSemanticModel(cls.SyntaxTree);

        foreach (FieldDeclarationSyntax field in cls.DescendantNodes().OfType<FieldDeclarationSyntax>())
        {
            foreach (var item in field.Declaration.Variables)
            {
                FieldInfo info = new FieldInfo
                {
                    Identifier = item.Identifier.ValueText,
                    TypeName = field.Declaration.Type.ToString()
                };

                fields.Add(info);
            }
        }

        return fields;
    }
}