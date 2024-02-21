namespace Peponi.Maths.Tests.Windowing;

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

internal static class DataCheck
{
    internal static bool IsEqual(IEnumerable<IEnumerable<int>> a, IEnumerable<IEnumerable<int>> b)
    {
        if (a == null || b == null) return false;
        else if (a.Count() != b.Count()) return false;
        else
        {
            for (int i = 0; i < a.Count(); i++)
            {
                if (a.ElementAt(i).Count() != b.ElementAt(i).Count()) return false;
                else
                {
                    for (int j = 0; j < a.ElementAt(i).Count(); j++)
                    {
                        if (a.ElementAt(i).ElementAt(j) != b.ElementAt(i).ElementAt(j)) return false;
                    }
                }
            }
            return true;
        }
    }

    internal static bool IsEqual(IEnumerable<IEnumerable<DateTime>> a, IEnumerable<IEnumerable<DateTime>> b)
    {
        if (a == null || b == null) return false;
        else if (a.Count() != b.Count()) return false;
        else
        {
            for (int i = 0; i < a.Count(); i++)
            {
                if (a.ElementAt(i).Count() != b.ElementAt(i).Count()) return false;
                else
                {
                    for (int j = 0; j < a.ElementAt(i).Count(); j++)
                    {
                        if (a.ElementAt(i).ElementAt(j) != b.ElementAt(i).ElementAt(j)) return false;
                    }
                }
            }
            return true;
        }
    }
}