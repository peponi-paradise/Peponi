using Peponi.Maths.Extensions;
using Peponi.Maths.UnitConversion;

namespace Peponi.Maths.Tests.UnitConversion;

[TestClass]
public class Temperature
{
    [TestMethod]
    public void FromKelvin()
    {
        double baseValue = 21.653;

        Assert.AreEqual(-251.497, baseValue.Convert(TemperatureUnit.Kelvin, TemperatureUnit.Celsius).Round(6));
        Assert.AreEqual(-420.6946, baseValue.Convert(TemperatureUnit.Kelvin, TemperatureUnit.Fahrenheit).Round(6));
        Assert.AreEqual(38.9754, baseValue.Convert(TemperatureUnit.Kelvin, TemperatureUnit.Rankine).Round(6));
        Assert.AreEqual(-201.1976, baseValue.Convert(TemperatureUnit.Kelvin, TemperatureUnit.Reaumur).Round(6));
        Assert.AreEqual(0.079269, baseValue.Convert(TemperatureUnit.Kelvin, TemperatureUnit.TriplePointOfWater).Round(6));
    }

    [TestMethod]
    public void FromCelsius()
    {
        double baseValue = 21.653;

        Assert.AreEqual(294.803, baseValue.Convert(TemperatureUnit.Celsius, TemperatureUnit.Kelvin).Round(6));
        Assert.AreEqual(70.9754, baseValue.Convert(TemperatureUnit.Celsius, TemperatureUnit.Fahrenheit).Round(6));
        Assert.AreEqual(530.6454, baseValue.Convert(TemperatureUnit.Celsius, TemperatureUnit.Rankine).Round(6));
        Assert.AreEqual(17.3224, baseValue.Convert(TemperatureUnit.Celsius, TemperatureUnit.Reaumur).Round(6));
        Assert.AreEqual(1.079232, baseValue.Convert(TemperatureUnit.Celsius, TemperatureUnit.TriplePointOfWater).Round(6));
    }

    [TestMethod]
    public void FromFahrenheit()
    {
        double baseValue = 21.653;

        Assert.AreEqual(267.401667, baseValue.Convert(TemperatureUnit.Fahrenheit, TemperatureUnit.Kelvin).Round(6));
        Assert.AreEqual(-5.748333, baseValue.Convert(TemperatureUnit.Fahrenheit, TemperatureUnit.Celsius).Round(6));
        Assert.AreEqual(481.323, baseValue.Convert(TemperatureUnit.Fahrenheit, TemperatureUnit.Rankine).Round(6));
        Assert.AreEqual(-4.598667, baseValue.Convert(TemperatureUnit.Fahrenheit, TemperatureUnit.Reaumur).Round(6));
        Assert.AreEqual(0.97892, baseValue.Convert(TemperatureUnit.Fahrenheit, TemperatureUnit.TriplePointOfWater).Round(6));
    }

    [TestMethod]
    public void FromRankine()
    {
        double baseValue = 21.653;

        Assert.AreEqual(12.029444, baseValue.Convert(TemperatureUnit.Rankine, TemperatureUnit.Kelvin).Round(6));
        Assert.AreEqual(-261.120556, baseValue.Convert(TemperatureUnit.Rankine, TemperatureUnit.Celsius).Round(6));
        Assert.AreEqual(-438.017, baseValue.Convert(TemperatureUnit.Rankine, TemperatureUnit.Fahrenheit).Round(6));
        Assert.AreEqual(-208.896444, baseValue.Convert(TemperatureUnit.Rankine, TemperatureUnit.Reaumur).Round(6));
        Assert.AreEqual(0.044038, baseValue.Convert(TemperatureUnit.Rankine, TemperatureUnit.TriplePointOfWater).Round(6));
    }

    [TestMethod]
    public void FromReaumur()
    {
        double baseValue = 21.653;

        Assert.AreEqual(300.21625, baseValue.Convert(TemperatureUnit.Reaumur, TemperatureUnit.Kelvin).Round(6));
        Assert.AreEqual(27.06625, baseValue.Convert(TemperatureUnit.Reaumur, TemperatureUnit.Celsius).Round(6));
        Assert.AreEqual(80.71925, baseValue.Convert(TemperatureUnit.Reaumur, TemperatureUnit.Fahrenheit).Round(6));
        Assert.AreEqual(540.38925, baseValue.Convert(TemperatureUnit.Reaumur, TemperatureUnit.Rankine).Round(6));
        Assert.AreEqual(1.099049, baseValue.Convert(TemperatureUnit.Reaumur, TemperatureUnit.TriplePointOfWater).Round(6));
    }

    [TestMethod]
    public void FromTriplePointOfWater()
    {
        double baseValue = 21.653;

        Assert.AreEqual(5914.73348, baseValue.Convert(TemperatureUnit.TriplePointOfWater, TemperatureUnit.Kelvin).Round(6));
        Assert.AreEqual(5641.58348, baseValue.Convert(TemperatureUnit.TriplePointOfWater, TemperatureUnit.Celsius).Round(6));
        Assert.AreEqual(10186.850264, baseValue.Convert(TemperatureUnit.TriplePointOfWater, TemperatureUnit.Fahrenheit).Round(6));
        Assert.AreEqual(10646.520264, baseValue.Convert(TemperatureUnit.TriplePointOfWater, TemperatureUnit.Rankine).Round(6));
        Assert.AreEqual(4513.266784, baseValue.Convert(TemperatureUnit.TriplePointOfWater, TemperatureUnit.Reaumur).Round(6));
    }
}