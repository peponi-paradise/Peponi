using Peponi.Math.UnitConversion;

namespace Peponi.Math.Extensions;

public static class UnitConvertExtensions
{
    public static T ConvertPressure<T>(this T value, PressureUnit convertFrom, PressureUnit convertTo) where T : struct
    {
        return Pressure.ConvertTo(value, convertFrom, convertTo);
    }

    public static T ConvertTemperature<T>(this T value, TemperatureUnit convertFrom, TemperatureUnit convertTo) where T : struct
    {
        return Temperature.ConvertTo(value, convertFrom, convertTo);
    }
}