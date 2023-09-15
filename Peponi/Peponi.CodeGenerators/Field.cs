using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Peponi.CodeGenerators;

internal struct FieldInfo
{
    public string Identifier;
    public string TypeName;
}

internal static class Field
{
    internal static string GetPropertyName(string identifier)
    {
        string rtnString = identifier.Clone().ToString();

        if (rtnString[0] == '_')
        {
            rtnString = identifier.Substring(1);
        }

        if (char.IsLower(rtnString[0]))
        {
            rtnString = rtnString[0].ToString().ToUpper() + rtnString.Substring(1);
        }
        else if (char.IsUpper(rtnString[0]))
        {
            rtnString = rtnString.ToUpper();
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