using Peponi.Utility.Helpers;

namespace Peponi.ConsoleTest;

internal class Program
{
    private static void Main(string[] args)
    {
        string path = "C:\\Temp\\\\\\";
        List<FileInfo> files = new List<FileInfo>();

        files.AddRange(DirectoryHelper.GetFileInfos(path));

        var subDirectoryInfo = DirectoryHelper.GetDirectoryInfos(path);

        foreach (var info in subDirectoryInfo)
        {
            files.AddRange(DirectoryHelper.GetFileInfos($@"{info.FullName}\"));
        }

        var sorted = files.OrderBy(info => info.LastWriteTime);
        Console.WriteLine(string.Join("\n", sorted));
    }
}