namespace Peponi.Math.Calculation;

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

    public static double PartialSum(this IEnumerable<double> values, int startIndex, int endIndex)
    {
        double partialSum = 0;

        for (int i = startIndex; i <= endIndex; i++)
        {
            partialSum += values.ElementAt(i);
        }

        return partialSum;
    }
}