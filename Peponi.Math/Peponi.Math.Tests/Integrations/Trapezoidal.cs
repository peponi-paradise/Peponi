using Peponi.Math.Extensions;
using Peponi.Math.Integration;

namespace Peponi.Math.Tests.Integrations;

[TestClass]
public class TrapezoidalTest
{
    [TestMethod]
    public void ListCalc()
    {
        List<int> xs = new() { 1, 4, 8, 12, 15, 20 };
        List<double> ys = new() { 0, 1, -1, 4, 7, 5 };

        Assert.AreEqual(54, Trapezoidal.Integrate(xs, ys));
    }

    [TestMethod]
    public void FunctionCalc()
    {
        Assert.AreEqual(0.627166, Trapezoidal.Integrate(System.Math.Sin, 0, 17.2, 8).Round(6));
    }
}