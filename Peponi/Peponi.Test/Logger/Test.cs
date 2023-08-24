using Peponi.Logger;
using System.Collections.Generic;
using System.Threading;

namespace Peponi.Test.Logger
{
    internal enum TestType
    {
        A,
        B,
        C,
        D,
        E,
    }

    internal class LogTest
    {
        private List<Thread> _workers = new List<Thread>();

        public LogTest()
        {
            LogStart();
        }

        private void LogStart()
        {
            Log.Configuration(new TestType(), Core.Enums.WriteOption.SeperateFolder, null, "yyyy-MM-dd_HH_mm_ss");

            int workers = 0;

            for (workers = 10; workers > 0; workers--)
            {
                var t = new Thread(WriteLog);
                t.IsBackground = true;
                t.Start();
                _workers.Add(t);
            }
        }

        private void WriteLog()
        {
            int writeCount = 0;

            for (writeCount = 100000; writeCount > 0; writeCount--)
            {
                $"{Thread.CurrentThread.ManagedThreadId} : A".WriteLog(TestType.A);
                $"{Thread.CurrentThread.ManagedThreadId} : B".WriteLog(TestType.B);
                $"{Thread.CurrentThread.ManagedThreadId} : C".WriteLog(TestType.C);

                Log.WriteLog(TestType.D, $"{Thread.CurrentThread.ManagedThreadId} : D");
                Log.WriteLog(TestType.E, $"{Thread.CurrentThread.ManagedThreadId} : E");
            }
        }
    }
}