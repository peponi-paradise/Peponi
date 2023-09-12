﻿using Peponi.Math.Extensions;
using Peponi.Math.UnitConversion;

namespace Peponi.Math.Tests.UnitConversion;

[TestClass]
public class UnitConversion
{
    [TestMethod]
    public void AreaTest()
    {
        var result = UnitConvert.Convert(451.12031d, AreaUnit.Perch, AreaUnit.MileUS);
        Assert.AreEqual(0.004405, result.Round(6));
    }

    [TestMethod]
    public void LengthTest()
    {
        var result = UnitConvert.Convert(451.12031d, LengthUnit.Furlong, LengthUnit.MileUSStatute);
        Assert.AreEqual(56.389926, result.Round(6));
    }

    [TestMethod]
    public void PressureTest()
    {
        var result = UnitConvert.Convert(500d, PressureUnit.kipfPerSquareInch, PressureUnit.atm);
        Assert.AreEqual(34022.981955, result.Round(6));
    }

    [TestMethod]
    public void TemperatureTest()
    {
        var result = UnitConvert.Convert(500d, TemperatureUnit.Reaumur, TemperatureUnit.Kelvin);
        Assert.AreEqual(898.15, result.Round(6));
    }

    [TestMethod]
    public void PrefixTest()
    {
        var result = UnitConvert.Convert(500d, PrefixUnit.Peta, PrefixUnit.Deci);
        Assert.AreEqual(5E+18, result.Round(6));
    }
}