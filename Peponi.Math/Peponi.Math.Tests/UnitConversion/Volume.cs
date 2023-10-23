using Peponi.Math.Extensions;
using Peponi.Math.UnitConversion;

namespace Peponi.Math.Tests.UnitConversion;

[TestClass]
public class Volume
{
    [TestMethod]
    public void Test()
    {
        double baseValue = 21.653;

        Assert.AreEqual(21.652999999999996E9, baseValue.Convert(VolumeUnit.CubicMeter, VolumeUnit.CubicMilliMeter).Round(6));
        Assert.AreEqual(21.653E6, baseValue.Convert(VolumeUnit.CubicMeter, VolumeUnit.CubicCentiMeter).Round(6));
        Assert.AreEqual(21.653E3, baseValue.Convert(VolumeUnit.CubicMeter, VolumeUnit.CubicDeciMeter).Round(6));
        Assert.AreEqual(21.653E-9, baseValue.Convert(VolumeUnit.CubicMeter, VolumeUnit.CubicKiloMeter));
        Assert.AreEqual(433060000, baseValue.Convert(VolumeUnit.CubicMeter, VolumeUnit.Drop));
        Assert.AreEqual(21.653E6, baseValue.Convert(VolumeUnit.CubicMeter, VolumeUnit.CC));
        Assert.AreEqual(21.653E21, baseValue.Convert(VolumeUnit.CubicMeter, VolumeUnit.AttoLiter));
        Assert.AreEqual(21.652999999999996E18, baseValue.Convert(VolumeUnit.CubicMeter, VolumeUnit.FemtoLiter));
        Assert.AreEqual(21.652999999999996E15, baseValue.Convert(VolumeUnit.CubicMeter, VolumeUnit.PicoLiter));
        Assert.AreEqual(21.653E12, baseValue.Convert(VolumeUnit.CubicMeter, VolumeUnit.NanoLiter));
        Assert.AreEqual(21.652999999999996E9, baseValue.Convert(VolumeUnit.CubicMeter, VolumeUnit.MicroLiter));
        Assert.AreEqual(21.653E6, baseValue.Convert(VolumeUnit.CubicMeter, VolumeUnit.MilliLiter));
        Assert.AreEqual(21.652999999999996E5, baseValue.Convert(VolumeUnit.CubicMeter, VolumeUnit.CentiLiter));
        Assert.AreEqual(21.652999999999996E4, baseValue.Convert(VolumeUnit.CubicMeter, VolumeUnit.DeciLiter));
        Assert.AreEqual(21.653E3, baseValue.Convert(VolumeUnit.CubicMeter, VolumeUnit.Liter));
        Assert.AreEqual(21.652999999999996E2, baseValue.Convert(VolumeUnit.CubicMeter, VolumeUnit.DecaLiter));
        Assert.AreEqual(21.652999999999996E1, baseValue.Convert(VolumeUnit.CubicMeter, VolumeUnit.HectoLiter));
        Assert.AreEqual(21.653, baseValue.Convert(VolumeUnit.CubicMeter, VolumeUnit.KiloLiter));
        Assert.AreEqual(21.653E-3, baseValue.Convert(VolumeUnit.CubicMeter, VolumeUnit.MegaLiter));
        Assert.AreEqual(21.652999999999996E-6, baseValue.Convert(VolumeUnit.CubicMeter, VolumeUnit.GigaLiter));
        Assert.AreEqual(21.653E-9, baseValue.Convert(VolumeUnit.CubicMeter, VolumeUnit.TeraLiter));
        Assert.AreEqual(21.652999999999996E-12, baseValue.Convert(VolumeUnit.CubicMeter, VolumeUnit.PetaLiter));
        Assert.AreEqual(21.652999999999996E-15, baseValue.Convert(VolumeUnit.CubicMeter, VolumeUnit.ExaLiter));
        Assert.AreEqual(4330600, baseValue.Convert(VolumeUnit.CubicMeter, VolumeUnit.TeaSpoon).Round(6));
        Assert.AreEqual(4393050.201378, baseValue.Convert(VolumeUnit.CubicMeter, VolumeUnit.TeaSpoon_US).Round(6));
        Assert.AreEqual(3657979.494467, baseValue.Convert(VolumeUnit.CubicMeter, VolumeUnit.TeaSpoon_UK).Round(6));
        Assert.AreEqual(1443533.333333, baseValue.Convert(VolumeUnit.CubicMeter, VolumeUnit.TableSpoon).Round(6));
        Assert.AreEqual(1464346.579382, baseValue.Convert(VolumeUnit.CubicMeter, VolumeUnit.TableSpoon_US).Round(6));
        Assert.AreEqual(1219324.030589, baseValue.Convert(VolumeUnit.CubicMeter, VolumeUnit.TableSpoon_UK).Round(6));
        Assert.AreEqual(732175.765466, baseValue.Convert(VolumeUnit.CubicMeter, VolumeUnit.Ounce_US).Round(6));
        Assert.AreEqual(762078.055545, baseValue.Convert(VolumeUnit.CubicMeter, VolumeUnit.Ounce_UK).Round(6));
        Assert.AreEqual(86612, baseValue.Convert(VolumeUnit.CubicMeter, VolumeUnit.Cup).Round(6));
        Assert.AreEqual(91521.893315, baseValue.Convert(VolumeUnit.CubicMeter, VolumeUnit.Cup_US).Round(6));
        Assert.AreEqual(76207.91284, baseValue.Convert(VolumeUnit.CubicMeter, VolumeUnit.Cup_UK).Round(6));
        Assert.AreEqual(45760.936987, baseValue.Convert(VolumeUnit.CubicMeter, VolumeUnit.Pint_US).Round(6));
        Assert.AreEqual(38103.949715, baseValue.Convert(VolumeUnit.CubicMeter, VolumeUnit.Pint_UK).Round(6));
        Assert.AreEqual(22880.470911, baseValue.Convert(VolumeUnit.CubicMeter, VolumeUnit.Quart_US).Round(6));
        Assert.AreEqual(19051.976534, baseValue.Convert(VolumeUnit.CubicMeter, VolumeUnit.Quart_UK).Round(6));
        Assert.AreEqual(5720.117426, baseValue.Convert(VolumeUnit.CubicMeter, VolumeUnit.Gallon_US).Round(6));
        Assert.AreEqual(4762.994133, baseValue.Convert(VolumeUnit.CubicMeter, VolumeUnit.Gallon_UK).Round(6));
        Assert.AreEqual(136.193273, baseValue.Convert(VolumeUnit.CubicMeter, VolumeUnit.Barrel).Round(6));
        Assert.AreEqual(181.59103, baseValue.Convert(VolumeUnit.CubicMeter, VolumeUnit.Barrel_US).Round(6));
        Assert.AreEqual(132.305393, baseValue.Convert(VolumeUnit.CubicMeter, VolumeUnit.Barrel_UK).Round(6));
        Assert.AreEqual(183043.78663, baseValue.Convert(VolumeUnit.CubicMeter, VolumeUnit.Gill_US).Round(6));
        Assert.AreEqual(152415.82568, baseValue.Convert(VolumeUnit.CubicMeter, VolumeUnit.Gill_UK).Round(6));
        Assert.AreEqual(351444016.110243, baseValue.Convert(VolumeUnit.CubicMeter, VolumeUnit.Minim_US).Round(6));
        Assert.AreEqual(365797949.446669, baseValue.Convert(VolumeUnit.CubicMeter, VolumeUnit.Minim_UK).Round(6));
        Assert.AreEqual(1321344.228082, baseValue.Convert(VolumeUnit.CubicMeter, VolumeUnit.CubicInch).Round(6));
        Assert.AreEqual(0.210652, baseValue.Convert(VolumeUnit.CubicMeter, VolumeUnit.AcreInch).Round(6));
        Assert.AreEqual(9176.021804, baseValue.Convert(VolumeUnit.CubicMeter, VolumeUnit.BoardFoot).Round(6));
        Assert.AreEqual(764.668478, baseValue.Convert(VolumeUnit.CubicMeter, VolumeUnit.CubicFoot).Round(6));
        Assert.AreEqual(7.646685, baseValue.Convert(VolumeUnit.CubicMeter, VolumeUnit.HundredCubicFoot).Round(6));
        Assert.AreEqual(0.017554, baseValue.Convert(VolumeUnit.CubicMeter, VolumeUnit.AcreFoot).Round(6));
        Assert.AreEqual(0.017554, baseValue.Convert(VolumeUnit.CubicMeter, VolumeUnit.AcreFoot_US).Round(6));
        Assert.AreEqual(28.321055, baseValue.Convert(VolumeUnit.CubicMeter, VolumeUnit.CubicYard).Round(6));
        Assert.AreEqual(5.194831E-9, baseValue.Convert(VolumeUnit.CubicMeter, VolumeUnit.CubicMile).Round(15));
        Assert.AreEqual(7.646685, baseValue.Convert(VolumeUnit.CubicMeter, VolumeUnit.TonRegister).Round(6));
        Assert.AreEqual(7.646685, baseValue.Convert(VolumeUnit.CubicMeter, VolumeUnit.Ccf).Round(6));
        Assert.AreEqual(216.53, baseValue.Convert(VolumeUnit.CubicMeter, VolumeUnit.DeciStere).Round(6));
        Assert.AreEqual(21.653, baseValue.Convert(VolumeUnit.CubicMeter, VolumeUnit.Stere).Round(6));
        Assert.AreEqual(2.1653, baseValue.Convert(VolumeUnit.CubicMeter, VolumeUnit.DecaStere).Round(6));
        Assert.AreEqual(5.973972, baseValue.Convert(VolumeUnit.CubicMeter, VolumeUnit.Cord).Round(6));
        Assert.AreEqual(22.698879, baseValue.Convert(VolumeUnit.CubicMeter, VolumeUnit.Tun).Round(6));
        Assert.AreEqual(90.795515, baseValue.Convert(VolumeUnit.CubicMeter, VolumeUnit.Hogshead).Round(6));
        Assert.AreEqual(5857400.268504, baseValue.Convert(VolumeUnit.CubicMeter, VolumeUnit.Dram).Round(6));
    }
}