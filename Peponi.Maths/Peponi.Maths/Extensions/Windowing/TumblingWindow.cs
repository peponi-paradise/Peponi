using Peponi.Maths.Windowing;

namespace Peponi.Maths.Extensions;

public static class TumblingWindowsExtensions
{
    // Count type

    public static IEnumerable<IEnumerable<T>> ToTumblingWindows<T>(this IEnumerable<T> datas, uint windowSize) where T : struct
    {
        return TumblingWindows.ToTumblingWindows(datas, windowSize);
    }

    public static Task<IEnumerable<IEnumerable<T>>> ToTumblingWindowsAsync<T>(this IEnumerable<T> datas, uint windowSize) where T : struct
    {
        return TumblingWindows.ToTumblingWindowsAsync(datas, windowSize);
    }

    public static IEnumerable<IEnumerable<T>> ToTumblingWindows<T>(this IEnumerable<T> datas, uint startPosition, uint windowSize) where T : struct
    {
        return TumblingWindows.ToTumblingWindows(datas, startPosition, windowSize);
    }

    public static Task<IEnumerable<IEnumerable<T>>> ToTumblingWindowsAsync<T>(this IEnumerable<T> datas, uint startPosition, uint windowSize) where T : struct
    {
        return TumblingWindows.ToTumblingWindowsAsync(datas, startPosition, windowSize);
    }

    public static IEnumerable<IEnumerable<T>> ToTumblingWindows<T>(this IEnumerable<T> datas, uint startPosition, uint endPosition, uint windowSize) where T : struct
    {
        return TumblingWindows.ToTumblingWindows(datas, startPosition, endPosition, windowSize);
    }

    public static Task<IEnumerable<IEnumerable<T>>> ToTumblingWindowsAsync<T>(this IEnumerable<T> datas, uint startPosition, uint endPosition, uint windowSize) where T : struct
    {
        return TumblingWindows.ToTumblingWindowsAsync(datas, startPosition, endPosition, windowSize);
    }

    public static IEnumerable<IEnumerable<V>> ToTumblingWindows<T, V>(this IEnumerable<T> datas, uint windowSize, Func<T, V> dataSelector) where V : struct
    {
        return TumblingWindows.ToTumblingWindows(datas, windowSize, dataSelector);
    }

    public static Task<IEnumerable<IEnumerable<V>>> ToTumblingWindowsAsync<T, V>(this IEnumerable<T> datas, uint windowSize, Func<T, V> dataSelector) where V : struct
    {
        return TumblingWindows.ToTumblingWindowsAsync(datas, windowSize, dataSelector);
    }

    public static IEnumerable<IEnumerable<V>> ToTumblingWindows<T, V>(this IEnumerable<T> datas, uint startPosition, uint windowSize, Func<T, V> dataSelector) where V : struct
    {
        return TumblingWindows.ToTumblingWindows(datas, startPosition, windowSize, dataSelector);
    }

    public static Task<IEnumerable<IEnumerable<V>>> ToTumblingWindowsAsync<T, V>(this IEnumerable<T> datas, uint startPosition, uint windowSize, Func<T, V> dataSelector) where V : struct
    {
        return TumblingWindows.ToTumblingWindowsAsync(datas, startPosition, windowSize, dataSelector);
    }

    public static IEnumerable<IEnumerable<V>> ToTumblingWindows<T, V>(this IEnumerable<T> datas, uint startPosition, uint endPosition, uint windowSize, Func<T, V> dataSelector) where V : struct
    {
        return TumblingWindows.ToTumblingWindows(datas, startPosition, endPosition, windowSize, dataSelector);
    }

    public static Task<IEnumerable<IEnumerable<V>>> ToTumblingWindowsAsync<T, V>(this IEnumerable<T> datas, uint startPosition, uint endPosition, uint windowSize, Func<T, V> dataSelector) where V : struct
    {
        return TumblingWindows.ToTumblingWindowsAsync(datas, startPosition, endPosition, windowSize, dataSelector);
    }

    // Time type

    public static IEnumerable<IEnumerable<DateTime>> ToTumblingWindows(this IEnumerable<DateTime> datas, DateTime startTime, TimeSpan windowSize)
    {
        return TumblingWindows.ToTumblingWindows(datas, startTime, windowSize);
    }

    public static Task<IEnumerable<IEnumerable<DateTime>>> ToTumblingWindowsAsync(this IEnumerable<DateTime> datas, DateTime startTime, TimeSpan windowSize)
    {
        return TumblingWindows.ToTumblingWindowsAsync(datas, startTime, windowSize);
    }

    public static IEnumerable<IEnumerable<DateTime>> ToTumblingWindows(this IEnumerable<DateTime> datas, DateTime startTime, DateTime endTime, TimeSpan windowSize)
    {
        return TumblingWindows.ToTumblingWindows(datas, startTime, endTime, windowSize);
    }

    public static Task<IEnumerable<IEnumerable<DateTime>>> ToTumblingWindowsAsync(this IEnumerable<DateTime> datas, DateTime startTime, DateTime endTime, TimeSpan windowSize)
    {
        return TumblingWindows.ToTumblingWindowsAsync(datas, startTime, endTime, windowSize);
    }

    public static IEnumerable<IEnumerable<V>> ToTumblingWindows<T, V>(this IEnumerable<T> datas, DateTime startTime, TimeSpan windowSize, Func<T, DateTime> dateTimeSelector, Func<T, V> dataSelector) where V : struct
    {
        return TumblingWindows.ToTumblingWindows(datas, startTime, windowSize, dateTimeSelector, dataSelector);
    }

    public static Task<IEnumerable<IEnumerable<V>>> ToTumblingWindowsAsync<T, V>(this IEnumerable<T> datas, DateTime startTime, TimeSpan windowSize, Func<T, DateTime> dateTimeSelector, Func<T, V> dataSelector) where V : struct
    {
        return TumblingWindows.ToTumblingWindowsAsync(datas, startTime, windowSize, dateTimeSelector, dataSelector);
    }

    public static IEnumerable<IEnumerable<V>> ToTumblingWindows<T, V>(this IEnumerable<T> datas, DateTime startTime, DateTime endTime, TimeSpan windowSize, Func<T, DateTime> dateTimeSelector, Func<T, V> dataSelector) where V : struct
    {
        return TumblingWindows.ToTumblingWindows(datas, startTime, endTime, windowSize, dateTimeSelector, dataSelector);
    }

    public static Task<IEnumerable<IEnumerable<V>>> ToTumblingWindowsAsync<T, V>(this IEnumerable<T> datas, DateTime startTime, DateTime endTime, TimeSpan windowSize, Func<T, DateTime> dateTimeSelector, Func<T, V> dataSelector) where V : struct
    {
        return TumblingWindows.ToTumblingWindowsAsync(datas, startTime, endTime, windowSize, dateTimeSelector, dataSelector);
    }
}