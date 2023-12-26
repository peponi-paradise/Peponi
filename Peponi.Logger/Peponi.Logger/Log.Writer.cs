using Peponi.Utility.Helpers;
using System.Collections.Concurrent;
using System.Text;

namespace Peponi.Logger.Writer;

internal class LogWriter
{
    private BlockingCollection<(string LogPath, string Message, LogOption Option)> _logQueue = new();
    private Dictionary<string, StreamWriter> _writeStreams = new();

    private CancellationTokenSource _cancellationToken = new();
    private Thread? _worker;

    public LogWriter()
    {
        StartWorker();
    }

    ~LogWriter()
    {
        _cancellationToken.Cancel();
    }

    internal void WriteLog(string logPath, string message, LogOption option)
    {
        _logQueue.Add((logPath, message, option), _cancellationToken.Token);
    }

    private bool StartWorker()
    {
        try
        {
            // 쓰레드 시작
            _worker = new Thread(LogWriteThread);
            _worker.IsBackground = true;
            _worker.Start();
            return true;
        }
        catch
        {
            return false;
        }
    }

    private void LogWriteThread()
    {
        List<(string LogPath, string Message, LogOption Option)> logContents = new();

        while (_cancellationToken.Token.IsCancellationRequested == false)
        {
            try
            {
                if (_logQueue.Count > 0)
                {
                    logContents.Add(_logQueue.Take(_cancellationToken.Token));
                }
                else if (logContents.Count != 0)
                {
                    Dump(logContents);
                }
                else
                {
                    logContents.Add(_logQueue.Take(_cancellationToken.Token));
                }
            }
            catch (OperationCanceledException)
            {
                break;
            }
        }
    }

    private void Dump(List<(string LogPath, string Message, LogOption Option)> logContents)
    {
        Dictionary<(string LogPath, LogOption Option), StringBuilder> writeContents = new();

        while (logContents.Count > 0)
        {
            string logPath = logContents[0].LogPath;
            LogOption currentOption = logContents[0].Option;
            StringBuilder builder = new StringBuilder();
            int removeCount = 0;

            for (int index = 0; index < logContents.Count; index++)
            {
                if (logContents[index].LogPath == logPath && logContents[index].Option == currentOption)
                {
                    builder.Append(logContents[index].Message);
                    removeCount++;
                }
                else
                {
                    break;
                }
            }

            if (!writeContents.ContainsKey((logPath, currentOption))) writeContents.Add((logPath, currentOption), builder);
            else writeContents[(logPath, currentOption)].Append(builder);

            logContents.RemoveRange(0, removeCount);
        }

        foreach (var logItem in writeContents)
        {
            string logFilePath = GetAppenderName(logItem.Key.LogPath, logItem.Key.Option);
            if (!_writeStreams.ContainsKey(logFilePath)) _writeStreams.Add(logFilePath, new(logFilePath, true));
            _writeStreams[logFilePath].Write(logItem.Value);
        }

        if (_logQueue.Count == 0)
        {
            // Close all streams when nothing to write
            foreach (var item in _writeStreams)
            {
                item.Value.Close();
            }
            _writeStreams.Clear();
        }
        else
        {
            // Go to next writing process
        }
    }

    private string GetAppenderName(string logfilePath, LogOption option)
    {
        if (option.FileOption.LogFileSize == 0)
        {
            return logfilePath;
        }
        else
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
                    CheckAppenderIndex(fileInfo, option, ref appenderIndex);
                }

                if (appenderIndex == 0)
                {
                    return logfilePath;
                }
                else
                {
                    return @$"{Path.GetDirectoryName(logfilePath)}\{Path.GetFileNameWithoutExtension(logfilePath)}_{appenderIndex}{Path.GetExtension(logfilePath)}";
                }
            }
        }
    }

    private void CheckAppenderIndex(FileInfo logFile, LogOption option, ref int appenderIndex)
    {
        if ((uint)Math.Round((double)logFile.Length / 1024) > option.FileOption.LogFileSize * 1024)
        {
            appenderIndex++;
        }
    }
}