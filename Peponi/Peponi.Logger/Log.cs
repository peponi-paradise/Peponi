using Peponi.Logger.Processor;
using Peponi.Logger.Writer;
using Peponi.Utility.Helpers;

namespace Peponi.Logger;

/// <summary>
/// Logger class. <br/><br/>
/// Call <br/>
/// 1. <see cref="Configure(LogOption)"/> or <br/>
/// 2. <see cref="Configure(Enum, LogWriteOption, string?, string?, uint)"/> at startup.
/// </summary>
public static class Log
{
    private static bool _isConfigured = false;

    /// <summary>
    /// Configure logger.
    /// </summary>
    /// <param name="option">Log option</param>
    public static void Configure(LogOption option)
    {
        var logTypes = Enum.GetNames(option.LogType!.GetType()).ToList();
        CheckLogPath(option.LogWriteOption, $@"{option.RootPath}\", logTypes);

        LogProcessor.Configure(option.LogWriteOption, logTypes, $@"{option.RootPath}\", option.LogFilePattern);
        LogWriter.Configure(option.LogWriteOption, logTypes, option.LogFileSize);

        _isConfigured = true;
    }

    /// <summary>
    /// Configure logger.
    /// </summary>
    /// <param name="logType">Any enum type user defined</param>
    /// <param name="writeOption">
    /// 1. <see cref="LogWriteOption.OneFile"/><br/>
    /// 2. <see cref="LogWriteOption.SeperateFile"/><br/>
    /// 3. <see cref="LogWriteOption.SeperateFolder"/><br/>
    /// </param>
    /// <param name="rootPath">Root path of log</param>
    /// <param name="logFilePattern">
    /// Saving time unit of log.<br/>
    /// Equal to DateTime.Now.ToString() format<br/><br/>
    /// ex:<br/>
    /// "yyyy-MM-dd"
    /// </param>
    /// <param name="logFileSize">
    /// Unit : mb <br/><br/>
    /// Value : <br/>
    /// 0 = Inf <br/>
    /// X = X mb <br/>
    /// </param>
    public static void Configure(Enum logType, LogWriteOption writeOption, string? rootPath = null, string? logFilePattern = null, uint logFileSize = 0)
    {
        var logTypes = Enum.GetNames(logType.GetType()).ToList();

        rootPath = $@"{rootPath}\" ?? $@"{Environment.CurrentDirectory}\Log\";
        logFilePattern = logFilePattern ?? "yyyy-MM-dd";
        CheckLogPath(writeOption, rootPath, logTypes);

        LogProcessor.Configure(writeOption, logTypes, rootPath, logFilePattern);
        LogWriter.Configure(writeOption, logTypes, logFileSize);

        _isConfigured = true;
    }

    /// <summary>
    /// Write log.
    /// </summary>
    /// <param name="logType">Configrated log type</param>
    /// <param name="message">Message want to log</param>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="AccessViolationException"></exception>
    public static void WriteLog(Enum logType, string message)
    {
        if (_isConfigured)
        {
            // Exception will be raised case of null or unregistered log type
            LogProcessor.WriteLog(DateTime.Now, logType.ToString()!, message);
        }
        else
        {
            throw new AccessViolationException("Log is not configured");
        }
    }

    private static void CheckLogPath(LogWriteOption writeOption, string rootPath, List<string> logTypes)
    {
        DirectoryHelper.CreateDirectory(rootPath);

        if (writeOption == LogWriteOption.SeperateFolder)
        {
            foreach (var logType in logTypes)
            {
                var totalLogPath = $@"{rootPath}\{logType}\";

                DirectoryHelper.CreateDirectory(totalLogPath);
            }
        }
    }
}