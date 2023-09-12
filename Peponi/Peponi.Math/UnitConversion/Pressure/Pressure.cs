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
            PressureUnit.at => 98066.500000003,
            PressureUnit.atm => 101325,
            PressureUnit.Pa => 1,
            PressureUnit.hPa => 100,
            PressureUnit.kPa => 1000,
            PressureUnit.MPa => 1000000,
            PressureUnit.NPerSquareMillimeter => 1000000,
            PressureUnit.NPerSquareCentimeter => 10000,
            PressureUnit.NPerSquareMeter => 1,
            PressureUnit.kNPerSquareMeter => 1000,
            PressureUnit.mbar => 100,
            PressureUnit.bar => 100000,
            PressureUnit.dynPerSquareCentimeter => 0.1,
            PressureUnit.kgfPerSquareMillimeter => 9806650,
            PressureUnit.kgfPerSquareCentimeter => 98066.5,
            PressureUnit.kgfPerSquareMeter => 9.80665,
            PressureUnit.kipfPerSquareInch => 6894757.2931783,
            PressureUnit.lbfPerSquareFoot => 47.8802589804,
            PressureUnit.lbfPerSquareInch => 6894.7572931783,
            PressureUnit.pdlPerSquareFoot => 1.4881639436,
            PressureUnit.ksi => 6894757.2931783,
            PressureUnit.psi => 6894.7572931783,
            PressureUnit.Torr => 133.3223684211,
            PressureUnit.mmHg0C => 133.322,
            PressureUnit.cmHg0C => 1333.22,
            PressureUnit.inHg32F => 3386.38,
            PressureUnit.inHg60F => 3376.85,
            PressureUnit.mmAq4C => 9.80638,
            PressureUnit.cmAq4C => 98.0638,
            PressureUnit.inAq4C => 249.082,
            PressureUnit.ftAq4C => 2988.98,
            PressureUnit.inAq60F => 248.843,
            PressureUnit.ftAq60F => 2986.116,
            _ => throw new ArgumentException($"{unit} is not supported")
        };
    }
}