using Peponi.Math.Windowing;

namespace Peponi.Math.Extensions;

public static class SlidingWindowsExtensions
{
    // Count type

    public static IEnumerable<IEnumerable<T>> ToSlidingWindows<T>(this IEnumerable<T> datas, uint windowSize) where T : struct
    {
        return SlidingWindows.ToSlidingWindows(datas, windowSize);
    }

    public static Task<IEnumerable<IEnumerable<T>>> ToSlidingWindowsAsync<T>(this IEnumerable<T> datas, uint windowSize) where T : struct
    {
        return SlidingWindows.ToSlidingWindowsAsync(datas, windowSize);
    }

    public static IEnumerable<IEnumerable<T>> ToSlidingWindows<T>(this IEnumerable<T> datas, uint startPosition, uint windowSize) where T : struct
    {
        return SlidingWindows.ToSlidingWindows(datas, startPosition, windowSize);
    }

    public static Task<IEnumerable<IEnumerable<T>>> ToSlidingWindowsAsync<T>(this IEnumerable<T> datas, uint startPosition, uint windowSize) where T : struct
    {
        return SlidingWindows.ToSlidingWindowsAsync(datas, startPosition, windowSize);
    }

    public static IEnumerable<IEnumerable<T>> ToSlidingWindows<T>(this IEnumerable<T> datas, uint startPosition, uint endPosition, uint windowSize) where T : struct
    {
        return SlidingWindows.ToSlidingWindows(datas, startPosition, endPosition, windowSize);
    }

    public static Task<IEnumerable<IEnumerable<T>>> ToSlidingWindowsAsync<T>(this IEnumerable<T> datas, uint startPosition, uint endPosition, uint windowSize) where T : struct
    {
        return SlidingWindows.ToSlidingWindowsAsync(datas, startPosition, endPosition, windowSize);
    }

    public static IEnumerable<IEnumerable<V>> ToSlidingWindows<T, V>(this IEnumerable<T> datas, uint windowSize, Func<T, V> dataSelector) where V : struct
    {
        return SlidingWindows.ToSlidingWindows(datas, windowSize, dataSelector);
    }

    public static Task<IEnumerable<IEnumerable<V>>> ToSlidingWindowsAsync<T, V>(this IEnumerable<T> datas, uint windowSize, Func<T, V> dataSelector) where V : struct
    {
        return SlidingWindows.ToSlidingWindowsAsync(datas, windowSize, dataSelector);
    }

    public static IEnumerable<IEnumerable<V>> ToSlidingWindows<T, V>(this IEnumerable<T> datas, uint startPosition, uint windowSize, Func<T, V> dataSelector) where V : struct
    {
        return SlidingWindows.ToSlidingWindows(datas, startPosition, windowSize, dataSelector);
    }

    public static Task<IEnumerable<IEnumerable<V>>> ToSlidingWindowsAsync<T, V>(this IEnumerable<T> datas, uint startPosition, uint windowSize, Func<T, V> dataSelector) where V : struct
    {
        return SlidingWindows.ToSlidingWindowsAsync(datas, startPosition, windowSize, dataSelector);
    }

    public static IEnumerable<IEnumerable<V>> ToSlidingWindows<T, V>(this IEnumerable<T> datas, uint startPosition, uint endPosition, uint windowSize, Func<T, V> dataSelector) where V : struct
    {
        return SlidingWindows.ToSlidingWindows(datas, startPosition, endPosition, windowSize, dataSelector);
    }

    public static Task<IEnumerable<IEnumerable<V>>> ToSlidingWindowsAsync<T, V>(this IEnumerable<T> datas, uint startPosition, uint endPosition, uint windowSize, Func<T, V> dataSelector) where V : struct
    {
        return SlidingWindows.ToSlidingWindowsAsync(datas, startPosition, endPosition, windowSize, dataSelector);
    }

    // Time type

    public static IEnumerable<IEnumerable<DateTime>> ToSlidingWindows(this IEnumerable<DateTime> datas, DateTime startTime, TimeSpan windowSize)
    {
        return SlidingWindows.ToSlidingWindows(datas, startTime, windowSize);
    }

    public static Task<IEnumerable<IEnumerable<DateTime>>> ToSlidingWindowsAsync(this IEnumerable<DateTime> datas, DateTime startTime, TimeSpan windowSize)
    {
        return SlidingWindows.ToSlidingWindowsAsync(datas, startTime, windowSize);
    }

    public static IEnumerable<IEnumerable<DateTime>> ToSlidingWindows(this IEnumerable<DateTime> datas, DateTime startTime, DateTime endTime, TimeSpan windowSize)
    {
        return SlidingWindows.ToSlidingWindows(datas, startTime, endTime, windowSize);
    }

    public static Task<IEnumerable<IEnumerable<DateTime>>> ToSlidingWindowsAsync(this IEnumerable<DateTime> datas, DateTime startTime, DateTime endTime, TimeSpan windowSize)
    {
        return SlidingWindows.ToSlidingWindowsAsync(datas, startTime, endTime, windowSize);
    }

    public static IEnumerable<IEnumerable<V>> ToSlidingWindows<T, V>(this IEnumerable<T> datas, DateTime startTime, TimeSpan windowSize, Func<T, DateTime> dateTimeSelector, Func<T, V> dataSelector) where V : struct
    {
        return SlidingWindows.ToSlidingWindows(datas, startTime, windowSize, dateTimeSelector, dataSelector);
    }

    public static Task<IEnumerable<IEnumerable<V>>> ToSlidingWindowsAsync<T, V>(this IEnumerable<T> datas, DateTime startTime, TimeSpan windowSize, Func<T, DateTime> dateTimeSelector, Func<T, V> dataSelector) where V : struct
    {
        return SlidingWindows.ToSlidingWindowsAsync(datas, startTime, windowSize, dateTimeSelector, dataSelector);
    }

    public static IEnumerable<IEnumerable<V>> ToSlidingWindows<T, V>(this IEnumerable<T> datas, DateTime startTime, DateTime endTime, TimeSpan windowSize, Func<T, DateTime> dateTimeSelector, Func<T, V> dataSelector) where V : struct
    {
        return SlidingWindows.ToSlidingWindows(datas, startTime, endTime, windowSize, dateTimeSelector, dataSelector);
    }

    public static Task<IEnumerable<IEnumerable<V>>> ToSlidingWindowsAsync<T, V>(this IEnumerable<T> datas, DateTime startTime, DateTime endTime, TimeSpan windowSize, Func<T, DateTime> dateTimeSelector, Func<T, V> dataSelector) where V : struct
    {
        return SlidingWindows.ToSlidingWindowsAsync(datas, startTime, endTime, windowSize, dateTimeSelector, dataSelector);
    }
}