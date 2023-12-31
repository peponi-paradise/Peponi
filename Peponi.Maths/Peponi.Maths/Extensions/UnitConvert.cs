﻿using Peponi.Maths.UnitConversion;

namespace Peponi.Maths.Extensions;

public static class UnitConvertExtensions
{
    public static T Convert<T>(this T value, AngleUnit convertFrom, AngleUnit convertTo) where T : struct
    {
        return Angle.ConvertTo(value, convertFrom, convertTo);
    }

    public static T Convert<T>(this T value, AngularSpeedUnit convertFrom, AngularSpeedUnit convertTo) where T : struct
    {
        return AngularSpeed.ConvertTo(value, convertFrom, convertTo);
    }

    public static T Convert<T>(this T value, AreaUnit convertFrom, AreaUnit convertTo) where T : struct
    {
        return Area.ConvertTo(value, convertFrom, convertTo);
    }

    public static T Convert<T>(this T value, DryVolumeUnit convertFrom, DryVolumeUnit convertTo) where T : struct
    {
        return DryVolume.ConvertTo(value, convertFrom, convertTo);
    }

    public static T Convert<T>(this T value, EnergyUnit convertFrom, EnergyUnit convertTo) where T : struct
    {
        return Energy.ConvertTo(value, convertFrom, convertTo);
    }

    public static T Convert<T>(this T value, ForceUnit convertFrom, ForceUnit convertTo) where T : struct
    {
        return Force.ConvertTo(value, convertFrom, convertTo);
    }

    public static T Convert<T>(this T value, LengthUnit convertFrom, LengthUnit convertTo) where T : struct
    {
        return Length.ConvertTo(value, convertFrom, convertTo);
    }

    public static T Convert<T>(this T value, PrefixUnit convertFrom, PrefixUnit convertTo) where T : struct
    {
        return Prefix.ConvertTo(value, convertFrom, convertTo);
    }

    public static T Convert<T>(this T value, PressureUnit convertFrom, PressureUnit convertTo) where T : struct
    {
        return Pressure.ConvertTo(value, convertFrom, convertTo);
    }

    public static T Convert<T>(this T value, SpeedUnit convertFrom, SpeedUnit convertTo) where T : struct
    {
        return Speed.ConvertTo(value, convertFrom, convertTo);
    }

    public static T Convert<T>(this T value, TemperatureUnit convertFrom, TemperatureUnit convertTo) where T : struct
    {
        return Temperature.ConvertTo(value, convertFrom, convertTo);
    }

    public static T Convert<T>(this T value, VolumeUnit convertFrom, VolumeUnit convertTo) where T : struct
    {
        return Volume.ConvertTo(value, convertFrom, convertTo);
    }

    public static T Convert<T>(this T value, WeightUnit convertFrom, WeightUnit convertTo) where T : struct
    {
        return Weight.ConvertTo(value, convertFrom, convertTo);
    }
}