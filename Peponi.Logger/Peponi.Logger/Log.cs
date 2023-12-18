using Peponi.Logger.Processor;

namespace Peponi.Logger;

public class Log
{
    private LogOption _option;
    private static LogProcessor _processor = new();

    public Log(LogOption option)
    {
        _option = option;
    }

    public static Log GetLogger(LogOption? option = null)
    {
        return option != null ? new Log(option) : new Log(GetDefaultOptions());
    }

    private static LogOption GetDefaultOptions()
    {
        LogDirectoryOption dirOption = new LogDirectoryOption()
        {
            DirectoryTree = new List<LogDirectoryTree>()
                {
                    LogDirectoryTree.None
                }
        };
        LogFileOption fileOption = new LogFileOption()
        {
            LogFileSize = 100,
            FileCreatingRules = new List<LogFileCreatingRule>()
                {
                    LogFileCreatingRule.DateTime_Year,
                    LogFileCreatingRule.DateTime_Month,
                    LogFileCreatingRule.DateTime_Day,
                    LogFileCreatingRule.Underbar,
                    LogFileCreatingRule.LoggerName
                }
        };
        LogMessageOption msgOption = new LogMessageOption();

        return new LogOption("Log", dirOption, fileOption, msgOption);
    }

    public void WriteLog(string message, DateTime? dateTime = null)
    {
        dateTime ??= DateTime.Now;
        _processor.WriteLog(message, (DateTime)dateTime, _option);
    }
}