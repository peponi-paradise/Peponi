namespace Peponi.Math.Calculation;

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

    public static int PartialSum(this IEnumerable<int> values, int startIndex, int endIndex)
    {
        int partialSum = 0;

        for (int i = startIndex; i <= endIndex; i++)
        {
            partialSum += values.ElementAt(i);
        }

        return partialSum;
    }
}