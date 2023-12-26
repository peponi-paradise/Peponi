using Peponi.Core.Utility.Helpers;

namespace Peponi.Logger;

/// <summary>
/// Configure logger options.<br/>
/// Logger will work by given options.<br/>
/// Concrete options are on their sections.
/// </summary>
public class LogOption : IEquatable<LogOption?>
{
    /// <summary>
    /// Logging base key name
    /// </summary>
    public string LoggerName;

    /// <summary>
    /// Configure directory tree
    /// </summary>
    public LogDirectoryOption DirectoryOption = new();

    /// <summary>
    /// Configure log file size and creating rule
    /// </summary>
    public LogFileOption FileOption = new();

    /// <summary>
    /// Configure log message format
    /// </summary>
    public LogMessageOption MessageOption = new();

    /// <summary>
    /// Configure logger options
    /// </summary>
    /// <param name="loggerName">Logging base key name</param>
    /// <param name="directoryOption">Configure directory tree</param>
    /// <param name="fileOption">Configure log file size and creating rule</param>
    public LogOption(string loggerName, LogDirectoryOption directoryOption, LogFileOption fileOption)
    {
        LoggerName = loggerName;
        DirectoryOption = directoryOption;
        FileOption = fileOption;
    }

    /// <summary>
    /// Configure logger options
    /// </summary>
    /// <param name="loggerName">Logging base key name</param>
    /// <param name="directoryOption">Configure directory tree</param>
    /// <param name="fileOption">Configure log file size and creating rule</param>
    /// <param name="messageOption">Configure log message format</param>
    public LogOption(string loggerName, LogDirectoryOption directoryOption, LogFileOption fileOption, LogMessageOption messageOption)
    {
        LoggerName = loggerName;
        DirectoryOption = directoryOption;
        FileOption = fileOption;
        MessageOption = messageOption;
    }

    public override bool Equals(object? obj)
    {
        return Equals(obj as LogOption);
    }

    public bool Equals(LogOption? other)
    {
        return other is not null &&
               LoggerName == other.LoggerName &&
               EqualityComparer<LogDirectoryOption>.Default.Equals(DirectoryOption, other.DirectoryOption) &&
               EqualityComparer<LogFileOption>.Default.Equals(FileOption, other.FileOption) &&
               EqualityComparer<LogMessageOption>.Default.Equals(MessageOption, other.MessageOption);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(LoggerName, DirectoryOption, FileOption, MessageOption);
    }

    public static bool operator ==(LogOption? left, LogOption? right)
    {
        return EqualityComparer<LogOption>.Default.Equals(left, right);
    }

    public static bool operator !=(LogOption? left, LogOption? right)
    {
        return !(left == right);
    }
}

public class LogDirectoryOption : IEquatable<LogDirectoryOption?>
{
    /// <summary>
    /// Root path of log
    /// </summary>
    public string RootPath = $@"{Environment.CurrentDirectory}\Log\";

    /// <summary>
    /// Configure directory tree
    /// </summary>
    public List<LogDirectoryTree> DirectoryTree = new()
                {
                    LogDirectoryTree.None
                };

    internal string CreateFolderTree(string loggerName, DateTime logTime)
    {
        string rtnPath = (string)RootPath.Clone();
        foreach (var tree in DirectoryTree)
        {
            rtnPath = Path.Combine(rtnPath, GetPath(tree));
            DirectoryHelper.CreateDirectory(rtnPath);
        }
        return rtnPath;

        string GetPath(LogDirectoryTree treeItem)
        {
            return treeItem switch
            {
                LogDirectoryTree.None => "",
                LogDirectoryTree.LoggerName => @$"{loggerName}\",
                LogDirectoryTree.DateTime_Second => $@"{logTime:ss}\",
                LogDirectoryTree.DateTime_Minute => $@"{logTime:mm}\",
                LogDirectoryTree.DateTime_Hour => $@"{logTime:HH}\",
                LogDirectoryTree.DateTime_Day => $@"{logTime:dd}\",
                LogDirectoryTree.DateTime_Month => $@"{logTime:MM}\",
                LogDirectoryTree.DateTime_Year => $@"{logTime:yyyy}\",
                _ => throw new ArgumentException($"Not supported tree item : {treeItem}")
            };
        }
    }

    public static bool operator ==(LogDirectoryOption? left, LogDirectoryOption? right)
    {
        return EqualityComparer<LogDirectoryOption>.Default.Equals(left, right);
    }

    public static bool operator !=(LogDirectoryOption? left, LogDirectoryOption? right)
    {
        return !(left == right);
    }

    public override bool Equals(object? obj)
    {
        return Equals(obj as LogDirectoryOption);
    }

    public bool Equals(LogDirectoryOption? other)
    {
        return other is not null &&
               RootPath == other.RootPath &&
               EqualityComparer<List<LogDirectoryTree>>.Default.Equals(DirectoryTree, other.DirectoryTree);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(RootPath, DirectoryTree);
    }
}

public class LogFileOption : IEquatable<LogFileOption?>
{
    /// <summary>
    /// Unit : mb <br/><br/>
    /// Value : <br/>
    /// 0 = Inf <br/>
    /// X = X mb <br/>
    /// </summary>
    public uint LogFileSize = 0;

