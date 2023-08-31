namespace Peponi.Math.Extensions;

public static class IntegerExtension
{
    public static bool IsOdd(this int value)
    {
        return value % 2 == 1;
    }

    public static bool IsEven(this int value)
    {
        return value % 2 == 0;
    }

    public static int Abs(this int value)
    {
        return System.Math.Abs(value);
    }
}