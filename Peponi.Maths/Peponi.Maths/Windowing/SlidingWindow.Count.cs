namespace Peponi.Maths.Windowing;

/// <summary>
/// Compute sliding windows
/// <br/>
/// <see href="주소 넣어야 함"/>
/// </summary>
public static partial class SlidingWindows
{
    /// <inheritdoc cref="ToSlidingWindowsCore{T}(IEnumerable{T}, uint, uint, uint)"/>
    public static IEnumerable<IEnumerable<T>> ToSlidingWindows<T>(IEnumerable<T> datas, uint windowSize) where T : struct
    {
        return ToSlidingWindowsCore(datas: datas, windowSize: windowSize);
    }

    /// <inheritdoc cref="ToSlidingWindowsCore{T}(IEnumerable{T}, uint, uint, uint)"/>
    public static Task<IEnumerable<IEnumerable<T>>> ToSlidingWindowsAsync<T>(IEnumerable<T> datas, uint windowSize) where T : struct
    {
        return Task.Run(() => ToSlidingWindows(datas, windowSize));
    }

    /// <inheritdoc cref="ToSlidingWindowsCore{T}(IEnumerable{T}, uint, uint, uint)"/>
    public static IEnumerable<IEnumerable<T>> ToSlidingWindows<T>(IEnumerable<T> datas, uint startPosition, uint windowSize) where T : struct
    {
        return ToSlidingWindowsCore(datas: datas, startPosition: startPosition, windowSize: windowSize);
    }

    /// <inheritdoc cref="ToSlidingWindowsCore{T}(IEnumerable{T}, uint, uint, uint)"/>
    public static Task<IEnumerable<IEnumerable<T>>> ToSlidingWindowsAsync<T>(IEnumerable<T> datas, uint startPosition, uint windowSize) where T : struct
    {
        return Task.Run(() => ToSlidingWindows(datas, startPosition, windowSize));
    }

    /// <inheritdoc cref="ToSlidingWindowsCore{T}(IEnumerable{T}, uint, uint, uint)"/>
    public static IEnumerable<IEnumerable<T>> ToSlidingWindows<T>(IEnumerable<T> datas, uint startPosition, uint endPosition, uint windowSize) where T : struct
    {
        return ToSlidingWindowsCore(datas, startPosition, endPosition, windowSize);
    }

    /// <inheritdoc cref="ToSlidingWindowsCore{T}(IEnumerable{T}, uint, uint, uint)"/>
    public static Task<IEnumerable<IEnumerable<T>>> ToSlidingWindowsAsync<T>(IEnumerable<T> datas, uint startPosition, uint endPosition, uint windowSize) where T : struct
    {
        return Task.Run(() => ToSlidingWindows(datas, startPosition, endPosition, windowSize));
    }

    /// <inheritdoc cref="ToSlidingWindowsCore{T, V}(IEnumerable{T}, uint, uint, uint, Func{T, V}?)"/>
    public static IEnumerable<IEnumerable<V>> ToSlidingWindows<T, V>(IEnumerable<T> datas, uint windowSize, Func<T, V> dataSelector) where V : struct
    {
        return ToSlidingWindowsCore(datas: datas, windowSize: windowSize, dataSelector: dataSelector);
    }

    /// <inheritdoc cref="ToSlidingWindowsCore{T, V}(IEnumerable{T}, uint, uint, uint, Func{T, V}?)"/>
    public static Task<IEnumerable<IEnumerable<V>>> ToSlidingWindowsAsync<T, V>(IEnumerable<T> datas, uint windowSize, Func<T, V> dataSelector) where V : struct
    {
        return Task.Run(() => ToSlidingWindows(datas, windowSize, dataSelector));
    }

    /// <inheritdoc cref="ToSlidingWindowsCore{T, V}(IEnumerable{T}, uint, uint, uint, Func{T, V}?)"/>
    public static IEnumerable<IEnumerable<V>> ToSlidingWindows<T, V>(IEnumerable<T> datas, uint startPosition, uint windowSize, Func<T, V> dataSelector) where V : struct
    {
        return ToSlidingWindowsCore(datas: datas, startPosition: startPosition, windowSize: windowSize, dataSelector: dataSelector);
    }

    /// <inheritdoc cref="ToSlidingWindowsCore{T, V}(IEnumerable{T}, uint, uint, uint, Func{T, V}?)"/>
    public static Task<IEnumerable<IEnumerable<V>>> ToSlidingWindowsAsync<T, V>(IEnumerable<T> datas, uint startPosition, uint windowSize, Func<T, V> dataSelector) where V : struct
    {
        return Task.Run(() => ToSlidingWindows(datas, startPosition, windowSize, dataSelector));
    }

