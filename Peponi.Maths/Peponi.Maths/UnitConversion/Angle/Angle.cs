namespace Peponi.Maths.UnitConversion;

internal static class Angle
{
    private static Dictionary<AngleUnit, double> _multipliers;

    static Angle()
    {
        _multipliers = new()
        {
            { AngleUnit.Degree, 1 },
            { AngleUnit.Radian, 57.29577951308232 },
            { AngleUnit.Grad, 0.9 },
            { AngleUnit.Minute, 0.016666666666666666 },
            { AngleUnit.Second, 0.0002777777777777778 },
            { AngleUnit.Gon, 0.9 },
            { AngleUnit.Sign, 30 },
            { AngleUnit.Mil, 0.05625 },
            { AngleUnit.Revolution, 360 },
            { AngleUnit.Circle, 360 },
            { AngleUnit.Turn, 360 },
            { AngleUnit.RightAngle, 90 },
            { AngleUnit.Octant, 45 },
            { AngleUnit.Quadrant, 90 },
            { AngleUnit.Sextant, 60 }
        };
    }

    internal static T ConvertTo<T>(T value, AngleUnit convertFrom, AngleUnit convertTo) where T : struct
    {
        return (T)Convert.ChangeType((Convert.ToDouble(value) * _multipliers[convertFrom] / _multipliers[convertTo]), typeof(T));
    }
}