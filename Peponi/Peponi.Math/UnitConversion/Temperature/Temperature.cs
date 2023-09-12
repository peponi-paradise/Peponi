namespace Peponi.Math.UnitConversion;

internal static class Temperature
{
    private enum ConvertDirection
    {
        From,
        To
    }

    // All values to Kelvin

    private static Func<double, double> FromKelvin = (x) => x;
    private static Func<double, double> FromCelsius = (x) => x + 273.15;
    private static Func<double, double> FromFahrenheit = (x) => (x + 459.67) / 1.8;
    private static Func<double, double> FromRankine = (x) => x / 1.8;
    private static Func<double, double> FromReaumur = (x) => x * 1.25 + 273.15;
    private static Func<double, double> FromTriplePointOfWater = (x) => x * 273.16;

    // Compute from Kelvin

    private static Func<double, double> ToKelvin = (x) => x;
    private static Func<double, double> ToCelsius = (x) => x - 273.15;
    private static Func<double, double> ToFahrenheit = (x) => x * 1.8 - 459.67;
    private static Func<double, double> ToRankine = (x) => x * 1.8;
    private static Func<double, double> ToReaumur = (x) => (x - 273.15) * 0.8;
    private static Func<double, double> ToTriplePointOfWater = (x) => x / 273.16;

    internal static T ConvertTo<T>(T value, TemperatureUnit convertFrom, TemperatureUnit convertTo) where T : struct
    {
        return Compute(value, GetFunc(ConvertDirection.From, convertFrom), GetFunc(ConvertDirection.To, convertTo));
    }

    private static T Compute<T>(T value, Func<double, double> funcFrom, Func<double, double> funcTo)
    {
        return (T)Convert.ChangeType(funcTo(funcFrom((double)Convert.ChangeType(value!, typeof(double)))), typeof(T));
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