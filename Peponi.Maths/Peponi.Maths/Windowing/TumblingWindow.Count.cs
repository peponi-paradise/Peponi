namespace Peponi.Maths.Windowing;

public static partial class TumblingWindows
{
    public static IEnumerable<IEnumerable<T>> ToTumblingWindows<T>(IEnumerable<T> datas, uint windowSize) where T : struct
    {
        return ToTumblingWindowsCore(datas: datas, windowSize: windowSize);
    }

    public static Task<IEnumerable<IEnumerable<T>>> ToTumblingWindowsAsync<T>(IEnumerable<T> datas, uint windowSize) where T : struct
    {
        return Task.Run(() => ToTumblingWindows(datas, windowSize));
    }

    public static IEnumerable<IEnumerable<T>> ToTumblingWindows<T>(IEnumerable<T> datas, uint startPosition, uint windowSize) where T : struct
    {
        return ToTumblingWindowsCore(datas: datas, startPosition: startPosition, windowSize: windowSize);
    }

    public static Task<IEnumerable<IEnumerable<T>>> ToTumblingWindowsAsync<T>(IEnumerable<T> datas, uint startPosition, uint windowSize) where T : struct
    {
        return Task.Run(() => ToTumblingWindows(datas, startPosition, windowSize));
    }

    public static IEnumerable<IEnumerable<T>> ToTumblingWindows<T>(IEnumerable<T> datas, uint startPosition, uint endPosition, uint windowSize) where T : struct
    {
        return ToTumblingWindowsCore(datas, startPosition, endPosition, windowSize);
    }

    public static Task<IEnumerable<IEnumerable<T>>> ToTumblingWindowsAsync<T>(IEnumerable<T> datas, uint startPosition, uint endPosition, uint windowSize) where T : struct
    {
        return Task.Run(() => ToTumblingWindows(datas, startPosition, endPosition, windowSize));
    }

    public static IEnumerable<IEnumerable<V>> ToTumblingWindows<T, V>(IEnumerable<T> datas, uint windowSize, Func<T, V> dataSelector) where V : struct
    {
        return ToTumblingWindowsCore(datas: datas, windowSize: windowSize, dataSelector: dataSelector);
    }

    public static Task<IEnumerable<IEnumerable<V>>> ToTumblingWindowsAsync<T, V>(IEnumerable<T> datas, uint windowSize, Func<T, V> dataSelector) where V : struct
    {
        return Task.Run(() => ToTumblingWindows(datas, windowSize, dataSelector));
    }

    public static IEnumerable<IEnumerable<V>> ToTumblingWindows<T, V>(IEnumerable<T> datas, uint startPosition, uint windowSize, Func<T, V> dataSelector) where V : struct
    {
        return ToTumblingWindowsCore(datas: datas, startPosition: startPosition, windowSize: windowSize, dataSelector: dataSelector);
    }

    public static Task<IEnumerable<IEnumerable<V>>> ToTumblingWindowsAsync<T, V>(IEnumerable<T> datas, uint startPosition, uint windowSize, Func<T, V> dataSelector) where V : struct
    {
        return Task.Run(() => ToTumblingWindows(datas, startPosition, windowSize, dataSelector));
    }

    public static IEnumerable<IEnumerable<V>> ToTumblingWindows<T, V>(IEnumerable<T> datas, uint startPosition, uint endPosition, uint windowSize, Func<T, V> dataSelector) where V : struct
    {
        return ToTumblingWindowsCore(datas, startPosition, endPosition, windowSize, dataSelector);
    }

    public static Task<IEnumerable<IEnumerable<V>>> ToTumblingWindowsAsync<T, V>(IEnumerable<T> datas, uint startPosition, uint endPosition, uint windowSize, Func<T, V> dataSelector) where V : struct
    {
        return Task.Run(() => ToTumblingWindows(datas, startPosition, endPosition, windowSize, dataSelector));
    }

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