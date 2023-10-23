namespace Peponi.Math.Tests.Windowing;

internal class DataClass
{
    public DateTime Time;
    public int Data;

    public DataClass(int data)
    {
        Data = data;
    }

    public DataClass(DateTime time, int data)
    {
        Time = time;
        Data = data;
    }
}