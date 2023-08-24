using Peponi.Core.Enums;
using Peponi.Core.Helpers;
using Peponi.Logger.Writer;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Peponi.Logger.Processor
{
    internal static class LogProcessor
    {
        private static Dictionary<string, BlockingCollection<(DateTime DateTime, string LogType, string Message)>> _logQueue = new Dictionary<string, BlockingCollection<(DateTime DateTime, string LogType, string Message)>>();

        private static string _logPath;
        private static string _logPattern;
        private static WriteOption _writeOption;
        private static TimeUnit _timeUnit;

        private static List<Thread> _workers = new List<Thread>();

        internal static void Configuration(WriteOption writeOption, List<string> logTypes, string logPath, string logPattern)
        {
            // 필요한 작업 처리
            _writeOption = writeOption;
            _logPath = logPath;
            _logPattern = logPattern;
            _timeUnit = TimeHelper.DateTimeFormatTest(logPattern);

            // 쓰레드 시작
            switch (_writeOption)
            {
                case WriteOption.OneFile:
                    _logQueue.Add(WriteOption.OneFile.ToString(), new BlockingCollection<(DateTime DateTime, string LogType, string Message)>());
                    var _worker = new Thread(() => LogProcessThread(WriteOption.OneFile.ToString()));
                    _worker.IsBackground = true;
                    _worker.Start();
                    _workers.Add(_worker);
                    break;

                case WriteOption.SeperateFile:
                case WriteOption.SeperateFolder:
                    foreach (var logType in logTypes)
                    {
                        _logQueue.Add(logType, new BlockingCollection<(DateTime DateTime, string LogType, string Message)>());
                        var worker = new Thread(() => LogProcessThread(logType));
                        worker.IsBackground = true;
                        worker.Start();
                        _workers.Add(worker);
                    }
                    break;
            }
        }

        internal static void WriteLog(DateTime dateTime, string logType, string message)
        {
            switch (_writeOption)
            {
                case WriteOption.OneFile:
                    _logQueue[WriteOption.OneFile.ToString()].Add((dateTime, logType, message));
                    break;

                case WriteOption.SeperateFile:
                case WriteOption.SeperateFolder:
                    _logQueue[logType].Add((dateTime, logType, message));
                    break;
            }
        }

        private static void LogProcessThread(string logType)
        {
            List<(DateTime DateTime, string LogType, string Message)> logContents = new List<(DateTime DateTime, string LogType, string Message)>();

            while (true)
            {
                if (logContents.Count > 100000)
                {
                    LogProcess(logContents);
                }
                else if (_logQueue[logType].Count > 0)
                {
                    logContents.Add(_logQueue[logType].Take());
                }
                else if (logContents.Count != 0)
                {
                    LogProcess(logContents);
                }
                else
                {
                    logContents.Add(_logQueue[logType].Take());
                }
            }
        }

        private static void LogProcess(List<(DateTime DateTime, string LogType, string Message)> logContents)
        {
            while (logContents.Count > 0)
            {
                switch (_writeOption)
                {
                    case WriteOption.OneFile:
                        OneFileProcess(logContents);
                        logContents.Clear();
                        break;

                    case WriteOption.SeperateFile:
                    case WriteOption.SeperateFolder:
                        MultiFileProcess(logContents);
                        logContents.Clear();
                        break;
                }
            }
        }

        private static void OneFileProcess(List<(DateTime DateTime, string LogType, string Message)> logContents)
        {
            logContents = logContents.OrderBy(x => x.DateTime).ToList();

            while (logContents.Count > 0)
            {
                DateTime logTime = logContents[0].DateTime;
                StringBuilder builder = new StringBuilder();
                int removeCount = 0;

                for (int index = 0; index < logContents.Count; index++)
                {
                    // Time check
                    if (TimeHelper.DateTimeEquals(_timeUnit, logTime, logContents[index].DateTime))
                    {
                        builder.Append($"{logContents[index].DateTime.ToString("HH:mm:ss.fff")} [{logContents[index].LogType}] - {logContents[index].Message}{Environment.NewLine}");
                        removeCount++;
                    }
                    else
                    {
                        break;
                    }
                }

                // Send to Writer queue
                string logPath = GetTotalPath(_writeOption, _logPath, logTime, _logPattern);
                LogWriter.WriteLog(WriteOption.OneFile.ToString(), logPath, builder.ToString());

                logContents.RemoveRange(0, removeCount);
            }
        }

        private static void MultiFileProcess(List<(DateTime DateTime, string LogType, string Message)> logContents)
        {
            Dictionary<(string, string), StringBuilder> writeContents = new Dictionary<(string, string), StringBuilder>();

            logContents = logContents.OrderBy(x => x.LogType).ThenBy(x => x.DateTime).ToList();

            while (logContents.Count > 0)
            {
                DateTime logTime = logContents[0].DateTime;
                string logType = logContents[0].LogType;
                StringBuilder builder = new StringBuilder();
                int removeCount = 0;

                for (int index = 0; index < logContents.Count; index++)
                {
                    // Time check
                    // Log type check
                    if (TimeHelper.DateTimeEquals(_timeUnit, logTime, logContents[index].DateTime) &&
                        logType == logContents[index].LogType)
                    {
                        builder.Append($"{logContents[index].DateTime.ToString("HH:mm:ss.fff")} - {logContents[index].Message}{Environment.NewLine}");
                        removeCount++;
                    }
                    else
                    {
                        break;
                    }
                }

                // Send to Writer queue
                string logPath = GetTotalPath(_writeOption, _logPath, logTime, _logPattern, logType);

                if (!writeContents.ContainsKey((logType, logPath))) writeContents.Add((logType, logPath), builder);
                else writeContents[(logType, logPath)].Append(builder);

                logContents.RemoveRange(0, removeCount);
            }

            foreach (var logItem in writeContents)
            {
                LogWriter.WriteLog(logItem.Key.Item1, logItem.Key.Item2, logItem.Value.ToString());
            }
        }

        private static string GetTotalPath(WriteOption writeOption, string basePath, DateTime logTime, string logPattern, string key = null)
        {
            string rtnString = string.Empty;

            switch (writeOption)
            {
                case WriteOption.OneFile:
                    rtnString = $@"{basePath}\Log{$"_{logTime.ToString(logPattern)}"}.log";
                    break;

                case WriteOption.SeperateFile:
                    rtnString = $@"{basePath}\{key}{$"_{logTime.ToString(logPattern)}"}.log";
                    break;

                case WriteOption.SeperateFolder:
                    rtnString = $@"{basePath}\{key}\{key}{$"_{logTime.ToString(logPattern)}"}.log";
                    break;
            }

            return rtnString;
        }
    }
}