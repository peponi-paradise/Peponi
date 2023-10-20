using Peponi.Math.Extensions;
using Peponi.Math.UnitConversion;

namespace Peponi.Math.Tests.UnitConversion;

[TestClass]
public class Length
{
    [TestMethod]
    public void Test()
    {
        double baseValue = 21.653;

        Assert.AreEqual(21.652999999999996E18, baseValue.Convert(LengthUnit.Meter, LengthUnit.AtttoMeter).Round(6));
        Assert.AreEqual(21.652999999999996E15, baseValue.Convert(LengthUnit.Meter, LengthUnit.FemtoMeter).Round(6));
        Assert.AreEqual(21.653E12, baseValue.Convert(LengthUnit.Meter, LengthUnit.PicoMeter).Round(6));
        Assert.AreEqual(21.652999999999996E9, baseValue.Convert(LengthUnit.Meter, LengthUnit.NanoMeter).Round(6));
        Assert.AreEqual(21.653E6, baseValue.Convert(LengthUnit.Meter, LengthUnit.MicroMeter).Round(6));
        Assert.AreEqual(21.653E3, baseValue.Convert(LengthUnit.Meter, LengthUnit.MilliMeter).Round(6));
        Assert.AreEqual(21.653E2, baseValue.Convert(LengthUnit.Meter, LengthUnit.CentiMeter).Round(6));
        Assert.AreEqual(216.53, baseValue.Convert(LengthUnit.Meter, LengthUnit.DeciMeter).Round(6));
        Assert.AreEqual(2.1653, baseValue.Convert(LengthUnit.Meter, LengthUnit.DecaMeter).Round(6));
        Assert.AreEqual(21.653E-2, baseValue.Convert(LengthUnit.Meter, LengthUnit.HectoMeter).Round(6));
        Assert.AreEqual(21.653E-3, baseValue.Convert(LengthUnit.Meter, LengthUnit.KiloMeter).Round(6));
        Assert.AreEqual(21.653E-6, baseValue.Convert(LengthUnit.Meter, LengthUnit.MegaMeter).Round(9));
        Assert.AreEqual(21.653E-9, baseValue.Convert(LengthUnit.Meter, LengthUnit.GigaMeter).Round(12));
        Assert.AreEqual(21.653E-12, baseValue.Convert(LengthUnit.Meter, LengthUnit.TeraMeter).Round(15));
        baseValue *= 1E9;
        Assert.AreEqual(21.653E-6, baseValue.Convert(LengthUnit.Meter, LengthUnit.PetaMeter).Round(9));
        Assert.AreEqual(21.653E-9, baseValue.Convert(LengthUnit.Meter, LengthUnit.ExaMeter).Round(12));
        baseValue /= 1E9;
        Assert.AreEqual(71.040026, baseValue.Convert(LengthUnit.Meter, LengthUnit.Foot).Round(6));
        Assert.AreEqual(71.039884, baseValue.Convert(LengthUnit.Meter, LengthUnit.Foot_US).Round(6));
        Assert.AreEqual(23.680009, baseValue.Convert(LengthUnit.Meter, LengthUnit.Yard).Round(6));
        Assert.AreEqual(23.680009E-3, baseValue.Convert(LengthUnit.Meter, LengthUnit.KiloYard).Round(9));
        Assert.AreEqual(852480.314961, baseValue.Convert(LengthUnit.Meter, LengthUnit.Mil).Round(6));
        Assert.AreEqual(0.013455, baseValue.Convert(LengthUnit.Meter, LengthUnit.Mile).Round(6));
        Assert.AreEqual(0.013455, baseValue.Convert(LengthUnit.Meter, LengthUnit.Mile_USStatute).Round(6));
        Assert.AreEqual(0.013455, baseValue.Convert(LengthUnit.Meter, LengthUnit.Mile_USSurvey).Round(6));
        Assert.AreEqual(0.014632, baseValue.Convert(LengthUnit.Meter, LengthUnit.Mile_Roman).Round(6));
        Assert.AreEqual(0.011692, baseValue.Convert(LengthUnit.Meter, LengthUnit.NauticalMile).Round(6));
        Assert.AreEqual(0.011684, baseValue.Convert(LengthUnit.Meter, LengthUnit.NauticalMile_UK).Round(6));
        Assert.AreEqual(852480314.96063, baseValue.Convert(LengthUnit.Meter, LengthUnit.MicroInch).Round(6));
        Assert.AreEqual(852480.314961, baseValue.Convert(LengthUnit.Meter, LengthUnit.MilliInch).Round(6));
        Assert.AreEqual(85248.031496, baseValue.Convert(LengthUnit.Meter, LengthUnit.CentiInch).Round(6));
        Assert.AreEqual(852.480315, baseValue.Convert(LengthUnit.Meter, LengthUnit.Inch).Round(6));
        Assert.AreEqual(852.47861, baseValue.Convert(LengthUnit.Meter, LengthUnit.Inch_US).Round(6));
        Assert.AreEqual(21.653E6, baseValue.Convert(LengthUnit.Meter, LengthUnit.Micron).Round(6));
        Assert.AreEqual(0.004485, baseValue.Convert(LengthUnit.Meter, LengthUnit.League).Round(6));
        Assert.AreEqual(0.004485, baseValue.Convert(LengthUnit.Meter, LengthUnit.League_US).Round(6));
        Assert.AreEqual(0.003897, baseValue.Convert(LengthUnit.Meter, LengthUnit.NauticalLeague).Round(6));
        Assert.AreEqual(0.003895, baseValue.Convert(LengthUnit.Meter, LengthUnit.NauticalLeague_UK).Round(6));
        Assert.AreEqual(0.107636, baseValue.Convert(LengthUnit.Meter, LengthUnit.Furlong).Round(6));
        Assert.AreEqual(0.107636, baseValue.Convert(LengthUnit.Meter, LengthUnit.Furlong_US).Round(6));
        Assert.AreEqual(1.076364, baseValue.Convert(LengthUnit.Meter, LengthUnit.Chain).Round(6));
        Assert.AreEqual(1.076362, baseValue.Convert(LengthUnit.Meter, LengthUnit.Chain_US).Round(6));
        Assert.AreEqual(3.552001, baseValue.Convert(LengthUnit.Meter, LengthUnit.Rope).Round(6));
        Assert.AreEqual(4.305456, baseValue.Convert(LengthUnit.Meter, LengthUnit.Rod).Round(6));
        Assert.AreEqual(4.305448, baseValue.Convert(LengthUnit.Meter, LengthUnit.Rod_US).Round(6));
        Assert.AreEqual(4.305456, baseValue.Convert(LengthUnit.Meter, LengthUnit.Perch).Round(6));
        Assert.AreEqual(4.305456, baseValue.Convert(LengthUnit.Meter, LengthUnit.Pole).Round(6));
        Assert.AreEqual(11.840004, baseValue.Convert(LengthUnit.Meter, LengthUnit.Fathom).Round(6));
        Assert.AreEqual(11.839981, baseValue.Convert(LengthUnit.Meter, LengthUnit.Fathom_US).Round(6));
        Assert.AreEqual(18.944007, baseValue.Convert(LengthUnit.Meter, LengthUnit.Ell).Round(6));
        Assert.AreEqual(107.636403, baseValue.Convert(LengthUnit.Meter, LengthUnit.Link).Round(6));
        Assert.AreEqual(107.636188, baseValue.Convert(LengthUnit.Meter, LengthUnit.Link_US).Round(6));
        Assert.AreEqual(47.360017, baseValue.Convert(LengthUnit.Meter, LengthUnit.Cubit_UK).Round(6));
        Assert.AreEqual(46.788162, baseValue.Convert(LengthUnit.Meter, LengthUnit.Cubit_GR).Round(6));
        Assert.AreEqual(40.594301, baseValue.Convert(LengthUnit.Meter, LengthUnit.LongCubit).Round(6));
        Assert.AreEqual(213.120079, baseValue.Convert(LengthUnit.Meter, LengthUnit.Hand).Round(6));
        Assert.AreEqual(284.160105, baseValue.Convert(LengthUnit.Meter, LengthUnit.HandBreadth).Round(6));
        Assert.AreEqual(1136.64042, baseValue.Convert(LengthUnit.Meter, LengthUnit.FingerBreadth).Round(6));
        Assert.AreEqual(94.720035, baseValue.Convert(LengthUnit.Meter, LengthUnit.Span_Cloth).Round(6));
        Assert.AreEqual(189.44007, baseValue.Convert(LengthUnit.Meter, LengthUnit.Finger_Cloth).Round(6));
        Assert.AreEqual(378.88014, baseValue.Convert(LengthUnit.Meter, LengthUnit.Nail_Cloth).Round(6));
        Assert.AreEqual(2557.440935, baseValue.Convert(LengthUnit.Meter, LengthUnit.Barleycorn).Round(6));
        Assert.AreEqual(409182368306.9865, baseValue.Convert(LengthUnit.Meter, LengthUnit.AtomicUnitOfLength).Round(6));
        Assert.AreEqual(216529999999.99997, baseValue.Convert(LengthUnit.Meter, LengthUnit.Angstrom).Round(6));
        Assert.AreEqual(21652999999999996, baseValue.Convert(LengthUnit.Meter, LengthUnit.Fermi).Round(6));
        Assert.AreEqual(1.3398719099037778E+36, baseValue.Convert(LengthUnit.Meter, LengthUnit.PlanckLength).Round(6));
        Assert.AreEqual(7683979407204889, baseValue.Convert(LengthUnit.Meter, LengthUnit.ElectronRadius).Round(6));
        Assert.AreEqual(409182368306.9865, baseValue.Convert(LengthUnit.Meter, LengthUnit.BohrRadius).Round(6));
        Assert.AreEqual(216080552450902.1, baseValue.Convert(LengthUnit.Meter, LengthUnit.XUnit).Round(6));
        Assert.AreEqual(0.37, baseValue.Convert(LengthUnit.Meter, LengthUnit.Arpent).Round(6));
        Assert.AreEqual(5114.88193, baseValue.Convert(LengthUnit.Meter, LengthUnit.Pica).Round(6));
        Assert.AreEqual(61378.578811, baseValue.Convert(LengthUnit.Meter, LengthUnit.Point).Round(6));
        Assert.AreEqual(1227570.88027, baseValue.Convert(LengthUnit.Meter, LengthUnit.Twip).Round(6));
        Assert.AreEqual(36.466504, baseValue.Convert(LengthUnit.Meter, LengthUnit.Aln).Round(6));
        Assert.AreEqual(12.155501, baseValue.Convert(LengthUnit.Meter, LengthUnit.Famn).Round(6));
        Assert.AreEqual(85248.031496, baseValue.Convert(LengthUnit.Meter, LengthUnit.Caliber).Round(6));
        Assert.AreEqual(10.221587, baseValue.Convert(LengthUnit.Meter, LengthUnit.Ken).Round(6));
        Assert.AreEqual(30.445726, baseValue.Convert(LengthUnit.Meter, LengthUnit.RussianArchin).Round(6));
        Assert.AreEqual(0.61031, baseValue.Convert(LengthUnit.Meter, LengthUnit.RomanActus).Round(6));
        Assert.AreEqual(8.642339, baseValue.Convert(LengthUnit.Meter, LengthUnit.VaraDeTarea).Round(6));
        Assert.AreEqual(8.642339, baseValue.Convert(LengthUnit.Meter, LengthUnit.VaraConuquera).Round(6));
        Assert.AreEqual(25.927017, baseValue.Convert(LengthUnit.Meter, LengthUnit.VaraCastellana).Round(6));
    }
}