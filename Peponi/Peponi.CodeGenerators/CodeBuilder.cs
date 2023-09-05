using System.Text;

namespace Peponi.CodeGenerators.CodeBuilder;

internal class CodeBuilder
{
    internal int _indent = 0;
    private StringBuilder _builder = new StringBuilder();

    public IDisposable Indent(bool indent = true)
    {
        return new IndentMark(this, indent);
    }

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

    public void IndentTab()
    {
        for (int i = 0; i < _indent; i++)
        {
            _builder.Append("\t");
        }
    }

    public class IndentMark : IDisposable
    {
        private CodeBuilder _outer;

        public IndentMark(CodeBuilder outer, bool indent)
        {
            _outer = outer;

            if (indent)
            {
                _outer._indent++;
            }
        }

        public void Dispose()
        {
            _outer._indent--;
        }
    }
}