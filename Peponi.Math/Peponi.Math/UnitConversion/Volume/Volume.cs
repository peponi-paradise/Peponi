namespace Peponi.Math.UnitConversion;

internal static partial class Volume
{
    internal static T ConvertTo<T>(T value, VolumeUnit convertFrom, VolumeUnit convertTo) where T : struct
    {
        var multiplierFrom = GetMultiplier(convertFrom);
        var multiplierTo = GetMultiplier(convertTo);
        return (T)Convert.ChangeType((Convert.ToDouble(value) * multiplierFrom / multiplierTo), typeof(T));
    }

    private static double GetMultiplier(VolumeUnit unit)
    {
        return unit switch
        {
            VolumeUnit.CubicMilliMeter => 1.0E-9,
            VolumeUnit.CubicCentiMeter => 1.0E-6,
            VolumeUnit.CubicDeciMeter => 0.001,
            VolumeUnit.CubicMeter => 1,
            VolumeUnit.CubicKiloMeter => 1000000000,
            VolumeUnit.Drop => 5.0E-8,
            VolumeUnit.CC => 1.0E-6,
            VolumeUnit.AttoLiter => 1.0E-21,
            VolumeUnit.FemtoLiter => 1.0E-18,
            VolumeUnit.PicoLiter => 1.0E-15,
            VolumeUnit.NanoLiter => 1.0E-12,
            VolumeUnit.MicroLiter => 1.0E-9,
            VolumeUnit.MilliLiter => 1.0E-6,
            VolumeUnit.CentiLiter => 1.0E-5,
            VolumeUnit.DeciLiter => 0.0001,
            VolumeUnit.Liter => 0.001,
            VolumeUnit.DekaLiter => 0.01,
            VolumeUnit.HectoLiter => 0.1,
            VolumeUnit.KiloLiter => 1,
            VolumeUnit.MegaLiter => 1000,
            VolumeUnit.GigaLiter => 1000000,
            VolumeUnit.TeraLiter => 1000000000,
            VolumeUnit.PetaLiter => 1000000000000,
            VolumeUnit.ExaLiter => 1.0E+15,
            VolumeUnit.TeaSpoon => 5.0E-6,
            VolumeUnit.TeaSpoonUS => 4.92892159375E-6,
            VolumeUnit.TeaSpoonUK => 5.9193880208333E-6,
            VolumeUnit.DessertSpoonUS => 9.8578431875E-6,
            VolumeUnit.DessertSpoonUK => 1.18388E-5,
            VolumeUnit.TableSpoon => 1.5E-5,
            VolumeUnit.TableSpoonUS => 1.47868E-5,
            VolumeUnit.TableSpoonUK => 1.77582E-5,
            VolumeUnit.OunceUS => 2.95735E-5,
            VolumeUnit.OunceUK => 2.84131E-5,
            VolumeUnit.Cup => 0.00025,
            VolumeUnit.CupUS => 0.0002365882,
            VolumeUnit.CupUK => 0.0002841306,
            VolumeUnit.PintUS => 0.0004731765,
            VolumeUnit.PintUK => 0.0005682613,
            VolumeUnit.QuartUS => 0.0009463529,
            VolumeUnit.QuartUK => 0.0011365225,
            VolumeUnit.GallonUS => 0.0037854118,
            VolumeUnit.GallonUK => 0.00454609,
            VolumeUnit.Barrel => 0.1589872949,
            VolumeUnit.BarrelUS => 0.1192404712,
            VolumeUnit.BarrelUK => 0.16365924,
            VolumeUnit.GillUS => 0.0001182941,
            VolumeUnit.GillUK => 0.0001420653,
            VolumeUnit.MinimUS => 6.1611519921875E-8,
            VolumeUnit.MinimUK => 5.9193880208333E-8,
            VolumeUnit.CubicInch => 1.63871E-5,
            VolumeUnit.AcreInch => 102.790153129,
            VolumeUnit.BoardFoot => 0.0023597372,
            VolumeUnit.CubicFoot => 0.0283168466,
            VolumeUnit.HundredCubicFoot => 2.8316846592,
            VolumeUnit.AcreFoot => 1233.4818375475,
            VolumeUnit.AcreFootUS => 1233.4892384682,
            VolumeUnit.CubicYard => 0.764554858,
            VolumeUnit.CubicMile => 4168181825.4406,
            VolumeUnit.TonRegister => 2.8316846592,
            VolumeUnit.Ccf => 2.8316846592,
            VolumeUnit.DeciStere => 0.1,
            VolumeUnit.Stere => 1,
            VolumeUnit.DekaStere => 10,
            VolumeUnit.Cord => 3.6245563638,
            VolumeUnit.Tun => 0.9539237696,
            VolumeUnit.Hogshead => 0.2384809424,
            VolumeUnit.Dram => 3.6966911953125E-6,
            _ => throw new ArgumentException($"{unit} is not supported")
        };
    }
}