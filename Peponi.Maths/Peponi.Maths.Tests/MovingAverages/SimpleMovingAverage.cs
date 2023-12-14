using Peponi.Maths.MovingAverage;

namespace Peponi.Maths.Tests.MovingAverage;

#nullable disable

[TestClass]
public class SimpleMovingAverage
{
    private SimpleMovingAverage<double> _movingAverage;

    [TestInitialize]
    public void TestInitialize()
    {
        _movingAverage = new SimpleMovingAverage<double>(3);
    }

    [TestMethod]
    public void ctorTest()
    {
        _movingAverage = new(10);
    }

    [TestMethod]
    public void AveragingTest()
    {
        List<double> exp = new() { 0, 1, 1.5, 2, 3 };
        for (int i = 1; i < 5; i++)
        {
            double rtn = _movingAverage.Average(i);
            Assert.AreEqual(exp[i], rtn);
        }
    }
}