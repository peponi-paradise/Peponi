using Peponi.Maths.Extensions;

namespace Peponi.Maths.Windowing;

public partial class HoppingWindows
{
    /// <inheritdoc cref="ToHoppingWindows(IEnumerable{DateTime}, DateTime, DateTime, TimeSpan, TimeSpan)"/>
    public static IEnumerable<IEnumerable<DateTime>> ToHoppingWindows(IEnumerable<DateTime> datas, DateTime startTime, TimeSpan windowSize, TimeSpan hoppingStep)
    {
        return ToHoppingWindowsCore(datas, startTime, DateTime.MaxValue, windowSize, hoppingStep);
    }

    /// <inheritdoc cref="ToHoppingWindows(IEnumerable{DateTime}, DateTime, DateTime, TimeSpan, TimeSpan)"/>
    public static Task<IEnumerable<IEnumerable<DateTime>>> ToHoppingWindowsAsync(IEnumerable<DateTime> datas, DateTime startTime, TimeSpan windowSize, TimeSpan hoppingStep)
    {
        return Task.Run(() => ToHoppingWindows(datas, startTime, windowSize, hoppingStep));
    }

    /// <summary>
    /// Compute hopping windows
    /// </summary>
    /// <param name="datas"></param>
    /// <param name="startTime">startTime + windowSize &lt;= endTime</param>
    /// <param name="endTime">startTime + windowSize &lt;= endTime</param>
    /// <param name="windowSize">Bigger than TimeSpan.Zero</param>
    /// <param name="hoppingStep">Bigger than TimeSpan.Zero</param>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
    public static IEnumerable<IEnumerable<DateTime>> ToHoppingWindows(IEnumerable<DateTime> datas, DateTime startTime, DateTime endTime, TimeSpan windowSize, TimeSpan hoppingStep)
    {
        return ToHoppingWindowsCore(datas, startTime, endTime, windowSize, hoppingStep);
    }

    /// <inheritdoc cref="ToHoppingWindows(IEnumerable{DateTime}, DateTime, DateTime, TimeSpan, TimeSpan)"/>
    public static Task<IEnumerable<IEnumerable<DateTime>>> ToHoppingWindowsAsync(IEnumerable<DateTime> datas, DateTime startTime, DateTime endTime, TimeSpan windowSize, TimeSpan hoppingStep)
    {
        return Task.Run(() => ToHoppingWindows(datas, startTime, endTime, windowSize, hoppingStep));
    }

    /// <inheritdoc cref="ToHoppingWindows{T, V}(IEnumerable{T}, DateTime, DateTime, TimeSpan, TimeSpan, Func{T, DateTime}, Func{T, V})"/>
    public static IEnumerable<IEnumerable<V>> ToHoppingWindows<T, V>(IEnumerable<T> datas, DateTime startTime, TimeSpan windowSize, TimeSpan hoppingStep, Func<T, DateTime> dateTimeSelector, Func<T, V> dataSelector) where V : struct
    {
        return ToHoppingWindowsCore(datas, startTime, DateTime.MaxValue, windowSize, hoppingStep, dateTimeSelector, dataSelector);
    }

    /// <inheritdoc cref="ToHoppingWindows{T, V}(IEnumerable{T}, DateTime, DateTime, TimeSpan, TimeSpan, Func{T, DateTime}, Func{T, V})"/>
    public static Task<IEnumerable<IEnumerable<V>>> ToHoppingWindowsAsync<T, V>(IEnumerable<T> datas, DateTime startTime, TimeSpan windowSize, TimeSpan hoppingStep, Func<T, DateTime> dateTimeSelector, Func<T, V> dataSelector) where V : struct
    {
        return Task.Run(() => ToHoppingWindows(datas, startTime, windowSize, hoppingStep, dateTimeSelector, dataSelector));
    }

    /// <summary>
    /// Compute hopping windows
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="V">Struct type</typeparam>
    /// <param name="datas"></param>
    /// <param name="startTime">startTime + windowSize &lt;= endTime</param>
    /// <param name="endTime">startTime + windowSize &lt;= endTime</param>
    /// <param name="windowSize">Bigger than TimeSpan.Zero</param>
    /// <param name="hoppingStep">Bigger than TimeSpan.Zero</param>
    /// <param name="dateTimeSelector">DateTime select function</param>
    /// <param name="dataSelector">Data select function</param>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
    public static IEnumerable<IEnumerable<V>> ToHoppingWindows<T, V>(IEnumerable<T> datas, DateTime startTime, DateTime endTime, TimeSpan windowSize, TimeSpan hoppingStep, Func<T, DateTime> dateTimeSelector, Func<T, V> dataSelector) where V : struct
    {
        return ToHoppingWindowsCore(datas, startTime, endTime, windowSize, hoppingStep, dateTimeSelector, dataSelector);
    }

