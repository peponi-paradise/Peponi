using Peponi.Maths.Extensions;
using Peponi.Maths.UnitConversion;

namespace Peponi.Maths.Tests.UnitConversion;

[TestClass]
public class Speed
{
    [TestMethod]
    public void Test()
    {
        double baseValue = 21.653;

        Assert.AreEqual(21653, baseValue.Convert(SpeedUnit.MeterPerSecond, SpeedUnit.MilliMeterPerSecond).Round(6));
        Assert.AreEqual(1299180, baseValue.Convert(SpeedUnit.MeterPerSecond, SpeedUnit.MilliMeterPerMinute).Round(6));
        Assert.AreEqual(77950800, baseValue.Convert(SpeedUnit.MeterPerSecond, SpeedUnit.MilliMeterPerHour).Round(6));
        Assert.AreEqual(2165.3, baseValue.Convert(SpeedUnit.MeterPerSecond, SpeedUnit.CentiMeterPerSecond).Round(6));
        Assert.AreEqual(129918, baseValue.Convert(SpeedUnit.MeterPerSecond, SpeedUnit.CentiMeterPerMinute).Round(6));
        Assert.AreEqual(7795080, baseValue.Convert(SpeedUnit.MeterPerSecond, SpeedUnit.CentiMeterPerHour).Round(6));
        Assert.AreEqual(1299.18, baseValue.Convert(SpeedUnit.MeterPerSecond, SpeedUnit.MeterPerMinute).Round(6));
        Assert.AreEqual(77950.8, baseValue.Convert(SpeedUnit.MeterPerSecond, SpeedUnit.MeterPerHour).Round(6));
        Assert.AreEqual(21.653E-3, baseValue.Convert(SpeedUnit.MeterPerSecond, SpeedUnit.KiloMeterPerSecond).Round(6));
        Assert.AreEqual(1.29918, baseValue.Convert(SpeedUnit.MeterPerSecond, SpeedUnit.KiloMeterPerMinute).Round(6));
        Assert.AreEqual(77.9508, baseValue.Convert(SpeedUnit.MeterPerSecond, SpeedUnit.KiloMeterPerHour).Round(6));
        Assert.AreEqual(71.040026, baseValue.Convert(SpeedUnit.MeterPerSecond, SpeedUnit.FootPerSecond).Round(6));
        Assert.AreEqual(4262.401575, baseValue.Convert(SpeedUnit.MeterPerSecond, SpeedUnit.FootPerMinute).Round(6));
        Assert.AreEqual(255744.094488, baseValue.Convert(SpeedUnit.MeterPerSecond, SpeedUnit.FootPerHour).Round(6));
        Assert.AreEqual(0.013455, baseValue.Convert(SpeedUnit.MeterPerSecond, SpeedUnit.MilePerSecond).Round(6));
        Assert.AreEqual(0.807273, baseValue.Convert(SpeedUnit.MeterPerSecond, SpeedUnit.MilePerMinute).Round(6));
        Assert.AreEqual(48.436382, baseValue.Convert(SpeedUnit.MeterPerSecond, SpeedUnit.MilePerHour).Round(6));
        Assert.AreEqual(23.680009, baseValue.Convert(SpeedUnit.MeterPerSecond, SpeedUnit.YardPerSecond).Round(6));
        Assert.AreEqual(1420.800525, baseValue.Convert(SpeedUnit.MeterPerSecond, SpeedUnit.YardPerMinute).Round(6));
        Assert.AreEqual(85248.031496, baseValue.Convert(SpeedUnit.MeterPerSecond, SpeedUnit.YardPerHour).Round(6));
        Assert.AreEqual(42.090065, baseValue.Convert(SpeedUnit.MeterPerSecond, SpeedUnit.Knot).Round(6));
        Assert.AreEqual(42.063173, baseValue.Convert(SpeedUnit.MeterPerSecond, SpeedUnit.Knot_UK).Round(6));
        Assert.AreEqual(0.063018, baseValue.Convert(SpeedUnit.MeterPerSecond, SpeedUnit.Mach_ATM20C).Round(6));
        Assert.AreEqual(0.073388, baseValue.Convert(SpeedUnit.MeterPerSecond, SpeedUnit.Mach_SI).Round(6));
        Assert.AreEqual(0.014604, baseValue.Convert(SpeedUnit.MeterPerSecond, SpeedUnit.SpeedOfSoundInPureWater).Round(6));
        Assert.AreEqual(0.01423, baseValue.Convert(SpeedUnit.MeterPerSecond, SpeedUnit.SpeedOfSoundInSeaWater_10Meter20C).Round(6));
        Assert.AreEqual(7.222663353325586E-8, baseValue.Convert(SpeedUnit.MeterPerSecond, SpeedUnit.SpeedOfLightInVacuum));
        Assert.AreEqual(0.002741, baseValue.Convert(SpeedUnit.MeterPerSecond, SpeedUnit.CosmicVelocity_1st).Round(6));
        Assert.AreEqual(0.001933, baseValue.Convert(SpeedUnit.MeterPerSecond, SpeedUnit.CosmicVelocity_2nd).Round(6));
        Assert.AreEqual(0.001299, baseValue.Convert(SpeedUnit.MeterPerSecond, SpeedUnit.CosmicVelocity_3rd).Round(6));
        Assert.AreEqual(0.000727, baseValue.Convert(SpeedUnit.MeterPerSecond, SpeedUnit.EarthVelocity).Round(6));
    }
}