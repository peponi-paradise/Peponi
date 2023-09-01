namespace Peponi.Core.Interfaces;

public interface IWindowResult<TData> where TData : struct
{
    List<TData> Datas { get; set; }
    DateTime StartTime { get; set; }
    DateTime EndTime { get; set; }
    int StartPosition { get; set; }
    int EndPosition { get; set; }

    TData Min();

    TData Max();

    TData Sum();

    TData Average();
}