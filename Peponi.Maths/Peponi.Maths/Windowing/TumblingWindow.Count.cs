namespace Peponi.Maths.Windowing;

/// <summary>
/// Compute tumbling windows
/// </summary>
/// <remarks>
/// <see href="https://github.com/peponi-paradise/Peponi/blob/Release/Peponi.Maths/Peponi.Maths/Docs/README.md"/>
/// </remarks>
public static partial class TumblingWindows
{
    /// <inheritdoc cref="ToTumblingWindows{T}(IEnumerable{T}, uint, uint, uint)"/>
    public static IEnumerable<IEnumerable<T>> ToTumblingWindows<T>(IEnumerable<T> datas, uint windowSize) where T : struct
    {
        return ToTumblingWindowsCore(datas: datas, windowSize: windowSize);
    }

    /// <inheritdoc cref="ToTumblingWindows{T}(IEnumerable{T}, uint, uint, uint)"/>
    public static Task<IEnumerable<IEnumerable<T>>> ToTumblingWindowsAsync<T>(IEnumerable<T> datas, uint windowSize) where T : struct
    {
        return Task.Run(() => ToTumblingWindows(datas, windowSize));
    }

    /// <inheritdoc cref="ToTumblingWindows{T}(IEnumerable{T}, uint, uint, uint)"/>
    public static IEnumerable<IEnumerable<T>> ToTumblingWindows<T>(IEnumerable<T> datas, uint startPosition, uint windowSize) where T : struct
    {
        return ToTumblingWindowsCore(datas: datas, startPosition: startPosition, windowSize: windowSize);
    }

    /// <inheritdoc cref="ToTumblingWindows{T}(IEnumerable{T}, uint, uint, uint)"/>
    public static Task<IEnumerable<IEnumerable<T>>> ToTumblingWindowsAsync<T>(IEnumerable<T> datas, uint startPosition, uint windowSize) where T : struct
    {
        return Task.Run(() => ToTumblingWindows(datas, startPosition, windowSize));
    }

    /// <summary>
    /// Compute tumbling windows
    /// </summary>
    /// <typeparam name="T">Struct type</typeparam>
    /// <param name="datas"></param>
    /// <param name="startPosition">startPosition &lt;= endPosition</param>
    /// <param name="endPosition">startPosition &lt;= endPosition</param>
    /// <param name="windowSize">Bigger than 0</param>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public static IEnumerable<IEnumerable<T>> ToTumblingWindows<T>(IEnumerable<T> datas, uint startPosition, uint endPosition, uint windowSize) where T : struct
    {
        return ToTumblingWindowsCore(datas, startPosition, endPosition, windowSize);
    }

    /// <inheritdoc cref="ToTumblingWindows{T}(IEnumerable{T}, uint, uint, uint)"/>
    public static Task<IEnumerable<IEnumerable<T>>> ToTumblingWindowsAsync<T>(IEnumerable<T> datas, uint startPosition, uint endPosition, uint windowSize) where T : struct
    {
        return Task.Run(() => ToTumblingWindows(datas, startPosition, endPosition, windowSize));
    }

    /// <inheritdoc cref="ToTumblingWindows{T, V}(IEnumerable{T}, uint, uint, uint, Func{T, V}?)"/>
    public static IEnumerable<IEnumerable<V>> ToTumblingWindows<T, V>(IEnumerable<T> datas, uint windowSize, Func<T, V> dataSelector) where V : struct
    {
        return ToTumblingWindowsCore(datas: datas, windowSize: windowSize, dataSelector: dataSelector);
    }

    /// <inheritdoc cref="ToTumblingWindows{T, V}(IEnumerable{T}, uint, uint, uint, Func{T, V}?)"/>
    public static Task<IEnumerable<IEnumerable<V>>> ToTumblingWindowsAsync<T, V>(IEnumerable<T> datas, uint windowSize, Func<T, V> dataSelector) where V : struct
    {
        return Task.Run(() => ToTumblingWindows(datas, windowSize, dataSelector));
    }

    /// <inheritdoc cref="ToTumblingWindows{T, V}(IEnumerable{T}, uint, uint, uint, Func{T, V}?)"/>
    public static IEnumerable<IEnumerable<V>> ToTumblingWindows<T, V>(IEnumerable<T> datas, uint startPosition, uint windowSize, Func<T, V> dataSelector) where V : struct
    {
        return ToTumblingWindowsCore(datas: datas, startPosition: startPosition, windowSize: windowSize, dataSelector: dataSelector);
    }

    /// <inheritdoc cref="ToTumblingWindows{T, V}(IEnumerable{T}, uint, uint, uint, Func{T, V}?)"/>
    public static Task<IEnumerable<IEnumerable<V>>> ToTumblingWindowsAsync<T, V>(IEnumerable<T> datas, uint startPosition, uint windowSize, Func<T, V> dataSelector) where V : struct
    {
        return Task.Run(() => ToTumblingWindows(datas, startPosition, windowSize, dataSelector));
    }

    /// <summary>
    /// Compute tumbling windows
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
    public static IEnumerable<IEnumerable<V>> ToTumblingWindows<T, V>(IEnumerable<T> datas, uint startPosition, uint endPosition, uint windowSize, Func<T, V> dataSelector) where V : struct
    {
        return ToTumblingWindowsCore(datas, startPosition, endPosition, windowSize, dataSelector);
    }

    /// <inheritdoc cref="ToTumblingWindows{T, V}(IEnumerable{T}, uint, uint, uint, Func{T, V}?)"/>
    public static Task<IEnumerable<IEnumerable<V>>> ToTumblingWindowsAsync<T, V>(IEnumerable<T> datas, uint startPosition, uint endPosition, uint windowSize, Func<T, V> dataSelector) where V : struct
    {
        return Task.Run(() => ToTumblingWindows(datas, startPosition, endPosition, windowSize, dataSelector));
    }

    /// <summary>
    /// Compute tumbling windows
    /// </summary>
    /// <typeparam name="T">Struct type</typeparam>
    /// <param name="datas"></param>
    /// <param name="startPosition">startPosition &lt;= endPosition</param>
    /// <param name="endPosition">startPosition &lt;= endPosition</param>
    /// <param name="windowSize">Bigger than 0</param>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    private static IEnumerable<IEnumerable<T>> ToTumblingWindowsCore<T>(IEnumerable<T> datas, uint startPosition = uint.MaxValue, uint endPosition = uint.MaxValue, uint windowSize = 0) where T : struct
    {
        DataCheck(datas, ref startPosition, ref endPosition, windowSize);

        List<List<T>> rtnDatas = new();
        List<T> windows = new();

        for (int i = (int)startPosition; i <= endPosition; i++)
        {
            windows.Add(datas.ElementAt(i));
            if (windows.Count == windowSize)
            {
                rtnDatas.Add(windows.ToList());
                windows.Clear();
            }
        }

        if (windows.Count > 0)
        {
            rtnDatas.Add(windows.ToList());
        }

        return rtnDatas;
    }

    /// <summary>
    /// Compute tumbling windows
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
    private static IEnumerable<IEnumerable<V>> ToTumblingWindowsCore<T, V>(IEnumerable<T> datas, uint startPosition = uint.MaxValue, uint endPosition = uint.MaxValue, uint windowSize = 0, Func<T, V>? dataSelector = null) where V : struct
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
            windows.Add(dataSelector(datas.ElementAt(i)));
            if (windows.Count == windowSize)
            {
                rtnDatas.Add(windows.ToList());
                windows.Clear();
            }
        }

        if (windows.Count > 0)
        {
            rtnDatas.Add(windows.ToList());
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