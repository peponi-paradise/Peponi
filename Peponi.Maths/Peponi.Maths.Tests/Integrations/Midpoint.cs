using Peponi.Maths.Extensions;
using Peponi.Maths.Integration;

namespace Peponi.Maths.Tests.Integrations;

[TestClass]
public class MidpointTest
{
    [TestMethod]
    public void ListCalc()
    {
        List<int> xs = new() { 1, 4, 7, 10, 13 };
        List<double> ys = new() { 0, 1, -1, 4, 7 };

        Assert.AreEqual(30, Midpoint.Integrate(xs, ys));
    }

    [TestMethod]
    public void FunctionCalc()
    {
        Assert.AreEqual(1.262177, Midpoint.Integrate(System.Math.Sin, 0, 17.2, 9).Round(6));
    }
}