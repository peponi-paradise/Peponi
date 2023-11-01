﻿using Peponi.Math.Windowing;

namespace Peponi.Math.Tests.Windowing;

[TestClass]
public class HoppingWindowsTest
{
    [TestMethod]
    public void Count1()
    {
        List<int> datas = new();
        for (int i = 0; i < 10; i++) datas.Add(i);

        List<List<int>> exp = new();
        List<int> input = new() { 0, 1, 2, 3, 4 };
        exp.Add(input);
        input = new() { 3, 4, 5, 6, 7 };
        exp.Add(input);
        input = new() { 6, 7, 8, 9 };
        exp.Add(input);

        Assert.IsTrue(DataCheck.IsEqual(exp, HoppingWindows.ToHoppingWindows(datas, 5, 3)));
    }

    [TestMethod]
    public async Task Count1Async()
    {
        List<int> datas = new();
        for (int i = 0; i < 10; i++) datas.Add(i);

        List<List<int>> exp = new();
        List<int> input = new() { 0, 1, 2, 3, 4 };
        exp.Add(input);
        input = new() { 3, 4, 5, 6, 7 };
        exp.Add(input);
        input = new() { 6, 7, 8, 9 };
        exp.Add(input);

        Assert.IsTrue(DataCheck.IsEqual(exp, await HoppingWindows.ToHoppingWindowsAsync(datas, 5, 3)));
    }

    [TestMethod]
    public void Count2()
    {
        List<int> datas = new();
        for (int i = 0; i < 10; i++) datas.Add(i);

        List<List<int>> exp = new();
        List<int> input = new() { 4, 5, 6, 7, 8 };
        exp.Add(input);
        input = new() { 7, 8, 9 };
        exp.Add(input);

        Assert.IsTrue(DataCheck.IsEqual(exp, HoppingWindows.ToHoppingWindows(datas, 4, 5, 3)));
    }

    [TestMethod]
    public async Task Count2Async()
    {
        List<int> datas = new();
        for (int i = 0; i < 10; i++) datas.Add(i);

        List<List<int>> exp = new();
        List<int> input = new() { 4, 5, 6, 7, 8 };
        exp.Add(input);
        input = new() { 7, 8, 9 };
        exp.Add(input);

        Assert.IsTrue(DataCheck.IsEqual(exp, await HoppingWindows.ToHoppingWindowsAsync(datas, 4, 5, 3)));
    }

    [TestMethod]
    public void Count3()
    {
        List<int> datas = new();
        for (int i = 0; i < 10; i++) datas.Add(i);

        List<List<int>> exp = new();
        List<int> input = new() { 1, 2, 3, 4, 5 };
        exp.Add(input);
        input = new() { 4, 5, 6, 7, 8 };
        exp.Add(input);
        input = new() { 7, 8 };
        exp.Add(input);

        Assert.IsTrue(DataCheck.IsEqual(exp, HoppingWindows.ToHoppingWindows(datas, 1, 8, 5, 3)));
    }

    [TestMethod]
    public async Task Count3Async()
    {
        List<int> datas = new();
        for (int i = 0; i < 10; i++) datas.Add(i);

        List<List<int>> exp = new();
        List<int> input = new() { 1, 2, 3, 4, 5 };
        exp.Add(input);
        input = new() { 4, 5, 6, 7, 8 };
        exp.Add(input);
        input = new() { 7, 8 };
        exp.Add(input);

        Assert.IsTrue(DataCheck.IsEqual(exp, await HoppingWindows.ToHoppingWindowsAsync(datas, 1, 8, 5, 3)));
    }

    [TestMethod]
    public void Count4()
    {
        List<DataClass> datas = new();
        for (int i = 0; i < 10; i++) datas.Add(new(i));

        List<List<int>> exp = new();
        List<int> input = new() { 0, 1, 2, 3, 4 };
        exp.Add(input);
        input = new() { 3, 4, 5, 6, 7 };
        exp.Add(input);
        input = new() { 6, 7, 8, 9 };
        exp.Add(input);

        Assert.IsTrue(DataCheck.IsEqual(exp, HoppingWindows.ToHoppingWindows(datas, 5, 3, x => x.Data)));
    }

    [TestMethod]
    public async Task Count4Async()
    {
        List<DataClass> datas = new();
        for (int i = 0; i < 10; i++) datas.Add(new(i));

        List<List<int>> exp = new();
        List<int> input = new() { 0, 1, 2, 3, 4 };
        exp.Add(input);
        input = new() { 3, 4, 5, 6, 7 };
        exp.Add(input);
        input = new() { 6, 7, 8, 9 };
        exp.Add(input);

        Assert.IsTrue(DataCheck.IsEqual(exp, await HoppingWindows.ToHoppingWindowsAsync(datas, 5, 3, x => x.Data)));
    }

