using Peponi.Math.UnitConversion;

namespace Peponi.ConsoleTest;

[Peponi.CodeGenerators.Class.PDataClass]
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
        //    list.Add(new TimeClass(now.AddSeconds(rand), rand));
        //}
        ////var windows = await list.ToTumblingWindowsAsync(TimeSpan.FromMinutes(1), (x) => x.CurrentTime, (x) => x.Time);
        //var windows = await HoppingWindows.ToHoppingWindowsAsync(list, now - TimeSpan.FromSeconds(1500), now + TimeSpan.FromSeconds(20), TimeSpan.FromMinutes(1), (x) => x.CurrentTime, (x) => x.Time);
        //foreach (var window in windows)
        //{
        //    Console.WriteLine(window.Count());
        //    if (window.Count() != 0) Console.WriteLine(window.Sum());
        //    if (window.Count() != 0) Console.WriteLine(window.Min());
        //    if (window.Count() != 0) Console.WriteLine(window.Max());
        //    if (window.Count() != 0) Console.WriteLine(window.Average());
        //    Console.WriteLine("----------------------------------------");
        //}

        //List<ValueClass> list = new();
        //for (int i = 0; i < 10; i++)
        //{
        //    int rand = Random.Shared.Next(10);
        //    list.Add(new ValueClass() { _value = rand });
        //}
        //List<double> list2 = new();
        //for (int i = 0; i < 10; i++)
        //{
        //    int rand = Random.Shared.Next(10);
        //    list2.Add(rand);
        //}
        //var t = HoppingWindows.ToHoppingWindows(list, 4, 2, (x) => x._value);
        //foreach (var x in t)
        //{
        //    Console.WriteLine(x.Count());
        //    Console.WriteLine(x.Sum());
        //    Console.WriteLine(x.Max());
        //    Console.WriteLine(x.Min());
        //    Console.WriteLine(x.Average());
        //    Console.WriteLine("----------------------------------------");
        //}

        //DateTime now = DateTime.Now;
        //List<TimeClass> times = new();
        //for (int i = 1; i < 11; i++)
        //{
        //    int rand = Random.Shared.Next(10);
        //    var data = new TimeClass(now + TimeSpan.FromSeconds(rand) + TimeSpan.FromMilliseconds(rand), i);
        //    times.Add(data);
        //}
        //foreach (var item in times)
        //{
        //    Console.WriteLine($"{item.CurrentTime.ToString("mm.ss.fff")}, {item.Data}");
        //}
        //Console.WriteLine("\n----------------------------------------");

        //DateTime now = DateTime.Parse("2023.09.11 08:00:00");
        //List<TimeClass> dates = new();
        //for (int i = 0; i < 10000; i++)
        //{
        //    int add = Random.Shared.Next(2);
        //    if (add == 1) dates.Add(new TimeClass(now + TimeSpan.FromSeconds(i), i));
        //}
        //var t = SlidingWindows.ToSlidingWindows(dates, now, DateTime.MaxValue, TimeSpan.FromSeconds(5), (x) => x.CurrentTime, (x) => x.Data);
        //foreach (var x in t)
        //{
        //    Console.WriteLine(x.Count());
        //    Console.WriteLine(x.Min());
        //    Console.WriteLine(x.Max());
        //    Console.WriteLine("----------------------------------------");
        //}

        double ksi = 654321;
        Console.WriteLine(UnitConvert.ConvertPressure(ksi, PressureUnit.ksi, PressureUnit.at));
    }
}