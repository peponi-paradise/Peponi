namespace Peponi.Maths.UnitConversion;

internal static partial class Temperature
{
    private enum ConvertDirection
    {
        From,
        To
    }

    internal static T ConvertTo<T>(T value, TemperatureUnit convertFrom, TemperatureUnit convertTo) where T : struct
    {
        return Compute(value, GetFunc(ConvertDirection.From, convertFrom), GetFunc(ConvertDirection.To, convertTo));
    }

    private static T Compute<T>(T value, Func<double, double> funcFrom, Func<double, double> funcTo)
    {
        return (T)Convert.ChangeType(funcTo(funcFrom(Convert.ToDouble(value!))), typeof(T));
    }

    private static Func<double, double> GetFunc(ConvertDirection direction, TemperatureUnit unit)
    {
        return direction switch
        {
            ConvertDirection.From => unit switch
            {
                TemperatureUnit.Kelvin => FromKelvin,
                TemperatureUnit.Celsius => FromCelsius,
                TemperatureUnit.Fahrenheit => FromFahrenheit,
                TemperatureUnit.Rankine => FromRankine,
                TemperatureUnit.Reaumur => FromReaumur,
                TemperatureUnit.TriplePointOfWater => FromTriplePointOfWater,
                _ => throw new ArgumentException($"{unit} is not supported")
            },
            ConvertDirection.To => unit switch
            {
                TemperatureUnit.Kelvin => ToKelvin,
                TemperatureUnit.Celsius => ToCelsius,
                TemperatureUnit.Fahrenheit => ToFahrenheit,
                TemperatureUnit.Rankine => ToRankine,
                TemperatureUnit.Reaumur => ToReaumur,
                TemperatureUnit.TriplePointOfWater => ToTriplePointOfWater,
                _ => throw new ArgumentException($"{unit} is not supported")
            },
            _ => throw new ArgumentException($"{direction} is not supported")
        };
    }
}