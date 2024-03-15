namespace Peponi.Maths.UnitConversion;

internal static class Volume
{
    private static Dictionary<VolumeUnit, double> _multipliers;

    static Volume()
    {
        _multipliers = new()
        {
            { VolumeUnit.CubicMilliMeter, 1E-9 },
            { VolumeUnit.CubicCentiMeter, 1E-6 },
            { VolumeUnit.CubicDeciMeter, 1E-3 },
            { VolumeUnit.CubicMeter, 1 },
            { VolumeUnit.CubicKiloMeter, 1E9 },
            { VolumeUnit.Drop, 5E-8 },
            { VolumeUnit.CC, 1E-6 },
            { VolumeUnit.AttoLiter, 1E-21 },
            { VolumeUnit.FemtoLiter, 1E-18 },
            { VolumeUnit.PicoLiter, 1E-15 },
            { VolumeUnit.NanoLiter, 1E-12 },
            { VolumeUnit.MicroLiter, 1E-9 },
            { VolumeUnit.MilliLiter, 1E-6 },
            { VolumeUnit.CentiLiter, 1E-5 },
            { VolumeUnit.DeciLiter, 1E-4 },
            { VolumeUnit.Liter, 1E-3 },
            { VolumeUnit.DecaLiter, 1E-2 },
            { VolumeUnit.HectoLiter, 1E-1 },
            { VolumeUnit.KiloLiter, 1 },
            { VolumeUnit.MegaLiter, 1E3 },
            { VolumeUnit.GigaLiter, 1E6 },
            { VolumeUnit.TeraLiter, 1E9 },
            { VolumeUnit.PetaLiter, 1E12 },
            { VolumeUnit.ExaLiter, 1E15 },
            { VolumeUnit.TeaSpoon, 5E-6 },
            { VolumeUnit.TeaSpoon_US, 4.92892159375E-6 },
            { VolumeUnit.TeaSpoon_UK, 5.9193880208333E-6 },
            { VolumeUnit.DessertSpoon_US, 9.8578431875E-6 },
            { VolumeUnit.DessertSpoon_UK, 1.18388E-5 },
            { VolumeUnit.TableSpoon, 1.5E-5 },
            { VolumeUnit.TableSpoon_US, 1.47868E-5 },
            { VolumeUnit.TableSpoon_UK, 1.77582E-5 },
            { VolumeUnit.Ounce_US, 2.95735E-5 },
            { VolumeUnit.Ounce_UK, 2.84131E-5 },
            { VolumeUnit.Cup, 0.00025 },
            { VolumeUnit.Cup_US, 0.0002365882 },
            { VolumeUnit.Cup_UK, 0.0002841306 },
            { VolumeUnit.Pint_US, 0.0004731765 },
            { VolumeUnit.Pint_UK, 0.0005682613 },
            { VolumeUnit.Quart_US, 0.0009463529 },
            { VolumeUnit.Quart_UK, 0.0011365225 },
            { VolumeUnit.Gallon_US, 0.0037854118 },
            { VolumeUnit.Gallon_UK, 0.00454609 },
            { VolumeUnit.Barrel, 0.1589872949 },
            { VolumeUnit.Barrel_US, 0.1192404712 },
            { VolumeUnit.Barrel_UK, 0.16365924 },
            { VolumeUnit.Gill_US, 0.0001182941 },
            { VolumeUnit.Gill_UK, 0.0001420653 },
            { VolumeUnit.Minim_US, 6.1611519921875E-8 },
            { VolumeUnit.Minim_UK, 5.9193880208333E-8 },
            { VolumeUnit.CubicInch, 1.63871E-5 },
            { VolumeUnit.AcreInch, 102.790153129 },
            { VolumeUnit.BoardFoot, 0.0023597372 },
            { VolumeUnit.CubicFoot, 0.0283168466 },
            { VolumeUnit.HundredCubicFoot, 2.8316846592 },
            { VolumeUnit.AcreFoot, 1233.4818375475 },
            { VolumeUnit.AcreFoot_US, 1233.4892384682 },
            { VolumeUnit.CubicYard, 0.764554858 },
            { VolumeUnit.CubicMile, 4168181825.4406 },
            { VolumeUnit.TonRegister, 2.8316846592 },
            { VolumeUnit.Ccf, 2.8316846592 },
            { VolumeUnit.DeciStere, 0.1 },
            { VolumeUnit.Stere, 1 },
            { VolumeUnit.DecaStere, 10 },
            { VolumeUnit.Cord, 3.6245563638 },
            { VolumeUnit.Tun, 0.9539237696 },
            { VolumeUnit.Hogshead, 0.2384809424 },
            { VolumeUnit.Dram, 3.6966911953125E-6 }
        };
    }

    internal static T ConvertTo<T>(T value, VolumeUnit convertFrom, VolumeUnit convertTo) where T : struct
    {
        return (T)Convert.ChangeType((Convert.ToDouble(value) * _multipliers[convertFrom] / _multipliers[convertTo]), typeof(T));
    }
}