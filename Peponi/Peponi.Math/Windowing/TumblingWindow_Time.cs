namespace Peponi.Math.Windowing;

public static partial class TumblingWindows
{
    public static IEnumerable<IEnumerable<DateTime>> ToTumblingWindows(IEnumerable<DateTime> datas, DateTime startTime, TimeSpan windowSize)
    {
        return ToTumblingWindowsCore(datas, startTime, DateTime.MaxValue, windowSize);
    }

    public static Task<IEnumerable<IEnumerable<DateTime>>> ToTumblingWindowsAsync(IEnumerable<DateTime> datas, DateTime startTime, TimeSpan windowSize)
    {
        return Task.Run(() => ToTumblingWindows(datas, startTime, windowSize));
    }

    public static IEnumerable<IEnumerable<DateTime>> ToTumblingWindows(IEnumerable<DateTime> datas, DateTime startTime, DateTime endTime, TimeSpan windowSize)
    {
        return ToTumblingWindowsCore(datas, startTime, endTime, windowSize);
    }

    public static Task<IEnumerable<IEnumerable<DateTime>>> ToTumblingWindowsAsync(IEnumerable<DateTime> datas, DateTime startTime, DateTime endTime, TimeSpan windowSize)
    {
        return Task.Run(() => ToTumblingWindows(datas, startTime, endTime, windowSize));
    }

    public static IEnumerable<IEnumerable<V>> ToTumblingWindows<T, V>(IEnumerable<T> datas, DateTime startTime, TimeSpan windowSize, Func<T, DateTime> dateTimeSelector, Func<T, V> dataSelector) where V : struct
    {
        return ToTumblingWindowsCore(datas, startTime, DateTime.MaxValue, windowSize, dateTimeSelector, dataSelector);
    }

    public static Task<IEnumerable<IEnumerable<V>>> ToTumblingWindowsAsync<T, V>(IEnumerable<T> datas, DateTime startTime, TimeSpan windowSize, Func<T, DateTime> dateTimeSelector, Func<T, V> dataSelector) where V : struct
    {
        return Task.Run(() => ToTumblingWindows(datas, startTime, windowSize, dateTimeSelector, dataSelector));
    }

    public static IEnumerable<IEnumerable<V>> ToTumblingWindows<T, V>(IEnumerable<T> datas, DateTime startTime, DateTime endTime, TimeSpan windowSize, Func<T, DateTime> dateTimeSelector, Func<T, V> dataSelector) where V : struct
    {
        return ToTumblingWindowsCore(datas, startTime, endTime, windowSize, dateTimeSelector, dataSelector);
    }

    public static Task<IEnumerable<IEnumerable<V>>> ToTumblingWindowsAsync<T, V>(IEnumerable<T> datas, DateTime startTime, DateTime endTime, TimeSpan windowSize, Func<T, DateTime> dateTimeSelector, Func<T, V> dataSelector) where V : struct
    {
        return Task.Run(() => ToTumblingWindows(datas, startTime, endTime, windowSize, dateTimeSelector, dataSelector));
    }

    private static IEnumerable<IEnumerable<DateTime>> ToTumblingWindowsCore(IEnumerable<DateTime> datas, DateTime startTime, DateTime endTime, TimeSpan windowSize)
    {
        datas = datas.Order();
        List<List<DateTime>> rtnDatas = new();
        List<DateTime> windows = new();
        int dataIndex = 0;

        while (dataIndex < datas.Count())
        {
            if (datas.ElementAt(dataIndex) < startTime + windowSize && datas.ElementAt(dataIndex) <= endTime)
            {
                windows.Add(datas.ElementAt(dataIndex++));
            }
            else
            {
                rtnDatas.Add(windows.ToList());
                windows.Clear();
                startTime += windowSize;
                if (datas.ElementAt(dataIndex) > endTime) break;
                else if (datas.ElementAt(dataIndex) < startTime + windowSize)
                {
                    windows.Add(datas.ElementAt(dataIndex++));
                }
            }
        }

        return rtnDatas;
    }

    private static IEnumerable<IEnumerable<V>> ToTumblingWindowsCore<T, V>(IEnumerable<T> datas, DateTime startTime, DateTime endTime, TimeSpan windowSize, Func<T, DateTime> dateTimeSelector, Func<T, V> dataSelector) where V : struct
    {
        datas = datas.OrderBy(dateTimeSelector).ToList();
        List<List<V>> rtnDatas = new();
        List<V> windows = new();
        int dataIndex = 0;

        while (dataIndex < datas.Count())
        {
            if (dateTimeSelector(datas.ElementAt(dataIndex)) < startTime + windowSize && dateTimeSelector(datas.ElementAt(dataIndex)) <= endTime)
            {
                windows.Add(dataSelector(datas.ElementAt(dataIndex++)));
            }
            else
            {
                rtnDatas.Add(windows.ToList());
                windows.Clear();
                startTime += windowSize;
                if (dateTimeSelector(datas.ElementAt(dataIndex)) > endTime) break;
                else if (dateTimeSelector(datas.ElementAt(dataIndex)) < startTime + windowSize)
                {
                    windows.Add(dataSelector(datas.ElementAt(dataIndex++)));
                }
            }
        }

        return rtnDatas;
    }
}