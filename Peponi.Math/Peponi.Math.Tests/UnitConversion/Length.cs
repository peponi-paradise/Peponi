using Peponi.Math.Extensions;
using Peponi.Math.UnitConversion;

namespace Peponi.Math.Tests.UnitConversion;

[TestClass]
public class Length
{
    [TestMethod]
    public void Test()
    {
        double baseValue = 21.653;

        Assert.AreEqual(21.652999999999996E18, baseValue.Convert(LengthUnit.Meter, LengthUnit.AtttoMeter).Round(6));
        Assert.AreEqual(21.652999999999996E15, baseValue.Convert(LengthUnit.Meter, LengthUnit.FemtoMeter).Round(6));
        Assert.AreEqual(21.653E12, baseValue.Convert(LengthUnit.Meter, LengthUnit.PicoMeter).Round(6));
        Assert.AreEqual(21.652999999999996E9, baseValue.Convert(LengthUnit.Meter, LengthUnit.NanoMeter).Round(6));
        Assert.AreEqual(21.653E6, baseValue.Convert(LengthUnit.Meter, LengthUnit.MicroMeter).Round(6));
        Assert.AreEqual(21.653E3, baseValue.Convert(LengthUnit.Meter, LengthUnit.MilliMeter).Round(6));
        Assert.AreEqual(21.653E2, baseValue.Convert(LengthUnit.Meter, LengthUnit.CentiMeter).Round(6));
        Assert.AreEqual(216.53, baseValue.Convert(LengthUnit.Meter, LengthUnit.DeciMeter).Round(6));
        Assert.AreEqual(2.1653, baseValue.Convert(LengthUnit.Meter, LengthUnit.DecaMeter).Round(6));
        Assert.AreEqual(21.653E-2, baseValue.Convert(LengthUnit.Meter, LengthUnit.HectoMeter).Round(6));
        Assert.AreEqual(21.653E-3, baseValue.Convert(LengthUnit.Meter, LengthUnit.KiloMeter).Round(6));
        Assert.AreEqual(21.653E-6, baseValue.Convert(LengthUnit.Meter, LengthUnit.MegaMeter).Round(9));
        Assert.AreEqual(21.653E-9, baseValue.Convert(LengthUnit.Meter, LengthUnit.GigaMeter).Round(12));
        Assert.AreEqual(21.653E-12, baseValue.Convert(LengthUnit.Meter, LengthUnit.TeraMeter).Round(15));
        baseValue *= 1E9;
        Assert.AreEqual(21.653E-6, baseValue.Convert(LengthUnit.Meter, LengthUnit.PetaMeter).Round(9));
        Assert.AreEqual(21.653E-9, baseValue.Convert(LengthUnit.Meter, LengthUnit.ExaMeter).Round(12));
        baseValue /= 1E9;
        Assert.AreEqual(71.040026, baseValue.Convert(LengthUnit.Meter, LengthUnit.Foot).Round(6));
        Assert.AreEqual(71.039884, baseValue.Convert(LengthUnit.Meter, LengthUnit.Foot_US).Round(6));
        Assert.AreEqual(23.680009, baseValue.Convert(LengthUnit.Meter, LengthUnit.Yard).Round(6));
        Assert.AreEqual(23.680009E-3, baseValue.Convert(LengthUnit.Meter, LengthUnit.KiloYard).Round(9));
        Assert.AreEqual(852480.314961, baseValue.Convert(LengthUnit.Meter, LengthUnit.Mil).Round(6));
        Assert.AreEqual(0.013455, baseValue.Convert(LengthUnit.Meter, LengthUnit.Mile).Round(6));
    }
}