namespace Peponi.Core.Enums;

public enum LogWriteOption
{
    /// <summary>
    /// All logs are in one file
    /// </summary>
    OneFile = 1,

    /// <summary>
    /// Separate files by log type
    /// </summary>
    SeperateFile = 2,

    /// <summary>
    /// Separate folders by log type
    /// </summary>
    SeperateFolder = 3,
}