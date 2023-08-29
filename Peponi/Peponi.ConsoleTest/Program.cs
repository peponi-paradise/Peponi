using Peponi.Logger;

namespace Peponi.ConsoleTest;

internal class Program
{
    private enum LogType
    {
        A, B, C, D, E, F,
    }

    private static void Main(string[] args)
    {
        LogOption logOption = new LogOption()
        {
            LogType = new LogType(),
            LogWriteOption = Core.Enums.LogWriteOption.SeperateFolder,
            RootPath = @"C:\temp\logTest",
            LogFilePattern = "yyyy-MM-dd_HH_mm_ss",
            LogFileSize = 0
        };
        Log.Configuration(logOption);

        for (int i = 0; i < 10; i++)
        {
            Thread t = new Thread(LogThread);
            t.IsBackground = true;
            t.Start();
        }

        Console.ReadLine();
    }

    private static void LogThread()
    {
        int seed = Thread.CurrentThread.ManagedThreadId;
        Random rand = new Random(seed);
        int logCount = 1000;

        while (logCount-- > 0)
        {
            Thread.Sleep(rand.Next(seed));
        }
    }
}