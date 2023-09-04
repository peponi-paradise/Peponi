using Peponi.Math.Windowing;

namespace Peponi.ConsoleTest;

internal class Program
{
    private class TimeClass
    {
        public DateTime CurrentTime { get; set; }
        public DateTime Time { get; set; }
    }

    private static async Task Main(string[] args)
    {
        DateTime now = DateTime.Now;
        List<TimeClass> list = new List<TimeClass>();
        for (int i = 1; i < 1000; i++)
        {
            int rand = Random.Shared.Next(1000);
            list.Add(new TimeClass() { CurrentTime = now.AddSeconds(rand), Time = DateTime.MinValue.AddSeconds(rand) });
        }
        //var windows = await list.ToTumblingWindowsAsync(TimeSpan.FromMinutes(1), (x) => x.CurrentTime, (x) => x.Time);
        var windows = await TumblingWindows.ToTumblingWindowsAsync(list, now - TimeSpan.FromSeconds(1500), TimeSpan.FromMinutes(1), (x) => x.CurrentTime, (x) => x.Time);
        foreach (var window in windows)
        {
            Console.WriteLine(window.Count());
            //Console.WriteLine(window.Sum());
            if (window.Count() != 0) Console.WriteLine(window.Min());
            if (window.Count() != 0) Console.WriteLine(window.Max());
            //Console.WriteLine(window.Average());
            Console.WriteLine("----------------------------------------");
        }

        //List<int> test = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        //test.Sum();
        //var t = test.ToTumblingWindows(2);
        //foreach (var x in t)
        //{
        //    Console.WriteLine(x.Sum());
        //    Console.WriteLine(x.Max());
        //    Console.WriteLine(x.Min());
        //    Console.WriteLine(x.Average());
        //}

        //DateTime now = DateTime.Now;
        //List<TimeSpan> times = new List<TimeSpan>();
        //for (int i = 0; i < 1000; i++)
        //{
        //    int rand = Random.Shared.Next(1000);
        //    times.Add(TimeSpan.FromSeconds(rand));
        //}
        //var t = await times.ToTumblingWindowsAsync(30);
        //foreach (var x in t)
        //{
        //    Console.WriteLine(x.Count());
        //    Console.WriteLine(x.Min());
        //    Console.WriteLine(x.Max());
        //    Console.WriteLine(x.Sum());
        //    Console.WriteLine(x.Average());
        //}
    }
}