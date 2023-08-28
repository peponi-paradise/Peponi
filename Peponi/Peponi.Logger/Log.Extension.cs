using System.Runtime.CompilerServices;

namespace Peponi.Logger
{
    /// <summary>
    /// string extension for easy logging.<br/><br/>
    /// ```C#<br/><br/>
    /// "LogMessage".WriteLog(LogType.Application);<br/><br/>
    /// ```
    /// </summary>
    public static class LogExtension
    {
        public static void WriteLog(this string message, object logType)
        {
            Log.WriteLog(logType.ToString(), message);
        }

        public static string GetmethodName([CallerMemberName] string methodname = "") => methodname;
    }
}