namespace Peponi.Math.UnitConversion;

public enum SpeedUnit
{
    /// <summary>
    /// <code>
    /// mm / s
    /// </code>
    /// </summary>
    MilliMeterPerSecond,

    /// <summary>
    /// <code>
    /// mm / min
    /// </code>
    /// </summary>
    MilliMeterPerMinute,

    /// <summary>
    /// <code>
    /// mm / h
    /// </code>
    /// </summary>
    MilliMeterPerHour,

    /// <summary>
    /// <code>
    /// cm / s
    /// </code>
    /// </summary>
    CentiMeterPerSecond,

    /// <summary>
    /// <code>
    /// cm / min
    /// </code>
    /// </summary>
    CentiMeterPerMinute,

    /// <summary>
    /// <code>
    /// cm / h
    /// </code>
    /// </summary>
    CentiMeterPerHour,

    /// <summary>
    /// <code>
    /// m / s
    /// </code>
    /// </summary>
    MeterPerSecond,

    /// <summary>
    /// <code>
    /// m / min
    /// </code>
    /// </summary>
    MeterPerMinute,

    /// <summary>
    /// <code>
    /// m / h
    /// </code>
    /// </summary>
    MeterPerHour,

    /// <summary>
    /// <code>
    /// km / s
    /// </code>
    /// </summary>
    KiloMeterPerSecond,

    /// <summary>
    /// <code>
    /// km / min
    /// </code>
    /// </summary>
    KiloMeterPerMinute,

    /// <summary>
    /// <code>
    /// km / h
    /// </code>
    /// </summary>
    KiloMeterPerHour,

    /// <summary>
    /// <code>
    /// ft / s
    /// </code>
    /// </summary>
    FootPerSecond,

    /// <summary>
    /// <code>
    /// ft / min
    /// </code>
    /// </summary>
    FootPerMinute,

    /// <summary>
    /// <code>
    /// ft / h
    /// </code>
    /// </summary>
    FootPerHour,

    /// <summary>
    /// <code>
    /// mi / s
    /// </code>
    /// </summary>
    MilePerSecond,

    /// <summary>
    /// <code>
    /// mi / min
    /// </code>
    /// </summary>
    MilePerMinute,

    /// <summary>
    /// <code>
    /// mi / h
    /// </code>
    /// </summary>
    MilePerHour,

    /// <summary>
    /// <code>
    /// yd / s
    /// </code>
    /// </summary>
    YardPerSecond,

    /// <summary>
    /// <code>
    /// yd / min
    /// </code>
    /// </summary>
    YardPerMinute,

    /// <summary>
    /// <code>
    /// yd / h
    /// </code>
    /// </summary>
    YardPerHour,

    /// <summary>
    /// <code>
    /// kt
    /// kn
    /// </code>
    /// </summary>
    Knot,

    /// <summary>
    /// <code>
    /// kt
    /// kn
    ///
    /// UK
    /// </code>
    /// </summary>
    Knot_UK,

    /// <summary>
    /// <code>
    /// M
    /// Ma
    ///
    /// Mach number at 20°C, 1atm
    /// </code>
    /// </summary>
    Mach_ATM20C,

    /// <summary>
    /// <code>
    /// M
    /// Ma
    ///
    /// SI standard Mach number
    /// </code>
    /// </summary>
    Mach_SI,

    /// <summary>
    /// <code>
    /// c
    ///
    /// Speed of sound in pure water
    /// </code>
    /// </summary>
    SpeedOfSoundInPureWater,

    /// <summary>
    /// <code>
    /// c
    ///
    /// Speed of sound in sea water (20°C, 10 meter deep)
    /// </code>
    /// </summary>
    SpeedOfSoundInSeaWater_10Meter20C,

    /// <summary>
    /// <code>
    /// c
    ///
    /// Speed of light in vacuum
    /// </code>
    /// </summary>
    SpeedOfLightInVacuum,

    CosmicVelocity_1st,
    CosmicVelocity_2nd,
    CosmicVelocity_3rd,
    EarthVelocity
}