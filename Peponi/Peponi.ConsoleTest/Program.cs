using Peponi.Math.Integration;

namespace Peponi.ConsoleTest;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine(Trapezoidal.Integrate(value =>
        {
            return 3 * System.Math.Sin(0.5 * value);
        }, -10, 44, 54));
        Console.WriteLine(Midpoint.Integrate(value =>
        {
            return 3 * System.Math.Sin(0.5 * value);
        }, -10, 44, 54));
        Console.WriteLine(Simpson1over3.Integrate(value =>
        {
            return 3 * System.Math.Sin(0.5 * value);
        }, -10, 44, 54));
        Console.WriteLine(Simpson3over8.Integrate(value =>
        {
            return 3 * System.Math.Sin(0.5 * value);
        }, -10, 44, 54));
    }
}