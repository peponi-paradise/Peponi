using Peponi.Utility.Helpers;

namespace Peponi.Logger;

/// <summary>
/// All log folders are divided by log folder tree
/// </summary>
public enum LogDirectoryTree
{
    None = 0,

    LoggerName = 1,

    /// <summary>
    /// DateTime format "ss"
    /// </summary>
    DateTime_Second = 10,

    /// <summary>
    /// DateTime format "mm"
    /// </summary>
    DateTime_Minute = 11,

    /// <summary>
    /// DateTime format "HH"
    /// </summary>
    DateTime_Hour = 12,

    /// <summary>
    /// DateTime format "dd"
    /// </summary>
    DateTime_Day = 13,

    /// <summary>
    /// DateTime format "MM"
    /// </summary>
    DateTime_Month = 14,

    /// <summary>
    /// DateTime format "yyyyy"
    /// </summary>
    DateTime_Year = 15,
}

public enum LogFileCreatingRule
{
    LoggerName = 0,
    CustomName = 1,

    /// <summary>
    /// DateTime format "ss"
    /// </summary>
    DateTime_Second = 10,

    /// <summary>
    /// DateTime format "mm"
    /// </summary>
    DateTime_Minute = 11,

    /// <summary>
    /// DateTime format "HH"
    /// </summary>
    DateTime_Hour = 12,

    /// <summary>
    /// DateTime format "dd"
    /// </summary>
    DateTime_Day = 13,

    /// <summary>
    /// DateTime format "MM"
    /// </summary>
    DateTime_Month = 14,

    /// <summary>
    /// DateTime format "yyyyy"
    /// </summary>
    DateTime_Year = 15,

    /// <summary>
    /// Insert ' . '
    /// </summary>
    Dot = 100,

    /// <summary>
    /// Insert empty space '  '
    /// </summary>
    Space = 102,

    /// <summary>
    /// Insert ' _ '
    /// </summary>
    Underbar = 103,

    /// <summary>
    /// Insert ' - '
    /// </summary>
    Dash = 104,
}

/// <summary>
/// All logs are written by given pattern
/// </summary>
public enum LogMessagePattern
{
    None = 0,

    LoggerName = 1,

    /// <summary>
    /// [yyyy.MM.dd HH:mm:ss.fff]
    /// </summary>
    DateTime = 2,

    Message = 3,

    /// <summary>
    /// Environment.NewLine
    /// </summary>
    NewLine = 1000,
}

public class LogOption : IEquatable<LogOption?>
{
    /// <summary>
    /// Logging base key name
    /// </summary>
    public string LoggerName;

    public LogDirectoryOption DirectoryOption = new();
    public LogFileOption FileOption = new();
    public LogMessageOption MessageOption = new();

    public LogOption(string loggerName, LogDirectoryOption directoryOption, LogFileOption fileOption)
    {
        LoggerName = loggerName;
        DirectoryOption = directoryOption;
        FileOption = fileOption;
    }

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

    public List<LogDirectoryTree> DirectoryTree = new();

    internal string CreateFolderTree(string loggerName, DateTime logTime)
    {
        string rtnPath = (string)RootPath.Clone();
        foreach (var tree in DirectoryTree)
        {
            if (tree != LogDirectoryTree.None)
            {
                rtnPath = Path.Combine(rtnPath, GetPath(tree));
                DirectoryHelper.CreateDirectory(rtnPath);
            }
        }
        return rtnPath;

        string GetPath(LogDirectoryTree treeItem)
        {
            return treeItem switch
            {
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

    public List<LogFileCreatingRule> FileCreatingRules = new();

    public string CustomName = "";
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
                LogFileCreatingRule.CustomName => CustomName,
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
               CustomName == other.CustomName &&
               Extension == other.Extension;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(LogFileSize, FileCreatingRules, CustomName, Extension);
    }
}

public class LogMessageOption : IEquatable<LogMessageOption?>
{
    public List<LogMessagePattern> MessagePatterns = new();

    public LogMessageOption()
    {
        MessagePatterns = new()
        {
            LogMessagePattern.DateTime,
            LogMessagePattern.LoggerName,
            LogMessagePattern.Message,
            LogMessagePattern.NewLine
        };
    }

    public LogMessageOption(List<LogMessagePattern> patterns)
    {
        MessagePatterns = patterns.ToList();
    }

    internal string BuildMessage((DateTime DateTime, string Message, LogOption Option) contents)
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