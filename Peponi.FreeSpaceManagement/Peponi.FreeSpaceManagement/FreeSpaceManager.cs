using Peponi.Core.Utility.Helpers;

namespace Peponi.StorageManagement;

public class FreeSpaceManager
{
    /// <summary>
    /// Indicates manager thread is running
    /// </summary>
    public bool IsRunning => _isRun;

    private string _rootPath = $@"C:\Log\";

    /// <summary>
    /// File management base folder
    /// </summary>
    public string RootPath
    {
        get => _rootPath;
        set
        {
            if (Path.IsPathFullyQualified(value)) _rootPath = value;
            else throw new ArgumentException($"{value}{Environment.NewLine}is not fully qualified");
        }
    }

    /// <summary>
    /// Minimum free space %
    /// </summary>
    public int DiskPreservePercent { get; set; } = 20;

    private volatile bool _isRun = false;
    private Thread? _worker;

    public FreeSpaceManager(string rootPath, int diskPreservePercent)
    {
        RootPath = rootPath;
        DiskPreservePercent = diskPreservePercent;
    }

    public void StartManager()
    {
        if (!_isRun)
        {
            _isRun = true;

            _worker = new Thread(ManagerThread);
            _worker.IsBackground = true;
            _worker.Start();
        }
    }

    public void StopManager()
    {
        _isRun = false;
    }

    private void ManagerThread()
    {
        while (_isRun)
        {
            if (StorageHelper.GetFreeSpacePercent(RootPath) < DiskPreservePercent)
            {
                RemoveOldest();
            }
            Thread.Sleep(2000);
        }
    }

    private void RemoveOldest()
    {
        List<FileInfo> files = DirectoryHelper.GetFileInfosIncludingSubDirectories(RootPath);

        var sorted = files.OrderBy(info => info.LastWriteTime).ToList();

        while (sorted.Count() != 0 && StorageHelper.GetFreeSpacePercent(RootPath) < DiskPreservePercent)
        {
            File.Delete(sorted.First().FullName);
            sorted.RemoveAt(0);
            Thread.Sleep(20);
        }
    }
}