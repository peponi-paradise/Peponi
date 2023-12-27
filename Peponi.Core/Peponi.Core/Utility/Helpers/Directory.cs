namespace Peponi.Core.Utility.Helpers;

public static class DirectoryHelper
{
    public static void CreateDirectory(string path)
    {
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);

            // 바로 만들어지지 않더라..
            Thread.Sleep(100);
        }
    }

    public static long GetDirectorySize(string path)
    {
        var directoryInfo = CheckPath(path);
        long size = 0;

        foreach (var fileInfo in directoryInfo.GetFiles("*", SearchOption.AllDirectories))
        {
            size += fileInfo.Length;
        }

        return size;
    }

    public static int GetDirectorySizeMB(string path)
    {
        return (int)(GetDirectorySize(path) / Math.Pow(1024, 2));
    }

    public static List<DirectoryInfo> GetDirectoryInfos(string path)
    {
        var baseInfo = CheckPath(path);
        return baseInfo.EnumerateDirectories("*", SearchOption.AllDirectories).ToList();
    }

    public static List<FileInfo> GetFileInfos(string path)
    {
        return CheckPath(path).GetFiles().ToList();
    }

    public static List<FileInfo> GetFileInfosIncludingSubdirectories(string path)
    {
        List<FileInfo> infos = new();
        foreach (var dirInfo in GetDirectoryInfos(path)) infos.AddRange(dirInfo.GetFiles());
        return infos;
    }

    private static DirectoryInfo CheckPath(string path)
    {
        path = $@"{path}\";

        if (!Path.IsPathFullyQualified(path))
        {
            throw new ArgumentException($"{path} is not fully qualified");
        }

        string directoryName = Path.GetDirectoryName(path)!;
        if (!Directory.Exists(directoryName))
        {
            throw new AccessViolationException($"{path} is not exists on system");
        }

        return new DirectoryInfo(Path.GetDirectoryName(path)!);
    }
}

public static class DirectoryHelperExtension
{
    public static List<FileInfo> ExtractFiles(this List<FileInfo> fileInfos, string extractingName)
    {
        List<FileInfo> infos = new List<FileInfo>();

        foreach (var info in fileInfos)
        {
            if (Path.GetFileNameWithoutExtension(info.FullName).Contains(Path.GetFileNameWithoutExtension(extractingName)))
            {
                infos.Add(info);
            }
        }

        return infos;
    }
}