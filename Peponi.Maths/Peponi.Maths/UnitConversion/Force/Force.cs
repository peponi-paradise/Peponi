﻿namespace Peponi.Maths.UnitConversion;

internal static class Force
{
    private static Dictionary<ForceUnit, double> _multipliers;

    static Force()
    {
        _multipliers = new()
        {
            { ForceUnit.AttoNewton, 1E-18 },
            { ForceUnit.FemtoNewton, 1E-15 },
            { ForceUnit.PicoNewton, 1E-12 },
            { ForceUnit.NanoNewton, 1E-9 },
            { ForceUnit.MicroNewton, 1E-6 },
            { ForceUnit.MilliNewton, 1E-3 },
            { ForceUnit.CentiNewton, 1E-2 },
            { ForceUnit.DeciNewton, 0.1 },
            { ForceUnit.Newton, 1 },
            { ForceUnit.DecaNewton, 10 },
            { ForceUnit.HectoNewton, 1E2 },
            { ForceUnit.KiloNewton, 1E3 },
            { ForceUnit.MegaNewton, 1E6 },
            { ForceUnit.GigaNewton, 1E9 },
            { ForceUnit.TeraNewton, 1E12 },
            { ForceUnit.PetaNewton, 1E15 },
            { ForceUnit.ExaNewton, 1E18 },
            { ForceUnit.GramForce, 9.80665E-3 },
            { ForceUnit.KiloGramForce, 9.80665 },
            { ForceUnit.TonForce, 9.80665E3 },
            { ForceUnit.TonForce_US, 8896.443230521 },
            { ForceUnit.TonForce_UK, 9964.0164181707 },
            { ForceUnit.Dyne, 1E-5 },
            { ForceUnit.JoulePerCentiMeter, 1E-2 },
            { ForceUnit.JoulePerMeter, 1 },
            { ForceUnit.KipForce, 4448.2216152548 },
            { ForceUnit.OunceForce, 0.278013851 },
            { ForceUnit.PoundForce, 4.4482216153 },
            { ForceUnit.KiloPoundForce, 4.4482216153E3 },
            { ForceUnit.Poundal, 0.1382549544 },
            { ForceUnit.PoundFootPerSquareSecond, 0.1382549544 },
            { ForceUnit.Pond, 9.80665E-3 },
            { ForceUnit.KiloPond, 9.80665 }
        };
    }

    internal static T ConvertTo<T>(T value, ForceUnit convertFrom, ForceUnit convertTo) where T : struct
    {
        return (T)Convert.ChangeType((Convert.ToDouble(value) * _multipliers[convertFrom] / _multipliers[convertTo]), typeof(T));
    }
}