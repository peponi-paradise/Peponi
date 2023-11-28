namespace Peponi.Maths.MovingAverage;

/// <summary>
/// Compute single moving average
/// <br/>
/// <see href="주소 넣어야 함"/>
/// </summary>
/// <typeparam name="T">Struct type</typeparam>
public class SimpleMovingAverage<T> where T : struct
{
    private List<double> _data = new();
    private uint _windowSize = 0;

    /// <summary>
    /// Initizlize window
    /// </summary>
    /// <param name="windowSize">Bigger than 0</param>
    /// <exception cref="ArgumentException"></exception>
    public SimpleMovingAverage(uint windowSize)
    {
        if (windowSize == 0)
        {
            throw new ArgumentException($"{windowSize} could not be 0.");
        }
        _windowSize = windowSize;
    }

    /// <summary>
    /// <code>
    /// Compute window
    /// Convert value to double internally
    /// </code>
    /// </summary>
    /// <param name="newValue"></param>
    /// <returns></returns>
    public T Average(T newValue)
    {
        if (_data.Count >= _windowSize)
        {
            _data.RemoveAt(0);
        }

        _data.Add(Convert.ToDouble(newValue));

        double averageData = 0;

        foreach (var data in _data)
        {
            averageData += data;
        }

        averageData /= _data.Count;

        return (T)Convert.ChangeType(averageData, typeof(T));
    }

    /// <summary>
    /// Clear window
    /// </summary>
    public void ClearWindow() => _data.Clear();
}