namespace Peponi.Math.Extensions;

public static class DecimalExtension
{
    public static decimal Round(this decimal value, int digits)
    {
        return System.Math.Round(value, digits);
    }

    public static decimal Abs(this decimal value)
    {
        return System.Math.Abs(value);
    }
}