using Peponi.Math.Extensions;
using Peponi.Math.UnitConversion;

namespace Peponi.Math.Tests.UnitConversion;

[TestClass]
public class Angle
{
    [TestMethod]
    public void Test()
    {
        double angleValue = 1.234;
        Assert.AreEqual(0.021537, angleValue.Convert(AngleUnit.Degree, AngleUnit.Radian).Round(6));
        Assert.AreEqual(1.371111, angleValue.Convert(AngleUnit.Degree, AngleUnit.Grad).Round(6));
        Assert.AreEqual(74.04, angleValue.Convert(AngleUnit.Degree, AngleUnit.Minute).Round(6));
        Assert.AreEqual(4442.4, angleValue.Convert(AngleUnit.Degree, AngleUnit.Second).Round(6));
        Assert.AreEqual(1.371111, angleValue.Convert(AngleUnit.Degree, AngleUnit.Gon).Round(6));
        Assert.AreEqual(0.041133, angleValue.Convert(AngleUnit.Degree, AngleUnit.Sign).Round(6));
        Assert.AreEqual(21.937778, angleValue.Convert(AngleUnit.Degree, AngleUnit.Mil).Round(6));
        Assert.AreEqual(0.003428, angleValue.Convert(AngleUnit.Degree, AngleUnit.Revolution).Round(6));
        Assert.AreEqual(0.003428, angleValue.Convert(AngleUnit.Degree, AngleUnit.Circle).Round(6));
        Assert.AreEqual(0.003428, angleValue.Convert(AngleUnit.Degree, AngleUnit.Turn).Round(6));
        Assert.AreEqual(0.013711, angleValue.Convert(AngleUnit.Degree, AngleUnit.RightAngle).Round(6));
        Assert.AreEqual(0.013711 * 2, angleValue.Convert(AngleUnit.Degree, AngleUnit.Octant).Round(6));
        Assert.AreEqual(0.013711, angleValue.Convert(AngleUnit.Degree, AngleUnit.Quadrant).Round(6));
        Assert.AreEqual(0.020567, angleValue.Convert(AngleUnit.Degree, AngleUnit.Sextant).Round(6));
    }
}