using Peponi.Utility.Helpers;

namespace Peponi.StorageManagement;

public static class FreeSpaceManager
{
    public static bool IsRunning => _isRun;

    private static int _diskPreservePercent = 20;
    private static volatile bool _isRun = false;
    private static string _rootPath = $@"C:\Log\";
    private static Thread _worker = new Thread(ManagerThread);

    public static void StartManager(int diskPreservePercent, string rootPath)
    {
        _diskPreservePercent = diskPreservePercent;
        _rootPath = $@"{rootPath}\";

        _isRun = true;

        _worker = new Thread(ManagerThread);
        _worker.IsBackground = true;
        _worker.Start();
    }

    public static void StopManager()
    {
        _isRun = false;
    }

    private static void ManagerThread()
    {
        while (_isRun)
        {
            if (StorageHelper.GetFreeSpacePercent(_rootPath) < _diskPreservePercent)
            {
                RemoveOldest();
            }
            Thread.Sleep(2000);
        }
    }

    private static void RemoveOldest()
    {
        List<FileInfo> files = new List<FileInfo>();

        files.AddRange(DirectoryHelper.GetFileInfos(_rootPath));

        var subDirectoryInfo = DirectoryHelper.GetDirectoryInfos(_rootPath);

        foreach (var info in subDirectoryInfo)
        {
            files.AddRange(DirectoryHelper.GetFileInfos($@"{info.FullName}\"));
        }

        var sorted = files.OrderBy(info => info.LastWriteTime);

        if (sorted.Count() != 0)
        {
            File.Delete(sorted.First().FullName);
        }
    }
}