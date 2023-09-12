namespace Peponi.Math.UnitConversion;

internal static class Prefix
{
    internal static T ConvertTo<T>(T value, PrefixUnit convertFrom, PrefixUnit convertTo) where T : struct
    {
        return (T)Convert.ChangeType((Convert.ToDouble(value) * System.Math.Pow(10, (int)convertFrom) / System.Math.Pow(10, (int)convertTo)), typeof(T));
    }
}