using Peponi.Math.Extensions;
using Peponi.Math.UnitConversion;

namespace Peponi.Math.Tests.UnitConversion;

[TestClass]
public class AngularSpeed
{
    [TestMethod]
    public void Test()
    {
        double baseValue = 21.653;

        Assert.AreEqual(1299.18, baseValue.Convert(AngularSpeedUnit.RadianPerSecond, AngularSpeedUnit.RadianPerMinute).Round(6));
        Assert.AreEqual(77950.8, baseValue.Convert(AngularSpeedUnit.RadianPerSecond, AngularSpeedUnit.RadianPerHour).Round(6));
        Assert.AreEqual(1870819.2, baseValue.Convert(AngularSpeedUnit.RadianPerSecond, AngularSpeedUnit.RadianPerDay).Round(6));
        Assert.AreEqual(3.446182, baseValue.Convert(AngularSpeedUnit.RadianPerSecond, AngularSpeedUnit.CyclePerSecond).Round(6));
        Assert.AreEqual(206.770919, baseValue.Convert(AngularSpeedUnit.RadianPerSecond, AngularSpeedUnit.CyclePerMinute).Round(6));
        Assert.AreEqual(12406.255138, baseValue.Convert(AngularSpeedUnit.RadianPerSecond, AngularSpeedUnit.CyclePerHour).Round(6));
        Assert.AreEqual(297750.123311, baseValue.Convert(AngularSpeedUnit.RadianPerSecond, AngularSpeedUnit.CyclePerDay).Round(6));
        Assert.AreEqual(1240.625514, baseValue.Convert(AngularSpeedUnit.RadianPerSecond, AngularSpeedUnit.DegreePerSecond).Round(6));
        Assert.AreEqual(74437.530828, baseValue.Convert(AngularSpeedUnit.RadianPerSecond, AngularSpeedUnit.DegreePerMinute).Round(6));
        Assert.AreEqual(4466251.849668, baseValue.Convert(AngularSpeedUnit.RadianPerSecond, AngularSpeedUnit.DegreePerHour).Round(6));
        Assert.AreEqual(107190044.392041, baseValue.Convert(AngularSpeedUnit.RadianPerSecond, AngularSpeedUnit.DegreePerDay).Round(6));
        Assert.AreEqual(3.446182, baseValue.Convert(AngularSpeedUnit.RadianPerSecond, AngularSpeedUnit.RevolutionPerSecond).Round(6));
        Assert.AreEqual(206.770919, baseValue.Convert(AngularSpeedUnit.RadianPerSecond, AngularSpeedUnit.RevolutionPerMinute).Round(6));
        Assert.AreEqual(12406.255138, baseValue.Convert(AngularSpeedUnit.RadianPerSecond, AngularSpeedUnit.RevolutionPerHour).Round(6));
        Assert.AreEqual(297750.123311, baseValue.Convert(AngularSpeedUnit.RadianPerSecond, AngularSpeedUnit.RevolutionPerDay).Round(6));
    }
}