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
            PressureUnit.at => at,
            PressureUnit.atm => atm,
            PressureUnit.Pa => 1,
            PressureUnit.hPa => h,
            PressureUnit.kPa => k,
            PressureUnit.MPa => M,
            PressureUnit.NPerSquareMillimeter => NPSMM,
            PressureUnit.NPerSquareCentimeter => NPSC,
            PressureUnit.NPerSquareMeter => NPSM,
            PressureUnit.kNPerSquareMeter => kNPSM,
            PressureUnit.mbar => mb,
            PressureUnit.bar => b,
            PressureUnit.dynPerSquareCentimeter => dPSC,
            PressureUnit.kgfPerSquareMillimeter => kgfPSMM,
            PressureUnit.kgfPerSquareCentimeter => kgfPSC,
            PressureUnit.kgfPerSquareMeter => kgfPSM,
            PressureUnit.kipfPerSquareInch => kipfPSI,
            PressureUnit.lbfPerSquareFoot => lbfPSF,
            PressureUnit.lbfPerSquareInch => lbfPSI,
            PressureUnit.pdlPerSquareFoot => pdlPSF,
            PressureUnit.ksi => ksi,
            PressureUnit.psi => psi,
            PressureUnit.Torr => Torr,
            PressureUnit.mmHg0C => mmHg,
            PressureUnit.cmHg0C => cmHg,
            PressureUnit.inHg32F => inHg32F,
            PressureUnit.inHg60F => inHg60F,
            PressureUnit.mmAq4C => mmAq,
            PressureUnit.cmAq4C => cmAq,
            PressureUnit.inAq4C => inAq4C,
            PressureUnit.ftAq4C => ftAq4C,
            PressureUnit.inAq60F => inAq60F,
            PressureUnit.ftAq60F => ftAq60F,
            _ => throw new ArgumentException($"{unit} is not supported")
        };
    }
}