using Peponi.Math.Windowing;

namespace Peponi.Math.Extensions;

public static class TumblingWindowsExtensions
{
    // Count type

    public static IEnumerable<IEnumerable<DataType>> ToTumblingWindows<DataType>(this IEnumerable<DataType> datas, uint windowSize) where DataType : struct
    {
        return TumblingWindows.ToTumblingWindows(datas, windowSize);
    }

    public static Task<IEnumerable<IEnumerable<DataType>>> ToTumblingWindowsAsync<DataType>(this IEnumerable<DataType> datas, uint windowSize) where DataType : struct
    {
        return TumblingWindows.ToTumblingWindowsAsync(datas, windowSize);
    }

    public static IEnumerable<IEnumerable<DataType>> ToTumblingWindows<DataType>(this IEnumerable<DataType> datas, uint startPosition, uint windowSize) where DataType : struct
    {
        return TumblingWindows.ToTumblingWindows(datas, startPosition, windowSize);
    }

    public static Task<IEnumerable<IEnumerable<DataType>>> ToTumblingWindowsAsync<DataType>(this IEnumerable<DataType> datas, uint startPosition, uint windowSize) where DataType : struct
    {
        return TumblingWindows.ToTumblingWindowsAsync(datas, startPosition, windowSize);
    }

    public static IEnumerable<IEnumerable<DataType>> ToTumblingWindows<DataType>(this IEnumerable<DataType> datas, uint startPosition, uint endPosition, uint windowSize) where DataType : struct
    {
        return TumblingWindows.ToTumblingWindows(datas, startPosition, endPosition, windowSize);
    }

    public static Task<IEnumerable<IEnumerable<DataType>>> ToTumblingWindowsAsync<DataType>(this IEnumerable<DataType> datas, uint startPosition, uint endPosition, uint windowSize) where DataType : struct
    {
        return TumblingWindows.ToTumblingWindowsAsync(datas, startPosition, endPosition, windowSize);
    }

    public static IEnumerable<IEnumerable<DataType>> ToTumblingWindows<Data, DataType>(this IEnumerable<Data> datas, uint windowSize, Func<Data, DataType> dataTypeSelector) where DataType : struct
    {
        return TumblingWindows.ToTumblingWindows(datas, windowSize, dataTypeSelector);
    }

    public static Task<IEnumerable<IEnumerable<DataType>>> ToTumblingWindowsAsync<Data, DataType>(this IEnumerable<Data> datas, uint windowSize, Func<Data, DataType> dataTypeSelector) where DataType : struct
    {
        return TumblingWindows.ToTumblingWindowsAsync(datas, windowSize, dataTypeSelector);
    }

    public static IEnumerable<IEnumerable<DataType>> ToTumblingWindows<Data, DataType>(this IEnumerable<Data> datas, uint startPosition, uint windowSize, Func<Data, DataType> dataTypeSelector) where DataType : struct
    {
        return TumblingWindows.ToTumblingWindows(datas, startPosition, windowSize, dataTypeSelector);
    }

    public static Task<IEnumerable<IEnumerable<DataType>>> ToTumblingWindowsAsync<Data, DataType>(this IEnumerable<Data> datas, uint startPosition, uint windowSize, Func<Data, DataType> dataTypeSelector) where DataType : struct
    {
        return TumblingWindows.ToTumblingWindowsAsync(datas, startPosition, windowSize, dataTypeSelector);
    }

    public static IEnumerable<IEnumerable<DataType>> ToTumblingWindows<Data, DataType>(this IEnumerable<Data> datas, uint startPosition, uint endPosition, uint windowSize, Func<Data, DataType> dataTypeSelector) where DataType : struct
    {
        return TumblingWindows.ToTumblingWindows(datas, startPosition, endPosition, windowSize, dataTypeSelector);
    }

    public static Task<IEnumerable<IEnumerable<DataType>>> ToTumblingWindowsAsync<Data, DataType>(this IEnumerable<Data> datas, uint startPosition, uint endPosition, uint windowSize, Func<Data, DataType> dataTypeSelector) where DataType : struct
    {
        return TumblingWindows.ToTumblingWindowsAsync(datas, startPosition, endPosition, windowSize, dataTypeSelector);
    }

    // Time type

    public static IEnumerable<IEnumerable<DateTime>> ToTumblingWindows(this IEnumerable<DateTime> datas, DateTime startTime, TimeSpan windowSize)
    {
        return TumblingWindows.ToTumblingWindows(datas, startTime, windowSize);
    }

    public static Task<IEnumerable<IEnumerable<DateTime>>> ToTumblingWindowsAsync(this IEnumerable<DateTime> datas, DateTime startTime, TimeSpan windowSize)
    {
        return TumblingWindows.ToTumblingWindowsAsync(datas, startTime, windowSize);
    }

    public static IEnumerable<IEnumerable<DateTime>> ToTumblingWindows(this IEnumerable<DateTime> datas, DateTime startTime, DateTime endTime, TimeSpan windowSize)
    {
        return TumblingWindows.ToTumblingWindows(datas, startTime, endTime, windowSize);
    }

    public static Task<IEnumerable<IEnumerable<DateTime>>> ToTumblingWindowsAsync(this IEnumerable<DateTime> datas, DateTime startTime, DateTime endTime, TimeSpan windowSize)
    {
        return TumblingWindows.ToTumblingWindowsAsync(datas, startTime, endTime, windowSize);
    }

    public static IEnumerable<IEnumerable<DataType>> ToTumblingWindows<Data, DataType>(this IEnumerable<Data> datas, DateTime startTime, TimeSpan windowSize, Func<Data, DateTime> dateTimeSelector, Func<Data, DataType> dataTypeSelector) where DataType : struct
    {
        return TumblingWindows.ToTumblingWindows(datas, startTime, windowSize, dateTimeSelector, dataTypeSelector);
    }

    public static Task<IEnumerable<IEnumerable<DataType>>> ToTumblingWindowsAsync<Data, DataType>(this IEnumerable<Data> datas, DateTime startTime, TimeSpan windowSize, Func<Data, DateTime> dateTimeSelector, Func<Data, DataType> dataTypeSelector) where DataType : struct
    {
        return TumblingWindows.ToTumblingWindowsAsync(datas, startTime, windowSize, dateTimeSelector, dataTypeSelector);
    }
}