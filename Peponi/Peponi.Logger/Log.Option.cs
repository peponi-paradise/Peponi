using Peponi.Core.Enums;

namespace Peponi.Logger;

public class LogOption
{
    /// <summary>
    /// Any enum type user defined
    /// </summary>
    public Enum? LogType;

    public LogWriteOption LogWriteOption = LogWriteOption.SeperateFolder;

    /// <summary>
    /// Root path of log
    /// </summary>
    public string RootPath = $@"{Environment.CurrentDirectory}\Log\";

    /// <summary>
    /// Saving time unit of log.<br/>
    /// Equal to DateTime.Now.ToString() format<br/><br/>
    /// ex:<br/>
    /// "yyyy-MM-dd"
    /// </summary>
    public string LogFilePattern = "yyyy-MM-dd";

    /// <summary>
    /// Unit : mb <br/><br/>
    /// Value : <br/>
    /// 0 = Inf <br/>
    /// X = X mb <br/>
    /// </summary>
    public uint LogFileSize = 0;

    public LogOption()
    { }

    public LogOption(Enum? logType, LogWriteOption logWriteOption, string rootPath, string logFilePattern, uint logFileSize)
    {
        LogType = logType;
        LogWriteOption = logWriteOption;
        RootPath = rootPath;
        LogFilePattern = logFilePattern;
        LogFileSize = logFileSize;
    }
}