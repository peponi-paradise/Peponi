namespace Peponi.Maths.UnitConversion;

/// <summary>
/// Convert value to selected unit
/// <br/>
/// Convert value to double internally
/// <br/>
/// <see href="주소 넣어야 함"/>
/// </summary>
public static class UnitConvert
{
    /// <summary>
    /// Converting unit
    /// <br/>
    /// Convert value to double internally
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="value"></param>
    /// <param name="convertFrom"></param>
    /// <param name="convertTo"></param>
    /// <returns></returns>
    public static T Convert<T>(T value, AngleUnit convertFrom, AngleUnit convertTo) where T : struct
    {
        return Angle.ConvertTo(value, convertFrom, convertTo);
    }

    /// <summary>
    /// Converting unit
    /// <br/>
    /// Convert value to double internally
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="value"></param>
    /// <param name="convertFrom"></param>
    /// <param name="convertTo"></param>
    /// <returns></returns>
    public static T Convert<T>(T value, AngularSpeedUnit convertFrom, AngularSpeedUnit convertTo) where T : struct
    {
        return AngularSpeed.ConvertTo(value, convertFrom, convertTo);
    }

    /// <summary>
    /// Converting unit
    /// <br/>
    /// Convert value to double internally
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="value"></param>
    /// <param name="convertFrom"></param>
    /// <param name="convertTo"></param>
    /// <returns></returns>
    public static T Convert<T>(T value, AreaUnit convertFrom, AreaUnit convertTo) where T : struct
    {
        return Area.ConvertTo(value, convertFrom, convertTo);
    }

    /// <summary>
    /// Converting unit
    /// <br/>
    /// Convert value to double internally
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="value"></param>
    /// <param name="convertFrom"></param>
    /// <param name="convertTo"></param>
    /// <returns></returns>
    public static T Convert<T>(T value, DryVolumeUnit convertFrom, DryVolumeUnit convertTo) where T : struct
    {
        return DryVolume.ConvertTo(value, convertFrom, convertTo);
    }

    /// <summary>
    /// Converting unit
    /// <br/>
    /// Convert value to double internally
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="value"></param>
    /// <param name="convertFrom"></param>
    /// <param name="convertTo"></param>
    /// <returns></returns>
    public static T Convert<T>(T value, EnergyUnit convertFrom, EnergyUnit convertTo) where T : struct
    {
        return Energy.ConvertTo(value, convertFrom, convertTo);
    }

    /// <summary>
    /// Converting unit
    /// <br/>
    /// Convert value to double internally
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="value"></param>
    /// <param name="convertFrom"></param>
    /// <param name="convertTo"></param>
    /// <returns></returns>
    public static T Convert<T>(T value, ForceUnit convertFrom, ForceUnit convertTo) where T : struct
    {
        return Force.ConvertTo(value, convertFrom, convertTo);
    }

    /// <summary>
    /// Converting unit
    /// <br/>
    /// Convert value to double internally
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="value"></param>
    /// <param name="convertFrom"></param>
    /// <param name="convertTo"></param>
    /// <returns></returns>
    public static T Convert<T>(T value, LengthUnit convertFrom, LengthUnit convertTo) where T : struct
    {
        return Length.ConvertTo(value, convertFrom, convertTo);
    }

    /// <summary>
    /// Converting unit
    /// <br/>
    /// Convert value to double internally
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="value"></param>
    /// <param name="convertFrom"></param>
    /// <param name="convertTo"></param>
    /// <returns></returns>
    public static T Convert<T>(T value, PrefixUnit convertFrom, PrefixUnit convertTo) where T : struct
    {
        return Prefix.ConvertTo(value, convertFrom, convertTo);
    }

    /// <summary>
    /// Converting unit
    /// <br/>
    /// Convert value to double internally
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="value"></param>
    /// <param name="convertFrom"></param>
    /// <param name="convertTo"></param>
    /// <returns></returns>
    public static T Convert<T>(T value, PressureUnit convertFrom, PressureUnit convertTo) where T : struct
    {
        return Pressure.ConvertTo(value, convertFrom, convertTo);
    }

    /// <summary>
    /// Converting unit
    /// <br/>
    /// Convert value to double internally
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="value"></param>
    /// <param name="convertFrom"></param>
    /// <param name="convertTo"></param>
    /// <returns></returns>
    public static T Convert<T>(T value, SpeedUnit convertFrom, SpeedUnit convertTo) where T : struct
    {
        return Speed.ConvertTo(value, convertFrom, convertTo);
    }

    /// <summary>
    /// Converting unit
    /// <br/>
    /// Convert value to double internally
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="value"></param>
    /// <param name="convertFrom"></param>
    /// <param name="convertTo"></param>
    /// <returns></returns>
    public static T Convert<T>(T value, TemperatureUnit convertFrom, TemperatureUnit convertTo) where T : struct
    {
        return Temperature.ConvertTo(value, convertFrom, convertTo);
    }

    /// <summary>
    /// Converting unit
    /// <br/>
    /// Convert value to double internally
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="value"></param>
    /// <param name="convertFrom"></param>
    /// <param name="convertTo"></param>
    /// <returns></returns>
    public static T Convert<T>(T value, VolumeUnit convertFrom, VolumeUnit convertTo) where T : struct
    {
        return Volume.ConvertTo(value, convertFrom, convertTo);
    }

    /// <summary>
    /// Converting unit
    /// <br/>
    /// Convert value to double internally
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="value"></param>
    /// <param name="convertFrom"></param>
    /// <param name="convertTo"></param>
    /// <returns></returns>
    public static T Convert<T>(T value, WeightUnit convertFrom, WeightUnit convertTo) where T : struct
    {
        return Weight.ConvertTo(value, convertFrom, convertTo);
    }
}