using Peponi.Core.Enums;
using System;
using System.Globalization;

namespace Peponi.Core.Helpers
{
    public static class TimeHelper
    {
        public static TimeUnit DateTimeFormatTest(string format)
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

        public static bool DateTimeEquals(TimeUnit unit, DateTime dateTime1, DateTime dateTime2)
        {
            switch (unit)
            {
                case TimeUnit.Seccond:
                    return dateTime1.Second == dateTime2.Second;

                case TimeUnit.Minute:
                    return dateTime1.Minute == dateTime2.Minute;

                case TimeUnit.Hour:
                    return dateTime1.Hour == dateTime2.Hour;

                case TimeUnit.Day:
                    return dateTime1.Day == dateTime2.Day;

                case TimeUnit.Month:
                    return dateTime1.Month == dateTime2.Month;

                case TimeUnit.Year:
                    return dateTime1.Year == dateTime2.Year;
            }
            return false;
        }

        private static TimeUnit GetTimeCheckMode(string format)
        {
            if (format.Contains("s")) return TimeUnit.Seccond;
            else if (format.Contains("m")) return TimeUnit.Minute;
            else if (format.Contains("H") || format.Contains("h")) return TimeUnit.Hour;
            else if (format.Contains("D") || format.Contains("d")) return TimeUnit.Day;
            else if (format.Contains("M") || format.Contains("Y")) return TimeUnit.Month;
            else if (format.Contains("y")) return TimeUnit.Year;
            else return TimeUnit.None;
        }
    }
}