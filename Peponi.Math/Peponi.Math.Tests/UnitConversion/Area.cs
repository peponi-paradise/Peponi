using Peponi.Math.Extensions;
using Peponi.Math.UnitConversion;

namespace Peponi.Math.Tests.UnitConversion;

[TestClass]
public class Area
{
    [TestMethod]
    public void Test()
    {
        double baseValue = 21.653;

        Assert.AreEqual(21652999999999996000.0, baseValue.Convert(AreaUnit.SquareMeter, AreaUnit.SquareNanoMeter).Round(0));
        Assert.AreEqual(21653000000000.0, baseValue.Convert(AreaUnit.SquareMeter, AreaUnit.SquareMicroMeter).Round(0));
        Assert.AreEqual(21653000.0, baseValue.Convert(AreaUnit.SquareMeter, AreaUnit.SquareMilliMeter).Round(0));
        Assert.AreEqual(216530.0, baseValue.Convert(AreaUnit.SquareMeter, AreaUnit.SquareCentiMeter).Round(0));
        Assert.AreEqual(2165.3, baseValue.Convert(AreaUnit.SquareMeter, AreaUnit.SquareDeciMeter).Round(1));
        Assert.AreEqual(0.21653, baseValue.Convert(AreaUnit.SquareMeter, AreaUnit.SquareDecaMeter).Round(6));
        Assert.AreEqual(0.002165, baseValue.Convert(AreaUnit.SquareMeter, AreaUnit.SquareHectoMeter).Round(6));
        Assert.AreEqual(0.000022, baseValue.Convert(AreaUnit.SquareMeter, AreaUnit.SquareKiloMeter).Round(6));
        Assert.AreEqual(0.002165, baseValue.Convert(AreaUnit.SquareMeter, AreaUnit.Hectare).Round(6));
        Assert.AreEqual(0.00535057, baseValue.Convert(AreaUnit.SquareMeter, AreaUnit.Acre).Round(8));
        Assert.AreEqual(0.00535055, baseValue.Convert(AreaUnit.SquareMeter, AreaUnit.Acre_US).Round(8));
        Assert.AreEqual(0.21653, baseValue.Convert(AreaUnit.SquareMeter, AreaUnit.Are).Round(6));
        Assert.AreEqual(0.00000836, baseValue.Convert(AreaUnit.SquareMeter, AreaUnit.SquareMile).Round(8));
        Assert.AreEqual(0.00000836, baseValue.Convert(AreaUnit.SquareMeter, AreaUnit.SquareMile_US).Round(8));
        Assert.AreEqual(25.89677247, baseValue.Convert(AreaUnit.SquareMeter, AreaUnit.SquareYard).Round(8));
        Assert.AreEqual(233.07095225, baseValue.Convert(AreaUnit.SquareMeter, AreaUnit.SquareFoot).Round(8));
        Assert.AreEqual(233.07002, baseValue.Convert(AreaUnit.SquareMeter, AreaUnit.SquareFoot_US).Round(8));
        Assert.AreEqual(33562.21712443, baseValue.Convert(AreaUnit.SquareMeter, AreaUnit.SquareInch).Round(8));
        Assert.AreEqual(42732.74028902, baseValue.Convert(AreaUnit.SquareMeter, AreaUnit.CircularInch).Round(8));
        Assert.AreEqual(2.1653E29, baseValue.Convert(AreaUnit.SquareMeter, AreaUnit.Barn).Round(8));
        Assert.AreEqual(2.32229723E-7, baseValue.Convert(AreaUnit.SquareMeter, AreaUnit.Township).Round(15));
        Assert.AreEqual(8.36E-6, baseValue.Convert(AreaUnit.SquareMeter, AreaUnit.Section).Round(8));
        Assert.AreEqual(3.344E-5, baseValue.Convert(AreaUnit.SquareMeter, AreaUnit.Homestead).Round(8));
        Assert.AreEqual(0.00338328, baseValue.Convert(AreaUnit.SquareMeter, AreaUnit.Plaza).Round(8));
        Assert.AreEqual(0.05350573, baseValue.Convert(AreaUnit.SquareMeter, AreaUnit.SquareChain).Round(8));
        Assert.AreEqual(0.02140229, baseValue.Convert(AreaUnit.SquareMeter, AreaUnit.Rood).Round(8));
        Assert.AreEqual(0.85609165, baseValue.Convert(AreaUnit.SquareMeter, AreaUnit.SquareRod).Round(8));
        Assert.AreEqual(0.85608823, baseValue.Convert(AreaUnit.SquareMeter, AreaUnit.SquareRod_US).Round(8));
        Assert.AreEqual(0.85609165, baseValue.Convert(AreaUnit.SquareMeter, AreaUnit.SquarePerch).Round(8));
        Assert.AreEqual(0.85609165, baseValue.Convert(AreaUnit.SquareMeter, AreaUnit.SquarePole).Round(8));
        Assert.AreEqual(33562217124.434246, baseValue.Convert(AreaUnit.SquareMeter, AreaUnit.SquareMil).Round(8));
        Assert.AreEqual(42732742051.817154, baseValue.Convert(AreaUnit.SquareMeter, AreaUnit.CircularMil).Round(8));
        Assert.AreEqual(233.07095225, baseValue.Convert(AreaUnit.SquareMeter, AreaUnit.Sabin).Round(8));
        Assert.AreEqual(0.00633334, baseValue.Convert(AreaUnit.SquareMeter, AreaUnit.Arpent).Round(8));
        Assert.AreEqual(0.00550911, baseValue.Convert(AreaUnit.SquareMeter, AreaUnit.Cuerda).Round(8));
        Assert.AreEqual(30.98876974, baseValue.Convert(AreaUnit.SquareMeter, AreaUnit.VarasCastellanasCuad).Round(8));
        Assert.AreEqual(3.44319664, baseValue.Convert(AreaUnit.SquareMeter, AreaUnit.VarasConuquerasCuad).Round(8));
        Assert.AreEqual(3.2548853795714244E+29, baseValue.Convert(AreaUnit.SquareMeter, AreaUnit.ElectronCrossSection).Round(8));
    }
}