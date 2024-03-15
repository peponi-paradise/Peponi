namespace Peponi.Maths.UnitConversion;

internal static class Weight
{
    private static Dictionary<WeightUnit, double> _multipliers;

    static Weight()
    {
        _multipliers = new()
        {
            { WeightUnit.AttoGram, 1E-21 },
            { WeightUnit.FemtoGram, 1E-18 },
            { WeightUnit.PicoGram, 1E-15 },
            { WeightUnit.NanoGram, 1E-12 },
            { WeightUnit.MicroGram, 1E-9 },
            { WeightUnit.MilliGram, 1E-6 },
            { WeightUnit.CentiGram, 1E-5 },
            { WeightUnit.DeciGram, 1E-4 },
            { WeightUnit.Gram, 1E-3 },
            { WeightUnit.DecaGram, 1E-2 },
            { WeightUnit.HectoGram, 0.1 },
            { WeightUnit.KiloGram, 1 },
            { WeightUnit.MegaGram, 1E3 },
            { WeightUnit.GigaGram, 1E6 },
            { WeightUnit.TeraGram, 1E9 },
            { WeightUnit.PetaGram, 1E12 },
            { WeightUnit.ExaGram, 1E15 },
            { WeightUnit.Grain, 6.47989E-5 },
            { WeightUnit.Stone_US, 5.669904625 },
            { WeightUnit.Stone_UK, 6.35029318 },
            { WeightUnit.Tonne, 1E3 },
            { WeightUnit.Ton, 1E3 },
            { WeightUnit.KiloTon, 1E6 },
            { WeightUnit.Ton_US, 907.18474 },
            { WeightUnit.Ton_UK, 1016.0469088 },
            { WeightUnit.AssayTon_US, 0.02916667 },
            { WeightUnit.AssayTon_UK, 0.0326666667 },
            { WeightUnit.Scruple_Apothecary, 0.0012959782 },
            { WeightUnit.Pound, 0.45359237 },
            { WeightUnit.Pound_TroyOrApothecary, 0.3732417216 },
            { WeightUnit.Poundal, 0.0140867196 },
            { WeightUnit.KiloPound, 453.59237 },
            { WeightUnit.Kip, 453.59237 },
            { WeightUnit.Slug, 14.5939029372 },
            { WeightUnit.Ounce, 0.0283495231 },
            { WeightUnit.Carat, 0.0002 },
            { WeightUnit.Dalton, 1.6605300000013E-27 },
            { WeightUnit.KiloGramForceSquareSecondPerMeter, 9.80665 },
            { WeightUnit.PoundForceSquareSecondPerFoot, 14.5939029372 },
            { WeightUnit.Quintal_kg, 100 },
            { WeightUnit.PennyWeight, 0.0015551738 },
            { WeightUnit.HundredWeight_US, 45.359237 },
            { WeightUnit.HundredWeight_UK, 50.80234544 },
            { WeightUnit.Quarter_US, 11.33980925 },
            { WeightUnit.Quarter_UK, 12.70058636 },
            { WeightUnit.Gamma, 1E-9 },
            { WeightUnit.PlanckMass, 2.17671E-8 },
            { WeightUnit.ElectronMass, 9.1093897E-31 },
            { WeightUnit.MuonMass, 1.8835327E-28 },
            { WeightUnit.ProtonMass, 1.6726231E-27 },
            { WeightUnit.NeutronMass, 1.6749286E-27 },
            { WeightUnit.DeuteronMass, 3.343586E-27 },
            { WeightUnit.AtomicMassUnit, 1.6605402E-27 }
        };
    }

    internal static T ConvertTo<T>(T value, WeightUnit convertFrom, WeightUnit convertTo) where T : struct
    {
        return (T)Convert.ChangeType((Convert.ToDouble(value) * _multipliers[convertFrom] / _multipliers[convertTo]), typeof(T));
    }
}