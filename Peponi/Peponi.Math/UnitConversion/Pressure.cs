namespace Peponi.Math.UnitConversion;

public enum PressureUnit
{
    Pa,
    Torr,
    Psi,
}

public static class Pressure
{
    public static T ConvertTo<T>(T value, PressureUnit current, PressureUnit converting) where T : struct
    {
        double multiplier = current switch
        {
            PressureUnit.Pa => converting switch
            {
                PressureUnit.Torr => 1 / 133.322,
                PressureUnit.Psi => 1 / 6894.76,
                _ => throw new ArgumentException($"{converting} is not configured")
            },
            PressureUnit.Torr => converting switch
            {
                PressureUnit.Pa => 133.322,
                PressureUnit.Psi => 1 / 51.7149,
                _ => throw new ArgumentException($"{converting} is not configured")
            },
            PressureUnit.Psi => converting switch
            {
                PressureUnit.Pa => 6894.76,
                PressureUnit.Torr => 51.7149,
                _ => throw new ArgumentException($"{converting} is not configured")
            },
            _ => throw new ArgumentException($"{converting} is not configured")
        };

        return (T)Convert.ChangeType((Convert.ToDouble(value) * multiplier), typeof(T));
    }
}