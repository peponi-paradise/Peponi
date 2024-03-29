﻿using Peponi.Maths.Extensions;

namespace Peponi.Maths.Windowing;

public static partial class TumblingWindows
{
    /// <inheritdoc cref="ToTumblingWindows(IEnumerable{DateTime}, DateTime, DateTime, TimeSpan)"/>
    public static IEnumerable<IEnumerable<DateTime>> ToTumblingWindows(IEnumerable<DateTime> datas, DateTime startTime, TimeSpan windowSize)
    {
        return ToTumblingWindowsCore(datas, startTime, DateTime.MaxValue, windowSize);
    }

    /// <inheritdoc cref="ToTumblingWindows(IEnumerable{DateTime}, DateTime, DateTime, TimeSpan)"/>
    public static Task<IEnumerable<IEnumerable<DateTime>>> ToTumblingWindowsAsync(IEnumerable<DateTime> datas, DateTime startTime, TimeSpan windowSize)
    {
        return Task.Run(() => ToTumblingWindows(datas, startTime, windowSize));
    }

    /// <summary>
    /// Compute tumbling windows
    /// </summary>
    /// <param name="datas"></param>
    /// <param name="startTime">startTime + windowSize &lt;= endTime</param>
    /// <param name="endTime">startTime + windowSize &lt;= endTime</param>
    /// <param name="windowSize">Bigger than TimeSpan.Zero</param>
    /// <returns></returns>
    /// <exception cref="ArgumentException"/>
    public static IEnumerable<IEnumerable<DateTime>> ToTumblingWindows(IEnumerable<DateTime> datas, DateTime startTime, DateTime endTime, TimeSpan windowSize)
    {
        return ToTumblingWindowsCore(datas, startTime, endTime, windowSize);
    }

    /// <inheritdoc cref="ToTumblingWindows(IEnumerable{DateTime}, DateTime, DateTime, TimeSpan)"/>
    public static Task<IEnumerable<IEnumerable<DateTime>>> ToTumblingWindowsAsync(IEnumerable<DateTime> datas, DateTime startTime, DateTime endTime, TimeSpan windowSize)
    {
        return Task.Run(() => ToTumblingWindows(datas, startTime, endTime, windowSize));
    }

    /// <inheritdoc cref="ToTumblingWindows{T, V}(IEnumerable{T}, DateTime, DateTime, TimeSpan, Func{T, DateTime}, Func{T, V})"/>
    public static IEnumerable<IEnumerable<V>> ToTumblingWindows<T, V>(IEnumerable<T> datas, DateTime startTime, TimeSpan windowSize, Func<T, DateTime> dateTimeSelector, Func<T, V> dataSelector) where V : struct
    {
        return ToTumblingWindowsCore(datas, startTime, DateTime.MaxValue, windowSize, dateTimeSelector, dataSelector);
    }

    /// <inheritdoc cref="ToTumblingWindows{T, V}(IEnumerable{T}, DateTime, DateTime, TimeSpan, Func{T, DateTime}, Func{T, V})"/>
    public static Task<IEnumerable<IEnumerable<V>>> ToTumblingWindowsAsync<T, V>(IEnumerable<T> datas, DateTime startTime, TimeSpan windowSize, Func<T, DateTime> dateTimeSelector, Func<T, V> dataSelector) where V : struct
    {
        return Task.Run(() => ToTumblingWindows(datas, startTime, windowSize, dateTimeSelector, dataSelector));
    }

    /// <summary>
    /// Compute tumbling windows
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
    /// <exception cref="ArgumentException"/>
    public static IEnumerable<IEnumerable<V>> ToTumblingWindows<T, V>(IEnumerable<T> datas, DateTime startTime, DateTime endTime, TimeSpan windowSize, Func<T, DateTime> dateTimeSelector, Func<T, V> dataSelector) where V : struct
    {
        return ToTumblingWindowsCore(datas, startTime, endTime, windowSize, dateTimeSelector, dataSelector);
    }

    /// <inheritdoc cref="ToTumblingWindows{T, V}(IEnumerable{T}, DateTime, DateTime, TimeSpan, Func{T, DateTime}, Func{T, V})"/>
    public static Task<IEnumerable<IEnumerable<V>>> ToTumblingWindowsAsync<T, V>(IEnumerable<T> datas, DateTime startTime, DateTime endTime, TimeSpan windowSize, Func<T, DateTime> dateTimeSelector, Func<T, V> dataSelector) where V : struct
    {
        return Task.Run(() => ToTumblingWindows(datas, startTime, endTime, windowSize, dateTimeSelector, dataSelector));
    }

    /// <summary>
    /// Compute tumbling windows
    /// </summary>
    /// <param name="datas"></param>
    /// <param name="startTime">startTime + windowSize &lt;= endTime</param>
    /// <param name="endTime">startTime + windowSize &lt;= endTime</param>
    /// <param name="windowSize">Bigger than TimeSpan.Zero</param>
    /// <returns></returns>
    /// <exception cref="ArgumentException"/>
    private static IEnumerable<IEnumerable<DateTime>> ToTumblingWindowsCore(IEnumerable<DateTime> datas, DateTime startTime, DateTime endTime, TimeSpan windowSize)
    {
        DataCheck(startTime, endTime, windowSize);

        datas = datas.Where(x => x.IsBetween(startTime, endTime)).Order().ToList();
        List<List<DateTime>> rtnDatas = new();

        while (true)
        {
            rtnDatas.Add(datas.Where((x) => x.IsBetween(startTime, startTime + windowSize)).ToList());
            startTime += windowSize;
            if (startTime >= datas.Last() || rtnDatas.Last().Last() >= datas.Last()) break;
        }

        return rtnDatas;
    }

    /// <summary>
    /// Compute tumbling windows
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
    /// <exception cref="ArgumentException"/>
    private static IEnumerable<IEnumerable<V>> ToTumblingWindowsCore<T, V>(IEnumerable<T> datas, DateTime startTime, DateTime endTime, TimeSpan windowSize, Func<T, DateTime> dateTimeSelector, Func<T, V> dataSelector) where V : struct
    {
        DataCheck(startTime, endTime, windowSize);

        datas = datas.Where(x => dateTimeSelector(x).IsBetween(startTime, endTime)).OrderBy(dateTimeSelector).ToList();
        List<List<V>> rtnDatas = new();

        while (true)
        {
            var window = datas.Where(x => dateTimeSelector(x).IsBetween(startTime, startTime + windowSize)).ToList();
            var inputData = from data in window select dataSelector(data);

            rtnDatas.Add(inputData.ToList());

            startTime += windowSize;

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