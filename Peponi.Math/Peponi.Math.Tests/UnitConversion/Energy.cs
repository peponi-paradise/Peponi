using Peponi.Math.Extensions;
using Peponi.Math.UnitConversion;

namespace Peponi.Math.Tests.UnitConversion;

[TestClass]
public class Energy
{
    [TestMethod]
    public void Test()
    {
        double baseValue = 21.653;

        Assert.AreEqual(21.652999999999996E18, baseValue.Convert(EnergyUnit.Joule, EnergyUnit.AttoJoule).Round(6));
        Assert.AreEqual(21.652999999999996E15, baseValue.Convert(EnergyUnit.Joule, EnergyUnit.FemtoJoule).Round(6));
        Assert.AreEqual(21.653E12, baseValue.Convert(EnergyUnit.Joule, EnergyUnit.PicoJoule).Round(6));
        Assert.AreEqual(21.652999999999996E9, baseValue.Convert(EnergyUnit.Joule, EnergyUnit.NanoJoule).Round(6));
        Assert.AreEqual(21.653E6, baseValue.Convert(EnergyUnit.Joule, EnergyUnit.MicroJoule).Round(6));
        Assert.AreEqual(21.653E3, baseValue.Convert(EnergyUnit.Joule, EnergyUnit.MilliJoule).Round(6));
        Assert.AreEqual(21.653E-3, baseValue.Convert(EnergyUnit.Joule, EnergyUnit.KiloJoule).Round(6));
        Assert.AreEqual(21.653E-6, baseValue.Convert(EnergyUnit.Joule, EnergyUnit.MegaJoule).Round(9));
        Assert.AreEqual(21.653E-9, baseValue.Convert(EnergyUnit.Joule, EnergyUnit.GigaJoule).Round(12));
        Assert.AreEqual(21.653E-12, baseValue.Convert(EnergyUnit.Joule, EnergyUnit.TeraJoule).Round(15));
        baseValue *= 1E6;
        Assert.AreEqual(21.653E-9, baseValue.Convert(EnergyUnit.Joule, EnergyUnit.PetaJoule).Round(15));
        Assert.AreEqual(21.653E-12, baseValue.Convert(EnergyUnit.Joule, EnergyUnit.ExaJoule).Round(15));
        baseValue *= 1E-6;
        Assert.AreEqual(21.653, baseValue.Convert(EnergyUnit.Joule, EnergyUnit.WattSecond).Round(6));
        Assert.AreEqual(21.653E-3, baseValue.Convert(EnergyUnit.Joule, EnergyUnit.KiloWattSecond).Round(6));
        Assert.AreEqual(21.653E-6, baseValue.Convert(EnergyUnit.Joule, EnergyUnit.MegaWattSecond).Round(9));
        Assert.AreEqual(0.006015, baseValue.Convert(EnergyUnit.Joule, EnergyUnit.WattHour).Round(6));
        Assert.AreEqual(0.006014722222E-3, baseValue.Convert(EnergyUnit.Joule, EnergyUnit.KiloWattHour).Round(15));
        Assert.AreEqual(0.006014722E-6, baseValue.Convert(EnergyUnit.Joule, EnergyUnit.MegaWattHour).Round(15));
        Assert.AreEqual(0.006015E-9, baseValue.Convert(EnergyUnit.Joule, EnergyUnit.GigaWattHour).Round(15));
        baseValue *= 1E9;
        Assert.AreEqual(0.006014722222E-3, baseValue.Convert(EnergyUnit.Joule, EnergyUnit.TeraWattHour).Round(15));
        Assert.AreEqual(0.006014722E-6, baseValue.Convert(EnergyUnit.Joule, EnergyUnit.PetaWattHour).Round(15));
        Assert.AreEqual(0.006015E-9, baseValue.Convert(EnergyUnit.Joule, EnergyUnit.ExaWattHour).Round(15));
        baseValue *= 1E-9;
        Assert.AreEqual(21.653E7, baseValue.Convert(EnergyUnit.Joule, EnergyUnit.DyneCentiMeter).Round(6));
        Assert.AreEqual(220799.151596, baseValue.Convert(EnergyUnit.Joule, EnergyUnit.GramForceCentiMeter).Round(6));
        Assert.AreEqual(2207.991516, baseValue.Convert(EnergyUnit.Joule, EnergyUnit.GramForceMeter).Round(6));
        Assert.AreEqual(220799.151596E-3, baseValue.Convert(EnergyUnit.Joule, EnergyUnit.KiloGramForceCentiMeter).Round(9));
        Assert.AreEqual(220799.151596E-5, baseValue.Convert(EnergyUnit.Joule, EnergyUnit.KiloGramForceMeter).Round(11));
        Assert.AreEqual(220799.151596E-5, baseValue.Convert(EnergyUnit.Joule, EnergyUnit.KiloPondMeter).Round(11));
        Assert.AreEqual(21.653, baseValue.Convert(EnergyUnit.Joule, EnergyUnit.NewtonMeter).Round(6));
        Assert.AreEqual(3066.323184, baseValue.Convert(EnergyUnit.Joule, EnergyUnit.OunceForceInch).Round(6));
        Assert.AreEqual(191.645199, baseValue.Convert(EnergyUnit.Joule, EnergyUnit.PoundForceInch).Round(6));
        Assert.AreEqual(15.970433, baseValue.Convert(EnergyUnit.Joule, EnergyUnit.PoundForceFoot).Round(6));
        Assert.AreEqual(3066.323184, baseValue.Convert(EnergyUnit.Joule, EnergyUnit.InchOunceForce).Round(6));
        Assert.AreEqual(191.645199, baseValue.Convert(EnergyUnit.Joule, EnergyUnit.InchPoundForce).Round(6));
        Assert.AreEqual(15.970433, baseValue.Convert(EnergyUnit.Joule, EnergyUnit.FootPoundForce).Round(6));
        Assert.AreEqual(513.833495, baseValue.Convert(EnergyUnit.Joule, EnergyUnit.PoundalFoot).Round(6));
    }
}