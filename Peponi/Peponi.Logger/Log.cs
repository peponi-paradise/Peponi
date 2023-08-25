using Peponi.Core.Enums;
using Peponi.Core.Helpers;
using Peponi.Logger.Processor;
using Peponi.Logger.Writer;
using System;
using System.Collections.Generic;
using System.Linq;
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

    /// <summary>
    /// Logger class.<br/>
    /// Call <see cref="Configuration(Enum, WriteOption, string, string)"/> at startup.
    /// </summary>
    public static class Log
    {
        private static bool _isConfigured = false;

        /// <summary>
        /// Configure logger.<br/><br/>
        /// ```C#<br/><br/>
        /// using Peponi.Logger;<br/><br/>
        /// Log.Configuration(new LogType(), Peponi.Core.Enums.WriteOption.SeperateFolder, $@"{Environment.CurrentDirectory}\{Paths.LogPath}", "yyyy-MM-dd_HH_mm_ss");<br/><br/>
        /// ```
        /// </summary>
        /// <param name="logType">Any enum type user defined</param>
        /// <param name="option">
        /// 1. <see cref="WriteOption.OneFile"/><br/>
        /// 2. <see cref="WriteOption.SeperateFile"/><br/>
        /// 3. <see cref="WriteOption.SeperateFolder"/><br/>
        /// </param>
        /// <param name="path">Base path of log</param>
        /// <param name="logFilePattern">
        /// Saving time unit of log.<br/>
        /// Equal to DateTime.Now.ToString() format<br/><br/>
        /// ex:<br/>
        /// "yyyy-MM-dd"
        /// </param>
        public static void Configuration(Enum logType, WriteOption option, string path = null, string logFilePattern = null)
        {
            var logTypes = Enum.GetNames(logType.GetType()).ToList();

            path = path ?? $@"{Environment.CurrentDirectory}\Log\";
            logFilePattern = logFilePattern ?? "yyyy-MM-dd";

            CheckLogPath(option, path, logTypes);

            LogProcessor.Configuration(option, logTypes, path, logFilePattern);
            LogWriter.Configuration(option, logTypes);

            _isConfigured = true;
        }

        /// <summary>
        /// Write log.<br/><br/>
        /// ```C#<br/><br/>
        /// Log.WriteLog(LogType.Application, "LogMessage");<br/><br/>
        /// ```
        /// </summary>
        /// <param name="logType">Equal to <see cref="Configuration(Enum, WriteOption, string, string)"/>'s logType</param>
        /// <param name="message">Message want to log</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="AccessViolationException"></exception>
        public static void WriteLog(object logType, string message)
        {
            if (_isConfigured)
            {
                LogProcessor.WriteLog(DateTime.Now, logType.ToString(), message);
            }
            else
            {
                throw new AccessViolationException("Log is not configured");
            }
        }

        private static void CheckLogPath(WriteOption writeOption, string basePath, List<string> logTypes)
        {
            DirectoryHelper.CreateDirectory(basePath);

            if (writeOption == WriteOption.SeperateFolder)
            {
                foreach (var logType in logTypes)
                {
                    var totalLogPath = $@"{basePath}\{logType}\";

                    DirectoryHelper.CreateDirectory(totalLogPath);
                }
            }
        }
    }
}