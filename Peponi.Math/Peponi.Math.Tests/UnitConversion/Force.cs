using Peponi.Math.Extensions;
using Peponi.Math.UnitConversion;

namespace Peponi.Math.Tests.UnitConversion;

[TestClass]
public class Force
{
    [TestMethod]
    public void Test()
    {
        double baseValue = 21.653;

        Assert.AreEqual(2.1652999999999996E+19, baseValue.Convert(ForceUnit.Newton, ForceUnit.AttoNewton).Round(0));
        Assert.AreEqual(2.1652999999999996E+16, baseValue.Convert(ForceUnit.Newton, ForceUnit.FemtoNewton).Round(0));
        Assert.AreEqual(2.1653E+13, baseValue.Convert(ForceUnit.Newton, ForceUnit.PicoNewton).Round(0));
        Assert.AreEqual(2.1653E+10, baseValue.Convert(ForceUnit.Newton, ForceUnit.NanoNewton).Round(0));
        Assert.AreEqual(2.1653E+7, baseValue.Convert(ForceUnit.Newton, ForceUnit.MicroNewton).Round(0));
        Assert.AreEqual(2.1653E+4, baseValue.Convert(ForceUnit.Newton, ForceUnit.MilliNewton).Round(0));
        Assert.AreEqual(2.1653E+3, baseValue.Convert(ForceUnit.Newton, ForceUnit.CentiNewton).Round(1));
        Assert.AreEqual(2.1653E+2, baseValue.Convert(ForceUnit.Newton, ForceUnit.DeciNewton).Round(2));
        Assert.AreEqual(2.1653, baseValue.Convert(ForceUnit.Newton, ForceUnit.DecaNewton).Round(4));
        Assert.AreEqual(0.21653, baseValue.Convert(ForceUnit.Newton, ForceUnit.HectoNewton).Round(5));
        Assert.AreEqual(0.021653, baseValue.Convert(ForceUnit.Newton, ForceUnit.KiloNewton).Round(6));
        Assert.AreEqual(0.021653E-3, baseValue.Convert(ForceUnit.Newton, ForceUnit.MegaNewton).Round(9));
        Assert.AreEqual(0.021653E-6, baseValue.Convert(ForceUnit.Newton, ForceUnit.GigaNewton).Round(12));
        Assert.AreEqual(0.021653E-9, baseValue.Convert(ForceUnit.Newton, ForceUnit.TeraNewton).Round(15));
        baseValue *= 1E9;
        Assert.AreEqual(0.021653E-3, baseValue.Convert(ForceUnit.Newton, ForceUnit.PetaNewton).Round(9));
        Assert.AreEqual(0.021653E-6, baseValue.Convert(ForceUnit.Newton, ForceUnit.ExaNewton).Round(12));
        baseValue /= 1E9;
        Assert.AreEqual(2207.991516, baseValue.Convert(ForceUnit.Newton, ForceUnit.GramForce).Round(6));
        Assert.AreEqual(2.207992, baseValue.Convert(ForceUnit.Newton, ForceUnit.KiloGramForce).Round(6));
        Assert.AreEqual(0.002207992, baseValue.Convert(ForceUnit.Newton, ForceUnit.TonForce).Round(9));
        Assert.AreEqual(0.002433894, baseValue.Convert(ForceUnit.Newton, ForceUnit.TonForce_US).Round(9));
        Assert.AreEqual(0.002173120, baseValue.Convert(ForceUnit.Newton, ForceUnit.TonForce_UK).Round(9));
        Assert.AreEqual(2.1653E+6, baseValue.Convert(ForceUnit.Newton, ForceUnit.Dyne).Round(0));
        Assert.AreEqual(2.1653E+3, baseValue.Convert(ForceUnit.Newton, ForceUnit.JoulePerCentiMeter).Round(1));
        Assert.AreEqual(21.653, baseValue.Convert(ForceUnit.Newton, ForceUnit.JoulePerMeter).Round(3));
        Assert.AreEqual(0.004867788, baseValue.Convert(ForceUnit.Newton, ForceUnit.KipForce).Round(9));
        Assert.AreEqual(77.884608706, baseValue.Convert(ForceUnit.Newton, ForceUnit.OunceForce).Round(9));
        Assert.AreEqual(4.867788045, baseValue.Convert(ForceUnit.Newton, ForceUnit.PoundForce).Round(9));
        Assert.AreEqual(4.867788045E-3, baseValue.Convert(ForceUnit.Newton, ForceUnit.KiloPoundForce).Round(12));
        Assert.AreEqual(156.616449, baseValue.Convert(ForceUnit.Newton, ForceUnit.Poundal).Round(6));
        Assert.AreEqual(156.616449, baseValue.Convert(ForceUnit.Newton, ForceUnit.PoundFootPerSquareSecond).Round(6));
        Assert.AreEqual(2207.991516, baseValue.Convert(ForceUnit.Newton, ForceUnit.Pond).Round(6));
        Assert.AreEqual(2.207992, baseValue.Convert(ForceUnit.Newton, ForceUnit.KiloPond).Round(6));
    }
}