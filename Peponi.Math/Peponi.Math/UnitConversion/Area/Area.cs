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
            AreaUnit.SquareNanoMeter => 1.0E-18,
            AreaUnit.SquareMicroMeter => 1.0E-12,
            AreaUnit.SquareMilliMeter => 1.0E-6,
            AreaUnit.SquareCentiMeter => 0.0001,
            AreaUnit.SquareDeciMeter => 0.01,
            AreaUnit.SquareMeter => 1,
            AreaUnit.SquareDekaMeter => 100,
            AreaUnit.SquareHectoMeter => 10000,
            AreaUnit.SquareKiloMeter => 1000000,
            AreaUnit.Hectare => 10000,
            AreaUnit.Acre => 4046.8564224,
            AreaUnit.AcreUS => 4046.8726098743,
            AreaUnit.Are => 100,
            AreaUnit.SquareMile => 2589988.110336,
            AreaUnit.SquareMileUS => 2589998.4703195,
            AreaUnit.SquareYard => 0.83612736,
            AreaUnit.SquareFoot => 0.09290304,
            AreaUnit.SquareFootUS => 0.0929034116,
            AreaUnit.SquareInch => 0.00064516,
            AreaUnit.CircularInch => 0.0005067075,
            AreaUnit.Barn => 1.0E-28,
            AreaUnit.Township => 93239571.972096,
            AreaUnit.Section => 2589988.110336,
            AreaUnit.Homestead => 647497.027584,
            AreaUnit.Plaza => 6400,
            AreaUnit.SquareChain => 404.68564224,
            AreaUnit.Rood => 1011.7141056,
            AreaUnit.SquareRod => 25.29285264,
            AreaUnit.SquareRodUS => 25.2929538117,
            AreaUnit.SquarePerch => 25.29285264,
            AreaUnit.SquarePole => 25.29285264,
            AreaUnit.SquareMil => 6.4516E-10,
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