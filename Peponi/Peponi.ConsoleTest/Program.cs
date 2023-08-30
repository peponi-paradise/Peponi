using Peponi.Math.Calculation;

namespace Peponi.ConsoleTest;

internal class Program
{
    private static void Main(string[] args)
    {
        List<int> A = new List<int>();
        for (int i = 0; i < 20; i++)
        {
            A.Add(i);
        }
        Console.WriteLine(A.PartialSum(0, 10));
    }
}