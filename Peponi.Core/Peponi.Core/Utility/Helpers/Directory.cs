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
        var directoryInfo = GetDirectoryInfo(path);
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

    public static DirectoryInfo GetDirectoryInfo(string path)
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

    public static List<DirectoryInfo> GetSubDirectoryInfos(string path)
    {
        var baseInfo = GetDirectoryInfo(path);
        return baseInfo.EnumerateDirectories("*", SearchOption.AllDirectories).ToList();
    }

    public static List<FileInfo> GetFileInfos(string path)
    {
        return GetDirectoryInfo(path).GetFiles().ToList();
    }

    public static List<FileInfo> GetFileInfosIncludingSubDirectories(string path)
    {
        List<FileInfo> infos = new();
        infos.AddRange(GetDirectoryInfo(path).GetFiles());
        foreach (var dirInfo in GetSubDirectoryInfos(path)) infos.AddRange(dirInfo.GetFiles());
        return infos;
    }

    public static List<FileInfo> FindFiles(this List<FileInfo> fileInfos, string matchingName)
    {
        List<FileInfo> infos = new List<FileInfo>();
        string checkName = Path.GetFileNameWithoutExtension(matchingName);

        foreach (var info in fileInfos)
        {
            if (Path.GetFileNameWithoutExtension(info.FullName).Contains(checkName))
            {
                infos.Add(info);
            }
        }

        return infos;
    }
}