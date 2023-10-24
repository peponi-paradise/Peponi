using Peponi.Math.MovingAverage;

namespace Peponi.Math.Tests.MovingAverage;

#nullable disable

[TestClass]
public class SimpleMovingAverage
{
    private SimpleMovingAverage<double> _movingAverage;

    [TestInitialize]
    public void TestInitialize()
    {
        _movingAverage = new SimpleMovingAverage<double>(10);
    }

    [TestMethod]
    public void ctorTest()
    {
        _movingAverage = new(10);
    }

    [TestMethod]
    public void AveragingTest()
    {
        List<double> exp = new() { 0, 0.5, 1, 1.5, 2 };
        for (int i = 0; i < 5; i++)
        {
            double rtn = _movingAverage.Average(i);
            Assert.AreEqual(exp[i], rtn);
        }
    }
}