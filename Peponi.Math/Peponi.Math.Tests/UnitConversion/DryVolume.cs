using Peponi.Math.Extensions;
using Peponi.Math.UnitConversion;

namespace Peponi.Math.Tests.UnitConversion;

[TestClass]
public class DryVolume
{
    [TestMethod]
    public void Test()
    {
        double baseValue = 21.653;

        Assert.AreEqual(39.325442, baseValue.Convert(DryVolumeUnit.Liter, DryVolumeUnit.Pint).Round(6));
        Assert.AreEqual(19.662721, baseValue.Convert(DryVolumeUnit.Liter, DryVolumeUnit.Quart).Round(6));
        Assert.AreEqual(0.187266, baseValue.Convert(DryVolumeUnit.Liter, DryVolumeUnit.Barrel).Round(6));
        Assert.AreEqual(2.457840, baseValue.Convert(DryVolumeUnit.Liter, DryVolumeUnit.Peck_US).Round(6));
        Assert.AreEqual(2.381497, baseValue.Convert(DryVolumeUnit.Liter, DryVolumeUnit.Peck_UK).Round(6));
        Assert.AreEqual(0.614460, baseValue.Convert(DryVolumeUnit.Liter, DryVolumeUnit.Bushel_US).Round(6));
        Assert.AreEqual(0.595374, baseValue.Convert(DryVolumeUnit.Liter, DryVolumeUnit.Bushel_UK).Round(6));
    }
}