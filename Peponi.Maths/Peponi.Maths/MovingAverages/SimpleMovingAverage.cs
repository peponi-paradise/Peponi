namespace Peponi.Maths.MovingAverage;

public class SimpleMovingAverage<T> where T : struct
{
    private List<T> _data = new();
    private uint _windowSize = 0;

    public SimpleMovingAverage(uint windowSize)
    {
        if (windowSize == 0)
        {
            throw new ArgumentException($"{windowSize} could not be 0.");
        }
        _windowSize = windowSize;
    }

    public T Average(T newValue)
    {
        if (_data.Count >= _windowSize)
        {
            _data.RemoveAt(0);
        }

        _data.Add(newValue);

        double averageData = 0;

        foreach (var data in _data)
        {
            averageData += Convert.ToDouble(data);
        }

        averageData /= _data.Count;

        return (T)Convert.ChangeType(averageData, typeof(T));
    }
}