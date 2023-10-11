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
            PressureUnit.Pascal => 1,
            PressureUnit.HectoPascal => 100,
            PressureUnit.KiloPascal => 1000,
            PressureUnit.MegaPascal => 1000000,
            PressureUnit.NewtonPerSquareMillimeter => 1000000,
            PressureUnit.NewtonPerSquareCentimeter => 10000,
            PressureUnit.NewtonPerSquareMeter => 1,
            PressureUnit.KiloNewtonPerSquareMeter => 1000,
            PressureUnit.MilliBar => 100,
            PressureUnit.Bar => 100000,
            PressureUnit.DynePerSquareCentimeter => 0.1,
            PressureUnit.KiloGramForcePerSquareMillimeter => Constants.GravitationalAcceleration * 1E6,
            PressureUnit.KiloGramForcePerSquareCentimeter => Constants.GravitationalAcceleration * 1E4,
            PressureUnit.KiloGramForcePerSquareMeter => Constants.GravitationalAcceleration,
            PressureUnit.KipForcePerSquareInch => 6894757.2931783,
            PressureUnit.PoundForcePerSquareFoot => 47.8802589804,
            PressureUnit.PoundForcePerSquareInch => 6894.7572931783,
            PressureUnit.PoundalPerSquareFoot => 1.4881639436,
            PressureUnit.KiloPoundPerSquareInch => 6894757.2931783,
            PressureUnit.PoundPerSquareInch => 6894.7572931783,
            PressureUnit.Torr => 133.3223684211,
            PressureUnit.MilliMeterMercury0C => 133.322,
            PressureUnit.CentiMeterMercury0C => 1333.22,
            PressureUnit.InchMercury32F => 3386.38,
            PressureUnit.InchMercury60F => 3376.85,
            PressureUnit.MilliMeterWater4C => 9.80638,
            PressureUnit.CentiMeterWater4C => 98.0638,
            PressureUnit.InchWater4C => 249.082,
            PressureUnit.FootWater4C => 2988.98,
            PressureUnit.InchWater60F => 248.843,
            PressureUnit.FootWater60F => 2986.116,
            _ => throw new ArgumentException($"{unit} is not supported")
        };
    }
}