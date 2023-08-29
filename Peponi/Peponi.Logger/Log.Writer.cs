using Peponi.Core.Enums;
using Peponi.Utility.Helpers;
using System.Collections.Concurrent;
using System.Text;

namespace Peponi.Logger.Writer;

internal static class LogWriter
{
    private static Dictionary<string, BlockingCollection<(string LogPath, string Message)>> _logQueue = new Dictionary<string, BlockingCollection<(string LogPath, string Message)>>();

    private static List<Thread> _workers = new List<Thread>();
    private static LogWriteOption _writeOption;
    private static uint _logSize = 0;

    internal static void Configuration(LogWriteOption writeOption, List<string> logTypes, uint logSize)
    {
        // 필요한 작업 처리
        _writeOption = writeOption;
        _logSize = logSize;

        // 쓰레드 시작
        Thread worker;
        switch (_writeOption)
        {
            case LogWriteOption.OneFile:
                _logQueue.Add(LogWriteOption.OneFile.ToString(), new BlockingCollection<(string LogPath, string Message)>());
                worker = new Thread(() => LogWriteThread(LogWriteOption.OneFile.ToString()));
                worker.IsBackground = true;
                worker.Start();
                _workers.Add(worker);
                break;

            case LogWriteOption.SeperateFile:
            case LogWriteOption.SeperateFolder:
                foreach (var logType in logTypes)
                {
                    _logQueue.Add(logType, new BlockingCollection<(string LogPath, string Message)>());
                    worker = new Thread(() => LogWriteThread(logType));
                    worker.IsBackground = true;
                    worker.Start();
                    _workers.Add(worker);
                }
                break;
        }
    }

    internal static void WriteLog(string logType, string logPath, string message)
    {
        _logQueue[logType].Add((logPath, message));
    }

    private static void LogWriteThread(string logType)
    {
        List<(string LogPath, string Message)> logContents = new List<(string LogPath, string Message)>();

        while (true)
        {
            if (_logQueue[logType].Count > 0)
            {
                logContents.Add(_logQueue[logType].Take());
            }
            else if (logContents.Count != 0)
            {
                Dump(logContents);
            }
            else
            {
                logContents.Add(_logQueue[logType].Take());
            }
        }
    }

    private static void Dump(List<(string LogPath, string Message)> logContents)
    {
        Dictionary<string, StringBuilder> writeContents = new Dictionary<string, StringBuilder>();

        while (logContents.Count > 0)
        {
            string logPath = logContents[0].LogPath;
            StringBuilder builder = new StringBuilder();
            int removeCount = 0;

            for (int index = 0; index < logContents.Count; index++)
            {
                if (logContents[index].LogPath == logPath)
                {
                    builder.Append(logContents[index].Message);
                    removeCount++;
                }
                else
                {
                    break;
                }
            }

            if (!writeContents.ContainsKey(logPath)) writeContents.Add(logPath, builder);
            else writeContents[logPath].Append(builder);

            logContents.RemoveRange(0, removeCount);
        }

        foreach (var logItem in writeContents)
        {
            if (_logSize == 0)
            {
                File.AppendAllText(logItem.Key, logItem.Value.ToString());
            }
            else
            {
                File.AppendAllText(GetAppenderName(logItem.Key), logItem.Value.ToString());
            }
        }
    }

    private static string GetAppenderName(string logfilePath)
    {
        var fileInfos = DirectoryHelper.GetFileInfos(Path.GetDirectoryName(logfilePath)!);
        var extractedInfos = fileInfos.ExtractFiles(logfilePath);

        if (extractedInfos.Count == 0)
        {
            return logfilePath;
        }
        else
        {
            int appenderIndex = 0;

            foreach (var fileInfo in extractedInfos)
            {
                CheckAppenderIndex(fileInfo, ref appenderIndex);
            }

            if (appenderIndex == 0)
            {
                return logfilePath;
            }
            else
            {
                return @$"{Path.GetDirectoryName(logfilePath)}\{Path.GetFileNameWithoutExtension(logfilePath)}_{appenderIndex}.log";
            }
        }
    }

    private static void CheckAppenderIndex(FileInfo logFile, ref int appenderIndex)
    {
        if ((uint)((double)logFile.Length / 1024 / 1024) >= _logSize)
        {
            appenderIndex++;
        }
    }
}