using System.Text;

namespace Peponi.CodeGenerators;

internal class CodeBuilder
{
    internal int Indent = 0;
    private StringBuilder _builder = new StringBuilder();

    public override string ToString()
    {
        return _builder.ToString();
    }

    public void Append(string text, bool indent = false)
    {
        if (indent)
        {
            IndentTab();
        }

        _builder.Append(text);
    }

    public void AppendLine(string text, bool indent = true)
    {
        if (indent)
        {
            IndentTab();
        }

        _builder.AppendLine(text);
    }

    private void IndentTab()
    {
        for (int i = 0; i < Indent; i++)
        {
            _builder.Append("\t");
        }
    }
}