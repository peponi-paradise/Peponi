namespace Peponi.Math.UnitConversion;

public class UnitConvert
{
    public static T ConvertPressure<T>(T value, PressureUnit convertFrom, PressureUnit convertTo) where T : struct
    {
        return Pressure.ConvertTo(value, convertFrom, convertTo);
    }

    public static T ConvertTemperature<T>(T value, TemperatureUnit convertFrom, TemperatureUnit convertTo) where T : struct
    {
        return Temperature.ConvertTo(value, convertFrom, convertTo);
    }
}