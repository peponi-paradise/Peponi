namespace Peponi.Math.Calculation;

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

    public static decimal PartialSum(this IEnumerable<decimal> values, int startIndex, int endIndex)
    {
        decimal partialSum = 0;

        for (int i = startIndex; i <= endIndex; i++)
        {
            partialSum += values.ElementAt(i);
        }

        return partialSum;
    }
}