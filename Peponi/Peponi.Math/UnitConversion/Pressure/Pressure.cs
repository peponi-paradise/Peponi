namespace Peponi.Math.UnitConversion;

internal static class Pressure
{
    private const double at = 98066.500000003;
    private const double atm = 101325;
    private const double h = 100;
    private const double k = 1000;
    private const double M = 1000000;
    private const double NPSMM = M;
    private const double NPSC = 10000;
    private const double NPSM = 1;
    private const double kNPSM = k;
    private const double mb = 100;
    private const double b = 100000;
    private const double dPSC = 0.1;
    private const double kgfPSMM = 9806650;
    private const double kgfPSC = 98066.5;
    private const double kgfPSM = 9.80665;
    private const double kipfPSI = 6894757.2931783;
    private const double lbfPSF = 47.8802589804;
    private const double lbfPSI = 6894.7572931783;
    private const double pdlPSF = 1.4881639436;
    private const double ksi = 6894757.2931783;
    private const double psi = 6894.7572931783;
    private const double Torr = 133.3223684211;
    private const double mmHg = 133.322;
    private const double cmHg = 1333.22;
    private const double inHg32F = 3386.38;
    private const double inHg60F = 3376.85;
    private const double mmAq = 9.80638;
    private const double cmAq = 98.0638;
    private const double inAq4C = 249.082;
    private const double ftAq4C = 2988.98;
    private const double inAq60F = 248.843;
    private const double ftAq60F = 2986.116;

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