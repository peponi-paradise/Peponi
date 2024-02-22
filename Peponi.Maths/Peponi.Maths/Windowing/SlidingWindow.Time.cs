using Peponi.Maths.Extensions;

namespace Peponi.Maths.Windowing;

public static partial class SlidingWindows
{
    /// <inheritdoc cref="ToSlidingWindows(IEnumerable{DateTime}, DateTime, DateTime, TimeSpan)"/>
    public static IEnumerable<IEnumerable<DateTime>> ToSlidingWindows(IEnumerable<DateTime> datas, DateTime startTime, TimeSpan windowSize)
    {
        return ToSlidingWindowsCore(datas, startTime, DateTime.MaxValue, windowSize);
    }

    /// <inheritdoc cref="ToSlidingWindows(IEnumerable{DateTime}, DateTime, DateTime, TimeSpan)"/>
    public static Task<IEnumerable<IEnumerable<DateTime>>> ToSlidingWindowsAsync(IEnumerable<DateTime> datas, DateTime startTime, TimeSpan windowSize)
    {
        return Task.Run(() => ToSlidingWindows(datas, startTime, windowSize));
    }

    /// <summary>
    /// Compute sliding windows
    /// </summary>
    /// <param name="datas"></param>
    /// <param name="startTime">startTime + windowSize &lt;= endTime</param>
    /// <param name="endTime">startTime + windowSize &lt;= endTime</param>
    /// <param name="windowSize">Bigger than TimeSpan.Zero</param>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
    public static IEnumerable<IEnumerable<DateTime>> ToSlidingWindows(IEnumerable<DateTime> datas, DateTime startTime, DateTime endTime, TimeSpan windowSize)
    {
        return ToSlidingWindowsCore(datas, startTime, endTime, windowSize);
    }

    /// <inheritdoc cref="ToSlidingWindows(IEnumerable{DateTime}, DateTime, DateTime, TimeSpan)"/>
    public static Task<IEnumerable<IEnumerable<DateTime>>> ToSlidingWindowsAsync(IEnumerable<DateTime> datas, DateTime startTime, DateTime endTime, TimeSpan windowSize)
    {
        return Task.Run(() => ToSlidingWindows(datas, startTime, endTime, windowSize));
    }

    /// <inheritdoc cref="ToSlidingWindows{T, V}(IEnumerable{T}, DateTime, DateTime, TimeSpan, Func{T, DateTime}, Func{T, V})"/>
    public static IEnumerable<IEnumerable<V>> ToSlidingWindows<T, V>(IEnumerable<T> datas, DateTime startTime, TimeSpan windowSize, Func<T, DateTime> dateTimeSelector, Func<T, V> dataSelector) where V : struct
    {
        return ToSlidingWindowsCore(datas, startTime, DateTime.MaxValue, windowSize, dateTimeSelector, dataSelector);
    }

    /// <inheritdoc cref="ToSlidingWindows{T, V}(IEnumerable{T}, DateTime, DateTime, TimeSpan, Func{T, DateTime}, Func{T, V})"/>
    public static Task<IEnumerable<IEnumerable<V>>> ToSlidingWindowsAsync<T, V>(IEnumerable<T> datas, DateTime startTime, TimeSpan windowSize, Func<T, DateTime> dateTimeSelector, Func<T, V> dataSelector) where V : struct
    {
        return Task.Run(() => ToSlidingWindows(datas, startTime, windowSize, dateTimeSelector, dataSelector));
    }

    /// <summary>
    /// Compute sliding windows
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="V">Struct type</typeparam>
    /// <param name="datas"></param>
    /// <param name="startTime">startTime + windowSize &lt;= endTime</param>
    /// <param name="endTime">startTime + windowSize &lt;= endTime</param>
    /// <param name="windowSize">Bigger than TimeSpan.Zero</param>
    /// <param name="dateTimeSelector">DateTime select function</param>
    /// <param name="dataSelector">Data select function</param>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
    public static IEnumerable<IEnumerable<V>> ToSlidingWindows<T, V>(IEnumerable<T> datas, DateTime startTime, DateTime endTime, TimeSpan windowSize, Func<T, DateTime> dateTimeSelector, Func<T, V> dataSelector) where V : struct
    {
        return ToSlidingWindowsCore(datas, startTime, endTime, windowSize, dateTimeSelector, dataSelector);
    }

