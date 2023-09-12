namespace Peponi.Math.UnitConversion;

internal static partial class Area
{
    internal static T ConvertTo<T>(T value, AreaUnit convertFrom, AreaUnit convertTo) where T : struct
    {
        var multiplierFrom = GetMultiplier(convertFrom);
        var multiplierTo = GetMultiplier(convertTo);
        return (T)Convert.ChangeType((Convert.ToDouble(value) * multiplierFrom / multiplierTo), typeof(T));
    }

    private static double GetMultiplier(AreaUnit unit)
    {
        return unit switch
        {
            AreaUnit.NanoMeter => NanoMeter,
            AreaUnit.MicroMeter => MicroMeter,
            AreaUnit.MilliMeter => MilliMeter,
            AreaUnit.CentiMeter => CentiMeter,
            AreaUnit.DeciMeter => DeciMeter,
            AreaUnit.Meter => Meter,
            AreaUnit.DekaMeter => DekaMeter,
            AreaUnit.HectoMeter => HectoMeter,
            AreaUnit.KiloMeter => KiloMeter,
            AreaUnit.Hectare => Hectare,
            AreaUnit.Acre => Acre,
            AreaUnit.AcreUS => AcreUS,
            AreaUnit.Are => Are,
            AreaUnit.Mile => Mile,
            AreaUnit.MileUS => MileUS,
            AreaUnit.Yard => Yard,
            AreaUnit.Foot => Foot,
            AreaUnit.FootUS => FootUS,
            AreaUnit.Inch => Inch,
            AreaUnit.CircularInch => CircularInch,
            AreaUnit.Barn => Barn,
            AreaUnit.Township => Township,
            AreaUnit.Section => Section,
            AreaUnit.Homestead => Homestead,
            AreaUnit.Plaza => Plaza,
            AreaUnit.Chain => Chain,
            AreaUnit.Rood => Rood,
            AreaUnit.Rod => Rod,
            AreaUnit.RodUS => RodUS,
            AreaUnit.Perch => Perch,
            AreaUnit.Pole => Pole,
            AreaUnit.Mil => Mil,
            AreaUnit.CircularMil => CircularMil,
            AreaUnit.Sabin => Sabin,
            AreaUnit.Arpent => Arpent,
            AreaUnit.Cuerda => Cuerda,
            AreaUnit.VarasCastellanasCuad => VarasCastellanasCuad,
            AreaUnit.VarasConuquerasCuad => VarasConuquerasCuad,
            AreaUnit.ElectronCrossSection => ElectronCrossSection,
            _ => throw new ArgumentException($"{unit} is not supported")
        };
    }
}