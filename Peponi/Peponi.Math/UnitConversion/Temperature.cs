namespace Peponi.Math.UnitConversion;

public enum TemperatureUnit
{
    Kelvin,
    Celsius,
    Fahrenheit,
}

public static class Temperature
{
    public static T ConvertTo<T>(T value, TemperatureUnit current, TemperatureUnit converting) where T : struct
    {
        return current switch
        {
            TemperatureUnit.Kelvin => converting switch
            {
                TemperatureUnit.Celsius => K_To_Celsius(value),
                TemperatureUnit.Fahrenheit => K_To_Fahrenheit(value),
                _ => throw new ArgumentException($"{converting} is not configured")
            },
            TemperatureUnit.Celsius => converting switch
            {
                TemperatureUnit.Kelvin => Celsius_To_K(value),
                TemperatureUnit.Fahrenheit => Celsius_To_Fahrenheit(value),
                _ => throw new ArgumentException($"{converting} is not configured")
            },
            TemperatureUnit.Fahrenheit => converting switch
            {
                TemperatureUnit.Kelvin => Fahrenheit_To_K(value),
                TemperatureUnit.Celsius => Fahrenheit_To_Celsius(value),
                _ => throw new ArgumentException($"{converting} is not configured")
            },
            _ => throw new ArgumentException($"{converting} is not configured")
        };
    }

    private static T K_To_Celsius<T>(T value) => (T)Convert.ChangeType((Convert.ToDouble(value) - 273.15), typeof(T));

    private static T K_To_Fahrenheit<T>(T value) => (T)Convert.ChangeType((Convert.ToDouble(K_To_Celsius(value)) * 9 / 5 + 32), typeof(T));

    private static T Celsius_To_K<T>(T value) => (T)Convert.ChangeType((Convert.ToDouble(value) + 273.15), typeof(T));

    private static T Celsius_To_Fahrenheit<T>(T value) => (T)Convert.ChangeType((Convert.ToDouble(value) * 9 / 5 + 32), typeof(T));

    private static T Fahrenheit_To_Celsius<T>(T value) => (T)Convert.ChangeType((Convert.ToDouble(value) - 32) * 5 / 9, typeof(T));

    private static T Fahrenheit_To_K<T>(T value) => (T)Convert.ChangeType(Convert.ToDouble(Fahrenheit_To_Celsius(value)) + 273.15, typeof(T));
}