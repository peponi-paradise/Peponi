namespace Peponi.Math.UnitConversion;

internal static class Temperature
{
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
        return convertFrom switch
        {
            TemperatureUnit.Kelvin => convertTo switch
            {
                TemperatureUnit.Kelvin => Compute(value, FromKelvin, ToKelvin),
                TemperatureUnit.Celsius => Compute(value, FromKelvin, ToCelsius),
                TemperatureUnit.Fahrenheit => Compute(value, FromKelvin, ToFahrenheit),
                TemperatureUnit.Rankine => Compute(value, FromKelvin, ToRankine),
                TemperatureUnit.Reaumur => Compute(value, FromKelvin, ToReaumur),
                TemperatureUnit.TriplePointOfWater => Compute(value, FromKelvin, ToTriplePointOfWater),
                _ => throw new ArgumentException($"{convertTo} is not configured")
            },
            TemperatureUnit.Celsius => convertTo switch
            {
                TemperatureUnit.Kelvin => Compute(value, FromCelsius, ToKelvin),
                TemperatureUnit.Celsius => Compute(value, FromCelsius, ToCelsius),
                TemperatureUnit.Fahrenheit => Compute(value, FromCelsius, ToFahrenheit),
                TemperatureUnit.Rankine => Compute(value, FromCelsius, ToRankine),
                TemperatureUnit.Reaumur => Compute(value, FromCelsius, ToReaumur),
                TemperatureUnit.TriplePointOfWater => Compute(value, FromCelsius, ToTriplePointOfWater),
                _ => throw new ArgumentException($"{convertTo} is not configured")
            },
            TemperatureUnit.Fahrenheit => convertTo switch
            {
                TemperatureUnit.Kelvin => Compute(value, FromFahrenheit, ToKelvin),
                TemperatureUnit.Celsius => Compute(value, FromFahrenheit, ToCelsius),
                TemperatureUnit.Fahrenheit => Compute(value, FromFahrenheit, ToFahrenheit),
                TemperatureUnit.Rankine => Compute(value, FromFahrenheit, ToRankine),
                TemperatureUnit.Reaumur => Compute(value, FromFahrenheit, ToReaumur),
                TemperatureUnit.TriplePointOfWater => Compute(value, FromFahrenheit, ToTriplePointOfWater),
                _ => throw new ArgumentException($"{convertTo} is not configured")
            },
            TemperatureUnit.Rankine => convertTo switch
            {
                TemperatureUnit.Kelvin => Compute(value, FromRankine, ToKelvin),
                TemperatureUnit.Celsius => Compute(value, FromRankine, ToCelsius),
                TemperatureUnit.Fahrenheit => Compute(value, FromRankine, ToFahrenheit),
                TemperatureUnit.Rankine => Compute(value, FromRankine, ToRankine),
                TemperatureUnit.Reaumur => Compute(value, FromRankine, ToReaumur),
                TemperatureUnit.TriplePointOfWater => Compute(value, FromRankine, ToTriplePointOfWater),
                _ => throw new ArgumentException($"{convertTo} is not configured")
            },
            TemperatureUnit.Reaumur => convertTo switch
            {
                TemperatureUnit.Kelvin => Compute(value, FromReaumur, ToKelvin),
                TemperatureUnit.Celsius => Compute(value, FromReaumur, ToCelsius),
                TemperatureUnit.Fahrenheit => Compute(value, FromReaumur, ToFahrenheit),
                TemperatureUnit.Rankine => Compute(value, FromReaumur, ToRankine),
                TemperatureUnit.Reaumur => Compute(value, FromReaumur, ToReaumur),
                TemperatureUnit.TriplePointOfWater => Compute(value, FromReaumur, ToTriplePointOfWater),
                _ => throw new ArgumentException($"{convertTo} is not configured")
            },
            TemperatureUnit.TriplePointOfWater => convertTo switch
            {
                TemperatureUnit.Kelvin => Compute(value, FromTriplePointOfWater, ToKelvin),
                TemperatureUnit.Celsius => Compute(value, FromTriplePointOfWater, ToCelsius),
                TemperatureUnit.Fahrenheit => Compute(value, FromTriplePointOfWater, ToFahrenheit),
                TemperatureUnit.Rankine => Compute(value, FromTriplePointOfWater, ToRankine),
                TemperatureUnit.Reaumur => Compute(value, FromTriplePointOfWater, ToReaumur),
                TemperatureUnit.TriplePointOfWater => Compute(value, FromTriplePointOfWater, ToTriplePointOfWater),
                _ => throw new ArgumentException($"{convertTo} is not configured")
            },
            _ => throw new ArgumentException($"{convertFrom} is not configured")
        };
    }

    private static T Compute<T>(T value, Func<double, double> funcFrom, Func<double, double> funcTo)
    {
        return (T)Convert.ChangeType(funcTo(funcFrom((double)Convert.ChangeType(value!, typeof(double)))), typeof(T));
    }
}