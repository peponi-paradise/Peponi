using Peponi.Math.Windowing;

namespace Peponi.Math.Extensions;

public static class TumblingWindowsExtensions
{
    public static IEnumerable<IEnumerable<TData>> ToTumblingWindows<TData>(this IEnumerable<TData> datas, int windowSize) where TData : struct
    {
        return TumblingWindows.ToTumblingWindows(datas, windowSize);
    }

    public static Task<IEnumerable<IEnumerable<TData>>> ToTumblingWindowsAsync<TData>(this IEnumerable<TData> datas, int windowSize) where TData : struct
    {
        return TumblingWindows.ToTumblingWindowsAsync(datas, windowSize);
    }

    public static IEnumerable<IEnumerable<DateTime>> ToTumblingWindows(this IEnumerable<DateTime> datas, DateTime startTime, TimeSpan windowSize)
    {
        return TumblingWindows.ToTumblingWindows(datas, startTime, windowSize);
    }

    public static Task<IEnumerable<IEnumerable<DateTime>>> ToTumblingWindowsAsync(this IEnumerable<DateTime> datas, DateTime startTime, TimeSpan windowSize)
    {
        return TumblingWindows.ToTumblingWindowsAsync(datas, startTime, windowSize);
    }

    public static IEnumerable<IEnumerable<DataType>> ToTumblingWindows<TData, DataType>(this IEnumerable<TData> datas, DateTime startTime, TimeSpan windowSize, Func<TData, DateTime> dateTimeSelector, Func<TData, DataType> dataTypeSelector) where DataType : struct
    {
        return TumblingWindows.ToTumblingWindows(datas, startTime, windowSize, dateTimeSelector, dataTypeSelector);
    }

    public static Task<IEnumerable<IEnumerable<DataType>>> ToTumblingWindowsAsync<TData, DataType>(this IEnumerable<TData> datas, DateTime startTime, TimeSpan windowSize, Func<TData, DateTime> dateTimeSelector, Func<TData, DataType> dataTypeSelector) where DataType : struct
    {
        return TumblingWindows.ToTumblingWindowsAsync(datas, startTime, windowSize, dateTimeSelector, dataTypeSelector);
    }
}