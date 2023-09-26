namespace Peponi.Math.Extensions;

public static class CollectionExtension
{
    public static decimal PartialSum(this IEnumerable<decimal> values, int startIndex, int endIndex)
    {
        decimal partialSum = 0;

        for (int i = startIndex; i <= endIndex; i++)
        {
            partialSum += values.ElementAt(i);
        }

        return partialSum;
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

    public static float PartialSum(this IEnumerable<float> values, int startIndex, int endIndex)
    {
        float partialSum = 0;

        for (int i = startIndex; i <= endIndex; i++)
        {
            partialSum += values.ElementAt(i);
        }

        return partialSum;
    }

    public static int PartialSum(this IEnumerable<int> values, int startIndex, int endIndex)
    {
        int partialSum = 0;

        for (int i = startIndex; i <= endIndex; i++)
        {
            partialSum += values.ElementAt(i);
        }

        return partialSum;
    }

    public static bool ContainsNegative(this IEnumerable<double> values)
    {
        foreach (var value in values)
        {
            if (value < 0) return true;
        }
        return false;
    }

    public static bool IsIntervalUniform(this IEnumerable<double> values)
    {
        double interval = values.ElementAt(1) - values.ElementAt(0);

        for (int i = 0; i < values.Count() - 1; i++)
        {
            if (values.ElementAt(i + 1) - values.ElementAt(i) != interval) return false;
        }

        return true;
    }
}