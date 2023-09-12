namespace Peponi.Math.UnitConversion;

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
            DryVolumeUnit.PeckUS => 8.8097675424,
            DryVolumeUnit.PeckUK => 9.09218,
            DryVolumeUnit.BushelUS => 35.2390701696,
            DryVolumeUnit.BushelUK => 36.36872,
            _ => throw new ArgumentException($"{unit} is not supported")
        };
    }
}