using Peponi.Maths.Extensions;
using Peponi.Maths.UnitConversion;

namespace Peponi.Maths.Tests.UnitConversion;

[TestClass]
public class Pressure
{
    [TestMethod]
    public void Test()
    {
        double baseValue = 21.653;

        Assert.AreEqual(0.000221, baseValue.Convert(PressureUnit.Pascal, PressureUnit.AtmosphereTechnical).Round(6));
        Assert.AreEqual(0.000214, baseValue.Convert(PressureUnit.Pascal, PressureUnit.StandardAtmosphere).Round(6));
        Assert.AreEqual(21.652999999999996E18, baseValue.Convert(PressureUnit.Pascal, PressureUnit.AttoPascal));
        Assert.AreEqual(21.652999999999996E15, baseValue.Convert(PressureUnit.Pascal, PressureUnit.FemtoPascal));
        Assert.AreEqual(21.653E12, baseValue.Convert(PressureUnit.Pascal, PressureUnit.PicoPascal));
        Assert.AreEqual(21.652999999999996E9, baseValue.Convert(PressureUnit.Pascal, PressureUnit.NanoPascal));
        Assert.AreEqual(21.653E6, baseValue.Convert(PressureUnit.Pascal, PressureUnit.MicroPascal));
        Assert.AreEqual(21.653E3, baseValue.Convert(PressureUnit.Pascal, PressureUnit.MilliPascal));
        Assert.AreEqual(21.652999999999996E2, baseValue.Convert(PressureUnit.Pascal, PressureUnit.CentiPascal));
        Assert.AreEqual(21.652999999999996E1, baseValue.Convert(PressureUnit.Pascal, PressureUnit.DeciPascal));
        Assert.AreEqual(21.653E-1, baseValue.Convert(PressureUnit.Pascal, PressureUnit.DecaPascal));
        Assert.AreEqual(21.653E-2, baseValue.Convert(PressureUnit.Pascal, PressureUnit.HectoPascal));
        Assert.AreEqual(21.653E-3, baseValue.Convert(PressureUnit.Pascal, PressureUnit.KiloPascal));
        Assert.AreEqual(21.652999999999996E-6, baseValue.Convert(PressureUnit.Pascal, PressureUnit.MegaPascal));
        Assert.AreEqual(21.653E-9, baseValue.Convert(PressureUnit.Pascal, PressureUnit.GigaPascal));
        Assert.AreEqual(21.652999999999996E-12, baseValue.Convert(PressureUnit.Pascal, PressureUnit.TeraPascal));
        Assert.AreEqual(21.652999999999996E-15, baseValue.Convert(PressureUnit.Pascal, PressureUnit.PetaPascal));
        Assert.AreEqual(21.652999999999996E-18, baseValue.Convert(PressureUnit.Pascal, PressureUnit.ExaPascal));
        Assert.AreEqual(21.652999999999996E-6, baseValue.Convert(PressureUnit.Pascal, PressureUnit.NewtonPerSquareMillimeter));
        Assert.AreEqual(21.652999999999996E-4, baseValue.Convert(PressureUnit.Pascal, PressureUnit.NewtonPerSquareCentimeter));
        Assert.AreEqual(21.653, baseValue.Convert(PressureUnit.Pascal, PressureUnit.NewtonPerSquareMeter));
        Assert.AreEqual(21.653E-3, baseValue.Convert(PressureUnit.Pascal, PressureUnit.KiloNewtonPerSquareMeter));
        Assert.AreEqual(21.652999999999996E1, baseValue.Convert(PressureUnit.Pascal, PressureUnit.MicroBar));
        Assert.AreEqual(21.653E-2, baseValue.Convert(PressureUnit.Pascal, PressureUnit.MilliBar));
        Assert.AreEqual(21.653E-5, baseValue.Convert(PressureUnit.Pascal, PressureUnit.Bar));
        Assert.AreEqual(21.652999999999996E1, baseValue.Convert(PressureUnit.Pascal, PressureUnit.DynePerSquareCentimeter));
        Assert.AreEqual(0.000002208, baseValue.Convert(PressureUnit.Pascal, PressureUnit.KiloGramForcePerSquareMillimeter).Round(9));
        Assert.AreEqual(0.000220799, baseValue.Convert(PressureUnit.Pascal, PressureUnit.KiloGramForcePerSquareCentimeter).Round(9));
        Assert.AreEqual(2.207991516, baseValue.Convert(PressureUnit.Pascal, PressureUnit.KiloGramForcePerSquareMeter).Round(9));
        Assert.AreEqual(0.000226116, baseValue.Convert(PressureUnit.Pascal, PressureUnit.TonForcePerSquareFoot_US).Round(9));
        Assert.AreEqual(0.000201889, baseValue.Convert(PressureUnit.Pascal, PressureUnit.TonForcePerSquareFoot_UK).Round(9));
        Assert.AreEqual(0.00000157, baseValue.Convert(PressureUnit.Pascal, PressureUnit.TonForcePerSquareInch_US).Round(9));
        Assert.AreEqual(0.000001402, baseValue.Convert(PressureUnit.Pascal, PressureUnit.TonForcePerSquareInch_UK).Round(9));
        Assert.AreEqual(0.000003141, baseValue.Convert(PressureUnit.Pascal, PressureUnit.KipForcePerSquareInch).Round(9));
        Assert.AreEqual(0.452232307, baseValue.Convert(PressureUnit.Pascal, PressureUnit.PoundForcePerSquareFoot).Round(9));
        Assert.AreEqual(0.003140502, baseValue.Convert(PressureUnit.Pascal, PressureUnit.PoundForcePerSquareInch).Round(9));
        Assert.AreEqual(14.550144218, baseValue.Convert(PressureUnit.Pascal, PressureUnit.PoundalPerSquareFoot).Round(9));
        Assert.AreEqual(0.000003141, baseValue.Convert(PressureUnit.Pascal, PressureUnit.KiloPoundPerSquareInch).Round(9));
        Assert.AreEqual(0.003140502, baseValue.Convert(PressureUnit.Pascal, PressureUnit.PoundPerSquareInch).Round(9));
        Assert.AreEqual(0.162410856, baseValue.Convert(PressureUnit.Pascal, PressureUnit.Torr).Round(9));
        Assert.AreEqual(0.162411305, baseValue.Convert(PressureUnit.Pascal, PressureUnit.MilliMeterMercury_0C).Round(9));
        Assert.AreEqual(0.01624113, baseValue.Convert(PressureUnit.Pascal, PressureUnit.CentiMeterMercury_0C).Round(9));
        Assert.AreEqual(0.006394144, baseValue.Convert(PressureUnit.Pascal, PressureUnit.InchMercury_32F).Round(9));
        Assert.AreEqual(0.006412189, baseValue.Convert(PressureUnit.Pascal, PressureUnit.InchMercury_60F).Round(9));
        Assert.AreEqual(2.208052309, baseValue.Convert(PressureUnit.Pascal, PressureUnit.MilliMeterWater_4C).Round(9));
        Assert.AreEqual(0.220805231, baseValue.Convert(PressureUnit.Pascal, PressureUnit.CentiMeterWater_4C).Round(9));
        Assert.AreEqual(0.086931211, baseValue.Convert(PressureUnit.Pascal, PressureUnit.InchWater_4C).Round(9));
        Assert.AreEqual(0.007244277, baseValue.Convert(PressureUnit.Pascal, PressureUnit.FootWater_4C).Round(9));
        Assert.AreEqual(0.087014704, baseValue.Convert(PressureUnit.Pascal, PressureUnit.InchWater_60F).Round(9));
        Assert.AreEqual(0.007251225, baseValue.Convert(PressureUnit.Pascal, PressureUnit.FootWater_60F).Round(9));
    }
}