using Peponi.Core.Enums;
using System.Globalization;

namespace Peponi.Utility.Helpers;

public static class DateTimeHelper
{
    public static DateTimeUnit GetDateTimeUnit(string format)
    {
        if (format.Contains("f")) throw new NotSupportedException("Format \"f\" is not supported");

        try
        {
            var testString = DateTime.Now.ToString(format);
            DateTime.ParseExact(testString, format, CultureInfo.InvariantCulture);
            return GetTimeCheckMode(format);
        }
        catch
        {
            throw new ArgumentException($"Format string is invalid : {format}");
        }
    }

    public static bool DateTimeUnitEquals(DateTimeUnit unit, DateTime dateTime1, DateTime dateTime2)
    {
        return unit switch
        {
            DateTimeUnit.Seccond => dateTime1.Second == dateTime2.Second,
            DateTimeUnit.Minute => dateTime1.Minute == dateTime2.Minute,
            DateTimeUnit.Hour => dateTime1.Hour == dateTime2.Hour,
            DateTimeUnit.Day => dateTime1.Day == dateTime2.Day,
            DateTimeUnit.Month => dateTime1.Month == dateTime2.Month,
            DateTimeUnit.Year => dateTime1.Year == dateTime2.Year,
            _ => false
        };
    }

    private static DateTimeUnit GetTimeCheckMode(string format)
    {
        if (format.Contains("s")) return DateTimeUnit.Seccond;
        else if (format.Contains("m")) return DateTimeUnit.Minute;
        else if (format.Contains("H") || format.Contains("h")) return DateTimeUnit.Hour;
        else if (format.Contains("D") || format.Contains("d")) return DateTimeUnit.Day;
        else if (format.Contains("M") || format.Contains("Y")) return DateTimeUnit.Month;
        else if (format.Contains("y")) return DateTimeUnit.Year;
        else throw new ArgumentException($"No type supported format : {format}");
    }
}