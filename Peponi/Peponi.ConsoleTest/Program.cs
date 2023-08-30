using Peponi.Utility.Helpers;

namespace Peponi.ConsoleTest;

internal class Program
{
    private static void Main(string[] args)
    {
        RegistryHelper.AppendCurrentUser($@"PeponiTest", "Hello", "World");
        Console.WriteLine(RegistryHelper.GetCurrentUser($@"PeponiTest", "Hello"));
    }
}