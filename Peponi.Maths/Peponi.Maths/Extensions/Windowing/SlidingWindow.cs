using Peponi.Maths.Windowing;

namespace Peponi.Maths.Extensions;

public static class SlidingWindowsExtensions
{
    // Count type

    /// <inheritdoc cref="SlidingWindows.ToSlidingWindowsCore{T}(IEnumerable{T}, uint, uint, uint)"/>
    public static IEnumerable<IEnumerable<T>> ToSlidingWindows<T>(this IEnumerable<T> datas, uint windowSize) where T : struct
    {
        return SlidingWindows.ToSlidingWindows(datas, windowSize);
    }

    /// <inheritdoc cref="SlidingWindows.ToSlidingWindowsCore{T}(IEnumerable{T}, uint, uint, uint)"/>
    public static Task<IEnumerable<IEnumerable<T>>> ToSlidingWindowsAsync<T>(this IEnumerable<T> datas, uint windowSize) where T : struct
    {
        return SlidingWindows.ToSlidingWindowsAsync(datas, windowSize);
    }

    /// <inheritdoc cref="SlidingWindows.ToSlidingWindowsCore{T}(IEnumerable{T}, uint, uint, uint)"/>
    public static IEnumerable<IEnumerable<T>> ToSlidingWindows<T>(this IEnumerable<T> datas, uint startPosition, uint windowSize) where T : struct
    {
        return SlidingWindows.ToSlidingWindows(datas, startPosition, windowSize);
    }

    /// <inheritdoc cref="SlidingWindows.ToSlidingWindowsCore{T}(IEnumerable{T}, uint, uint, uint)"/>
    public static Task<IEnumerable<IEnumerable<T>>> ToSlidingWindowsAsync<T>(this IEnumerable<T> datas, uint startPosition, uint windowSize) where T : struct
    {
        return SlidingWindows.ToSlidingWindowsAsync(datas, startPosition, windowSize);
    }

    /// <inheritdoc cref="SlidingWindows.ToSlidingWindowsCore{T}(IEnumerable{T}, uint, uint, uint)"/>
    public static IEnumerable<IEnumerable<T>> ToSlidingWindows<T>(this IEnumerable<T> datas, uint startPosition, uint endPosition, uint windowSize) where T : struct
    {
        return SlidingWindows.ToSlidingWindows(datas, startPosition, endPosition, windowSize);
    }

    /// <inheritdoc cref="SlidingWindows.ToSlidingWindowsCore{T}(IEnumerable{T}, uint, uint, uint)"/>
    public static Task<IEnumerable<IEnumerable<T>>> ToSlidingWindowsAsync<T>(this IEnumerable<T> datas, uint startPosition, uint endPosition, uint windowSize) where T : struct
    {
        return SlidingWindows.ToSlidingWindowsAsync(datas, startPosition, endPosition, windowSize);
    }

    /// <inheritdoc cref="SlidingWindows.ToSlidingWindowsCore{T, V}(IEnumerable{T}, uint, uint, uint, Func{T, V}?)"/>
    public static IEnumerable<IEnumerable<V>> ToSlidingWindows<T, V>(this IEnumerable<T> datas, uint windowSize, Func<T, V> dataSelector) where V : struct
    {
        return SlidingWindows.ToSlidingWindows(datas, windowSize, dataSelector);
    }

    /// <inheritdoc cref="SlidingWindows.ToSlidingWindowsCore{T, V}(IEnumerable{T}, uint, uint, uint, Func{T, V}?)"/>
    public static Task<IEnumerable<IEnumerable<V>>> ToSlidingWindowsAsync<T, V>(this IEnumerable<T> datas, uint windowSize, Func<T, V> dataSelector) where V : struct
    {
        return SlidingWindows.ToSlidingWindowsAsync(datas, windowSize, dataSelector);
    }

    /// <inheritdoc cref="SlidingWindows.ToSlidingWindowsCore{T, V}(IEnumerable{T}, uint, uint, uint, Func{T, V}?)"/>
    public static IEnumerable<IEnumerable<V>> ToSlidingWindows<T, V>(this IEnumerable<T> datas, uint startPosition, uint windowSize, Func<T, V> dataSelector) where V : struct
    {
        return SlidingWindows.ToSlidingWindows(datas, startPosition, windowSize, dataSelector);
    }

    /// <inheritdoc cref="SlidingWindows.ToSlidingWindowsCore{T, V}(IEnumerable{T}, uint, uint, uint, Func{T, V}?)"/>
    public static Task<IEnumerable<IEnumerable<V>>> ToSlidingWindowsAsync<T, V>(this IEnumerable<T> datas, uint startPosition, uint windowSize, Func<T, V> dataSelector) where V : struct
    {
        return SlidingWindows.ToSlidingWindowsAsync(datas, startPosition, windowSize, dataSelector);
    }

    /// <inheritdoc cref="SlidingWindows.ToSlidingWindowsCore{T, V}(IEnumerable{T}, uint, uint, uint, Func{T, V}?)"/>
    public static IEnumerable<IEnumerable<V>> ToSlidingWindows<T, V>(this IEnumerable<T> datas, uint startPosition, uint endPosition, uint windowSize, Func<T, V> dataSelector) where V : struct
    {
        return SlidingWindows.ToSlidingWindows(datas, startPosition, endPosition, windowSize, dataSelector);
    }

