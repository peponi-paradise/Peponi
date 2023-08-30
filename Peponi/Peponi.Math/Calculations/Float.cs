namespace Peponi.Math.Calculation;

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

    public static float PartialSum(this IEnumerable<float> values, int startIndex, int endIndex)
    {
        float partialSum = 0;

        for (int i = startIndex; i <= endIndex; i++)
        {
            partialSum += values.ElementAt(i);
        }

        return partialSum;
    }
}