    [TestMethod]
    public void Count5()
    {
        List<DataClass> datas = new();
        for (int i = 0; i < 10; i++) datas.Add(new(i));

        List<List<int>> exp = new();
        List<int> input = new() { 4, 5, 6, 7, 8 };
        exp.Add(input);
        input = new() { 7, 8, 9 };
        exp.Add(input);

        Assert.IsTrue(DataCheck.IsEqual(exp, HoppingWindows.ToHoppingWindows(datas, 4, 5, 3, x => x.Data)));
    }

    [TestMethod]
    public async Task Count5Async()
    {
        List<DataClass> datas = new();
        for (int i = 0; i < 10; i++) datas.Add(new(i));

        List<List<int>> exp = new();
        List<int> input = new() { 4, 5, 6, 7, 8 };
        exp.Add(input);
        input = new() { 7, 8, 9 };
        exp.Add(input);

        Assert.IsTrue(DataCheck.IsEqual(exp, await HoppingWindows.ToHoppingWindowsAsync(datas, 4, 5, 3, x => x.Data)));
    }

    [TestMethod]
    public void Count6()
    {
        List<DataClass> datas = new();
        for (int i = 0; i < 10; i++) datas.Add(new(i));

        List<List<int>> exp = new();
        List<int> input = new() { 1, 2, 3, 4, 5 };
        exp.Add(input);
        input = new() { 4, 5, 6, 7, 8 };
        exp.Add(input);
        input = new() { 7, 8 };
        exp.Add(input);

        Assert.IsTrue(DataCheck.IsEqual(exp, HoppingWindows.ToHoppingWindows(datas, 1, 8, 5, 3, x => x.Data)));
    }

    [TestMethod]
    public async Task Count6Async()
    {
        List<DataClass> datas = new();
        for (int i = 0; i < 10; i++) datas.Add(new(i));

        List<List<int>> exp = new();
        List<int> input = new() { 1, 2, 3, 4, 5 };
        exp.Add(input);
        input = new() { 4, 5, 6, 7, 8 };
        exp.Add(input);
        input = new() { 7, 8 };
        exp.Add(input);

        Assert.IsTrue(DataCheck.IsEqual(exp, await HoppingWindows.ToHoppingWindowsAsync(datas, 1, 8, 5, 3, x => x.Data)));
    }

    [TestMethod]
    public void DateTime1()
    {
        List<DateTime> datas = new();
        for (int i = 0; i < 10; i++) datas.Add(DateTime.Today + TimeSpan.FromSeconds(i));

        List<List<DateTime>> exp = new();
        int timeIndex;
        List<DateTime> input = new();
        for (timeIndex = 0; timeIndex < 6; timeIndex++) input.Add(DateTime.Today + TimeSpan.FromSeconds(timeIndex));
        exp.Add(input);
        input = new();
        for (timeIndex = 3; timeIndex < 9; timeIndex++) input.Add(DateTime.Today + TimeSpan.FromSeconds(timeIndex));
        exp.Add(input);
        input = new();
        for (timeIndex = 6; timeIndex < 10; timeIndex++) input.Add(DateTime.Today + TimeSpan.FromSeconds(timeIndex));
        exp.Add(input);

        Assert.IsTrue(DataCheck.IsEqual(exp, HoppingWindows.ToHoppingWindows(datas, DateTime.Today, TimeSpan.FromSeconds(5), TimeSpan.FromSeconds(3))));
    }

    [TestMethod]
    public async Task DateTime1Async()
    {
        List<DateTime> datas = new();
        for (int i = 0; i < 10; i++) datas.Add(DateTime.Today + TimeSpan.FromSeconds(i));

        List<List<DateTime>> exp = new();
        int timeIndex;
        List<DateTime> input = new();
        for (timeIndex = 0; timeIndex < 6; timeIndex++) input.Add(DateTime.Today + TimeSpan.FromSeconds(timeIndex));
        exp.Add(input);
        input = new();
        for (timeIndex = 3; timeIndex < 9; timeIndex++) input.Add(DateTime.Today + TimeSpan.FromSeconds(timeIndex));
        exp.Add(input);
        input = new();
        for (timeIndex = 6; timeIndex < 10; timeIndex++) input.Add(DateTime.Today + TimeSpan.FromSeconds(timeIndex));
        exp.Add(input);

        Assert.IsTrue(DataCheck.IsEqual(exp, await HoppingWindows.ToHoppingWindowsAsync(datas, DateTime.Today, TimeSpan.FromSeconds(5), TimeSpan.FromSeconds(3))));
    }

