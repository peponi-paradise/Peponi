using Peponi.Math.Extensions;
using Peponi.Math.UnitConversion;

namespace Peponi.Math.Tests.UnitConversion;

[TestClass]
public class Weight
{
    [TestMethod]
    public void Test()
    {
        double baseValue = 21.653;

        Assert.AreEqual(21.653E21, baseValue.Convert(WeightUnit.KiloGram, WeightUnit.AttoGram));
        Assert.AreEqual(21.652999999999996E18, baseValue.Convert(WeightUnit.KiloGram, WeightUnit.FemtoGram));
        Assert.AreEqual(21.652999999999996E15, baseValue.Convert(WeightUnit.KiloGram, WeightUnit.PicoGram));
        Assert.AreEqual(21.653E12, baseValue.Convert(WeightUnit.KiloGram, WeightUnit.NanoGram));
        Assert.AreEqual(21.652999999999996E9, baseValue.Convert(WeightUnit.KiloGram, WeightUnit.MicroGram));
        Assert.AreEqual(21.653E6, baseValue.Convert(WeightUnit.KiloGram, WeightUnit.MilliGram));
        Assert.AreEqual(21.652999999999996E5, baseValue.Convert(WeightUnit.KiloGram, WeightUnit.CentiGram));
        Assert.AreEqual(21.652999999999996E4, baseValue.Convert(WeightUnit.KiloGram, WeightUnit.DeciGram));
        Assert.AreEqual(21.653E3, baseValue.Convert(WeightUnit.KiloGram, WeightUnit.Gram));
        Assert.AreEqual(21.652999999999996E2, baseValue.Convert(WeightUnit.KiloGram, WeightUnit.DecaGram));
        Assert.AreEqual(21.652999999999996E1, baseValue.Convert(WeightUnit.KiloGram, WeightUnit.HectoGram));
        Assert.AreEqual(21.653E-3, baseValue.Convert(WeightUnit.KiloGram, WeightUnit.MegaGram));
        Assert.AreEqual(21.652999999999996E-6, baseValue.Convert(WeightUnit.KiloGram, WeightUnit.GigaGram));
        Assert.AreEqual(21.653E-9, baseValue.Convert(WeightUnit.KiloGram, WeightUnit.TeraGram));
        Assert.AreEqual(21.652999999999996E-12, baseValue.Convert(WeightUnit.KiloGram, WeightUnit.PetaGram));
        Assert.AreEqual(21.652999999999996E-15, baseValue.Convert(WeightUnit.KiloGram, WeightUnit.ExaGram));
        Assert.AreEqual(334156.906985, baseValue.Convert(WeightUnit.KiloGram, WeightUnit.Grain).Round(6));
        Assert.AreEqual(3.818935, baseValue.Convert(WeightUnit.KiloGram, WeightUnit.Stone_US).Round(6));
        Assert.AreEqual(3.409764, baseValue.Convert(WeightUnit.KiloGram, WeightUnit.Stone_UK).Round(6));
        Assert.AreEqual(21.653E-3, baseValue.Convert(WeightUnit.KiloGram, WeightUnit.Tonne).Round(6));
        Assert.AreEqual(21.653E-3, baseValue.Convert(WeightUnit.KiloGram, WeightUnit.Ton).Round(6));
        Assert.AreEqual(21.652999999999996E-6, baseValue.Convert(WeightUnit.KiloGram, WeightUnit.KiloTon));
        Assert.AreEqual(0.023868, baseValue.Convert(WeightUnit.KiloGram, WeightUnit.Ton_US).Round(6));
        Assert.AreEqual(0.021311, baseValue.Convert(WeightUnit.KiloGram, WeightUnit.Ton_UK).Round(6));
        Assert.AreEqual(742.388487, baseValue.Convert(WeightUnit.KiloGram, WeightUnit.AssayTon_US).Round(6));
        Assert.AreEqual(662.846938, baseValue.Convert(WeightUnit.KiloGram, WeightUnit.AssayTon_UK).Round(6));
        Assert.AreEqual(16707.842771, baseValue.Convert(WeightUnit.KiloGram, WeightUnit.Scruple_Apothecary).Round(6));
        Assert.AreEqual(47.736694, baseValue.Convert(WeightUnit.KiloGram, WeightUnit.Pound).Round(6));
        Assert.AreEqual(58.013343, baseValue.Convert(WeightUnit.KiloGram, WeightUnit.Pound_TroyOrApothecary).Round(6));
        Assert.AreEqual(1537.121531, baseValue.Convert(WeightUnit.KiloGram, WeightUnit.Poundal).Round(6));
        Assert.AreEqual(0.047737, baseValue.Convert(WeightUnit.KiloGram, WeightUnit.KiloPound).Round(6));
        Assert.AreEqual(0.047737, baseValue.Convert(WeightUnit.KiloGram, WeightUnit.Kip).Round(6));
        Assert.AreEqual(1.483702, baseValue.Convert(WeightUnit.KiloGram, WeightUnit.Slug).Round(6));
        Assert.AreEqual(763.787099, baseValue.Convert(WeightUnit.KiloGram, WeightUnit.Ounce).Round(6));
        Assert.AreEqual(108265, baseValue.Convert(WeightUnit.KiloGram, WeightUnit.Carat).Round(6));
        Assert.AreEqual(1.3039812589946009E+28, baseValue.Convert(WeightUnit.KiloGram, WeightUnit.Dalton).Round(6));
        Assert.AreEqual(2.207992, baseValue.Convert(WeightUnit.KiloGram, WeightUnit.KiloGramForceSquareSecondPerMeter).Round(6));
        Assert.AreEqual(1.483702, baseValue.Convert(WeightUnit.KiloGram, WeightUnit.PoundForceSquareSecondPerFoot).Round(6));
        Assert.AreEqual(0.21653, baseValue.Convert(WeightUnit.KiloGram, WeightUnit.Quintal_kg).Round(6));
        Assert.AreEqual(13923.202667, baseValue.Convert(WeightUnit.KiloGram, WeightUnit.PennyWeight).Round(6));
        Assert.AreEqual(0.477367, baseValue.Convert(WeightUnit.KiloGram, WeightUnit.HundredWeight_US).Round(6));
        Assert.AreEqual(0.42622, baseValue.Convert(WeightUnit.KiloGram, WeightUnit.HundredWeight_UK).Round(6));
        Assert.AreEqual(1.909468, baseValue.Convert(WeightUnit.KiloGram, WeightUnit.Quarter_US).Round(6));
        Assert.AreEqual(1.704882, baseValue.Convert(WeightUnit.KiloGram, WeightUnit.Quarter_UK).Round(6));
        Assert.AreEqual(21.652999999999996E9, baseValue.Convert(WeightUnit.KiloGram, WeightUnit.Gamma));
        Assert.AreEqual(994758144.171709, baseValue.Convert(WeightUnit.KiloGram, WeightUnit.PlanckMass).Round(6));
        Assert.AreEqual(2.3769978794517927E+31, baseValue.Convert(WeightUnit.KiloGram, WeightUnit.ElectronMass));
        Assert.AreEqual(1.149595119851118E+29, baseValue.Convert(WeightUnit.KiloGram, WeightUnit.MuonMass));
        Assert.AreEqual(1.2945534472171284E+28, baseValue.Convert(WeightUnit.KiloGram, WeightUnit.ProtonMass));
        Assert.AreEqual(1.2927715247085757E+28, baseValue.Convert(WeightUnit.KiloGram, WeightUnit.NeutronMass));
        Assert.AreEqual(6.47598117709549E+27, baseValue.Convert(WeightUnit.KiloGram, WeightUnit.DeuteronMass));
        Assert.AreEqual(1.3039732491872223E+28, baseValue.Convert(WeightUnit.KiloGram, WeightUnit.AtomicMassUnit));
    }
}