namespace System.Linq;

public static class LinqExtension
{
    public static TimeSpan Sum(this IEnumerable<TimeSpan> timeSpans)
    {
        TimeSpan sum = new();
        foreach (var span in timeSpans)
        {
            sum += span;
        }
        return sum;
    }

    public static TimeSpan Average(this IEnumerable<TimeSpan> timeSpans)
    {
        TimeSpan sum = new();
        foreach (var span in timeSpans)
        {
            sum += span;
        }
        return sum / timeSpans.Count();
    }
}