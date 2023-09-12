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
            AreaUnit.NanoMeter => 1.0E-18,
            AreaUnit.MicroMeter => 1.0E-12,
            AreaUnit.MilliMeter => 1.0E-6,
            AreaUnit.CentiMeter => 0.0001,
            AreaUnit.DeciMeter => 0.01,
            AreaUnit.Meter => 1,
            AreaUnit.DekaMeter => 100,
            AreaUnit.HectoMeter => 10000,
            AreaUnit.KiloMeter => 1000000,
            AreaUnit.Hectare => 10000,
            AreaUnit.Acre => 4046.8564224,
            AreaUnit.AcreUS => 4046.8726098743,
            AreaUnit.Are => 100,
            AreaUnit.Mile => 2589988.110336,
            AreaUnit.MileUS => 2589998.4703195,
            AreaUnit.Yard => 0.83612736,
            AreaUnit.Foot => 0.09290304,
            AreaUnit.FootUS => 0.0929034116,
            AreaUnit.Inch => 0.00064516,
            AreaUnit.CircularInch => 0.0005067075,
            AreaUnit.Barn => 1.0E-28,
            AreaUnit.Township => 93239571.972096,
            AreaUnit.Section => 2589988.110336,
            AreaUnit.Homestead => 647497.027584,
            AreaUnit.Plaza => 6400,
            AreaUnit.Chain => 404.68564224,
            AreaUnit.Rood => 1011.7141056,
            AreaUnit.Rod => 25.29285264,
            AreaUnit.RodUS => 25.2929538117,
            AreaUnit.Perch => 25.29285264,
            AreaUnit.Pole => 25.29285264,
            AreaUnit.Mil => 6.4516E-10,
            AreaUnit.CircularMil => 5.067074790975E-10,
            AreaUnit.Sabin => 0.09290304,
            AreaUnit.Arpent => 3418.8929236669,
            AreaUnit.Cuerda => 3930.395625,
            AreaUnit.VarasCastellanasCuad => 0.698737,
            AreaUnit.VarasConuquerasCuad => 6.288633,
            AreaUnit.ElectronCrossSection => 6.6524615999999E-29,
            _ => throw new ArgumentException($"{unit} is not supported")
        };
    }
}