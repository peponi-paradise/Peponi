namespace Peponi.Math.Extensions;

public static class DateTimeExtension
{
    public static bool IsBetween(this DateTime target, DateTime start, DateTime end)
    {
        if (target >= start && target <= end) return true;
        return false;
    }
}