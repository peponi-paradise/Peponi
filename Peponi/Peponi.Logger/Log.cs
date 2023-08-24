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
    public static class LogExtension
    {
        public static void WriteLog(this string message, object logType)
        {
            Log.WriteLog(logType.ToString(), message);
        }

        public static string GetmethodName([CallerMemberName] string methodname = "") => methodname;
    }

    public static class Log
    {
        public static void Configuration(Enum logType, WriteOption option, string path = null, string logPattern = null)
        {
            var logTypes = Enum.GetNames(logType.GetType()).ToList();

            path = path ?? $@"{Environment.CurrentDirectory}\Log\";
            logPattern = logPattern ?? "yyyy-MM-dd";

            CheckLogPath(option, path, logTypes);

            LogProcessor.Configuration(option, logTypes, path, logPattern);
            LogWriter.Configuration(option, logTypes);
        }

        public static void WriteLog(object logType, string message)
        {
            LogProcessor.WriteLog(DateTime.Now, logType.ToString(), message);
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