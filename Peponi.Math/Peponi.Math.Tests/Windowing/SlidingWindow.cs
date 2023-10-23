using Peponi.Math.Windowing;

namespace Peponi.Math.Tests.Windowing;

[TestClass]
public class SlidingWindowsTest
{
    [TestMethod]
    public void Count1()
    {
        List<int> datas = new();
        for (int i = 0; i < 20; i++) datas.Add(i);

        List<List<int>> exp = new();
        for (int i = 0; i <= 19; i++)
        {
            List<int> ints = new();
            for (int j = i; j < i + 5; j++)
            {
                if (j >= datas.Count || j > 19)
                {
                    i = datas.Count;
                    break;
                }
                ints.Add(j);
            }
            if (ints.Count != 0) exp.Add(ints);
        }

        Assert.IsTrue(IsEqual(exp, SlidingWindows.ToSlidingWindows(datas, 5)));
    }

    [TestMethod]
    public async Task Count1Async()
    {
        List<int> datas = new();
        for (int i = 0; i < 20; i++) datas.Add(i);

        List<List<int>> exp = new();
        for (int i = 0; i <= 19; i++)
        {
            List<int> ints = new();
            for (int j = i; j < i + 5; j++)
            {
                if (j >= datas.Count || j > 19)
                {
                    i = datas.Count;
                    break;
                }
                ints.Add(j);
            }
            if (ints.Count != 0) exp.Add(ints);
        }

        Assert.IsTrue(IsEqual(exp, await SlidingWindows.ToSlidingWindowsAsync(datas, 5)));
    }

    [TestMethod]
    public void Count2()
    {
        List<int> datas = new();
        for (int i = 0; i < 20; i++) datas.Add(i);

        List<List<int>> exp = new();
        for (int i = 7; i <= 19; i++)
        {
            List<int> ints = new();
            for (int j = i; j < i + 5; j++)
            {
                if (j >= datas.Count || j > 19)
                {
                    i = datas.Count;
                    break;
                }
                ints.Add(j);
            }
            if (ints.Count != 0) exp.Add(ints);
        }

        Assert.IsTrue(IsEqual(exp, SlidingWindows.ToSlidingWindows(datas, 7, 5)));
    }

    [TestMethod]
    public async Task Count2Async()
    {
        List<int> datas = new();
        for (int i = 0; i < 20; i++) datas.Add(i);

        List<List<int>> exp = new();
        for (int i = 7; i <= 19; i++)
        {
            List<int> ints = new();
            for (int j = i; j < i + 5; j++)
            {
                if (j >= datas.Count || j > 19)
                {
                    i = datas.Count;
                    break;
                }
                ints.Add(j);
            }
            if (ints.Count != 0) exp.Add(ints);
        }

        Assert.IsTrue(IsEqual(exp, await SlidingWindows.ToSlidingWindowsAsync(datas, 7, 5)));
    }

    [TestMethod]
    public void Count3()
    {
        List<int> datas = new();
        for (int i = 0; i < 20; i++) datas.Add(i);

        List<List<int>> exp = new();
        for (int i = 7; i <= 15; i++)
        {
            List<int> ints = new();
            for (int j = i; j < i + 5; j++)
            {
                if (j >= datas.Count || j > 15)
                {
                    i = datas.Count;
                    break;
                }
                ints.Add(j);
            }
            if (ints.Count != 0) exp.Add(ints);
        }

        Assert.IsTrue(IsEqual(exp, SlidingWindows.ToSlidingWindows(datas, 7, 15, 5)));
    }

    [TestMethod]
    public async Task Count3Async()
    {
        List<int> datas = new();
        for (int i = 0; i < 20; i++) datas.Add(i);

        List<List<int>> exp = new();
        for (int i = 7; i <= 15; i++)
        {
            List<int> ints = new();
            for (int j = i; j < i + 5; j++)
            {
                if (j >= datas.Count || j > 15)
                {
                    i = datas.Count;
                    break;
                }
                ints.Add(j);
            }
            if (ints.Count != 0) exp.Add(ints);
        }

        Assert.IsTrue(IsEqual(exp, await SlidingWindows.ToSlidingWindowsAsync(datas, 7, 15, 5)));
    }

    [TestMethod]
    public void Count4()
    {
        List<DataClass> datas = new();
        for (int i = 0; i < 20; i++) datas.Add(new(i));

        List<List<int>> exp = new();
        for (int i = 0; i <= 19; i++)
        {
            List<int> ints = new();
            for (int j = i; j < i + 5; j++)
            {
                if (j >= datas.Count || j > 19)
                {
                    i = datas.Count;
                    break;
                }
                ints.Add(j);
            }
            if (ints.Count != 0) exp.Add(ints);
        }

        Assert.IsTrue(IsEqual(exp, SlidingWindows.ToSlidingWindows(datas, 5, x => x.Data)));
    }

    [TestMethod]
    public async Task Count4Async()
    {
        List<DataClass> datas = new();
        for (int i = 0; i < 20; i++) datas.Add(new(i));

        List<List<int>> exp = new();
        for (int i = 0; i <= 19; i++)
        {
            List<int> ints = new();
            for (int j = i; j < i + 5; j++)
            {
                if (j >= datas.Count || j > 19)
                {
                    i = datas.Count;
                    break;
                }
                ints.Add(j);
            }
            if (ints.Count != 0) exp.Add(ints);
        }

        Assert.IsTrue(IsEqual(exp, await SlidingWindows.ToSlidingWindowsAsync(datas, 5, x => x.Data)));
    }

