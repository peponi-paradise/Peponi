namespace Peponi.Utility.Helpers;

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

    public static List<FileInfo> GetFileInfos(string path)
    {
        if (Directory.Exists(path))
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(path);
            return directoryInfo.GetFiles().ToList();
        }
        else throw new AccessViolationException($"{path} is not exists on system");
    }

    public static List<FileInfo> ExtractFiles(this List<FileInfo> fileInfos, string filePath)
    {
        List<FileInfo> infos = new List<FileInfo>();

        foreach (var info in fileInfos)
        {
            if (Path.GetFileNameWithoutExtension(info.FullName).Contains(Path.GetFileNameWithoutExtension(filePath)))
            {
                infos.Add(info);
            }
        }

        return infos;
    }
}