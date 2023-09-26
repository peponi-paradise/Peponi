using System.Runtime.CompilerServices;

namespace Peponi.Logger;

/// <summary>
/// string extension for easy logging.
/// </summary>
public static class LogExtension
{
    public static void WriteLog(this string message, Enum logType)
    {
        Log.WriteLog(logType, message);
    }

    public static string GetmethodName([CallerMemberName] string methodname = "") => methodname;
}