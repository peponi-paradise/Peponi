namespace Peponi.Maths.UnitConversion;

internal static class Temperature
{
    private static Dictionary<TemperatureUnit, Func<double, double>> _funcFrom;
    private static Dictionary<TemperatureUnit, Func<double, double>> _funcTo;

    static Temperature()
    {
        _funcFrom = new()
        {
            { TemperatureUnit.Kelvin, (x) => x },
            { TemperatureUnit.Celsius, (x) => x + 273.15 },
            { TemperatureUnit.Fahrenheit, (x) => (x + 459.67) / 1.8 },
            { TemperatureUnit.Rankine, (x) => x / 1.8 },
            { TemperatureUnit.Reaumur, (x) => x * 1.25 + 273.15 },
            { TemperatureUnit.TriplePointOfWater, (x) => x * 273.16 }
        };

        _funcTo = new()
        {
            { TemperatureUnit.Kelvin, (x) => x },
            { TemperatureUnit.Celsius, (x) => x - 273.15 },
            { TemperatureUnit.Fahrenheit, (x) => x * 1.8 - 459.67 },
            { TemperatureUnit.Rankine, (x) => x * 1.8 },
            { TemperatureUnit.Reaumur, (x) => (x - 273.15) * 0.8 },
            { TemperatureUnit.TriplePointOfWater, (x) => x / 273.16 }
        };
    }

    internal static T ConvertTo<T>(T value, TemperatureUnit convertFrom, TemperatureUnit convertTo) where T : struct
    {
        return (T)Convert.ChangeType(_funcTo[convertTo](_funcFrom[convertFrom](Convert.ToDouble(value!))), typeof(T));
    }
}