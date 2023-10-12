namespace Peponi.Math.UnitConversion;

internal static partial class Pressure
{
    internal static T ConvertTo<T>(T value, PressureUnit convertFrom, PressureUnit convertTo) where T : struct
    {
        var multiplierFrom = GetMultiplier(convertFrom);
        var multiplierTo = GetMultiplier(convertTo);

        return (T)Convert.ChangeType((Convert.ToDouble(value) * multiplierFrom / multiplierTo), typeof(T));
    }

    private static double GetMultiplier(PressureUnit unit)
    {
        return unit switch
        {
            PressureUnit.AtmosphereTechnical => 98066.500000003,
            PressureUnit.StandardAtmosphere => 101325,
            PressureUnit.AttoPascal => 1E-18,
            PressureUnit.FemtoPascal => 1E-15,
            PressureUnit.PicoPascal => 1E-12,
            PressureUnit.NanoPascal => 1E-9,
            PressureUnit.MicroPascal => 1E-6,
            PressureUnit.MilliPascal => 1E-3,
            PressureUnit.CentiPascal => 0.01,
            PressureUnit.DeciPascal => 0.1,
            PressureUnit.Pascal => 1,
            PressureUnit.DekaPascal => 10,
            PressureUnit.HectoPascal => 100,
            PressureUnit.KiloPascal => 1000,
            PressureUnit.MegaPascal => 1E6,
            PressureUnit.GigaPascal => 1E9,
            PressureUnit.TeraPascal => 1E12,
            PressureUnit.PetaPascal => 1E15,
            PressureUnit.ExaPascal => 1E18,
            PressureUnit.NewtonPerSquareMillimeter => 1000000,
            PressureUnit.NewtonPerSquareCentimeter => 10000,
            PressureUnit.NewtonPerSquareMeter => 1,
            PressureUnit.KiloNewtonPerSquareMeter => 1000,
            PressureUnit.MicroBar => 0.1,
            PressureUnit.MilliBar => 100,
            PressureUnit.Bar => 100000,
            PressureUnit.DynePerSquareCentimeter => 0.1,
            PressureUnit.KiloGramForcePerSquareMillimeter => Constants.GravitationalAcceleration * 1E6,
            PressureUnit.KiloGramForcePerSquareCentimeter => Constants.GravitationalAcceleration * 1E4,
            PressureUnit.KiloGramForcePerSquareMeter => Constants.GravitationalAcceleration,
            PressureUnit.TonForcePerSquareFoot_US => 95760.517960678,
            PressureUnit.TonForcePerSquareInch_US => 13789514.586338,
            PressureUnit.TonForcePerSquareFoot_UK => 107251.78011595,
            PressureUnit.TonForcePerSquareInch_UK => 15444256.336697,
            PressureUnit.KipForcePerSquareInch => 6894757.2931783,
            PressureUnit.PoundForcePerSquareFoot => 47.8802589804,
            PressureUnit.PoundForcePerSquareInch => 6894.7572931783,
            PressureUnit.PoundalPerSquareFoot => 1.4881639436,
            PressureUnit.KiloPoundPerSquareInch => 6894757.2931783,
            PressureUnit.PoundPerSquareInch => 6894.7572931783,
            PressureUnit.Torr => 133.3223684211,
            PressureUnit.MilliMeterMercury_0C => 133.322,
            PressureUnit.CentiMeterMercury_0C => 1333.22,
            PressureUnit.InchMercury_32F => 3386.38,
            PressureUnit.InchMercury_60F => 3376.85,
            PressureUnit.MilliMeterWater_4C => 9.80638,
            PressureUnit.CentiMeterWater_4C => 98.0638,
            PressureUnit.InchWater_4C => 249.082,
            PressureUnit.FootWater_4C => 2988.98,
            PressureUnit.InchWater_60F => 248.843,
            PressureUnit.FootWater_60F => 2986.116,
            _ => throw new ArgumentException($"{unit} is not supported")
        };
    }
}