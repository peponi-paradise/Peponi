namespace Peponi.Maths.UnitConversion;

internal static partial class Temperature
{
    // All values to Kelvin

    private static Func<double, double> FromKelvin = (x) => x;
    private static Func<double, double> FromCelsius = (x) => x + 273.15;
    private static Func<double, double> FromFahrenheit = (x) => (x + 459.67) / 1.8;
    private static Func<double, double> FromRankine = (x) => x / 1.8;
    private static Func<double, double> FromReaumur = (x) => x * 1.25 + 273.15;
    private static Func<double, double> FromTriplePointOfWater = (x) => x * 273.16;

    // Compute from Kelvin

    private static Func<double, double> ToKelvin = (x) => x;
    private static Func<double, double> ToCelsius = (x) => x - 273.15;
    private static Func<double, double> ToFahrenheit = (x) => x * 1.8 - 459.67;
    private static Func<double, double> ToRankine = (x) => x * 1.8;
    private static Func<double, double> ToReaumur = (x) => (x - 273.15) * 0.8;
    private static Func<double, double> ToTriplePointOfWater = (x) => x / 273.16;
}