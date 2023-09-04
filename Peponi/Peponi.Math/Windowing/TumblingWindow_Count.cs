using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Peponi.Math.Windowing;

public static partial class TumblingWindows
{
    public static IEnumerable<IEnumerable<DataType>> ToTumblingWindows<DataType>(IEnumerable<DataType> datas, uint windowSize) where DataType : struct
    {
        if (windowSize == 0)
        {
            throw new ArgumentException($"Window size could not be 0");
        }

        List<List<DataType>> rtnDatas = new();
        List<DataType> windows = new();

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

    public static Task<IEnumerable<IEnumerable<DataType>>> ToTumblingWindowsAsync<DataType>(IEnumerable<DataType> datas, uint windowSize) where DataType : struct
    {
        return Task.Run(() => ToTumblingWindows(datas, windowSize));
    }

    public static IEnumerable<IEnumerable<DataType>> ToTumblingWindows<DataType>(IEnumerable<DataType> datas, uint startPosition, uint windowSize) where DataType : struct
    {
        if (startPosition == 0 || windowSize == 0)
        {
            throw new ArgumentException($"Start position, window size could not be 0");
        }
        else if (startPosition > datas.Count())
        {
            throw new ArgumentOutOfRangeException($"Start position : {startPosition} could not bigger than data length : {datas.Count()}");
        }

        List<List<DataType>> rtnDatas = new();
        List<DataType> windows = new();

        for (int i = (int)startPosition; i < datas.Count(); i++)
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

    public static Task<IEnumerable<IEnumerable<DataType>>> ToTumblingWindowsAsync<DataType>(IEnumerable<DataType> datas, uint startPosition, uint windowSize) where DataType : struct
    {
        return Task.Run(() => ToTumblingWindows(datas, startPosition, windowSize));
    }

    public static IEnumerable<IEnumerable<DataType>> ToTumblingWindows<DataType>(IEnumerable<DataType> datas, uint startPosition, uint endPosition, uint windowSize) where DataType : struct
    {
        if (startPosition == 0 || endPosition == 0 || windowSize == 0)
        {
            throw new ArgumentException($"Start & end position, window size could not be 0");
        }
        else if (startPosition > datas.Count())
        {
            throw new ArgumentOutOfRangeException($"Start position : {startPosition} could not bigger than data length : {datas.Count()}");
        }
        else if (endPosition - 1 > datas.Count())
        {
            throw new ArgumentOutOfRangeException($"End position -1 : {endPosition - 1} could not bigger than data length : {datas.Count()}");
        }

        List<List<DataType>> rtnDatas = new();
        List<DataType> windows = new();

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

    public static Task<IEnumerable<IEnumerable<DataType>>> ToTumblingWindowsAsync<DataType>(IEnumerable<DataType> datas, uint startPosition, uint endPosition, uint windowSize) where DataType : struct
    {
        return Task.Run(() => ToTumblingWindows(datas, startPosition, endPosition, windowSize));
    }

    public static IEnumerable<IEnumerable<DataType>> ToTumblingWindows<Data, DataType>(IEnumerable<Data> datas, uint windowSize, Func<Data, DataType> dataTypeSelector) where DataType : struct
    {
        if (windowSize == 0)
        {
            throw new ArgumentException($"Window size could not be 0");
        }

        List<List<DataType>> rtnDatas = new();
        List<DataType> windows = new();

        for (int i = 0; i < datas.Count(); i++)
        {
            windows.Add(dataTypeSelector(datas.ElementAt(i)));
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

    public static Task<IEnumerable<IEnumerable<DataType>>> ToTumblingWindowsAsync<Data, DataType>(IEnumerable<Data> datas, uint windowSize, Func<Data, DataType> dataTypeSelector) where DataType : struct
    {
        return Task.Run(() => ToTumblingWindows(datas, windowSize, dataTypeSelector));
    }

    public static IEnumerable<IEnumerable<DataType>> ToTumblingWindows<Data, DataType>(IEnumerable<Data> datas, uint startPosition, uint windowSize, Func<Data, DataType> dataTypeSelector) where DataType : struct
    {
        if (startPosition == 0 || windowSize == 0)
        {
            throw new ArgumentException($"Start position, window size could not be 0");
        }
        else if (startPosition > datas.Count())
        {
            throw new ArgumentOutOfRangeException($"Start position : {startPosition} could not bigger than data length : {datas.Count()}");
        }

        List<List<DataType>> rtnDatas = new();
        List<DataType> windows = new();

        for (int i = (int)startPosition; i < datas.Count(); i++)
        {
            windows.Add(dataTypeSelector(datas.ElementAt(i)));
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

    public static Task<IEnumerable<IEnumerable<DataType>>> ToTumblingWindowsAsync<Data, DataType>(IEnumerable<Data> datas, uint startPosition, uint windowSize, Func<Data, DataType> dataTypeSelector) where DataType : struct
    {
        return Task.Run(() => ToTumblingWindows(datas, startPosition, windowSize, dataTypeSelector));
    }

    public static IEnumerable<IEnumerable<DataType>> ToTumblingWindows<Data, DataType>(IEnumerable<Data> datas, uint startPosition, uint endPosition, uint windowSize, Func<Data, DataType> dataTypeSelector) where DataType : struct
    {
        if (startPosition == 0 || endPosition == 0 || windowSize == 0)
        {
            throw new ArgumentException($"Start & end position, window size could not be 0");
        }
        else if (startPosition > datas.Count())
        {
            throw new ArgumentOutOfRangeException($"Start position : {startPosition} could not bigger than data length : {datas.Count()}");
        }
        else if (endPosition - 1 > datas.Count())
        {
            throw new ArgumentOutOfRangeException($"End position -1 : {endPosition - 1} could not bigger than data length : {datas.Count()}");
        }

        List<List<DataType>> rtnDatas = new();
        List<DataType> windows = new();

        for (int i = (int)startPosition; i <= endPosition; i++)
        {
            windows.Add(dataTypeSelector(datas.ElementAt(i)));
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

    public static Task<IEnumerable<IEnumerable<DataType>>> ToTumblingWindowsAsync<Data, DataType>(IEnumerable<Data> datas, uint startPosition, uint endPosition, uint windowSize, Func<Data, DataType> dataTypeSelector) where DataType : struct
    {
        return Task.Run(() => ToTumblingWindows(datas, startPosition, endPosition, windowSize, dataTypeSelector));
    }
}