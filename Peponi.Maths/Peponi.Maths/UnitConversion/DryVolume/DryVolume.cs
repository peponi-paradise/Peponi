namespace Peponi.Maths.UnitConversion;

internal static partial class DryVolume
{
    internal static T ConvertTo<T>(T value, DryVolumeUnit convertFrom, DryVolumeUnit convertTo) where T : struct
    {
        var multiplierFrom = GetMultiplier(convertFrom);
        var multiplierTo = GetMultiplier(convertTo);
        return (T)Convert.ChangeType((Convert.ToDouble(value) * multiplierFrom / multiplierTo), typeof(T));
    }

    private static double GetMultiplier(DryVolumeUnit unit)
    {
        return unit switch
        {
            DryVolumeUnit.Liter => 1,
            DryVolumeUnit.Pint => 0.5506104714,
            DryVolumeUnit.Quart => 1.1012209428,
            DryVolumeUnit.Barrel => 115.6271236039,
            DryVolumeUnit.Peck_US => 8.8097675424,
            DryVolumeUnit.Peck_UK => 9.09218,
            DryVolumeUnit.Bushel_US => 35.2390701696,
            DryVolumeUnit.Bushel_UK => 36.36872,
            _ => throw new ArgumentException($"{unit} is not supported")
        };
    }
}