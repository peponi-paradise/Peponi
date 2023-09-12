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