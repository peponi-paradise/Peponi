namespace Peponi.Math.UnitConversion;

internal static partial class Length
{
    internal static T ConvertTo<T>(T value, LengthUnit convertFrom, LengthUnit convertTo) where T : struct
    {
        var multiplierFrom = GetMultiplier(convertFrom);
        var multiplierTo = GetMultiplier(convertTo);
        return (T)Convert.ChangeType((Convert.ToDouble(value) * multiplierFrom / multiplierTo), typeof(T));
    }

    private static double GetMultiplier(LengthUnit unit)
    {
        return unit switch
        {
            LengthUnit.FemtoMeter => 1E-15,
            LengthUnit.PicoMeter => 1E-12,
            LengthUnit.NanoMeter => 1E-9,
            LengthUnit.MicroMeter => 1E-6,
            LengthUnit.MilliMeter => 0.001,
            LengthUnit.CentiMeter => 0.01,
            LengthUnit.Meter => 1,
            LengthUnit.KiloMeter => 1000,
            LengthUnit.Foot => 0.3048,
            LengthUnit.FootUS => 0.3048006096,
            LengthUnit.Yard => 0.9144,
            LengthUnit.KiloYard => 914.4,
            LengthUnit.Mil => 2.54E-5,
            LengthUnit.Mile => 1609.344,
            LengthUnit.MileUSStatute => 1609.3472186944,
            LengthUnit.MileUSSurvey => 1609.3472186944,
            LengthUnit.MileRoman => 1479.804,
            LengthUnit.NauticalMileUK => 1853.184,
            LengthUnit.NauticalMile => 1852,
            LengthUnit.MicroInch => 2.54E-8,
            LengthUnit.CentiInch => 0.000254,
            LengthUnit.Inch => 0.0254,
            LengthUnit.InchUS => 0.0254000508,
            LengthUnit.Micron => 1.0E-6,
            LengthUnit.League => 4828.032,
            LengthUnit.LeagueUS => 4828.0416560833,
            LengthUnit.NauticalLeagueUK => 5559.552,
            LengthUnit.NauticalLeague => 5556,
            LengthUnit.Furlong => 201.168,
            LengthUnit.FurlongUS => 201.1684023368,
            LengthUnit.Chain => 20.1168,
            LengthUnit.ChainUS => 20.1168402337,
            LengthUnit.Rope => 6.096,
            LengthUnit.Rod => 5.0292,
            LengthUnit.RodUS => 5.0292100584,
            LengthUnit.Perch => 5.0292,
            LengthUnit.Pole => 5.0292,
            LengthUnit.Fathom => 1.8288,
            LengthUnit.FathomUS => 1.8288036576,
            LengthUnit.Ell => 1.143,
            LengthUnit.Link => 0.201168,
            LengthUnit.LinkUS => 0.2011684023,
            LengthUnit.CubitUK => 0.4572,
            LengthUnit.LongCubit => 0.5334,
            LengthUnit.CubitGR => 0.462788,
            LengthUnit.Hand => 0.1016,
            LengthUnit.HandBreadth => 0.0762,
            LengthUnit.FingerBreadth => 0.01905,
            LengthUnit.Span_Cloth => 0.2286,
            LengthUnit.Finger_Cloth => 0.1143,
            LengthUnit.Nail_Cloth => 0.05715,
            LengthUnit.Barleycorn => 0.0084666667,
            LengthUnit.AUOfLength => 5.2917724900001E-11,
            LengthUnit.Angstrom => 1E-10,
            LengthUnit.Fermi => 1E-15,
            LengthUnit.PlanckLength => 1.61605E-35,
            LengthUnit.ElectronRadius => 2.81794092E-15,
            LengthUnit.BohrRadius => 5.2917724900001E-11,
            LengthUnit.XUnit => 1.00208E-13,
            LengthUnit.Arpent => 58.5216,
            LengthUnit.Pica => 0.0042333333,
            LengthUnit.Point => 0.0003527778,
            LengthUnit.Twip => 1.76389E-5,
            LengthUnit.Aln => 0.5937777778,
            LengthUnit.Famn => 1.7813333333,
            LengthUnit.Caliber => 0.000254,
            LengthUnit.Ken => 2.11836,
            LengthUnit.RussianArchin => 0.7112,
            LengthUnit.RomanActus => 35.47872,
            LengthUnit.VaraDeTarea => 2.505456,
            LengthUnit.VaraConuquera => 2.505456,
            LengthUnit.VaraCastellana => 0.835152,
            LengthUnit.Reed => 2.7432,
            LengthUnit.LongReed => 3.2004,
            LengthUnit.Parsec => 3.08567758128E+16,
            LengthUnit.KiloParsec => 3.08567758128E+19,
            LengthUnit.MegaParsec => 3.08567758128E+22,
            LengthUnit.AU => 149597870691,
            LengthUnit.LightYear => 9.46073047258E+15,
            _ => throw new ArgumentException($"{unit} is not supported")
        };
    }
}