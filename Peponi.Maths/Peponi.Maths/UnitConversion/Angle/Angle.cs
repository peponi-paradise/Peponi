namespace Peponi.Maths.UnitConversion;

internal static partial class Angle
{
    internal static T ConvertTo<T>(T value, AngleUnit convertFrom, AngleUnit convertTo) where T : struct
    {
        var multiplierFrom = GetMultiplier(convertFrom);
        var multiplierTo = GetMultiplier(convertTo);
        return (T)Convert.ChangeType((Convert.ToDouble(value) * multiplierFrom / multiplierTo), typeof(T));
    }

    private static double GetMultiplier(AngleUnit unit)
    {
        return unit switch
        {
            AngleUnit.Degree => 1,
            AngleUnit.Radian => 180 / Constants.PI,
            AngleUnit.Grad => 0.9,
            AngleUnit.Minute => 1.0 / 60,
            AngleUnit.Second => 1.0 / 3600,
            AngleUnit.Gon => 0.9,
            AngleUnit.Sign => 30,
            AngleUnit.Mil => 0.05625,
            AngleUnit.Revolution => 360,
            AngleUnit.Circle => 360,
            AngleUnit.Turn => 360,
            AngleUnit.RightAngle => 90,
            AngleUnit.Octant => 45,
            AngleUnit.Quadrant => 90,
            AngleUnit.Sextant => 60,
            _ => throw new ArgumentException($"{unit} is not supported")
        };
    }
}