    /// <inheritdoc cref="ToSlidingWindows{T, V}(IEnumerable{T}, DateTime, DateTime, TimeSpan, Func{T, DateTime}, Func{T, V})"/>
    public static Task<IEnumerable<IEnumerable<V>>> ToSlidingWindowsAsync<T, V>(IEnumerable<T> datas, DateTime startTime, DateTime endTime, TimeSpan windowSize, Func<T, DateTime> dateTimeSelector, Func<T, V> dataSelector) where V : struct
    {
        return Task.Run(() => ToSlidingWindows(datas, startTime, endTime, windowSize, dateTimeSelector, dataSelector));
    }

    /// <summary>
    /// Compute sliding windows
    /// </summary>
    /// <param name="datas"></param>
    /// <param name="startTime">startTime + windowSize &lt;= endTime</param>
    /// <param name="endTime">startTime + windowSize &lt;= endTime</param>
    /// <param name="windowSize">Bigger than TimeSpan.Zero</param>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
    private static IEnumerable<IEnumerable<DateTime>> ToSlidingWindowsCore(IEnumerable<DateTime> datas, DateTime startTime, DateTime endTime, TimeSpan windowSize)
    {
        DataCheck(startTime, endTime, windowSize);

        datas = datas.Where(x => x >= startTime && x <= endTime).Order().ToList();
        List<List<DateTime>> rtnDatas = new();
        List<DateTime> windows = new();

        for (int i = 0; i < datas.Count(); i++)
        {
            for (int j = i; j < datas.Count(); j++)
            {
                if (windows.Count == 0) windows.Add(datas.ElementAt(j));
                else if (datas.ElementAt(j).IsBetween(windows[0], windows[0] + windowSize))
                {
                    windows.Add(datas.ElementAt(j));
                    if (datas.ElementAt(j) == datas.Last())
                    {
                        i = datas.Count();
                        break;
                    }
                }
                else break;
            }
            if (windows.Count != 0) rtnDatas.Add(windows.ToList());
            windows.Clear();
        }

        return rtnDatas;
    }

    /// <summary>
    /// Compute sliding windows
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="V">Struct type</typeparam>
    /// <param name="datas"></param>
    /// <param name="startTime">startTime + windowSize &lt;= endTime</param>
    /// <param name="endTime">startTime + windowSize &lt;= endTime</param>
    /// <param name="windowSize">Bigger than TimeSpan.Zero</param>
    /// <param name="dateTimeSelector">DateTime select function</param>
    /// <param name="dataSelector">Data select function</param>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
    private static IEnumerable<IEnumerable<V>> ToSlidingWindowsCore<T, V>(IEnumerable<T> datas, DateTime startTime, DateTime endTime, TimeSpan windowSize, Func<T, DateTime> dateTimeSelector, Func<T, V> dataSelector) where V : struct
    {
        DataCheck(startTime, endTime, windowSize);

        datas = datas.Where(x => dateTimeSelector(x) >= startTime && dateTimeSelector(x) <= endTime).OrderBy(dateTimeSelector).ToList();
        List<List<V>> rtnDatas = new();
        List<(DateTime Time, V Value)> windows = new();

        for (int i = 0; i < datas.Count(); i++)
        {
            for (int j = i; j < datas.Count(); j++)
            {
                if (windows.Count == 0) windows.Add((dateTimeSelector(datas.ElementAt(j)), dataSelector(datas.ElementAt(j))));
                else if (dateTimeSelector(datas.ElementAt(j)).IsBetween(windows[0].Time, windows[0].Time + windowSize))
                {
                    windows.Add((dateTimeSelector(datas.ElementAt(j)), dataSelector(datas.ElementAt(j))));
                    if (dateTimeSelector(datas.ElementAt(j)) == dateTimeSelector(datas.Last()))
                    {
                        i = datas.Count();
                        break;
                    }
                }
                else break;
            }
            if (windows.Count != 0) rtnDatas.Add((from data in windows select data.Value).ToList());
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