    [TestMethod]
    public void DateTime2()
    {
        List<DateTime> datas = new();
        for (int i = 0; i < 10; i++) datas.Add(DateTime.Today + TimeSpan.FromSeconds(i));

        List<List<DateTime>> exp = new();
        int timeIndex;
        List<DateTime> input = new();
        for (timeIndex = 0; timeIndex < 6; timeIndex++) input.Add(DateTime.Today + TimeSpan.FromSeconds(timeIndex));
        exp.Add(input);
        input = new();
        for (timeIndex = 3; timeIndex < 9; timeIndex++) input.Add(DateTime.Today + TimeSpan.FromSeconds(timeIndex));
        exp.Add(input);

        Assert.IsTrue(DataCheck.IsEqual(exp, HoppingWindows.ToHoppingWindows(datas, DateTime.Today, DateTime.Today + TimeSpan.FromSeconds(9), TimeSpan.FromSeconds(5), TimeSpan.FromSeconds(3))));
    }

    [TestMethod]
    public async Task DateTime2Async()
    {
        List<DateTime> datas = new();
        for (int i = 0; i < 10; i++) datas.Add(DateTime.Today + TimeSpan.FromSeconds(i));

        List<List<DateTime>> exp = new();
        int timeIndex;
        List<DateTime> input = new();
        for (timeIndex = 0; timeIndex < 6; timeIndex++) input.Add(DateTime.Today + TimeSpan.FromSeconds(timeIndex));
        exp.Add(input);
        input = new();
        for (timeIndex = 3; timeIndex < 9; timeIndex++) input.Add(DateTime.Today + TimeSpan.FromSeconds(timeIndex));
        exp.Add(input);

        Assert.IsTrue(DataCheck.IsEqual(exp, await HoppingWindows.ToHoppingWindowsAsync(datas, DateTime.Today, DateTime.Today + TimeSpan.FromSeconds(9), TimeSpan.FromSeconds(5), TimeSpan.FromSeconds(3))));
    }

    [TestMethod]
    public void DateTime3()
    {
        List<DataClass> datas = new();
        for (int i = 0; i < 10; i++) datas.Add(new(DateTime.Today + TimeSpan.FromSeconds(i), i));

        List<List<int>> exp = new();
        List<int> input = new() { 0, 1, 2, 3, 4, 5 };
        exp.Add(input);
        input = new() { 3, 4, 5, 6, 7, 8 };
        exp.Add(input);
        input = new() { 6, 7, 8, 9 };
        exp.Add(input);

        Assert.IsTrue(DataCheck.IsEqual(exp, HoppingWindows.ToHoppingWindows(datas, DateTime.Today, TimeSpan.FromSeconds(5), TimeSpan.FromSeconds(3), x => x.Time, x => x.Data)));
    }

    [TestMethod]
    public async Task DateTime3Async()
    {
        List<DataClass> datas = new();
        for (int i = 0; i < 10; i++) datas.Add(new(DateTime.Today + TimeSpan.FromSeconds(i), i));

        List<List<int>> exp = new();
        List<int> input = new() { 0, 1, 2, 3, 4, 5 };
        exp.Add(input);
        input = new() { 3, 4, 5, 6, 7, 8 };
        exp.Add(input);
        input = new() { 6, 7, 8, 9 };
        exp.Add(input);

        Assert.IsTrue(DataCheck.IsEqual(exp, await HoppingWindows.ToHoppingWindowsAsync(datas, DateTime.Today, TimeSpan.FromSeconds(5), TimeSpan.FromSeconds(3), x => x.Time, x => x.Data)));
    }

    [TestMethod]
    public void DateTime4()
    {
        List<DataClass> datas = new();
        for (int i = 0; i < 10; i++) datas.Add(new(DateTime.Today + TimeSpan.FromSeconds(i), i));

        List<List<int>> exp = new();
        List<int> input = new() { 0, 1, 2, 3, 4, 5 };
        exp.Add(input);
        input = new() { 3, 4, 5, 6, 7, 8 };
        exp.Add(input);

        Assert.IsTrue(DataCheck.IsEqual(exp, HoppingWindows.ToHoppingWindows(datas, DateTime.Today, DateTime.Today + TimeSpan.FromSeconds(8), TimeSpan.FromSeconds(5), TimeSpan.FromSeconds(3), x => x.Time, x => x.Data)));
    }

    [TestMethod]
    public async Task DateTime4Async()
    {
        List<DataClass> datas = new();
        for (int i = 0; i < 10; i++) datas.Add(new(DateTime.Today + TimeSpan.FromSeconds(i), i));

        List<List<int>> exp = new();
        List<int> input = new() { 0, 1, 2, 3, 4, 5 };
        exp.Add(input);
        input = new() { 3, 4, 5, 6, 7, 8 };
        exp.Add(input);

        Assert.IsTrue(DataCheck.IsEqual(exp, await HoppingWindows.ToHoppingWindowsAsync(datas, DateTime.Today, DateTime.Today + TimeSpan.FromSeconds(9), TimeSpan.FromSeconds(5), TimeSpan.FromSeconds(3), x => x.Time, x => x.Data)));
    }
}