    private List<LogFileCreatingRule> _fileCreatingRules = new()
                {
                    LogFileCreatingRule.DateTime_Year,
                    LogFileCreatingRule.DateTime_Month,
                    LogFileCreatingRule.DateTime_Day,
                    LogFileCreatingRule.Underbar,
                    LogFileCreatingRule.LoggerName
                };

    /// <summary>
    /// Configure log file's creating rule
    /// </summary>
    public List<LogFileCreatingRule> FileCreatingRules
    {
        get => _fileCreatingRules;
        set
        {
            if (!value.Contains(LogFileCreatingRule.LoggerName))
            {
                throw new ArgumentException($"File creating rules should have {nameof(LogFileCreatingRule.LoggerName)}");
            }
            else
            {
                _fileCreatingRules = value;
            }
        }
    }

    /// <summary>
    /// Log file's extension
    /// </summary>
    public string Extension = ".log";

    internal string GetFileName(string loggerName, DateTime logTime)
    {
        string name = string.Empty;
        foreach (var rule in FileCreatingRules)
        {
            name += GetPath(rule);
        }
        return name + Extension;

        string GetPath(LogFileCreatingRule rule)
        {
            return rule switch
            {
                LogFileCreatingRule.LoggerName => loggerName,
                LogFileCreatingRule.DateTime_Second => $"{logTime:ss}",
                LogFileCreatingRule.DateTime_Minute => $"{logTime:mm}",
                LogFileCreatingRule.DateTime_Hour => $"{logTime:HH}",
                LogFileCreatingRule.DateTime_Day => $"{logTime:dd}",
                LogFileCreatingRule.DateTime_Month => $"{logTime:MM}",
                LogFileCreatingRule.DateTime_Year => $"{logTime:yyyy}",
                LogFileCreatingRule.Dot => ".",
                LogFileCreatingRule.Space => " ",
                LogFileCreatingRule.Underbar => "_",
                LogFileCreatingRule.Dash => "-",
                _ => throw new ArgumentException($"Not supported rule item : {rule}")
            };
        }
    }

    public static bool operator ==(LogFileOption? left, LogFileOption? right)
    {
        return EqualityComparer<LogFileOption>.Default.Equals(left, right);
    }

    public static bool operator !=(LogFileOption? left, LogFileOption? right)
    {
        return !(left == right);
    }

    public override bool Equals(object? obj)
    {
        return Equals(obj as LogFileOption);
    }

    public bool Equals(LogFileOption? other)
    {
        return other is not null &&
               LogFileSize == other.LogFileSize &&
               EqualityComparer<List<LogFileCreatingRule>>.Default.Equals(FileCreatingRules, other.FileCreatingRules) &&
               Extension == other.Extension;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(LogFileSize, FileCreatingRules, Extension);
    }
}

public class LogMessageOption : IEquatable<LogMessageOption?>
{
    /// <summary>
    /// Configure log message
    /// </summary>
    public List<LogMessagePattern> MessagePatterns = new();

    public LogMessageOption()
    {
        MessagePatterns = new()
        {
            LogMessagePattern.DateTime,
            LogMessagePattern.LoggerName,
            LogMessagePattern.LogType,
            LogMessagePattern.Message,
            LogMessagePattern.NewLine
        };
    }

    public LogMessageOption(List<LogMessagePattern> patterns)
    {
        MessagePatterns = patterns.ToList();
    }

    internal string BuildMessage((DateTime DateTime, LogType LogType, string Message, LogOption Option) contents)
    {
        if (MessagePatterns.Count == 0 || MessagePatterns.Contains(LogMessagePattern.None)) return contents.Message;
        string rtnString = string.Empty;
        foreach (var pattern in MessagePatterns)
        {
            rtnString += GetMessagePattern(pattern);
        }
        return rtnString;

        string GetMessagePattern(LogMessagePattern patternItem)
        {
            return patternItem switch
            {
                LogMessagePattern.None => "",
                LogMessagePattern.LoggerName => $"[{contents.Option.LoggerName}] ",
                LogMessagePattern.DateTime => $"[{contents.DateTime:yyyy-MM-dd HH.mm.ss.fff}] ",
                LogMessagePattern.LogType => $"[{contents.LogType}] ",
                LogMessagePattern.Message => $"{contents.Message} ",
                LogMessagePattern.NewLine => Environment.NewLine,
                _ => throw new ArgumentException($"Not supported pattern item : {patternItem}")
            };
        }
    }

    public static bool operator ==(LogMessageOption? left, LogMessageOption? right)
    {
        return EqualityComparer<LogMessageOption>.Default.Equals(left, right);
    }

    public static bool operator !=(LogMessageOption? left, LogMessageOption? right)
    {
        return !(left == right);
    }

    public override bool Equals(object? obj)
    {
        return Equals(obj as LogMessageOption);
    }

    public bool Equals(LogMessageOption? other)
    {
        return other is not null &&
               EqualityComparer<List<LogMessagePattern>>.Default.Equals(MessagePatterns, other.MessagePatterns);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(MessagePatterns);
    }
}