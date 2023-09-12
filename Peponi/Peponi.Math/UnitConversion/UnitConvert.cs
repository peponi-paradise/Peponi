namespace Peponi.Math.UnitConversion;

public static class UnitConvert
{
    public static T Convert<T>(T value, AreaUnit convertFrom, AreaUnit convertTo) where T : struct
    {
        return Area.ConvertTo(value, convertFrom, convertTo);
    }

    public static T Convert<T>(T value, LengthUnit convertFrom, LengthUnit convertTo) where T : struct
    {
        return Length.ConvertTo(value, convertFrom, convertTo);
    }

    public static T Convert<T>(T value, PressureUnit convertFrom, PressureUnit convertTo) where T : struct
    {
        return Pressure.ConvertTo(value, convertFrom, convertTo);
    }

    public static T Convert<T>(T value, TemperatureUnit convertFrom, TemperatureUnit convertTo) where T : struct
    {
        return Temperature.ConvertTo(value, convertFrom, convertTo);
    }
}