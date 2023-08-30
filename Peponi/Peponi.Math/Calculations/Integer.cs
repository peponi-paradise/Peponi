namespace Peponi.Math.Calculation;

public static class IntegerExtension
{
    public static bool IsEven(this int value)
    {
        return value % 2 == 0;
    }
}