    [TestMethod]
    public void Count5()
    {
        List<DataClass> datas = new();
        for (int i = 0; i < 20; i++) datas.Add(new(i));

        List<List<int>> exp = new();
        for (int i = 7; i <= 19; i++)
        {
            List<int> ints = new();
            for (int j = i; j < i + 5; j++)
            {
                if (j >= datas.Count || j > 19)
                {
                    i = datas.Count;
                    break;
                }
                ints.Add(j);
            }
            if (ints.Count != 0) exp.Add(ints);
        }

        Assert.IsTrue(IsEqual(exp, SlidingWindows.ToSlidingWindows(datas, 7, 5, x => x.Data)));
    }

    [TestMethod]
    public async Task Count5Async()
    {
        List<DataClass> datas = new();
        for (int i = 0; i < 20; i++) datas.Add(new(i));

        List<List<int>> exp = new();
        for (int i = 7; i <= 19; i++)
        {
            List<int> ints = new();
            for (int j = i; j < i + 5; j++)
            {
                if (j >= datas.Count || j > 19)
                {
                    i = datas.Count;
                    break;
                }
                ints.Add(j);
            }
            if (ints.Count != 0) exp.Add(ints);
        }

        Assert.IsTrue(IsEqual(exp, await SlidingWindows.ToSlidingWindowsAsync(datas, 7, 5, x => x.Data)));
    }

    [TestMethod]
    public void Count6()
    {
        List<DataClass> datas = new();
        for (int i = 0; i < 20; i++) datas.Add(new(i));

        List<List<int>> exp = new();
        for (int i = 7; i <= 15; i++)
        {
            List<int> ints = new();
            for (int j = i; j < i + 5; j++)
            {
                if (j >= datas.Count || j > 15)
                {
                    i = datas.Count;
                    break;
                }
                ints.Add(j);
            }
            if (ints.Count != 0) exp.Add(ints);
        }

        Assert.IsTrue(IsEqual(exp, SlidingWindows.ToSlidingWindows(datas, 7, 15, 5, x => x.Data)));
    }

    [TestMethod]
    public async Task Count6Async()
    {
        List<DataClass> datas = new();
        for (int i = 0; i < 20; i++) datas.Add(new(i));

        List<List<int>> exp = new();
        for (int i = 7; i <= 15; i++)
        {
            List<int> ints = new();
            for (int j = i; j < i + 5; j++)
            {
                if (j >= datas.Count || j > 15)
                {
                    i = datas.Count;
                    break;
                }
                ints.Add(j);
            }
            if (ints.Count != 0) exp.Add(ints);
        }

        Assert.IsTrue(IsEqual(exp, await SlidingWindows.ToSlidingWindowsAsync(datas, 7, 15, 5, x => x.Data)));
    }

    [TestMethod]
    public void DateTime1()
    {
        List<DateTime> datas = new();
        for (int i = 0; i < 20; i++) datas.Add(DateTime.Today + TimeSpan.FromSeconds(i));

        List<List<DateTime>> exp = new();
        DateTime currentTime = DateTime.Today;
        List<DateTime> dataWindow = new();
        for (int i = 0; i < 20; i++)
        {
            DateTime currentData = DateTime.Today + TimeSpan.FromSeconds(i);
            if (currentTime <= currentData && currentData <= currentTime + TimeSpan.FromSeconds(5) && currentData <= DateTime.MaxValue)
            {
                dataWindow.Add(currentData);
                List<DateTime> currentWindow = new();
                foreach (var data in dataWindow)
                {
                    if (data < currentData - TimeSpan.FromSeconds(5)) continue;
                    currentWindow.Add(data);
                }
                exp.Add(currentWindow.ToList());
                dataWindow = currentWindow.ToList();
            }
            else if (currentData > DateTime.MaxValue) break;
            else if (currentData < currentTime || currentData > currentTime)
            {
                i--;
                currentTime += TimeSpan.FromMilliseconds(5);
            }
        }

        Assert.IsTrue(IsEqual(exp, SlidingWindows.ToSlidingWindows(datas, DateTime.Today, TimeSpan.FromSeconds(5))));
    }

    [TestMethod]
    public async Task DateTime1Async()
    {
        List<DateTime> datas = new();
        for (int i = 0; i < 20; i++) datas.Add(DateTime.Today + TimeSpan.FromSeconds(i));

        List<List<DateTime>> exp = new();
        DateTime startTime = DateTime.Today;
        while (startTime + TimeSpan.FromSeconds(5) <= DateTime.MaxValue)
        {
            List<DateTime> times = new();
            for (int i = 0; i <= 5; i++)
            {
                if (startTime + TimeSpan.FromSeconds(i) > datas.Last()) break;
                times.Add(startTime + TimeSpan.FromSeconds(i));
            }
            if (times.Count != 0) exp.Add(times);
            startTime += TimeSpan.FromSeconds(3);
            if (startTime >= datas.Last()) break;
        }

        Assert.IsTrue(IsEqual(exp, await HoppingWindows.ToHoppingWindowsAsync(datas, DateTime.Today, TimeSpan.FromSeconds(5), TimeSpan.FromSeconds(3))));
    }

    private bool IsEqual(IEnumerable<IEnumerable<int>> a, IEnumerable<IEnumerable<int>> b)
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

    private bool IsEqual(IEnumerable<IEnumerable<DateTime>> a, IEnumerable<IEnumerable<DateTime>> b)
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