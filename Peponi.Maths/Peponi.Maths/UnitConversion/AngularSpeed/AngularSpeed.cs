namespace Peponi.Maths.UnitConversion;

internal static class AngularSpeed
{
    private static Dictionary<AngularSpeedUnit, double> _multipliers;

    static AngularSpeed()
    {
        _multipliers = new()
        {
            { AngularSpeedUnit.RadianPerSecond, 1 },
            { AngularSpeedUnit.RadianPerMinute, 0.0166666666666667 },
            { AngularSpeedUnit.RadianPerHour, 2.777777777777778E-4 },
            { AngularSpeedUnit.RadianPerDay, 1.157407407407407E-5 },
            { AngularSpeedUnit.CyclePerSecond, 6.283185307179586 },
            { AngularSpeedUnit.CyclePerMinute, 0.10471975511965977 },
            { AngularSpeedUnit.CyclePerHour, 0.0017453292519943296 },
            { AngularSpeedUnit.CyclePerDay, 7.27220521664304E-05 },
            { AngularSpeedUnit.DegreePerSecond, 0.017453292519943295 },
            { AngularSpeedUnit.DegreePerMinute, 0.0002908882086657216 },
            { AngularSpeedUnit.DegreePerHour, 4.84813681109536E-06 },
            { AngularSpeedUnit.DegreePerDay, 2.0200570046230665E-07 },
            { AngularSpeedUnit.RevolutionPerSecond, 6.283185307179586 },
            { AngularSpeedUnit.RevolutionPerMinute, 0.10471975511965977 },
            { AngularSpeedUnit.RevolutionPerHour, 0.0017453292519943296 },
            { AngularSpeedUnit.RevolutionPerDay, 7.27220521664304E-05 }
        };
    }

    internal static T ConvertTo<T>(T value, AngularSpeedUnit convertFrom, AngularSpeedUnit convertTo) where T : struct
    {
        return (T)Convert.ChangeType((Convert.ToDouble(value) * _multipliers[convertFrom] / _multipliers[convertTo]), typeof(T));
    }
}