namespace Peponi.Maths.UnitConversion;

public enum EnergyUnit
{
    /// <summary>
    /// <code>
    /// aJ
    /// </code>
    /// </summary>
    AttoJoule,

    /// <summary>
    /// <code>
    /// fJ
    /// </code>
    /// </summary>
    FemtoJoule,

    /// <summary>
    /// <code>
    /// pJ
    /// </code>
    /// </summary>
    PicoJoule,

    /// <summary>
    /// <code>
    /// nJ
    /// </code>
    /// </summary>
    NanoJoule,

    /// <summary>
    /// <code>
    /// µJ
    /// </code>
    /// </summary>
    MicroJoule,

    /// <summary>
    /// <code>
    /// mJ
    /// </code>
    /// </summary>
    MilliJoule,

    /// <summary>
    /// <code>
    /// J
    /// </code>
    /// </summary>
    Joule,

    /// <summary>
    /// <code>
    /// kJ
    /// </code>
    /// </summary>
    KiloJoule,

    /// <summary>
    /// <code>
    /// MJ
    /// </code>
    /// </summary>
    MegaJoule,

    /// <summary>
    /// <code>
    /// GJ
    /// </code>
    /// </summary>
    GigaJoule,

    /// <summary>
    /// <code>
    /// TJ
    /// </code>
    /// </summary>
    TeraJoule,

    /// <summary>
    /// <code>
    /// PJ
    /// </code>
    /// </summary>
    PetaJoule,

    /// <summary>
    /// <code>
    /// EJ
    /// </code>
    /// </summary>
    ExaJoule,

    /// <summary>
    /// <code>
    /// W * s
    /// </code>
    /// </summary>
    WattSecond,

    /// <summary>
    /// <code>
    /// kW * s
    /// </code>
    /// </summary>
    KiloWattSecond,

    /// <summary>
    /// <code>
    /// MW * s
    /// </code>
    /// </summary>
    MegaWattSecond,

    /// <summary>
    /// <code>
    /// W * h
    /// </code>
    /// </summary>
    WattHour,

    /// <summary>
    /// <code>
    /// kW * h
    /// </code>
    /// </summary>
    KiloWattHour,

    /// <summary>
    /// <code>
    /// MW * h
    /// </code>
    /// </summary>
    MegaWattHour,

    /// <summary>
    /// <code>
    /// GW * h
    /// </code>
    /// </summary>
    GigaWattHour,

    /// <summary>
    /// <code>
    /// TW * h
    /// </code>
    /// </summary>
    TeraWattHour,

    /// <summary>
    /// <code>
    /// PW * h
    /// </code>
    /// </summary>
    PetaWattHour,

    /// <summary>
    /// <code>
    /// EW * h
    /// </code>
    /// </summary>
    ExaWattHour,

    /// <summary>
    /// <code>
    /// dyn * cm
    /// </code>
    /// </summary>
    DyneCentiMeter,

    /// <summary>
    /// <code>
    /// gf * cm
    /// </code>
    /// </summary>
    GramForceCentiMeter,

    /// <summary>
    /// <code>
    /// gf * m
    /// </code>
    /// </summary>
    GramForceMeter,

    /// <summary>
    /// <code>
    /// kgf * cm
    /// </code>
    /// </summary>
    KiloGramForceCentiMeter,

    /// <summary>
    /// <code>
    /// kgf * m
    /// </code>
    /// </summary>
    KiloGramForceMeter,

    /// <summary>
    /// <code>
    /// kp * m
    /// </code>
    /// </summary>
    KiloPondMeter,

    /// <summary>
    /// <code>
    /// N * m
    /// </code>
    /// </summary>
    NewtonMeter,

    /// <summary>
    /// <code>
    /// ozf * in
    /// </code>
    /// </summary>
    OunceForceInch,

    /// <summary>
    /// <code>
    /// lbf * in
    /// </code>
    /// </summary>
    PoundForceInch,

    /// <summary>
    /// <code>
    /// lbf * ft
    /// </code>
    /// </summary>
    PoundForceFoot,

    /// <summary>
    /// <code>
    /// in * ozf
    /// </code>
    /// </summary>
    InchOunceForce,

    /// <summary>
    /// <code>
    /// in * lbf
    /// </code>
    /// </summary>
    InchPoundForce,

    /// <summary>
    /// <code>
    /// ft * lbf
    /// </code>
    /// </summary>
    FootPoundForce,

