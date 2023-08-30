namespace Peponi.Math.MovingAverage;

public class SimpleMovingAverage
{
    private List<double> _data = new();
    private uint _windowSize = 0;

    public SimpleMovingAverage(uint windowSize)
    {
        if (windowSize == 0)
        {
            throw new ArgumentException($"{windowSize} could not be 0.");
        }
        _windowSize = windowSize;
    }

    public double Average(double newValue)
    {
        if (_data.Count > _windowSize)
        {
            _data.RemoveAt(0);
        }

        _data.Add(newValue);

        double averageData = 0;

        foreach (var data in _data)
        {
            averageData += data;
        }

        averageData /= _data.Count;

        return averageData;
    }
}