namespace Peponi.Math.UnitConversion;

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
            EnergyUnit.ThermEC => 105506000,
            EnergyUnit.ThermUS => 105480400,
            EnergyUnit.ThermUK => 105505585.257348,
            EnergyUnit.TonHourRefrigeration => 12660670.23144,
            EnergyUnit.FuelOilKiloLiter => 40197627984.822,
            EnergyUnit.FuelOilBarrelUS => 6383087908.3509,
            EnergyUnit.TonTNT => 4184000000,
            EnergyUnit.KiloTonTNT => 4184000000E3,
            EnergyUnit.MegaTonTNT => 4184000000E6,
            EnergyUnit.GigaTonTNT => 4184000000E9,
            EnergyUnit.CalorieNutritional => 4186.8,
            EnergyUnit.CalorieInternationalTable => 4.1868,
            EnergyUnit.KiloCalorieInternationalTable => 4186.8,
            EnergyUnit.CalorieThermochemical => 4.184,
            EnergyUnit.KiloCalorieThermochemical => 4184,
            EnergyUnit.HorsePowerHour => 2647795.5,
            EnergyUnit.HorsePowerHourUK => 2684519.5368856,
            EnergyUnit.BritishThermalUnitInternationalTable => 1055.05585262,
            EnergyUnit.MegaBritishThermalUnitInternationalTable => 1055.05585262E6,
            EnergyUnit.BritishThermalUnitThermochemical => 1054.3499999744,
            EnergyUnit.MegaBritishThermalUnitThermochemical => 1054.3499999744E6,
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