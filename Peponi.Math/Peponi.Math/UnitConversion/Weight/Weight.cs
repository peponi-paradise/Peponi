﻿namespace Peponi.Math.UnitConversion;

internal static partial class Weight
{
    internal static T ConvertTo<T>(T value, WeightUnit convertFrom, WeightUnit convertTo) where T : struct
    {
        var multiplierFrom = GetMultiplier(convertFrom);
        var multiplierTo = GetMultiplier(convertTo);
        return (T)Convert.ChangeType((Convert.ToDouble(value) * multiplierFrom / multiplierTo), typeof(T));
    }

    private static double GetMultiplier(WeightUnit unit)
    {
        return unit switch
        {
            WeightUnit.AttoGram => 1.0E-21,
            WeightUnit.FemtoGram => 1.0E-18,
            WeightUnit.PicoGram => 1.0E-15,
            WeightUnit.NanoGram => 1.0E-12,
            WeightUnit.MicroGram => 1.0E-9,
            WeightUnit.MilliGram => 1E-6,
            WeightUnit.CentiGram => 1E-5,
            WeightUnit.DeciGram => 0.0001,
            WeightUnit.Gram => 0.001,
            WeightUnit.DekaGram => 0.01,
            WeightUnit.HectoGram => 0.1,
            WeightUnit.KiloGram => 1,
            WeightUnit.MegaGram => 1000,
            WeightUnit.GigaGram => 1000000,
            WeightUnit.TeraGram => 1000000000,
            WeightUnit.PetaGram => 1000000000000,
            WeightUnit.ExaGram => 1.0E+15,
            WeightUnit.Grain => 6.47989E-5,
            WeightUnit.StoneUS => 5.669904625,
            WeightUnit.StoneUK => 6.35029318,
            WeightUnit.Tonne => 1000,
            WeightUnit.Ton => 1000,
            WeightUnit.KiloTon => 1000000,
            WeightUnit.TonUS => 907.18474,
            WeightUnit.TonUK => 1016.0469088,
            WeightUnit.TonAssayUS => 0.02916667,
            WeightUnit.TonAssayUK => 0.0326666667,
            WeightUnit.ScrupleApothecary => 0.0012959782,
            WeightUnit.Pound => 0.45359237,
            WeightUnit.PoundTroy => 0.3732417216,
            WeightUnit.Poundal => 0.0140867196,
            WeightUnit.KiloPound => 453.59237,
            WeightUnit.Kip => 453.59237,
            WeightUnit.Slug => 14.5939029372,
            WeightUnit.Ounce => 0.0283495231,
            WeightUnit.Carat => 0.0002,
            WeightUnit.Dalton => 1.6605300000013E-27,
            WeightUnit.KgfSquareSecondPerMeter => 9.80665,
            WeightUnit.LbfSquareSecondPerFoot => 14.5939029372,
            WeightUnit.Quintal => 100,
            WeightUnit.PennyWeight => 0.0015551738,
            WeightUnit.HundredWeightUS => 45.359237,
            WeightUnit.HundredWeightUK => 50.80234544,
            WeightUnit.QuarterUS => 11.33980925,
            WeightUnit.QuarterUK => 12.70058636,
            WeightUnit.Gamma => 1.0E-9,
            WeightUnit.PlanckMass => 2.17671E-8,
            WeightUnit.ElectronMass => 9.1093897E-31,
            WeightUnit.MuonMass => 1.8835327E-28,
            WeightUnit.ProtonMass => 1.6726231E-27,
            WeightUnit.NeutronMass => 1.6749286E-27,
            WeightUnit.DeuteronMass => 3.343586E-27,
            WeightUnit.AtomicMassUnit => 1.6605402E-27,
            _ => throw new ArgumentException($"{unit} is not supported")
        };
    }
}