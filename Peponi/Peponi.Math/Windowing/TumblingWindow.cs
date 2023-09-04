namespace Peponi.Math.Windowing;

public static class TumblingWindows
{
    public static IEnumerable<IEnumerable<TData>> ToTumblingWindows<TData>(IEnumerable<TData> datas, int windowSize) where TData : struct
    {
        List<List<TData>> rtnDatas = new();
        List<TData> windows = new();

        for (int i = 0; i < datas.Count(); i++)
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

    public static Task<IEnumerable<IEnumerable<TData>>> ToTumblingWindowsAsync<TData>(IEnumerable<TData> datas, int windowSize) where TData : struct
    {
        return Task.Run(() => ToTumblingWindows(datas, windowSize));
    }

    public static IEnumerable<IEnumerable<DataType>> ToTumblingWindows<TData, DataType>(IEnumerable<TData> datas, DateTime startTime, TimeSpan windowSize, Func<TData, DateTime> dateTimeSelector, Func<TData, DataType> dataTypeSelector) where DataType : struct
    {
        datas = datas.OrderBy(dateTimeSelector).ToList();
        List<List<DataType>> rtnDatas = new();
        List<DataType> windows = new();

        for (int i = 0; i < datas.Count(); i++)
        {
            if (dateTimeSelector(datas.ElementAt(i)) - windowSize < startTime)
            {
                windows.Add(dataTypeSelector(datas.ElementAt(i)));
            }
            else
            {
                rtnDatas.Add(windows.ToList());
                windows.Clear();
                startTime += windowSize;
                windows.Add(dataTypeSelector(datas.ElementAt(i)));
            }
        }

        if (windows.Count > 0)
        {
            rtnDatas.Add(windows.ToList());
        }

        return rtnDatas;
    }

    public static Task<IEnumerable<IEnumerable<DataType>>> ToTumblingWindowsAsync<TData, DataType>(IEnumerable<TData> datas, DateTime startTime, TimeSpan windowSize, Func<TData, DateTime> dateTimeSelector, Func<TData, DataType> dataTypeSelector) where DataType : struct
    {
        return Task.Run(() => ToTumblingWindows(datas, startTime, windowSize, dateTimeSelector, dataTypeSelector));
    }

    public static IEnumerable<IEnumerable<DateTime>> ToTumblingWindows(IEnumerable<DateTime> datas, DateTime startTime, TimeSpan windowSize)
    {
        datas = datas.Order();
        List<List<DateTime>> rtnDatas = new();
        List<DateTime> windows = new();

        for (int i = 0; i < datas.Count(); i++)
        {
            if (datas.ElementAt(i) - windowSize < startTime)
            {
                windows.Add(datas.ElementAt(i));
            }
            else
            {
                rtnDatas.Add(windows.ToList());
                windows.Clear();
                startTime += windowSize;
                windows.Add(datas.ElementAt(i));
            }
        }

        if (windows.Count > 0)
        {
            rtnDatas.Add(windows.ToList());
        }

        return rtnDatas;
    }

    public static Task<IEnumerable<IEnumerable<DateTime>>> ToTumblingWindowsAsync(IEnumerable<DateTime> datas, DateTime startTime, TimeSpan windowSize)
    {
        return Task.Run(() => ToTumblingWindows(datas, startTime, windowSize));
    }
}