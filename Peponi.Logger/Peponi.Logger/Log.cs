using Peponi.Logger.Processor;

namespace Peponi.Logger;

public class Log
{
    /// <summary>
    /// Options for logging
    /// </summary>
    public LogOption Option;

    private static Dictionary<string, Log> _loggers = new();
    private LogProcessor _processor = new();

    internal Log(LogOption option)
    {
        Option = option;
    }

    /// <summary>
    /// Get logger for given name
    /// </summary>
    /// <param name="loggerName"></param>
    /// <returns></returns>
    public static Log GetLogger(string loggerName)
    {
        var option = GetDefaultOptions();
        option.LoggerName = loggerName;
        return GetLoggerCore(option);
    }

    /// <summary>
    /// Get logger for given option
    /// </summary>
    /// <param name="option"></param>
    /// <returns></returns>
    public static Log GetLogger(LogOption? option = null)
    {
        if (option == null) option = GetDefaultOptions();
        return GetLoggerCore(option);
    }

    /// <summary>
    /// Write Log<br/>
    /// <see cref="LogType.General"/> is selected by default
    /// </summary>
    /// <param name="message"></param>
    /// <param name="dateTime"></param>
    public void Write(string message, DateTime? dateTime = null)
    {
        WriteCore(LogType.General, message, dateTime);
    }

    /// <summary>
    /// Write Log
    /// </summary>
    /// <param name="logType"></param>
    /// <param name="message"></param>
    /// <param name="dateTime"></param>
    public void Write(LogType logType, string message, DateTime? dateTime = null)
    {
        WriteCore(logType, message, dateTime);
    }

    private static Log GetLoggerCore(LogOption option)
    {
        if (_loggers.TryGetValue(option.LoggerName, out Log? value)) return value;
        else
        {
            Log logger = new(option);
            _loggers.Add(option.LoggerName, logger);
            return logger;
        }
    }

    private static LogOption GetDefaultOptions()
    {
        LogDirectoryOption dirOption = new LogDirectoryOption();
        LogFileOption fileOption = new LogFileOption();
        LogMessageOption msgOption = new LogMessageOption();

        return new LogOption("Log", dirOption, fileOption, msgOption);
    }

    private void WriteCore(LogType logType, string message, DateTime? dateTime = null)
    {
        dateTime ??= DateTime.Now;
        _processor.WriteLog(logType, message, (DateTime)dateTime, Option);
    }
}