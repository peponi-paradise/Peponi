using Peponi.Utility.MiniDump;

namespace Peponi.Utility.Tests;

[TestClass]
public class Minidump
{
    [TestMethod]
    public void Dump()
    {
        try
        {
            // Assume an exception occurred.
            throw new Exception("Test");
        }
        catch
        {
            // Write dump files
            MiniDumpWriter.Dump();
        }
    }
}