using Peponi.Logger.Writer;
using System.Collections.Concurrent;
using System.Text;

namespace Peponi.Logger.Processor;

internal class LogProcessor
{
    private BlockingCollection<(DateTime DateTime, LogType LogType, string Message, LogOption Option)> _logQueue = new();

    private LogWriter? _writer;

    private Thread? _worker;
    private CancellationTokenSource cancellationToken = new();

    public LogProcessor()
    {
        _writer = new();
        StartWorker();
    }

    ~LogProcessor()
    {
        cancellationToken.Cancel();
    }

    internal void WriteLog(LogType logType, string message, DateTime logTime, LogOption option)
    {
        _logQueue.Add((logTime, logType, message, option), cancellationToken.Token);
    }

    private bool StartWorker()
    {
        try
        {
            // 쓰레드 시작
            _worker = new Thread(LogProcessThread);
            _worker.IsBackground = true;
            _worker.Start();
            return true;
        }
        catch
        {
            return false;
        }
    }

    private void LogProcessThread()
    {
        List<(DateTime DateTime, LogType LogType, string Message, LogOption Option)> logContents = new();

        while (cancellationToken.Token.IsCancellationRequested == false)
        {
            try
            {
                if (logContents.Count > 100)
                {
                    StringMergeProcess(logContents);
                    logContents.Clear();
                }
                else if (_logQueue.Count > 0)
                {
                    logContents.Add(_logQueue.Take(cancellationToken.Token));
                }
                else if (logContents.Count != 0)
                {
                    StringMergeProcess(logContents);
                    logContents.Clear();
                }
                else
                {
                    logContents.Add(_logQueue.Take(cancellationToken.Token));
                }
            }
            catch (OperationCanceledException)
            {
                break;
            }
        }
    }

    private void StringMergeProcess(List<(DateTime DateTime, LogType LogType, string Message, LogOption Option)> logContents)
    {
        logContents = logContents.OrderBy(x => x.DateTime).ToList();

        while (logContents.Count > 0)
        {
            DateTime logTime = logContents[0].DateTime;
            LogOption currentOption = logContents[0].Option;
            StringBuilder builder = new StringBuilder();
            int removeCount = 0;

            for (int index = 0; index < logContents.Count; index++)
            {
                if (logContents[index].Option == currentOption && DateTimeCompare(logTime, logContents[index].DateTime, currentOption))
                {
                    builder.Append(logContents[index].Option.MessageOption.BuildMessage(logContents[index]));
                    removeCount++;
                }
                else
                {
                    break;
                }
            }

            // Send to Writer queue
            string logPath = Path.Combine(CheckFolderPath(logTime, currentOption), currentOption.FileOption.GetFileName(currentOption.LoggerName, logTime));
            _writer?.WriteLog(logPath, builder.ToString(), currentOption);

            logContents.RemoveRange(0, removeCount);
        }
    }

    private string CheckFolderPath(DateTime logTime, LogOption option)
    {
        return option.DirectoryOption.CreateFolderTree(option.LoggerName, logTime);
    }

    private bool DateTimeCompare(DateTime date1, DateTime date2, LogOption option)
    {
        if (option.FileOption.FileCreatingRules.Contains(LogFileCreatingRule.DateTime_Second))
        {
            return date1.Second == date2.Second;
        }
        else if (option.FileOption.FileCreatingRules.Contains(LogFileCreatingRule.DateTime_Minute))
        {
            return date1.Minute == date2.Minute;
        }
        else if (option.FileOption.FileCreatingRules.Contains(LogFileCreatingRule.DateTime_Hour))
        {
            return date1.Hour == date2.Hour;
        }
        else if (option.FileOption.FileCreatingRules.Contains(LogFileCreatingRule.DateTime_Day))
        {
            return date1.Day == date2.Day;
        }
        else if (option.FileOption.FileCreatingRules.Contains(LogFileCreatingRule.DateTime_Month))
        {
            return date1.Month == date2.Month;
        }
        else return date1.Year == date2.Year;
    }
}