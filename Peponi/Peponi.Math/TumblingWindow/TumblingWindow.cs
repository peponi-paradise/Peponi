using Peponi.Core.Interfaces;

namespace Peponi.Math.TumblingWindow;

public sealed record TumblingWindowSettings
{
    public DateTime StartTime = DateTime.MinValue;
    public DateTime EndTime = DateTime.MaxValue;
    public TimeSpan WindowWidth_Time = TimeSpan.Zero;
    public int StartPosition = -1;
    public int EndPosition = -1;
    public int WindowWidth_Count = 0;
}

public sealed class TumblingWindowResult<TData> : IWindowResult<TData> where TData : struct
{
    public List<TData> Datas { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public DateTime StartTime { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public DateTime EndTime { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public int StartPosition { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public int EndPosition { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public TData Average()
    {
        throw new NotImplementedException();
    }

    public TData Max()
    {
        throw new NotImplementedException();
    }

    public TData Min()
    {
        throw new NotImplementedException();
    }

    public TData Sum()
    {
        throw new NotImplementedException();
    }
}

public class TumblingWindow<TData> where TData : struct
{
    private TumblingWindowSettings _settings;

    public TumblingWindow(TumblingWindowSettings settings)
    {
        _settings = settings;
    }

    public IEnumerable
}