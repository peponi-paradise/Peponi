namespace Peponi.Math.Extensions;

public static class FloatExtension
{
    public static float Round(this float value, int digits)
    {
        return (float)System.Math.Round(value, digits);
    }

    public static float Abs(this float value)
    {
        return System.Math.Abs(value);
    }
}