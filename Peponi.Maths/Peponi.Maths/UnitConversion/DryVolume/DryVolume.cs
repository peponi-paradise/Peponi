namespace Peponi.Maths.UnitConversion;

internal static class DryVolume
{
    private static Dictionary<DryVolumeUnit, double> _multipliers;

    static DryVolume()
    {
        _multipliers = new()
        {
            { DryVolumeUnit.Liter, 1 },
            { DryVolumeUnit.Pint, 0.5506104714 },
            { DryVolumeUnit.Quart, 1.1012209428 },
            { DryVolumeUnit.Barrel, 115.6271236039 },
            { DryVolumeUnit.Peck_US, 8.8097675424 },
            { DryVolumeUnit.Peck_UK, 9.09218 },
            { DryVolumeUnit.Bushel_US, 35.2390701696 },
            { DryVolumeUnit.Bushel_UK, 36.36872 }
        };
    }

    internal static T ConvertTo<T>(T value, DryVolumeUnit convertFrom, DryVolumeUnit convertTo) where T : struct
    {
        return (T)Convert.ChangeType((Convert.ToDouble(value) * _multipliers[convertFrom] / _multipliers[convertTo]), typeof(T));
    }
}