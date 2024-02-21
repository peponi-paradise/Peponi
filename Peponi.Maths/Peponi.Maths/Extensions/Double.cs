namespace Peponi.Maths.Extensions;

public static class DoubleExtension
{
    public static double Round(this double value, int digits)
    {
        return System.Math.Round(value, digits);
    }

    public static double Abs(this double value)
    {
        return System.Math.Abs(value);
    }
}