    /// <summary>
    /// <code>
    /// pdl * ft
    /// </code>
    /// </summary>
    PoundalFoot,

    /// <summary>
    /// <code>
    /// thm
    ///
    /// Council of the European Communities (now the European Union, EU)
    /// </code>
    /// </summary>
    Therm_EC,

    /// <summary>
    /// <code>
    /// thm
    ///
    /// US natural gas industry
    /// </code>
    /// </summary>
    Therm_US,

    /// <summary>
    /// <code>
    /// thm
    ///
    /// UK
    /// </code>
    /// </summary>
    Therm_UK,

    /// <summary>
    /// <code>
    /// TR
    /// TOR
    ///
    /// Abbreviated as RT
    /// </code>
    /// </summary>
    TonHour_Refrigeration,

    /// <summary>
    /// <code>
    /// fuel-oil=kL
    ///
    /// Fuel oil equivalent @kiloliter
    /// </code>
    /// </summary>
    FuelOilEquivalent_KiloLiter,

    /// <summary>
    /// <code>
    /// fuel-oil=barrel
    ///
    /// Fuel oil equivalent @barrel (US)
    /// </code>
    /// </summary>
    FuelOilEquivalent_Barrel_US,

    /// <summary>
    /// <code>
    /// ton
    ///
    /// Ton of TNT
    /// </code>
    /// </summary>
    Ton_TNT,

    /// <summary>
    /// <code>
    /// kton
    ///
    /// Ton of TNT
    /// </code>
    /// </summary>
    KiloTon_TNT,

    /// <summary>
    /// <code>
    /// Mton
    ///
    /// Ton of TNT
    /// </code>
    /// </summary>
    MegaTon_TNT,

    /// <summary>
    /// <code>
    /// Gton
    ///
    /// Ton of TNT
    /// </code>
    /// </summary>
    GigaTon_TNT,

    /// <summary>
    /// <code>
    /// cal
    ///
    /// Nutrition
    /// </code>
    /// </summary>
    Calorie_Nutritional,

    /// <summary>
    /// <code>
    /// kcal
    ///
    /// Nutrition
    /// </code>
    /// </summary>
    KiloCalorie_Nutritional,

    /// <summary>
    /// <code>
    /// cal
    ///
    /// International table
    /// </code>
    /// </summary>
    Calorie_InternationalTable,

    /// <summary>
    /// <code>
    /// kcal
    ///
    /// International table
    /// </code>
    /// </summary>
    KiloCalorie_InternationalTable,

    /// <summary>
    /// <code>
    /// cal
    ///
    /// Thermochemical
    /// </code>
    /// </summary>
    Calorie_Thermochemical,

    /// <summary>
    /// <code>
    /// kcal
    ///
    /// Thermochemical
    /// </code>
    /// </summary>
    KiloCalorie_Thermochemical,

    /// <summary>
    /// <code>
    /// hp * h
    ///
    /// Metric
    /// </code>
    /// </summary>
    HorsePowerHour,

    /// <summary>
    /// <code>
    /// hp * h
    ///
    /// UK
    /// </code>
    /// </summary>
    HorsePowerHour_UK,

    /// <summary>
    /// <code>
    /// Btu
    /// BTU
    ///
    /// International table
    /// </code>
    /// </summary>
    BritishThermalUnit_InternationalTable,

    /// <summary>
    /// <code>
    /// MBtu
    /// MBTU
    ///
    /// International table
    /// </code>
    /// </summary>
    MegaBritishThermalUnit_InternationalTable,

    /// <summary>
    /// <code>
    /// Btu
    /// BTU
    ///
    /// Thermochemical
    /// </code>
    /// </summary>
    BritishThermalUnit_Thermochemical,

    /// <summary>
    /// <code>
    /// MBtu
    /// MBTU
    ///
    /// Thermochemical
    /// </code>
    /// </summary>
    MegaBritishThermalUnit_Thermochemical,

    /// <summary>
    /// <code>
    /// erg
    /// </code>
    /// </summary>
    Erg,

    /// <summary>
    /// <code>
    /// eV
    /// </code>
    /// </summary>
    ElectronVolt,

    /// <summary>
    /// <code>
    /// keV
    /// </code>
    /// </summary>
    KiloElectronVolt,

    /// <summary>
    /// <code>
    /// MeV
    /// </code>
    /// </summary>
    MegaElectronVolt,

    /// <summary>
    /// <code>
    /// GeV
    /// </code>
    /// </summary>
    GigaElectronVolt,

    Hartree,
    RydbergConstant,
}