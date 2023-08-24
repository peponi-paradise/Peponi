using Peponi.Core.Enums;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;

namespace Peponi.Logger.Writer
{
    internal static class LogWriter
    {
        private static Dictionary<string, BlockingCollection<(string LogPath, string Message)>> _logQueue = new Dictionary<string, BlockingCollection<(string LogPath, string Message)>>();

        private static List<Thread> _workers = new List<Thread>();
        private static WriteOption _writeOption;

        internal static void Configuration(WriteOption writeOption, List<string> logTypes)
        {
            // 필요한 작업 처리
            _writeOption = writeOption;

            // 쓰레드 시작
            switch (_writeOption)
            {
                case WriteOption.OneFile:
                    _logQueue.Add(WriteOption.OneFile.ToString(), new BlockingCollection<(string LogPath, string Message)>());
                    var _worker = new Thread(() => LogWriteThread(WriteOption.OneFile.ToString()));
                    _worker.IsBackground = true;
                    _worker.Start();
                    _workers.Add(_worker);
                    break;

                case WriteOption.SeperateFile:
                case WriteOption.SeperateFolder:
                    foreach (var logType in logTypes)
                    {
                        _logQueue.Add(logType, new BlockingCollection<(string LogPath, string Message)>());
                        var worker = new Thread(() => LogWriteThread(logType));
                        worker.IsBackground = true;
                        worker.Start();
                        _workers.Add(worker);
                    }
                    break;
            }
        }

        internal static void WriteLog(string logType, string logPath, string message)
        {
            _logQueue[logType].Add((logPath, message));
        }

        private static void LogWriteThread(string logType)
        {
            List<(string LogPath, string Message)> logContents = new List<(string LogPath, string Message)>();

            while (true)
            {
                if (_logQueue[logType].Count > 0)
                {
                    logContents.Add(_logQueue[logType].Take());
                }
                else if (logContents.Count != 0)
                {
                    Dump(logContents);
                }
                else
                {
                    logContents.Add(_logQueue[logType].Take());
                }
            }
        }

        private static void Dump(List<(string LogPath, string Message)> logContents)
        {
            Dictionary<string, StringBuilder> writeContents = new Dictionary<string, StringBuilder>();

            while (logContents.Count > 0)
            {
                string logPath = logContents[0].LogPath;
                StringBuilder builder = new StringBuilder();
                int removeCount = 0;

                for (int index = 0; index < logContents.Count; index++)
                {
                    if (logContents[index].LogPath == logPath)
                    {
                        builder.Append(logContents[index].Message);
                        removeCount++;
                    }
                    else
                    {
                        break;
                    }
                }

                logContents.RemoveRange(0, removeCount);

                if (!writeContents.ContainsKey(logPath)) writeContents.Add(logPath, builder);
                else writeContents[logPath].Append(builder);
            }

            foreach (var logItem in writeContents)
            {
                File.AppendAllText(logItem.Key, logItem.Value.ToString());
            }
        }
    }
}