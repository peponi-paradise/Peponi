namespace Peponi.Maths.UnitConversion;

internal static partial class AngularSpeed
{
    internal static T ConvertTo<T>(T value, AngularSpeedUnit convertFrom, AngularSpeedUnit convertTo) where T : struct
    {
        var multiplierFrom = GetMultiplier(convertFrom);
        var multiplierTo = GetMultiplier(convertTo);

        return (T)Convert.ChangeType((Convert.ToDouble(value) * multiplierFrom / multiplierTo), typeof(T));
    }

    private static double GetMultiplier(AngularSpeedUnit unit)
    {
        return unit switch
        {
            AngularSpeedUnit.RadianPerSecond => 1,
            AngularSpeedUnit.RadianPerMinute => 0.0166666666666667,
            AngularSpeedUnit.RadianPerHour => 2.777777777777778E-4,
            AngularSpeedUnit.RadianPerDay => 1.157407407407407E-5,
            AngularSpeedUnit.CyclePerSecond => 2 * Constants.PI,
            AngularSpeedUnit.CyclePerMinute => 2 * Constants.PI / 60,
            AngularSpeedUnit.CyclePerHour => 2 * Constants.PI / 3600,
            AngularSpeedUnit.CyclePerDay => 2 * Constants.PI / 86400,
            AngularSpeedUnit.DegreePerSecond => 1.0 / 180 * Constants.PI,
            AngularSpeedUnit.DegreePerMinute => 1.0 / 180 * Constants.PI / 60,
            AngularSpeedUnit.DegreePerHour => 1.0 / 180 * Constants.PI / 3600,
            AngularSpeedUnit.DegreePerDay => 1.0 / 180 * Constants.PI / 86400,
            AngularSpeedUnit.RevolutionPerSecond => 2 * Constants.PI,
            AngularSpeedUnit.RevolutionPerMinute => 2 * Constants.PI / 60,
            AngularSpeedUnit.RevolutionPerHour => 2 * Constants.PI / 3600,
            AngularSpeedUnit.RevolutionPerDay => 2 * Constants.PI / 86400,
            _ => throw new ArgumentException($"{unit} is not supported")
        };
    }
}