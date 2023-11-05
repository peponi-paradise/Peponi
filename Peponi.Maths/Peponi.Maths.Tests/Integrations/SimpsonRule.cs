using Peponi.Maths.Extensions;
using Peponi.Maths.Integration;

namespace Peponi.Maths.Tests.Integrations;

[TestClass]
public class SimpsonRuleTest
{
    [TestMethod]
    public void ListCalc()
    {
        List<int> xs = new() { 1, 4, 7, 10, 13 };
        List<double> ys = new() { 0, 1, -1, 4, 7 };

        Assert.AreEqual(25, Simpson1over3.Integrate(xs, ys));

        xs = new() { 1, 4, 7, 10, 13, 16, 19 };
        ys = new() { 0, 1, -1, 4, 7, -2, 5 };

        Assert.AreEqual(31.5, Simpson3over8.Integrate(xs, ys));
    }

    [TestMethod]
    public void FunctionCalc()
    {
        Assert.AreEqual(1.341822, Simpson1over3.Integrate(System.Math.Sin, 0, 17.2, 8).Round(6));
        Assert.AreEqual(2.189858, Simpson3over8.Integrate(System.Math.Sin, 0, 17.2, 9).Round(6));
    }
}