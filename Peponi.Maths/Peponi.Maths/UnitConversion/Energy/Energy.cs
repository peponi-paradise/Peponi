namespace Peponi.Maths.UnitConversion;

internal static partial class Energy
{
    internal static T ConvertTo<T>(T value, EnergyUnit convertFrom, EnergyUnit convertTo) where T : struct
    {
        var multiplierFrom = GetMultiplier(convertFrom);
        var multiplierTo = GetMultiplier(convertTo);

        return (T)Convert.ChangeType((Convert.ToDouble(value) * multiplierFrom / multiplierTo), typeof(T));
    }

    private static double GetMultiplier(EnergyUnit unit)
    {
        return unit switch
        {
            EnergyUnit.AttoJoule => 1E-18,
            EnergyUnit.FemtoJoule => 1E-15,
            EnergyUnit.PicoJoule => 1E-12,
            EnergyUnit.NanoJoule => 1E-9,
            EnergyUnit.MicroJoule => 1E-6,
            EnergyUnit.MilliJoule => 1E-3,
            EnergyUnit.Joule => 1,
            EnergyUnit.KiloJoule => 1E3,
            EnergyUnit.MegaJoule => 1E6,
            EnergyUnit.GigaJoule => 1E9,
            EnergyUnit.TeraJoule => 1E12,
            EnergyUnit.PetaJoule => 1E15,
            EnergyUnit.ExaJoule => 1E18,
            EnergyUnit.WattSecond => 1,
            EnergyUnit.KiloWattSecond => 1E3,
            EnergyUnit.MegaWattSecond => 1E6,
            EnergyUnit.WattHour => 3600,
            EnergyUnit.KiloWattHour => 3600E3,
            EnergyUnit.MegaWattHour => 3600E6,
            EnergyUnit.GigaWattHour => 3600E9,
            EnergyUnit.TeraWattHour => 3600E12,
            EnergyUnit.PetaWattHour => 3600E15,
            EnergyUnit.ExaWattHour => 3600E18,
            EnergyUnit.DyneCentiMeter => 1E-7,
            EnergyUnit.GramForceCentiMeter => Constants.GravitationalAcceleration * 1E-5,
            EnergyUnit.GramForceMeter => Constants.GravitationalAcceleration * 1E-3,
            EnergyUnit.KiloGramForceCentiMeter => Constants.GravitationalAcceleration * 1E-2,
            EnergyUnit.KiloGramForceMeter => Constants.GravitationalAcceleration,
            EnergyUnit.KiloPondMeter => Constants.GravitationalAcceleration,
            EnergyUnit.NewtonMeter => 1,
            EnergyUnit.OunceForceInch => 0.0070615518,
            EnergyUnit.PoundForceInch => 0.112984829,
            EnergyUnit.PoundForceFoot => 1.3558179483,
            EnergyUnit.InchOunceForce => 0.0070615518,
            EnergyUnit.InchPoundForce => 0.112984829,
            EnergyUnit.FootPoundForce => 1.3558179483,
            EnergyUnit.PoundalFoot => 0.04214011,
            EnergyUnit.Therm_EC => 105506000,
            EnergyUnit.Therm_US => 105480400,
            EnergyUnit.Therm_UK => 105505585.257348,
            EnergyUnit.TonHour_Refrigeration => 12660670.23144,
            EnergyUnit.FuelOilEquivalent_KiloLiter => 40197627984.822,
            EnergyUnit.FuelOilEquivalent_Barrel_US => 6383087908.3509,
            EnergyUnit.Ton_TNT => 4184000000,
            EnergyUnit.KiloTon_TNT => 4184000000E3,
            EnergyUnit.MegaTon_TNT => 4184000000E6,
            EnergyUnit.GigaTon_TNT => 4184000000E9,
            EnergyUnit.Calorie_Nutritional => 4186.8,
            EnergyUnit.KiloCalorie_Nutritional => 4186800,
            EnergyUnit.Calorie_InternationalTable => 4.1868,
            EnergyUnit.KiloCalorie_InternationalTable => 4186.8,
            EnergyUnit.Calorie_Thermochemical => 4.184,
            EnergyUnit.KiloCalorie_Thermochemical => 4184,
            EnergyUnit.HorsePowerHour => 2647795.5,
            EnergyUnit.HorsePowerHour_UK => 2684519.5368856,
            EnergyUnit.BritishThermalUnit_InternationalTable => 1055.05585262,
            EnergyUnit.MegaBritishThermalUnit_InternationalTable => 1055.05585262E6,
            EnergyUnit.BritishThermalUnit_Thermochemical => 1054.3499999744,
            EnergyUnit.MegaBritishThermalUnit_Thermochemical => 1054.3499999744E6,
            EnergyUnit.Erg => 1E-7,
            EnergyUnit.ElectronVolt => 1.6021766339999E-19,
            EnergyUnit.KiloElectronVolt => 1.6021766339999E-16,
            EnergyUnit.MegaElectronVolt => 1.6021766339999E-13,
            EnergyUnit.GigaElectronVolt => 1.6021766339999E-10,
            EnergyUnit.Hartree => 4.3597482E-18,
            EnergyUnit.RydbergConstant => 2.1798741E-18,
            _ => throw new ArgumentException($"{unit} is not supported")
        };
    }
}