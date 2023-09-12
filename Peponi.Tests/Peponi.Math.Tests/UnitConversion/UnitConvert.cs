using Peponi.Math.Extensions;
using Peponi.Math.UnitConversion;

namespace Peponi.Math.Tests.UnitConversion;

[TestClass]
public class UnitConversion
{
    [TestMethod]
    public void LengthTest()
    {
        var result = UnitConvert.ConvertLength(451.12031d, LengthUnit.Furlong, LengthUnit.MileUSStatute);
        Assert.AreEqual(56.389926, result.Round(6));
    }

    [TestMethod]
    public void PressureTest()
    {
        var result = UnitConvert.ConvertPressure(500d, PressureUnit.kipfPerSquareInch, PressureUnit.atm);
        Assert.AreEqual(34022.981955, result.Round(6));
    }

    [TestMethod]
    public void TemperatureTest()
    {
        var result = UnitConvert.ConvertTemperature(500d, TemperatureUnit.Reaumur, TemperatureUnit.Kelvin);
        Assert.AreEqual(898.15, result.Round(6));
    }
}