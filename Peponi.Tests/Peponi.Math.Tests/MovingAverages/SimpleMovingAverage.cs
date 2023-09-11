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
        double sum = 0;
        double average = 0;
        for (int i = 0; i < 10; i++)
        {
            sum += i;
            average = sum / (i + 1);
            double rtn = _movingAverage.Average(i);
            Assert.AreEqual(average, rtn);
        }
    }
}