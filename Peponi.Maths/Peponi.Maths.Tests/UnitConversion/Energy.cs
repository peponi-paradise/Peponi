using Peponi.Maths.Extensions;
using Peponi.Maths.UnitConversion;

namespace Peponi.Maths.Tests.UnitConversion;

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
        Assert.AreEqual(2.05230034E-7, baseValue.Convert(EnergyUnit.Joule, EnergyUnit.Therm_EC).Round(15));
        Assert.AreEqual(2.05279843E-7, baseValue.Convert(EnergyUnit.Joule, EnergyUnit.Therm_US).Round(15));
        Assert.AreEqual(2.05230841E-7, baseValue.Convert(EnergyUnit.Joule, EnergyUnit.Therm_UK).Round(15));
        Assert.AreEqual(1.7103E-6, baseValue.Convert(EnergyUnit.Joule, EnergyUnit.TonHour_Refrigeration).Round(10));
        Assert.AreEqual(5.38664E-10, baseValue.Convert(EnergyUnit.Joule, EnergyUnit.FuelOilEquivalent_KiloLiter).Round(15));
        Assert.AreEqual(3.392245E-9, baseValue.Convert(EnergyUnit.Joule, EnergyUnit.FuelOilEquivalent_Barrel_US).Round(15));
        Assert.AreEqual(5.175191E-9, baseValue.Convert(EnergyUnit.Joule, EnergyUnit.Ton_TNT).Round(15));
        baseValue *= 1E9;
        Assert.AreEqual(5.175191E-3, baseValue.Convert(EnergyUnit.Joule, EnergyUnit.KiloTon_TNT).Round(9));
        Assert.AreEqual(5.175191E-6, baseValue.Convert(EnergyUnit.Joule, EnergyUnit.MegaTon_TNT).Round(12));
        Assert.AreEqual(5.175191E-9, baseValue.Convert(EnergyUnit.Joule, EnergyUnit.GigaTon_TNT).Round(15));
        baseValue *= 1E-9;
        Assert.AreEqual(0.005172, baseValue.Convert(EnergyUnit.Joule, EnergyUnit.Calorie_Nutritional).Round(6));
        Assert.AreEqual(5.171730, baseValue.Convert(EnergyUnit.Joule, EnergyUnit.Calorie_InternationalTable).Round(6));
        Assert.AreEqual(5.175191, baseValue.Convert(EnergyUnit.Joule, EnergyUnit.Calorie_Thermochemical).Round(6));
        Assert.AreEqual(0.000005172, baseValue.Convert(EnergyUnit.Joule, EnergyUnit.KiloCalorie_Nutritional).Round(9));
        Assert.AreEqual(0.005171730, baseValue.Convert(EnergyUnit.Joule, EnergyUnit.KiloCalorie_InternationalTable).Round(9));
        Assert.AreEqual(0.005175191, baseValue.Convert(EnergyUnit.Joule, EnergyUnit.KiloCalorie_Thermochemical).Round(9));
        Assert.AreEqual(8.177746E-6, baseValue.Convert(EnergyUnit.Joule, EnergyUnit.HorsePowerHour).Round(12));
        Assert.AreEqual(8.065875E-6, baseValue.Convert(EnergyUnit.Joule, EnergyUnit.HorsePowerHour_UK).Round(12));
        Assert.AreEqual(0.020523084, baseValue.Convert(EnergyUnit.Joule, EnergyUnit.BritishThermalUnit_InternationalTable).Round(9));
        Assert.AreEqual(0.020536824, baseValue.Convert(EnergyUnit.Joule, EnergyUnit.BritishThermalUnit_Thermochemical).Round(9));
        Assert.AreEqual(0.020523084E-6, baseValue.Convert(EnergyUnit.Joule, EnergyUnit.MegaBritishThermalUnit_InternationalTable).Round(15));
        Assert.AreEqual(0.020536824E-6, baseValue.Convert(EnergyUnit.Joule, EnergyUnit.MegaBritishThermalUnit_Thermochemical).Round(15));
        Assert.AreEqual(216530000, baseValue.Convert(EnergyUnit.Joule, EnergyUnit.Erg).Round(0));
        Assert.AreEqual(1.3514739598930736E+20, baseValue.Convert(EnergyUnit.Joule, EnergyUnit.ElectronVolt).Round(0));
        Assert.AreEqual(1.3514739598930736E+17, baseValue.Convert(EnergyUnit.Joule, EnergyUnit.KiloElectronVolt).Round(3));
        Assert.AreEqual(1.3514739598930736E+14, baseValue.Convert(EnergyUnit.Joule, EnergyUnit.MegaElectronVolt).Round(6));
        Assert.AreEqual(1.3514739598930736E+11, baseValue.Convert(EnergyUnit.Joule, EnergyUnit.GigaElectronVolt).Round(9));
        Assert.AreEqual(4.966571234549741E+18, baseValue.Convert(EnergyUnit.Joule, EnergyUnit.Hartree).Round(0));
        Assert.AreEqual(9.933142469099481E+18, baseValue.Convert(EnergyUnit.Joule, EnergyUnit.RydbergConstant).Round(0));
    }
}