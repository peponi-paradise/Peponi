namespace Peponi.Math.Windowing;

public static partial class TumblingWindows
{
    public static IEnumerable<IEnumerable<DateTime>> ToTumblingWindows(IEnumerable<DateTime> datas, DateTime startTime, TimeSpan windowSize)
    {
        datas = datas.Order();
        List<List<DateTime>> rtnDatas = new();
        List<DateTime> windows = new();
        int dataIndex = 0;

        while (dataIndex < datas.Count())
        {
            if (datas.ElementAt(dataIndex) < startTime + windowSize)
            {
                windows.Add(datas.ElementAt(dataIndex++));
            }
            else
            {
                rtnDatas.Add(windows.ToList());
                windows.Clear();
                startTime += windowSize;
                if (datas.ElementAt(dataIndex) < startTime + windowSize)
                {
                    windows.Add(datas.ElementAt(dataIndex++));
                }
            }
        }

        return rtnDatas;
    }

    public static Task<IEnumerable<IEnumerable<DateTime>>> ToTumblingWindowsAsync(IEnumerable<DateTime> datas, DateTime startTime, TimeSpan windowSize)
    {
        return Task.Run(() => ToTumblingWindows(datas, startTime, windowSize));
    }

    public static IEnumerable<IEnumerable<DateTime>> ToTumblingWindows(IEnumerable<DateTime> datas, DateTime startTime, DateTime endTime, TimeSpan windowSize)
    {
        datas = datas.Order();
        List<List<DateTime>> rtnDatas = new();
        List<DateTime> windows = new();
        int dataIndex = 0;

        while (dataIndex < datas.Count())
        {
            if (datas.ElementAt(dataIndex) < startTime + windowSize)
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

    public static Task<IEnumerable<IEnumerable<DateTime>>> ToTumblingWindowsAsync(IEnumerable<DateTime> datas, DateTime startTime, DateTime endTime, TimeSpan windowSize)
    {
        return Task.Run(() => ToTumblingWindows(datas, startTime, endTime, windowSize));
    }

    public static IEnumerable<IEnumerable<DataType>> ToTumblingWindows<Data, DataType>(IEnumerable<Data> datas, DateTime startTime, TimeSpan windowSize, Func<Data, DateTime> dateTimeSelector, Func<Data, DataType> dataTypeSelector) where DataType : struct
    {
        datas = datas.OrderBy(dateTimeSelector).ToList();
        List<List<DataType>> rtnDatas = new();
        List<DataType> windows = new();
        int dataIndex = 0;

        while (dataIndex < datas.Count())
        {
            if (dateTimeSelector(datas.ElementAt(dataIndex)) < startTime + windowSize)
            {
                windows.Add(dataTypeSelector(datas.ElementAt(dataIndex++)));
            }
            else
            {
                rtnDatas.Add(windows.ToList());
                windows.Clear();
                startTime += windowSize;
                if (dateTimeSelector(datas.ElementAt(dataIndex)) < startTime + windowSize)
                {
                    windows.Add(dataTypeSelector(datas.ElementAt(dataIndex++)));
                }
            }
        }

        return rtnDatas;
    }

    public static Task<IEnumerable<IEnumerable<DataType>>> ToTumblingWindowsAsync<Data, DataType>(IEnumerable<Data> datas, DateTime startTime, TimeSpan windowSize, Func<Data, DateTime> dateTimeSelector, Func<Data, DataType> dataTypeSelector) where DataType : struct
    {
        return Task.Run(() => ToTumblingWindows(datas, startTime, windowSize, dateTimeSelector, dataTypeSelector));
    }
}