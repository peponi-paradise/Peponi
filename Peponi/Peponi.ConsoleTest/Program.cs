using Peponi.Math.Integration;

namespace Peponi.ConsoleTest;

internal class Program
{
    private static void Main(string[] args)
    {
        //List<double> xs = new List<double>() { 1, 2 };
        //List<double> ys = new List<double>() { 1, -2 };
        //Console.WriteLine(Trapezoidal.Integrate(xs, ys));

        //List<double> xs = new List<double>();
        //List<double> ys = new List<double>();
        //for (int i = -10; i <= 44; i++)
        //{
        //    xs.Add(i);
        //    ys.Add(3 * System.Math.Sin(0.5 * i));
        //}
        //Console.WriteLine(Trapezoidal.Integrate(xs, ys));
        //Console.WriteLine(Midpoint.Integrate(xs, ys));
        //Console.WriteLine(Simpson1over3.Integrate(xs, ys));
        //Console.WriteLine(Simpson3over8.Integrate(xs, ys));

        //Console.WriteLine((44 + 10) % 3);

        List<double> xs = new List<double>() { 0, 2, 4, 6, 8 };
        List<double> ys = new List<double>() { 0, 2.5244129544236893, 2.727892280477045, 0.4233600241796016, -2.2704074859237844 };
        //-10, -2, 6, -2, 0, -7, -6, 9, 0, -3,

        //Console.WriteLine(Trapezoidal.Integrate(xs, ys));
        Console.WriteLine(Midpoint.Integrate(xs, ys));
        //Console.WriteLine(Simpson1over3.Integrate(xs, ys));
        //Console.WriteLine(Simpson3over8.Integrate(xs, ys));

        //for (int i = 0; i < 10; i++)
        //{
        //    Console.Write($"{Random.Shared.Next(-10, 10)}, ");
        //}

        for (int i = 0; i <= 8; i += 2)
        {
            Console.Write($"{3 * System.Math.Sin(0.5 * i)}, ");
        }
        //0, 2.5244129544236893, 2.727892280477045, 0.4233600241796016, -2.2704074859237844,
    }
}