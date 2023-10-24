using Peponi.Math.Extensions;

namespace Peponi.Math.Windowing;

public static partial class SlidingWindows
{
    public static IEnumerable<IEnumerable<DateTime>> ToSlidingWindows(IEnumerable<DateTime> datas, DateTime startTime, TimeSpan windowSize)
    {
        return ToSlidingWindowsCore(datas, startTime, DateTime.MaxValue, windowSize);
    }

    public static Task<IEnumerable<IEnumerable<DateTime>>> ToSlidingWindowsAsync(IEnumerable<DateTime> datas, DateTime startTime, TimeSpan windowSize)
    {
        return Task.Run(() => ToSlidingWindows(datas, startTime, windowSize));
    }

    public static IEnumerable<IEnumerable<DateTime>> ToSlidingWindows(IEnumerable<DateTime> datas, DateTime startTime, DateTime endTime, TimeSpan windowSize)
    {
        return ToSlidingWindowsCore(datas, startTime, endTime, windowSize);
    }

    public static Task<IEnumerable<IEnumerable<DateTime>>> ToSlidingWindowsAsync(IEnumerable<DateTime> datas, DateTime startTime, DateTime endTime, TimeSpan windowSize)
    {
        return Task.Run(() => ToSlidingWindows(datas, startTime, endTime, windowSize));
    }

    public static IEnumerable<IEnumerable<V>> ToSlidingWindows<T, V>(IEnumerable<T> datas, DateTime startTime, TimeSpan windowSize, Func<T, DateTime> dateTimeSelector, Func<T, V> dataSelector) where V : struct
    {
        return ToSlidingWindowsCore(datas, startTime, DateTime.MaxValue, windowSize, dateTimeSelector, dataSelector);
    }

    public static Task<IEnumerable<IEnumerable<V>>> ToSlidingWindowsAsync<T, V>(IEnumerable<T> datas, DateTime startTime, TimeSpan windowSize, Func<T, DateTime> dateTimeSelector, Func<T, V> dataSelector) where V : struct
    {
        return Task.Run(() => ToSlidingWindows(datas, startTime, windowSize, dateTimeSelector, dataSelector));
    }

    public static IEnumerable<IEnumerable<V>> ToSlidingWindows<T, V>(IEnumerable<T> datas, DateTime startTime, DateTime endTime, TimeSpan windowSize, Func<T, DateTime> dateTimeSelector, Func<T, V> dataSelector) where V : struct
    {
        return ToSlidingWindowsCore(datas, startTime, endTime, windowSize, dateTimeSelector, dataSelector);
    }

    public static Task<IEnumerable<IEnumerable<V>>> ToSlidingWindowsAsync<T, V>(IEnumerable<T> datas, DateTime startTime, DateTime endTime, TimeSpan windowSize, Func<T, DateTime> dateTimeSelector, Func<T, V> dataSelector) where V : struct
    {
        return Task.Run(() => ToSlidingWindows(datas, startTime, endTime, windowSize, dateTimeSelector, dataSelector));
    }

    private static IEnumerable<IEnumerable<DateTime>> ToSlidingWindowsCore(IEnumerable<DateTime> datas, DateTime startTime, DateTime endTime, TimeSpan windowSize)
    {
        DataCheck(startTime, endTime, windowSize);

        datas = datas.Order();
        List<List<DateTime>> rtnDatas = new();
        List<DateTime> windows = new();

        for (int i = 0; i < datas.Count(); i++)
        {
            bool isBreak = false;
            for (int j = i; j < datas.Count(); j++)
            {
                if (windows.Count == 0 && datas.ElementAt(j) >= startTime && datas.ElementAt(j) <= endTime) windows.Add(datas.ElementAt(j));
                else if (datas.ElementAt(j) >= startTime
                    && datas.ElementAt(j).IsBetween(windows[0], windows[0] + windowSize)
                    && datas.ElementAt(j).IsBetween(windows[0], endTime))
                {
                    windows.Add(datas.ElementAt(j));
                    if (datas.ElementAt(j) >= datas.Last() || datas.ElementAt(j) >= endTime)
                    {
                        isBreak = true;
                        break;
                    }
                }
                else break;
            }
            if (windows.Count != 0) rtnDatas.Add(windows.ToList());
            if (isBreak) break;
            windows.Clear();
        }

        return rtnDatas;
    }

    private static IEnumerable<IEnumerable<V>> ToSlidingWindowsCore<T, V>(IEnumerable<T> datas, DateTime startTime, DateTime endTime, TimeSpan windowSize, Func<T, DateTime> dateTimeSelector, Func<T, V> dataSelector) where V : struct
    {
        DataCheck(startTime, endTime, windowSize);

        datas = datas.OrderBy(dateTimeSelector).ToList();
        List<List<V>> rtnDatas = new();
        List<(DateTime Time, V Value)> windows = new();

        for (int i = 0; i < datas.Count(); i++)
        {
            bool isBreak = false;
            for (int j = i; j < datas.Count(); j++)
            {
                if (windows.Count == 0 && dateTimeSelector(datas.ElementAt(j)) >= startTime && dateTimeSelector(datas.ElementAt(j)) <= endTime) windows.Add((dateTimeSelector(datas.ElementAt(j)), dataSelector(datas.ElementAt(j))));
                else if (dateTimeSelector(datas.ElementAt(j)) >= startTime
                    && dateTimeSelector(datas.ElementAt(j)).IsBetween(windows[0].Time, windows[0].Time + windowSize)
                    && dateTimeSelector(datas.ElementAt(j)).IsBetween(windows[0].Time, endTime))
                {
                    windows.Add((dateTimeSelector(datas.ElementAt(j)), dataSelector(datas.ElementAt(j))));
                    if (dateTimeSelector(datas.ElementAt(j)) >= dateTimeSelector(datas.Last()) || dateTimeSelector(datas.ElementAt(j)) >= endTime)
                    {
                        isBreak = true;
                        break;
                    }
                }
                else break;
            }
            if (windows.Count != 0) rtnDatas.Add((from data in windows select data.Value).ToList());
            if (isBreak) break;
            windows.Clear();
        }

        return rtnDatas;
    }

    private static void DataCheck(DateTime startTime, DateTime endTime, TimeSpan windowSize)
    {
        if (startTime > endTime) throw new ArgumentException($"Start time could not be bigger than end time. Start time : {startTime}, end time : {endTime}");
        else if (startTime + windowSize > endTime) throw new ArgumentException($"Start time + window size could not be bigger than end time. Start time + window size : {startTime + windowSize}, end time : {endTime}");
    }
}