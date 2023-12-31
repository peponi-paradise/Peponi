﻿namespace Peponi.Core.Utility.Helpers;

public static class StorageHelper
{
    /// <summary>
    /// Get total disk size
    /// </summary>
    /// <param name="path"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
    public static double GetDiskSizeGB(string path)
    {
        CheckRootPath(path);

        foreach (var drive in DriveInfo.GetDrives())
        {
            if (drive.Name.Contains(Path.GetPathRoot(path)!))
            {
                return drive.TotalSize / Math.Pow(1024, 3);
            }
        }

        throw new ArgumentException($"The root path of {path} is not exist on system");
    }

    /// <summary>
    /// Get free space size of disk
    /// </summary>
    /// <param name="path"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
    public static double GetFreeSpaceGB(string path)
    {
        CheckRootPath(path);

        foreach (var drive in DriveInfo.GetDrives())
        {
            if (drive.Name.Contains(Path.GetPathRoot(path)!))
            {
                return drive.AvailableFreeSpace / Math.Pow(1024, 3);
            }
        }

        throw new ArgumentException($"The root path of {path} is not exist on system");
    }

    /// <summary>
    /// Get free space size of disk
    /// </summary>
    /// <param name="path"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
    public static int GetFreeSpacePercent(string path)
    {
        CheckRootPath(path);

        foreach (var drive in DriveInfo.GetDrives())
        {
            if (drive.Name.Contains(Path.GetPathRoot(path)!))
            {
                double free = drive.AvailableFreeSpace / Math.Pow(1024, 3);
                double total = drive.TotalSize / Math.Pow(1024, 3);

                return (int)(free / total * 100);
            }
        }

        throw new ArgumentException($"The root path of {path} is not exist on system");
    }

    private static void CheckRootPath(string path)
    {
        if (!Path.IsPathRooted(path))
        {
            throw new ArgumentException($"{path} is not contains root path");
        }
    }
}