using Peponi.Math.Extensions;

namespace Peponi.Math.Windowing;

public partial class HoppingWindows
{
    public static IEnumerable<IEnumerable<DateTime>> ToHoppingWindows(IEnumerable<DateTime> datas, DateTime startTime, TimeSpan windowSize, TimeSpan hoppingStep)
    {
        return ToHoppingWindowsCore(datas, startTime, DateTime.MaxValue, windowSize, hoppingStep);
    }

    public static Task<IEnumerable<IEnumerable<DateTime>>> ToHoppingWindowsAsync(IEnumerable<DateTime> datas, DateTime startTime, TimeSpan windowSize, TimeSpan hoppingStep)
    {
        return Task.Run(() => ToHoppingWindows(datas, startTime, windowSize, hoppingStep));
    }

    public static IEnumerable<IEnumerable<DateTime>> ToHoppingWindows(IEnumerable<DateTime> datas, DateTime startTime, DateTime endTime, TimeSpan windowSize, TimeSpan hoppingStep)
    {
        return ToHoppingWindowsCore(datas, startTime, endTime, windowSize, hoppingStep);
    }

    public static Task<IEnumerable<IEnumerable<DateTime>>> ToHoppingWindowsAsync(IEnumerable<DateTime> datas, DateTime startTime, DateTime endTime, TimeSpan windowSize, TimeSpan hoppingStep)
    {
        return Task.Run(() => ToHoppingWindows(datas, startTime, endTime, windowSize, hoppingStep));
    }

    public static IEnumerable<IEnumerable<V>> ToHoppingWindows<T, V>(IEnumerable<T> datas, DateTime startTime, TimeSpan windowSize, TimeSpan hoppingStep, Func<T, DateTime> dateTimeSelector, Func<T, V> dataSelector) where V : struct
    {
        return ToHoppingWindowsCore(datas, startTime, DateTime.MaxValue, windowSize, hoppingStep, dateTimeSelector, dataSelector);
    }

    public static Task<IEnumerable<IEnumerable<V>>> ToHoppingWindowsAsync<T, V>(IEnumerable<T> datas, DateTime startTime, TimeSpan windowSize, TimeSpan hoppingStep, Func<T, DateTime> dateTimeSelector, Func<T, V> dataSelector) where V : struct
    {
        return Task.Run(() => ToHoppingWindows(datas, startTime, windowSize, hoppingStep, dateTimeSelector, dataSelector));
    }

    public static IEnumerable<IEnumerable<V>> ToHoppingWindows<T, V>(IEnumerable<T> datas, DateTime startTime, DateTime endTime, TimeSpan windowSize, TimeSpan hoppingStep, Func<T, DateTime> dateTimeSelector, Func<T, V> dataSelector) where V : struct
    {
        return ToHoppingWindowsCore(datas, startTime, endTime, windowSize, hoppingStep, dateTimeSelector, dataSelector);
    }

    public static Task<IEnumerable<IEnumerable<V>>> ToHoppingWindowsAsync<T, V>(IEnumerable<T> datas, DateTime startTime, DateTime endTime, TimeSpan windowSize, TimeSpan hoppingStep, Func<T, DateTime> dateTimeSelector, Func<T, V> dataSelector) where V : struct
    {
        return Task.Run(() => ToHoppingWindows(datas, startTime, endTime, windowSize, hoppingStep, dateTimeSelector, dataSelector));
    }

    private static IEnumerable<IEnumerable<DateTime>> ToHoppingWindowsCore(IEnumerable<DateTime> datas, DateTime startTime, DateTime endTime, TimeSpan windowSize, TimeSpan hoppingStep)
    {
        DataCheck(startTime, endTime, windowSize);

        datas = datas.Order();
        List<List<DateTime>> rtnDatas = new();

        while (startTime + windowSize <= endTime)
        {
            rtnDatas.Add(datas.Where((x) => x.IsBetween(startTime, startTime + windowSize) && x.IsBetween(startTime, endTime)).ToList());
            startTime += hoppingStep;
            if (startTime >= datas.Last()) break;
        }

        return rtnDatas;
    }

    private static IEnumerable<IEnumerable<V>> ToHoppingWindowsCore<T, V>(IEnumerable<T> datas, DateTime startTime, DateTime endTime, TimeSpan windowSize, TimeSpan hoppingStep, Func<T, DateTime> dateTimeSelector, Func<T, V> dataSelector) where V : struct
    {
        DataCheck(startTime, endTime, windowSize);

        datas = datas.OrderBy(dateTimeSelector).ToList();
        List<List<V>> rtnDatas = new();

        while (startTime + windowSize <= endTime)
        {
            var window = datas.Where((x) => dateTimeSelector(x).IsBetween(startTime, startTime + windowSize) && dateTimeSelector(x).IsBetween(startTime, endTime));
            var inputData = from data in window select dataSelector(data);

            rtnDatas.Add(inputData.ToList());

            startTime += hoppingStep;

            if (startTime >= dateTimeSelector(datas.Last())) break;
        }

        return rtnDatas;
    }

    private static void DataCheck(DateTime startTime, DateTime endTime, TimeSpan windowSize)
    {
        if (startTime > endTime) throw new ArgumentException($"Start time could not be bigger than end time. Start time : {startTime}, end time : {endTime}");
        else if (startTime + windowSize > endTime) throw new ArgumentException($"Start time + window size could not be bigger than end time. Start time + window size : {startTime + windowSize}, end time : {endTime}");
    }
}