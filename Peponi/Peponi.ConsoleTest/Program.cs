using Peponi.Math.Windowing;
using Peponi.CodeGenerators.Class;

namespace Peponi.ConsoleTest;

[PDataClass]
internal partial class TimeClass
{
    private DateTime currentTime;
    private double data;
}

internal class Program
{
    public partial class ValueClass
    {
        public double _value;
        private double _value2;
    }

    private static async Task Main(string[] args)
    {
        //DateTime now = DateTime.Now;
        //List<TimeClass> list = new List<TimeClass>();
        //for (int i = 1; i < 1000; i++)
        //{
        //    int rand = Random.Shared.Next(1000);
        //    list.Add(new TimeClass() { CurrentTime = now.AddSeconds(rand), Time = rand });
        //}
        ////var windows = await list.ToTumblingWindowsAsync(TimeSpan.FromMinutes(1), (x) => x.CurrentTime, (x) => x.Time);
        //var windows = await TumblingWindows.ToTumblingWindowsAsync(list, now - TimeSpan.FromSeconds(1500), now + TimeSpan.FromSeconds(20), TimeSpan.FromMinutes(1), (x) => x.CurrentTime, (x) => x.Time);
        //foreach (var window in windows)
        //{
        //    Console.WriteLine(window.Count());
        //    if (window.Count() != 0) Console.WriteLine(window.Sum());
        //    if (window.Count() != 0) Console.WriteLine(window.Min());
        //    if (window.Count() != 0) Console.WriteLine(window.Max());
        //    if (window.Count() != 0) Console.WriteLine(window.Average());
        //    Console.WriteLine("----------------------------------------");
        //}

        List<ValueClass> list = new();
        for (int i = 0; i < 10; i++)
        {
            int rand = Random.Shared.Next(10);
            list.Add(new ValueClass() { _value = rand });
        }
        List<double> list2 = new();
        for (int i = 0; i < 10; i++)
        {
            int rand = Random.Shared.Next(10);
            list2.Add(rand);
        }
        var t = HoppingWindows.ToHoppingWindows(list, 4, 2, (x) => x._value);
        foreach (var x in t)
        {
            Console.WriteLine(x.Count());
            Console.WriteLine(x.Sum());
            Console.WriteLine(x.Max());
            Console.WriteLine(x.Min());
            Console.WriteLine(x.Average());
            Console.WriteLine("----------------------------------------");
        }

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