    /// <inheritdoc cref="ToHoppingWindows{T, V}(IEnumerable{T}, DateTime, DateTime, TimeSpan, TimeSpan, Func{T, DateTime}, Func{T, V})"/>
    public static Task<IEnumerable<IEnumerable<V>>> ToHoppingWindowsAsync<T, V>(IEnumerable<T> datas, DateTime startTime, DateTime endTime, TimeSpan windowSize, TimeSpan hoppingStep, Func<T, DateTime> dateTimeSelector, Func<T, V> dataSelector) where V : struct
    {
        return Task.Run(() => ToHoppingWindows(datas, startTime, endTime, windowSize, hoppingStep, dateTimeSelector, dataSelector));
    }

    /// <summary>
    /// Compute hopping windows
    /// </summary>
    /// <param name="datas"></param>
    /// <param name="startTime">startTime + windowSize &lt;= endTime</param>
    /// <param name="endTime">startTime + windowSize &lt;= endTime</param>
    /// <param name="windowSize">Bigger than TimeSpan.Zero</param>
    /// <param name="hoppingStep">Bigger than TimeSpan.Zero</param>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
    private static IEnumerable<IEnumerable<DateTime>> ToHoppingWindowsCore(IEnumerable<DateTime> datas, DateTime startTime, DateTime endTime, TimeSpan windowSize, TimeSpan hoppingStep)
    {
        DataCheck(startTime, endTime, windowSize);

        datas = datas.Where(x => x.IsBetween(startTime, endTime)).Order().ToList();
        List<List<DateTime>> rtnDatas = new();

        while (startTime <= endTime)
        {
            rtnDatas.Add(datas.Where(x => x.IsBetween(startTime, startTime + windowSize)).ToList());
            startTime += hoppingStep;
            if (startTime >= datas.Last() || rtnDatas.Last().Last() >= datas.Last()) break;
        }

        return rtnDatas;
    }

    /// <summary>
    /// Compute hopping windows
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="V">Struct type</typeparam>
    /// <param name="datas"></param>
    /// <param name="startTime">startTime + windowSize &lt;= endTime</param>
    /// <param name="endTime">startTime + windowSize &lt;= endTime</param>
    /// <param name="windowSize">Bigger than TimeSpan.Zero</param>
    /// <param name="hoppingStep">Bigger than TimeSpan.Zero</param>
    /// <param name="dateTimeSelector">DateTime select function</param>
    /// <param name="dataSelector">Data select function</param>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
    private static IEnumerable<IEnumerable<V>> ToHoppingWindowsCore<T, V>(IEnumerable<T> datas, DateTime startTime, DateTime endTime, TimeSpan windowSize, TimeSpan hoppingStep, Func<T, DateTime> dateTimeSelector, Func<T, V> dataSelector) where V : struct
    {
        DataCheck(startTime, endTime, windowSize);

        datas = datas.Where(x => dateTimeSelector(x).IsBetween(startTime, endTime)).OrderBy(dateTimeSelector).ToList();
        List<List<V>> rtnDatas = new();

        while (startTime <= endTime)
        {
            var window = datas.Where(x => dateTimeSelector(x).IsBetween(startTime, startTime + windowSize)).ToList();
            var inputData = from data in window select dataSelector(data);

            rtnDatas.Add(inputData.ToList());

            startTime += hoppingStep;

            if (startTime >= dateTimeSelector(datas.Last()) || dateTimeSelector(window.Last()) >= dateTimeSelector(datas.Last())) break;
        }

        return rtnDatas;
    }

    private static void DataCheck(DateTime startTime, DateTime endTime, TimeSpan windowSize)
    {
        if (startTime > endTime) throw new ArgumentException($"Start time could not be bigger than end time. Start time : {startTime}, end time : {endTime}");
        else if (startTime + windowSize > endTime) throw new ArgumentException($"Start time + window size could not be bigger than end time. Start time + window size : {startTime + windowSize}, end time : {endTime}");
    }
}