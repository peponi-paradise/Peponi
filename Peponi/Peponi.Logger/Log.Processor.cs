using Peponi.Core.Enums;
using Peponi.Logger.Writer;
using Peponi.Utility.Helpers;
using System.Collections.Concurrent;
using System.Text;

namespace Peponi.Logger.Processor;

internal static class LogProcessor
{
    private static Dictionary<string, BlockingCollection<(DateTime DateTime, string LogType, string Message)>> _logQueue = new Dictionary<string, BlockingCollection<(DateTime DateTime, string LogType, string Message)>>();

    private static string _rootPath = string.Empty;
    private static string _logFilePattern = string.Empty;
    private static LogWriteOption _writeOption;
    private static DateTimeUnit _timeUnit;

    private static List<Thread> _workers = new List<Thread>();

    internal static void Configuration(LogWriteOption writeOption, List<string> logTypes, string rootPath, string logFilePattern)
    {
        // 필요한 작업 처리
        _writeOption = writeOption;
        _rootPath = rootPath;
        _logFilePattern = logFilePattern;
        _timeUnit = DateTimeHelper.GetDateTimeUnit(logFilePattern);

        // 쓰레드 시작
        Thread worker;
        switch (_writeOption)
        {
            case LogWriteOption.OneFile:
                _logQueue.Add(LogWriteOption.OneFile.ToString(), new BlockingCollection<(DateTime DateTime, string LogType, string Message)>());
                worker = new Thread(() => LogProcessThread(LogWriteOption.OneFile.ToString()));
                worker.IsBackground = true;
                worker.Start();
                _workers.Add(worker);
                break;

            case LogWriteOption.SeperateFile:
            case LogWriteOption.SeperateFolder:
                foreach (var logType in logTypes)
                {
                    _logQueue.Add(logType, new BlockingCollection<(DateTime DateTime, string LogType, string Message)>());
                    worker = new Thread(() => LogProcessThread(logType));
                    worker.IsBackground = true;
                    worker.Start();
                    _workers.Add(worker);
                }
                break;
        }
    }

    internal static void WriteLog(DateTime dateTime, string logType, string message)
    {
        switch (_writeOption)
        {
            case LogWriteOption.OneFile:
                _logQueue[LogWriteOption.OneFile.ToString()].Add((dateTime, logType, message));
                break;

            case LogWriteOption.SeperateFile:
            case LogWriteOption.SeperateFolder:
                _logQueue[logType].Add((dateTime, logType, message));
                break;
        }
    }

    private static void LogProcessThread(string logType)
    {
        List<(DateTime DateTime, string LogType, string Message)> logContents = new List<(DateTime DateTime, string LogType, string Message)>();

        while (true)
        {
            if (logContents.Count > 100000)
            {
                LogProcess(logContents);
            }
            else if (_logQueue[logType].Count > 0)
            {
                logContents.Add(_logQueue[logType].Take());
            }
            else if (logContents.Count != 0)
            {
                LogProcess(logContents);
            }
            else
            {
                logContents.Add(_logQueue[logType].Take());
            }
        }
    }

    private static void LogProcess(List<(DateTime DateTime, string LogType, string Message)> logContents)
    {
        switch (_writeOption)
        {
            case LogWriteOption.OneFile:
                OneFileProcess(logContents);
                break;

            case LogWriteOption.SeperateFile:
            case LogWriteOption.SeperateFolder:
                MultiFileProcess(logContents);
                break;
        }
        logContents.Clear();
    }

    private static void OneFileProcess(List<(DateTime DateTime, string LogType, string Message)> logContents)
    {
        logContents = logContents.OrderBy(x => x.DateTime).ToList();

        while (logContents.Count > 0)
        {
            DateTime logTime = logContents[0].DateTime;
            StringBuilder builder = new StringBuilder();
            int removeCount = 0;

            for (int index = 0; index < logContents.Count; index++)
            {
                // Time unit check
                if (DateTimeHelper.DateTimeUnitEquals(_timeUnit, logTime, logContents[index].DateTime))
                {
                    builder.Append($"{logContents[index].DateTime.ToString("HH:mm:ss.fff")} [{logContents[index].LogType}] - {logContents[index].Message}{Environment.NewLine}");
                    removeCount++;
                }
                else
                {
                    break;
                }
            }

            // Send to Writer queue
            string logPath = GetTotalPath(_writeOption, _rootPath, logTime, _logFilePattern);
            LogWriter.WriteLog(LogWriteOption.OneFile.ToString(), logPath, builder.ToString());

            logContents.RemoveRange(0, removeCount);
        }
    }

    private static void MultiFileProcess(List<(DateTime DateTime, string LogType, string Message)> logContents)
    {
        Dictionary<(string, string), StringBuilder> writeContents = new Dictionary<(string, string), StringBuilder>();

        logContents = logContents.OrderBy(x => x.LogType).ThenBy(x => x.DateTime).ToList();

        while (logContents.Count > 0)
        {
            DateTime logTime = logContents[0].DateTime;
            string logType = logContents[0].LogType;
            StringBuilder builder = new StringBuilder();
            int removeCount = 0;

            for (int index = 0; index < logContents.Count; index++)
            {
                // Time unit check
                // Log type check
                if (DateTimeHelper.DateTimeUnitEquals(_timeUnit, logTime, logContents[index].DateTime) &&
                    logType == logContents[index].LogType)
                {
                    builder.Append($"{logContents[index].DateTime.ToString("HH:mm:ss.fff")} - {logContents[index].Message}{Environment.NewLine}");
                    removeCount++;
                }
                else
                {
                    break;
                }
            }

            string logPath = GetTotalPath(_writeOption, _rootPath, logTime, _logFilePattern, logType);

            if (!writeContents.ContainsKey((logType, logPath))) writeContents.Add((logType, logPath), builder);
            else writeContents[(logType, logPath)].Append(builder);

            logContents.RemoveRange(0, removeCount);
        }

        // Send to Writer queue
        foreach (var logItem in writeContents)
        {
            LogWriter.WriteLog(logItem.Key.Item1, logItem.Key.Item2, logItem.Value.ToString());
        }
    }

    private static string GetTotalPath(LogWriteOption writeOption, string rootPath, DateTime logTime, string logPattern, string? key = null)
    {
        return writeOption switch
        {
            LogWriteOption.OneFile => $@"{rootPath}\Log{$"_{logTime.ToString(logPattern)}"}.log",
            LogWriteOption.SeperateFile => $@"{rootPath}\{key}{$"_{logTime.ToString(logPattern)}"}.log",
            LogWriteOption.SeperateFolder => $@"{rootPath}\{key}\{key}{$"_{logTime.ToString(logPattern)}"}.log",
            _ => throw new NotImplementedException($"{writeOption} is not defined")
        };
    }
}