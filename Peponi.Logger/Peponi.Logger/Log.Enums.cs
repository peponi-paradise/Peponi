namespace Peponi.Logger;

[Flags]
public enum LogType
{
    General = 0b_1,
    Info = 0b_10,
    Notify = 0b_100,
    Warning = 0b_1000,
    Error = 0b_10000,
    Exception = 0b_100000,
}

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
    DateTime = 10,

    LogType = 20,
    Message = 21,

    /// <summary>
    /// Environment.NewLine
    /// </summary>
    NewLine = 1000,
}