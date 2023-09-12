namespace Peponi.Math.UnitConversion;

internal static class Length
{
    private const double FemtoMeter = 1E-15;
    private const double PicoMeter = 1E-12;
    private const double NanoMeter = 1E-9;
    private const double MicroMeter = 1E-6;
    private const double MilliMeter = 0.001;
    private const double CentiMeter = 0.01;
    private const double Meter = 1;
    private const double KiloMeter = 1000;
    private const double Foot = 0.3048;
    private const double FootUS = 0.3048006096;
    private const double Yard = 0.9144;
    private const double KiloYard = 914.4;
    private const double Mil = 2.54E-5;
    private const double Mile = 1609.344;
    private const double MileUSStatute = 1609.3472186944;
    private const double MileUSSurvey = 1609.3472186944;
    private const double MileRoman = 1479.804;
    private const double NauticalMileUK = 1853.184;
    private const double NauticalMile = 1852;
    private const double MicroInch = 2.54E-8;
    private const double CentiInch = 0.000254;
    private const double Inch = 0.0254;
    private const double InchUS = 0.0254000508;
    private const double Micron = 1.0E-6;
    private const double League = 4828.032;
    private const double LeagueUS = 4828.0416560833;
    private const double NauticalLeagueUK = 5559.552;
    private const double NauticalLeague = 5556;
    private const double Furlong = 201.168;
    private const double FurlongUS = 201.1684023368;
    private const double Chain = 20.1168;
    private const double ChainUS = 20.1168402337;
    private const double Rope = 6.096;
    private const double Rod = 5.0292;
    private const double RodUS = 5.0292100584;
    private const double Perch = 5.0292;
    private const double Pole = 5.0292;
    private const double Fathom = 1.8288;
    private const double FathomUS = 1.8288036576;
    private const double Ell = 1.143;
    private const double Link = 0.201168;
    private const double LinkUS = 0.2011684023;
    private const double CubitUK = 0.4572;
    private const double LongCubit = 0.5334;
    private const double CubitGR = 0.462788;
    private const double Hand = 0.1016;
    private const double HandBreadth = 0.0762;
    private const double FingerBreadth = 0.01905;
    private const double Span_Cloth = 0.2286;
    private const double Finger_Cloth = 0.1143;
    private const double Nail_Cloth = 0.05715;
    private const double Barleycorn = 0.0084666667;
    private const double AUOfLength = 5.2917724900001E-11;
    private const double Angstrom = 1E-10;
    private const double Fermi = 1E-15;
    private const double PlanckLength = 1.61605E-35;
    private const double ElectronRadius = 2.81794092E-15;
    private const double BohrRadius = 5.2917724900001E-11;
    private const double XUnit = 1.00208E-13;
    private const double Arpent = 58.5216;
    private const double Pica = 0.0042333333;
    private const double Point = 0.0003527778;
    private const double Twip = 1.76389E-5;
    private const double Aln = 0.5937777778;
    private const double Famn = 1.7813333333;
    private const double Caliber = 0.000254;
    private const double Ken = 2.11836;
    private const double RussianArchin = 0.7112;
    private const double RomanActus = 35.47872;
    private const double VaraDeTarea = 2.505456;
    private const double VaraConuquera = 2.505456;
    private const double VaraCastellana = 0.835152;
    private const double Reed = 2.7432;
    private const double LongReed = 3.2004;
    private const double Parsec = 3.08567758128E+16;
    private const double KiloParsec = 3.08567758128E+19;
    private const double MegaParsec = 3.08567758128E+22;
    private const double AU = 149597870691;
    private const double LightYear = 9.46073047258E+15;

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
            LengthUnit.FemtoMeter => FemtoMeter,
            LengthUnit.PicoMeter => PicoMeter,
            LengthUnit.NanoMeter => NanoMeter,
            LengthUnit.MicroMeter => MicroMeter,
            LengthUnit.MilliMeter => MilliMeter,
            LengthUnit.CentiMeter => CentiMeter,
            LengthUnit.Meter => Meter,
            LengthUnit.KiloMeter => KiloMeter,
            LengthUnit.Foot => Foot,
            LengthUnit.FootUS => FootUS,
            LengthUnit.Yard => Yard,
            LengthUnit.KiloYard => KiloYard,
            LengthUnit.Mil => Mil,
            LengthUnit.Mile => Mile,
            LengthUnit.MileUSStatute => MileUSStatute,
            LengthUnit.MileUSSurvey => MileUSSurvey,
            LengthUnit.MileRoman => MileRoman,
            LengthUnit.NauticalMileUK => NauticalMileUK,
            LengthUnit.NauticalMile => NauticalMile,
            LengthUnit.MicroInch => MicroInch,
            LengthUnit.CentiInch => CentiInch,
            LengthUnit.Inch => Inch,
            LengthUnit.InchUS => InchUS,
            LengthUnit.Micron => Micron,
            LengthUnit.League => League,
            LengthUnit.LeagueUS => LeagueUS,
            LengthUnit.NauticalLeagueUK => NauticalLeagueUK,
            LengthUnit.NauticalLeague => NauticalLeague,
            LengthUnit.Furlong => Furlong,
            LengthUnit.FurlongUS => FurlongUS,
            LengthUnit.Chain => Chain,
            LengthUnit.ChainUS => ChainUS,
            LengthUnit.Rope => Rope,
            LengthUnit.Rod => Rod,
            LengthUnit.RodUS => RodUS,
            LengthUnit.Perch => Perch,
            LengthUnit.Pole => Pole,
            LengthUnit.Fathom => Fathom,
            LengthUnit.FathomUS => FathomUS,
            LengthUnit.Ell => Ell,
            LengthUnit.Link => Link,
            LengthUnit.LinkUS => LinkUS,
            LengthUnit.CubitUK => CubitUK,
            LengthUnit.CubitGR => CubitGR,
            LengthUnit.LongCubit => LongCubit,
            LengthUnit.Hand => Hand,
            LengthUnit.HandBreadth => HandBreadth,
            LengthUnit.FingerBreadth => FingerBreadth,
            LengthUnit.Span_Cloth => Span_Cloth,
            LengthUnit.Finger_Cloth => Finger_Cloth,
            LengthUnit.Nail_Cloth => Nail_Cloth,
            LengthUnit.Barleycorn => Barleycorn,
            LengthUnit.AUOfLength => AUOfLength,
            LengthUnit.Angstrom => Angstrom,
            LengthUnit.Fermi => Fermi,
            LengthUnit.PlanckLength => PlanckLength,
            LengthUnit.ElectronRadius => ElectronRadius,
            LengthUnit.BohrRadius => BohrRadius,
            LengthUnit.XUnit => XUnit,
            LengthUnit.Arpent => Arpent,
            LengthUnit.Pica => Pica,
            LengthUnit.Point => Point,
            LengthUnit.Twip => Twip,
            LengthUnit.Aln => Aln,
            LengthUnit.Famn => Famn,
            LengthUnit.Caliber => Caliber,
            LengthUnit.Ken => Ken,
            LengthUnit.RussianArchin => RussianArchin,
            LengthUnit.RomanActus => RomanActus,
            LengthUnit.VaraDeTarea => VaraDeTarea,
            LengthUnit.VaraConuquera => VaraConuquera,
            LengthUnit.VaraCastellana => VaraCastellana,
            LengthUnit.Reed => Reed,
            LengthUnit.LongReed => LongReed,
            LengthUnit.Parsec => Parsec,
            LengthUnit.KiloParsec => KiloParsec,
            LengthUnit.MegaParsec => MegaParsec,
            LengthUnit.AU => AU,
            LengthUnit.LightYear => LightYear,
            _ => throw new ArgumentException($"{unit} is not supported")
        };
    }
}