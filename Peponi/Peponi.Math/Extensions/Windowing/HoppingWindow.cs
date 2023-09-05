using Peponi.Math.Windowing;

namespace Peponi.Math.Extensions;

public static class HoppingWindowsExtensions
{
    // Count type

    public static IEnumerable<IEnumerable<T>> ToHoppingWindows<T>(this IEnumerable<T> datas, uint windowSize, uint hoppingStep) where T : struct
    {
        return HoppingWindows.ToHoppingWindows(datas, windowSize, hoppingStep);
    }

    public static Task<IEnumerable<IEnumerable<T>>> ToHoppingWindowsAsync<T>(this IEnumerable<T> datas, uint windowSize, uint hoppingStep) where T : struct
    {
        return HoppingWindows.ToHoppingWindowsAsync(datas, windowSize, hoppingStep);
    }

    public static IEnumerable<IEnumerable<T>> ToHoppingWindows<T>(this IEnumerable<T> datas, uint startPosition, uint windowSize, uint hoppingStep) where T : struct
    {
        return HoppingWindows.ToHoppingWindows(datas, startPosition, windowSize, hoppingStep);
    }

    public static Task<IEnumerable<IEnumerable<T>>> ToHoppingWindowsAsync<T>(this IEnumerable<T> datas, uint startPosition, uint windowSize, uint hoppingStep) where T : struct
    {
        return HoppingWindows.ToHoppingWindowsAsync(datas, startPosition, windowSize, hoppingStep);
    }

    public static IEnumerable<IEnumerable<T>> ToHoppingWindows<T>(this IEnumerable<T> datas, uint startPosition, uint endPosition, uint windowSize, uint hoppingStep) where T : struct
    {
        return HoppingWindows.ToHoppingWindows(datas, startPosition, endPosition, windowSize, hoppingStep);
    }

    public static Task<IEnumerable<IEnumerable<T>>> ToHoppingWindowsAsync<T>(this IEnumerable<T> datas, uint startPosition, uint endPosition, uint windowSize, uint hoppingStep) where T : struct
    {
        return HoppingWindows.ToHoppingWindowsAsync(datas, startPosition, endPosition, windowSize, hoppingStep);
    }

    public static IEnumerable<IEnumerable<V>> ToHoppingWindows<T, V>(this IEnumerable<T> datas, uint windowSize, uint hoppingStep, Func<T, V> dataSelector) where V : struct
    {
        return HoppingWindows.ToHoppingWindows(datas, windowSize, hoppingStep, dataSelector);
    }

    public static Task<IEnumerable<IEnumerable<V>>> ToHoppingWindowsAsync<T, V>(this IEnumerable<T> datas, uint windowSize, uint hoppingStep, Func<T, V> dataSelector) where V : struct
    {
        return HoppingWindows.ToHoppingWindowsAsync(datas, windowSize, hoppingStep, dataSelector);
    }

    public static IEnumerable<IEnumerable<V>> ToHoppingWindows<T, V>(this IEnumerable<T> datas, uint startPosition, uint windowSize, uint hoppingStep, Func<T, V> dataSelector) where V : struct
    {
        return HoppingWindows.ToHoppingWindows(datas, startPosition, windowSize, hoppingStep, dataSelector);
    }

    public static Task<IEnumerable<IEnumerable<V>>> ToHoppingWindowsAsync<T, V>(this IEnumerable<T> datas, uint startPosition, uint windowSize, uint hoppingStep, Func<T, V> dataSelector) where V : struct
    {
        return HoppingWindows.ToHoppingWindowsAsync(datas, startPosition, windowSize, hoppingStep, dataSelector);
    }

    public static IEnumerable<IEnumerable<V>> ToHoppingWindows<T, V>(this IEnumerable<T> datas, uint startPosition, uint endPosition, uint windowSize, uint hoppingStep, Func<T, V> dataSelector) where V : struct
    {
        return HoppingWindows.ToHoppingWindows(datas, startPosition, endPosition, windowSize, hoppingStep, dataSelector);
    }

    public static Task<IEnumerable<IEnumerable<V>>> ToHoppingWindowsAsync<T, V>(this IEnumerable<T> datas, uint startPosition, uint endPosition, uint windowSize, uint hoppingStep, Func<T, V> dataSelector) where V : struct
    {
        return HoppingWindows.ToHoppingWindowsAsync(datas, startPosition, endPosition, windowSize, hoppingStep, dataSelector);
    }

    // Time type
}