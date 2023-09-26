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
        DateTime currentTime = startTime;

        for (int i = 0; i < datas.Count(); i++)
        {
            if (datas.ElementAt(i).IsBetween(currentTime, currentTime + windowSize) && datas.ElementAt(i).IsBetween(currentTime, endTime))
            {
                windows.Add(datas.ElementAt(i));
                List<DateTime> currentWindow = new List<DateTime>();
                foreach (var item in windows)
                {
                    if (item < datas.ElementAt(i) - windowSize) continue;
                    else currentWindow.Add(item);
                }
                rtnDatas.Add(currentWindow.ToList());
                windows = currentWindow.ToList();
            }
            else if (datas.ElementAt(i) > endTime)
            {
                break;
            }
            else if (datas.ElementAt(i) < currentTime || datas.ElementAt(i) > currentTime)
            {
                i--;
                currentTime += windowSize;
            }
        }

        return rtnDatas;
    }

    private static IEnumerable<IEnumerable<V>> ToSlidingWindowsCore<T, V>(IEnumerable<T> datas, DateTime startTime, DateTime endTime, TimeSpan windowSize, Func<T, DateTime> dateTimeSelector, Func<T, V> dataSelector) where V : struct
    {
        DataCheck(startTime, endTime, windowSize);

        datas = datas.OrderBy(dateTimeSelector).ToList();
        List<List<V>> rtnDatas = new();
        List<(DateTime Time, V Value)> windows = new();
        DateTime currentTime = startTime;

        for (int i = 0; i < datas.Count(); i++)
        {
            if (dateTimeSelector(datas.ElementAt(i)).IsBetween(currentTime, currentTime + windowSize) && dateTimeSelector(datas.ElementAt(i)).IsBetween(currentTime, endTime))
            {
                windows.Add((dateTimeSelector(datas.ElementAt(i)), dataSelector(datas.ElementAt(i))));
                List<(DateTime Time, V Value)> currentWindow = new();
                foreach (var item in windows)
                {
                    if (item.Time < dateTimeSelector(datas.ElementAt(i)) - windowSize) continue;
                    else currentWindow.Add(item);
                }
                rtnDatas.Add((from data in currentWindow select data.Value).ToList());
                windows = currentWindow.ToList();
            }
            else if (dateTimeSelector(datas.ElementAt(i)) > endTime)
            {
                break;
            }
            else if (dateTimeSelector(datas.ElementAt(i)) < currentTime || dateTimeSelector(datas.ElementAt(i)) > currentTime)
            {
                i--;
                currentTime += windowSize;
            }
        }

        return rtnDatas;
    }

    private static void DataCheck(DateTime startTime, DateTime endTime, TimeSpan windowSize)
    {
        if (startTime > endTime) throw new ArgumentException($"Start time could not be bigger than end time. Start time : {startTime}, end time : {endTime}");
        else if (startTime + windowSize > endTime) throw new ArgumentException($"Start time + window size could not be bigger than end time. Start time + window size : {startTime + windowSize}, end time : {endTime}");
    }
}