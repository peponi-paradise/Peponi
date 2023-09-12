using Peponi.Math.Extensions;
using Peponi.Math.UnitConversion;

namespace Peponi.Math.Tests.UnitConversion;

[TestClass]
public class UnitConversion
{
    [TestMethod]
    public void Area()
    {
        var result = UnitConvert.Convert(451.12031d, AreaUnit.Perch, AreaUnit.MileUS);
        Assert.AreEqual(0.004405, result.Round(6));
    }

    [TestMethod]
    public void DryVolume()
    {
        var result = UnitConvert.Convert(451.12031d, DryVolumeUnit.BushelUS, DryVolumeUnit.PeckUK);
        Assert.AreEqual(1748.432198, result.Round(6));
    }

    [TestMethod]
    public void Length()
    {
        var result = UnitConvert.Convert(451.12031d, LengthUnit.Furlong, LengthUnit.MileUSStatute);
        Assert.AreEqual(56.389926, result.Round(6));
    }

    [TestMethod]
    public void Prefix()
    {
        var result = UnitConvert.Convert(500d, PrefixUnit.Peta, PrefixUnit.Deci);
        Assert.AreEqual(5E+18, result.Round(6));
    }

    [TestMethod]
    public void Pressure()
    {
        var result = UnitConvert.Convert(500d, PressureUnit.kipfPerSquareInch, PressureUnit.atm);
        Assert.AreEqual(34022.981955, result.Round(6));
    }

    [TestMethod]
    public void Temperature()
    {
        var result = UnitConvert.Convert(500d, TemperatureUnit.Reaumur, TemperatureUnit.Kelvin);
        Assert.AreEqual(898.15, result.Round(6));
    }

    [TestMethod]
    public void Volume()
    {
        var result = UnitConvert.Convert(451.12031d, VolumeUnit.Cord, VolumeUnit.HundredCubicFoot);
        Assert.AreEqual(577.433997, result.Round(6));
    }

    [TestMethod]
    public void Weight()
    {
        var result = UnitConvert.Convert(451.12031d, WeightUnit.DekaGram, WeightUnit.StoneUK);
        Assert.AreEqual(0.710393, result.Round(6));
    }
}