    /// <inheritdoc cref="ToSlidingWindowsCore{T, V}(IEnumerable{T}, uint, uint, uint, Func{T, V}?)"/>
    public static IEnumerable<IEnumerable<V>> ToSlidingWindows<T, V>(IEnumerable<T> datas, uint startPosition, uint endPosition, uint windowSize, Func<T, V> dataSelector) where V : struct
    {
        return ToSlidingWindowsCore(datas, startPosition, endPosition, windowSize, dataSelector);
    }

    /// <inheritdoc cref="ToSlidingWindowsCore{T, V}(IEnumerable{T}, uint, uint, uint, Func{T, V}?)"/>
    public static Task<IEnumerable<IEnumerable<V>>> ToSlidingWindowsAsync<T, V>(IEnumerable<T> datas, uint startPosition, uint endPosition, uint windowSize, Func<T, V> dataSelector) where V : struct
    {
        return Task.Run(() => ToSlidingWindows(datas, startPosition, endPosition, windowSize, dataSelector));
    }

    /// <summary>
    /// Compute sliding windows
    /// </summary>
    /// <typeparam name="T">Struct type</typeparam>
    /// <param name="datas"></param>
    /// <param name="startPosition">startPosition &lt;= endPosition</param>
    /// <param name="endPosition">startPosition &lt;= endPosition</param>
    /// <param name="windowSize">Bigger than 0</param>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    private static IEnumerable<IEnumerable<T>> ToSlidingWindowsCore<T>(IEnumerable<T> datas, uint startPosition = uint.MaxValue, uint endPosition = uint.MaxValue, uint windowSize = 0) where T : struct
    {
        DataCheck(datas, ref startPosition, ref endPosition, windowSize);

        List<List<T>> rtnDatas = new();
        List<T> windows = new();

        for (int i = (int)startPosition; i <= endPosition; i++)
        {
            for (int j = i; j < i + windowSize; j++)
            {
                if (j >= datas.Count())
                {
                    i = datas.Count();
                    break;
                }
                windows.Add(datas.ElementAt(j));
                if (j >= endPosition)
                {
                    i = datas.Count();
                    break;
                }
            }
            rtnDatas.Add(windows.ToList());
            windows.Clear();
        }

        return rtnDatas;
    }

    /// <summary>
    /// Compute sliding windows
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="V">Struct type</typeparam>
    /// <param name="datas"></param>
    /// <param name="startPosition">startPosition &lt;= endPosition</param>
    /// <param name="endPosition">startPosition &lt;= endPosition</param>
    /// <param name="windowSize">Bigger than 0</param>
    /// <param name="dataSelector">Data select function</param>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    /// <exception cref="ArgumentNullException"></exception>
    private static IEnumerable<IEnumerable<V>> ToSlidingWindowsCore<T, V>(IEnumerable<T> datas, uint startPosition = uint.MaxValue, uint endPosition = uint.MaxValue, uint windowSize = 0, Func<T, V>? dataSelector = null) where V : struct
    {
        DataCheck(datas, ref startPosition, ref endPosition, windowSize);

        if (dataSelector == null)
        {
            throw new ArgumentNullException($"{nameof(dataSelector)} could not be null");
        }

        List<List<V>> rtnDatas = new();
        List<V> windows = new();

        for (int i = (int)startPosition; i <= endPosition; i++)
        {
            for (int j = i; j < i + windowSize; j++)
            {
                if (j >= datas.Count())
                {
                    i = datas.Count();
                    break;
                }
                windows.Add(dataSelector(datas.ElementAt(j)));
                if (j >= endPosition)
                {
                    i = datas.Count();
                    break;
                }
            }
            rtnDatas.Add(windows.ToList());
            windows.Clear();
        }

        return rtnDatas;
    }

    private static void DataCheck<T>(IEnumerable<T> datas, ref uint startPosition, ref uint endPosition, uint windowSize)
    {
        if (startPosition == uint.MaxValue) startPosition = 0;
        if (endPosition == uint.MaxValue) endPosition = (uint)datas.Count() - 1;

        if (windowSize == 0)
        {
            throw new ArgumentException($"Window size could not be 0");
        }
        else if (startPosition > endPosition)
        {
            throw new ArgumentException($"Start position could not bigger than end position");
        }
        else if (startPosition > datas.Count() - 1)
        {
            throw new ArgumentOutOfRangeException($"Start position : {startPosition} could not bigger than data length - 1 : {datas.Count() - 1}");
        }
        else if (endPosition > datas.Count() - 1)
        {
            throw new ArgumentOutOfRangeException($"End position : {endPosition} could not bigger than data length - 1 : {datas.Count() - 1}");
        }
    }
}