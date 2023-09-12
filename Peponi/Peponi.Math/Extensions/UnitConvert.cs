using Peponi.Math.UnitConversion;

namespace Peponi.Math.Extensions;

public static class UnitConvertExtensions
{
    public static T Convert<T>(this T value, AreaUnit convertFrom, AreaUnit convertTo) where T : struct
    {
        return Area.ConvertTo(value, convertFrom, convertTo);
    }

    public static T Convert<T>(this T value, LengthUnit convertFrom, LengthUnit convertTo) where T : struct
    {
        return Length.ConvertTo(value, convertFrom, convertTo);
    }

    public static T Convert<T>(this T value, PressureUnit convertFrom, PressureUnit convertTo) where T : struct
    {
        return Pressure.ConvertTo(value, convertFrom, convertTo);
    }

    public static T Convert<T>(this T value, TemperatureUnit convertFrom, TemperatureUnit convertTo) where T : struct
    {
        return Temperature.ConvertTo(value, convertFrom, convertTo);
    }

    public static T Convert<T>(this T value, PrefixUnit convertFrom, PrefixUnit convertTo) where T : struct
    {
        return Prefix.ConvertTo(value, convertFrom, convertTo);
    }
}