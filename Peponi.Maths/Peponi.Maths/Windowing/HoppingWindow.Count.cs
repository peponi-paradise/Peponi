namespace Peponi.Maths.Windowing;

public static partial class HoppingWindows
{
    public static IEnumerable<IEnumerable<T>> ToHoppingWindows<T>(IEnumerable<T> datas, uint windowSize, uint hoppingStep) where T : struct
    {
        return ToHoppingWindowsCore(datas: datas, windowSize: windowSize, hoppingStep: hoppingStep);
    }

    public static Task<IEnumerable<IEnumerable<T>>> ToHoppingWindowsAsync<T>(IEnumerable<T> datas, uint windowSize, uint hoppingStep) where T : struct
    {
        return Task.Run(() => ToHoppingWindows(datas, windowSize, hoppingStep));
    }

    public static IEnumerable<IEnumerable<T>> ToHoppingWindows<T>(IEnumerable<T> datas, uint startPosition, uint windowSize, uint hoppingStep) where T : struct
    {
        return ToHoppingWindowsCore(datas: datas, startPosition: startPosition, windowSize: windowSize, hoppingStep: hoppingStep);
    }

    public static Task<IEnumerable<IEnumerable<T>>> ToHoppingWindowsAsync<T>(IEnumerable<T> datas, uint startPosition, uint windowSize, uint hoppingStep) where T : struct
    {
        return Task.Run(() => ToHoppingWindows(datas, startPosition, windowSize, hoppingStep));
    }

    public static IEnumerable<IEnumerable<T>> ToHoppingWindows<T>(IEnumerable<T> datas, uint startPosition, uint endPosition, uint windowSize, uint hoppingStep) where T : struct
    {
        return ToHoppingWindowsCore(datas, startPosition, endPosition, windowSize, hoppingStep);
    }

    public static Task<IEnumerable<IEnumerable<T>>> ToHoppingWindowsAsync<T>(IEnumerable<T> datas, uint startPosition, uint endPosition, uint windowSize, uint hoppingStep) where T : struct
    {
        return Task.Run(() => ToHoppingWindows(datas, startPosition, endPosition, windowSize, hoppingStep));
    }

    public static IEnumerable<IEnumerable<V>> ToHoppingWindows<T, V>(IEnumerable<T> datas, uint windowSize, uint hoppingStep, Func<T, V> dataSelector) where V : struct
    {
        return ToHoppingWindowsCore(datas: datas, windowSize: windowSize, hoppingStep: hoppingStep, dataSelector: dataSelector);
    }

    public static Task<IEnumerable<IEnumerable<V>>> ToHoppingWindowsAsync<T, V>(IEnumerable<T> datas, uint windowSize, uint hoppingStep, Func<T, V> dataSelector) where V : struct
    {
        return Task.Run(() => ToHoppingWindows(datas, windowSize, hoppingStep, dataSelector));
    }

    public static IEnumerable<IEnumerable<V>> ToHoppingWindows<T, V>(IEnumerable<T> datas, uint startPosition, uint windowSize, uint hoppingStep, Func<T, V> dataSelector) where V : struct
    {
        return ToHoppingWindowsCore(datas: datas, startPosition: startPosition, windowSize: windowSize, hoppingStep: hoppingStep, dataSelector: dataSelector);
    }

    public static Task<IEnumerable<IEnumerable<V>>> ToHoppingWindowsAsync<T, V>(IEnumerable<T> datas, uint startPosition, uint windowSize, uint hoppingStep, Func<T, V> dataSelector) where V : struct
    {
        return Task.Run(() => ToHoppingWindows(datas, startPosition, windowSize, hoppingStep, dataSelector));
    }

    public static IEnumerable<IEnumerable<V>> ToHoppingWindows<T, V>(IEnumerable<T> datas, uint startPosition, uint endPosition, uint windowSize, uint hoppingStep, Func<T, V> dataSelector) where V : struct
    {
        return ToHoppingWindowsCore(datas, startPosition, endPosition, windowSize, hoppingStep, dataSelector);
    }

    public static Task<IEnumerable<IEnumerable<V>>> ToHoppingWindowsAsync<T, V>(IEnumerable<T> datas, uint startPosition, uint endPosition, uint windowSize, uint hoppingStep, Func<T, V> dataSelector) where V : struct
    {
        return Task.Run(() => ToHoppingWindows(datas, startPosition, endPosition, windowSize, hoppingStep, dataSelector));
    }

    private static IEnumerable<IEnumerable<T>> ToHoppingWindowsCore<T>(IEnumerable<T> datas, uint startPosition = uint.MaxValue, uint endPosition = uint.MaxValue, uint windowSize = 0, uint hoppingStep = 0) where T : struct
    {
        DataCheck(datas, ref startPosition, ref endPosition, windowSize, hoppingStep);

        List<List<T>> rtnDatas = new();
        List<T> windows = new();

        for (int i = (int)startPosition; i <= endPosition; i += (int)hoppingStep)
        {
            for (int j = i; j < i + windowSize; j++)
            {
                windows.Add(datas.ElementAt(j));
                if (j >= datas.Count() || j >= endPosition)
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

    private static IEnumerable<IEnumerable<V>> ToHoppingWindowsCore<T, V>(IEnumerable<T> datas, uint startPosition = uint.MaxValue, uint endPosition = uint.MaxValue, uint windowSize = 0, uint hoppingStep = 0, Func<T, V>? dataSelector = null) where V : struct
    {
        DataCheck(datas, ref startPosition, ref endPosition, windowSize, hoppingStep);
        if (dataSelector == null)
        {
            throw new ArgumentNullException($"{nameof(dataSelector)} could not be null");
        }

        List<List<V>> rtnDatas = new();
        List<V> windows = new();

        for (int i = (int)startPosition; i <= endPosition; i += (int)hoppingStep)
        {
            for (int j = i; j < i + windowSize; j++)
            {
                windows.Add(dataSelector(datas.ElementAt(j)));
                if (j >= datas.Count() || j >= endPosition)
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

    private static void DataCheck<T>(IEnumerable<T> datas, ref uint startPosition, ref uint endPosition, uint windowSize, uint hoppingStep)
    {
        if (startPosition == uint.MaxValue) startPosition = 0;
        if (endPosition == uint.MaxValue) endPosition = (uint)datas.Count() - 1;

        if (windowSize == 0 || hoppingStep == 0)
        {
            throw new ArgumentException($"Window size, hopping step could not be 0");
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