namespace Peponi.Maths.UnitConversion;

internal static class Pressure
{
    private static Dictionary<PressureUnit, double> _multipliers;

    static Pressure()
    {
        _multipliers = new()
        {
            { PressureUnit.AtmosphereTechnical, 98066.500000003 },
            { PressureUnit.StandardAtmosphere, 101325 },
            { PressureUnit.AttoPascal, 1E-18 },
            { PressureUnit.FemtoPascal, 1E-15 },
            { PressureUnit.PicoPascal, 1E-12 },
            { PressureUnit.NanoPascal, 1E-9 },
            { PressureUnit.MicroPascal, 1E-6 },
            { PressureUnit.MilliPascal, 1E-3 },
            { PressureUnit.CentiPascal, 0.01 },
            { PressureUnit.DeciPascal, 0.1 },
            { PressureUnit.Pascal, 1 },
            { PressureUnit.DecaPascal, 10 },
            { PressureUnit.HectoPascal, 100 },
            { PressureUnit.KiloPascal, 1000 },
            { PressureUnit.MegaPascal, 1E6 },
            { PressureUnit.GigaPascal, 1E9 },
            { PressureUnit.TeraPascal, 1E12 },
            { PressureUnit.PetaPascal, 1E15 },
            { PressureUnit.ExaPascal, 1E18 },
            { PressureUnit.NewtonPerSquareMillimeter, 1E6 },
            { PressureUnit.NewtonPerSquareCentimeter, 1E4 },
            { PressureUnit.NewtonPerSquareMeter, 1 },
            { PressureUnit.KiloNewtonPerSquareMeter, 1E3 },
            { PressureUnit.MicroBar, 0.1 },
            { PressureUnit.MilliBar, 1E2 },
            { PressureUnit.Bar, 1E5 },
            { PressureUnit.DynePerSquareCentimeter, 0.1 },
            { PressureUnit.KiloGramForcePerSquareMillimeter, 9.80665E6 },
            { PressureUnit.KiloGramForcePerSquareCentimeter, 9.80665E4 },
            { PressureUnit.KiloGramForcePerSquareMeter, 9.80665 },
            { PressureUnit.TonForcePerSquareFoot_US, 95760.517960678 },
            { PressureUnit.TonForcePerSquareInch_US, 13789514.586338 },
            { PressureUnit.TonForcePerSquareFoot_UK, 107251.78011595 },
            { PressureUnit.TonForcePerSquareInch_UK, 15444256.336697 },
            { PressureUnit.KipForcePerSquareInch, 6894757.2931783 },
            { PressureUnit.PoundForcePerSquareFoot, 47.8802589804 },
            { PressureUnit.PoundForcePerSquareInch, 6894.7572931783 },
            { PressureUnit.PoundalPerSquareFoot, 1.4881639436 },
            { PressureUnit.KiloPoundPerSquareInch, 6894757.2931783 },
            { PressureUnit.PoundPerSquareInch, 6894.7572931783 },
            { PressureUnit.Torr, 133.3223684211 },
            { PressureUnit.MilliMeterMercury_0C, 133.322 },
            { PressureUnit.CentiMeterMercury_0C, 1333.22 },
            { PressureUnit.InchMercury_32F, 3386.38 },
            { PressureUnit.InchMercury_60F, 3376.85 },
            { PressureUnit.MilliMeterWater_4C, 9.80638 },
            { PressureUnit.CentiMeterWater_4C, 98.0638 },
            { PressureUnit.InchWater_4C, 249.082 },
            { PressureUnit.FootWater_4C, 2988.98 },
            { PressureUnit.InchWater_60F, 248.843 },
            { PressureUnit.FootWater_60F, 2986.116 }
        };
    }

    internal static T ConvertTo<T>(T value, PressureUnit convertFrom, PressureUnit convertTo) where T : struct
    {
        return (T)Convert.ChangeType((Convert.ToDouble(value) * _multipliers[convertFrom] / _multipliers[convertTo]), typeof(T));
    }
}