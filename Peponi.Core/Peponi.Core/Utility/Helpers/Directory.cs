namespace Peponi.Core.Utility.Helpers;

public static class DirectoryHelper
{
    /// <summary>
    /// Create directory
    /// </summary>
    /// <param name="path"></param>
    public static void CreateDirectory(string path)
    {
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);

            // 바로 만들어지지 않더라..
            Thread.Sleep(100);
        }
    }

    /// <summary>
    /// Get directory size
    /// </summary>
    /// <param name="path"></param>
    /// <returns>Directory size as byte</returns>
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

    /// <summary>
    /// Get directory size
    /// </summary>
    /// <param name="path"></param>
    /// <returns>Directory size as mb</returns>
    public static int GetDirectorySizeMB(string path)
    {
        return (int)(GetDirectorySize(path) / Math.Pow(1024, 2));
    }

    /// <summary>
    /// Get directory info
    /// </summary>
    /// <param name="path"></param>
    /// <returns><see cref="DirectoryInfo"/></returns>
    /// <exception cref="ArgumentException"></exception>
    /// <exception cref="AccessViolationException"></exception>
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

    /// <summary>
    /// Get all sub directory infos
    /// </summary>
    /// <param name="path"></param>
    /// <returns></returns>
    public static List<DirectoryInfo> GetSubDirectoryInfos(string path)
    {
        var baseInfo = GetDirectoryInfo(path);
        return baseInfo.EnumerateDirectories("*", SearchOption.AllDirectories).ToList();
    }

    /// <summary>
    /// Get file infos for given directory
    /// </summary>
    /// <param name="path"></param>
    /// <returns></returns>
    public static List<FileInfo> GetFileInfos(string path)
    {
        return GetDirectoryInfo(path).GetFiles().ToList();
    }

    /// <summary>
    /// Get file infos including sub directories
    /// </summary>
    /// <param name="path"></param>
    /// <returns></returns>
    public static List<FileInfo> GetFileInfosIncludingSubDirectories(string path)
    {
        List<FileInfo> infos = new();
        infos.AddRange(GetDirectoryInfo(path).GetFiles());
        foreach (var dirInfo in GetSubDirectoryInfos(path)) infos.AddRange(dirInfo.GetFiles());
        return infos;
    }

    /// <summary>
    /// Get files with the specified name
    /// </summary>
    /// <param name="fileInfos"></param>
    /// <param name="matchingName"></param>
    /// <returns></returns>
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