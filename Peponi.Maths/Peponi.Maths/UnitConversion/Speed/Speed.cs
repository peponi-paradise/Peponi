namespace Peponi.Maths.UnitConversion;

internal static class Speed
{
    private static Dictionary<SpeedUnit, double> _multipliers;

    static Speed()
    {
        _multipliers = new()
        {
            { SpeedUnit.MilliMeterPerSecond, 1E-3 },
            { SpeedUnit.MilliMeterPerMinute, 1.666666666666667E-5 },
            { SpeedUnit.MilliMeterPerHour, 2.777777777777778E-7 },
            { SpeedUnit.CentiMeterPerSecond, 1E-2 },
            { SpeedUnit.CentiMeterPerMinute, 1.666666666666667E-4 },
            { SpeedUnit.CentiMeterPerHour, 2.777777777777778E-6 },
            { SpeedUnit.MeterPerSecond, 1 },
            { SpeedUnit.MeterPerMinute, 0.0166666666666667 },
            { SpeedUnit.MeterPerHour, 2.777777777777778E-4 },
            { SpeedUnit.KiloMeterPerSecond, 1E3 },
            { SpeedUnit.KiloMeterPerMinute, 16.66666666666667 },
            { SpeedUnit.KiloMeterPerHour, 0.2777777777777778 },
            { SpeedUnit.FootPerSecond, 0.3048 },
            { SpeedUnit.FootPerMinute, 0.00508 },
            { SpeedUnit.FootPerHour, 8.466666666666667E-5 },
            { SpeedUnit.MilePerSecond, 1609.344 },
            { SpeedUnit.MilePerMinute, 26.8224 },
            { SpeedUnit.MilePerHour, 0.44704 },
            { SpeedUnit.YardPerSecond, 0.9144 },
            { SpeedUnit.YardPerMinute, 0.01524 },
            { SpeedUnit.YardPerHour, 0.000254 },
            { SpeedUnit.Knot, 0.5144444444444457 },
            { SpeedUnit.Knot_UK, 0.5147733333 },
            { SpeedUnit.Mach_ATM20C, 343.6 },
            { SpeedUnit.Mach_SI, 295.0464000003 },
            { SpeedUnit.SpeedOfSoundInPureWater, 1482.6999999998 },
            { SpeedUnit.SpeedOfSoundInSeaWater_10Meter20C, 1521.6 },
            { SpeedUnit.SpeedOfLightInVacuum, 299792458 },
            { SpeedUnit.CosmicVelocity_1st, 7899.9999999999 },
            { SpeedUnit.CosmicVelocity_2nd, 11200 },
            { SpeedUnit.CosmicVelocity_3rd, 16670 },
            { SpeedUnit.EarthVelocity, 29765 }
        };
    }

    internal static T ConvertTo<T>(T value, SpeedUnit convertFrom, SpeedUnit convertTo) where T : struct
    {
        return (T)Convert.ChangeType((Convert.ToDouble(value) * _multipliers[convertFrom] / _multipliers[convertTo]), typeof(T));
    }
}