    /// <inheritdoc cref="SlidingWindows.ToSlidingWindowsCore{T, V}(IEnumerable{T}, uint, uint, uint, Func{T, V}?)"/>
    public static Task<IEnumerable<IEnumerable<V>>> ToSlidingWindowsAsync<T, V>(this IEnumerable<T> datas, uint startPosition, uint endPosition, uint windowSize, Func<T, V> dataSelector) where V : struct
    {
        return SlidingWindows.ToSlidingWindowsAsync(datas, startPosition, endPosition, windowSize, dataSelector);
    }

    // Time type

    /// <inheritdoc cref="SlidingWindows.ToSlidingWindowsCore(IEnumerable{DateTime}, DateTime, DateTime, TimeSpan)"/>
    public static IEnumerable<IEnumerable<DateTime>> ToSlidingWindows(this IEnumerable<DateTime> datas, DateTime startTime, TimeSpan windowSize)
    {
        return SlidingWindows.ToSlidingWindows(datas, startTime, windowSize);
    }

    /// <inheritdoc cref="SlidingWindows.ToSlidingWindowsCore(IEnumerable{DateTime}, DateTime, DateTime, TimeSpan)"/>
    public static Task<IEnumerable<IEnumerable<DateTime>>> ToSlidingWindowsAsync(this IEnumerable<DateTime> datas, DateTime startTime, TimeSpan windowSize)
    {
        return SlidingWindows.ToSlidingWindowsAsync(datas, startTime, windowSize);
    }

    /// <inheritdoc cref="SlidingWindows.ToSlidingWindowsCore(IEnumerable{DateTime}, DateTime, DateTime, TimeSpan)"/>
    public static IEnumerable<IEnumerable<DateTime>> ToSlidingWindows(this IEnumerable<DateTime> datas, DateTime startTime, DateTime endTime, TimeSpan windowSize)
    {
        return SlidingWindows.ToSlidingWindows(datas, startTime, endTime, windowSize);
    }

    /// <inheritdoc cref="SlidingWindows.ToSlidingWindowsCore(IEnumerable{DateTime}, DateTime, DateTime, TimeSpan)"/>
    public static Task<IEnumerable<IEnumerable<DateTime>>> ToSlidingWindowsAsync(this IEnumerable<DateTime> datas, DateTime startTime, DateTime endTime, TimeSpan windowSize)
    {
        return SlidingWindows.ToSlidingWindowsAsync(datas, startTime, endTime, windowSize);
    }

    /// <inheritdoc cref="SlidingWindows.ToSlidingWindowsCore{T, V}(IEnumerable{T}, DateTime, DateTime, TimeSpan, Func{T, DateTime}, Func{T, V})"/>
    public static IEnumerable<IEnumerable<V>> ToSlidingWindows<T, V>(this IEnumerable<T> datas, DateTime startTime, TimeSpan windowSize, Func<T, DateTime> dateTimeSelector, Func<T, V> dataSelector) where V : struct
    {
        return SlidingWindows.ToSlidingWindows(datas, startTime, windowSize, dateTimeSelector, dataSelector);
    }

    /// <inheritdoc cref="SlidingWindows.ToSlidingWindowsCore{T, V}(IEnumerable{T}, DateTime, DateTime, TimeSpan, Func{T, DateTime}, Func{T, V})"/>
    public static Task<IEnumerable<IEnumerable<V>>> ToSlidingWindowsAsync<T, V>(this IEnumerable<T> datas, DateTime startTime, TimeSpan windowSize, Func<T, DateTime> dateTimeSelector, Func<T, V> dataSelector) where V : struct
    {
        return SlidingWindows.ToSlidingWindowsAsync(datas, startTime, windowSize, dateTimeSelector, dataSelector);
    }

    /// <inheritdoc cref="SlidingWindows.ToSlidingWindowsCore{T, V}(IEnumerable{T}, DateTime, DateTime, TimeSpan, Func{T, DateTime}, Func{T, V})"/>
    public static IEnumerable<IEnumerable<V>> ToSlidingWindows<T, V>(this IEnumerable<T> datas, DateTime startTime, DateTime endTime, TimeSpan windowSize, Func<T, DateTime> dateTimeSelector, Func<T, V> dataSelector) where V : struct
    {
        return SlidingWindows.ToSlidingWindows(datas, startTime, endTime, windowSize, dateTimeSelector, dataSelector);
    }

    /// <inheritdoc cref="SlidingWindows.ToSlidingWindowsCore{T, V}(IEnumerable{T}, DateTime, DateTime, TimeSpan, Func{T, DateTime}, Func{T, V})"/>
    public static Task<IEnumerable<IEnumerable<V>>> ToSlidingWindowsAsync<T, V>(this IEnumerable<T> datas, DateTime startTime, DateTime endTime, TimeSpan windowSize, Func<T, DateTime> dateTimeSelector, Func<T, V> dataSelector) where V : struct
    {
        return SlidingWindows.ToSlidingWindowsAsync(datas, startTime, endTime, windowSize, dateTimeSelector, dataSelector);
    }
}