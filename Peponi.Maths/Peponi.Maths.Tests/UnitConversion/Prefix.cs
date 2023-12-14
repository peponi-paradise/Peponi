using Peponi.Maths.Extensions;
using Peponi.Maths.UnitConversion;

namespace Peponi.Maths.Tests.UnitConversion;

[TestClass]
public class Prefix
{
    [TestMethod]
    public void Test()
    {
        double baseValue = 21.653;

        Assert.AreEqual(21.652999999999996E18, baseValue.Convert(PrefixUnit.None, PrefixUnit.Atto));
        Assert.AreEqual(21.652999999999996E15, baseValue.Convert(PrefixUnit.None, PrefixUnit.Femto));
        Assert.AreEqual(21.653E12, baseValue.Convert(PrefixUnit.None, PrefixUnit.Pico));
        Assert.AreEqual(21.652999999999996E9, baseValue.Convert(PrefixUnit.None, PrefixUnit.Nano));
        Assert.AreEqual(21.653E6, baseValue.Convert(PrefixUnit.None, PrefixUnit.Micro));
        Assert.AreEqual(21.653E3, baseValue.Convert(PrefixUnit.None, PrefixUnit.Milli));
        Assert.AreEqual(21.652999999999996E2, baseValue.Convert(PrefixUnit.None, PrefixUnit.Centi));
        Assert.AreEqual(21.652999999999996E1, baseValue.Convert(PrefixUnit.None, PrefixUnit.Deci));
        Assert.AreEqual(21.653E-1, baseValue.Convert(PrefixUnit.None, PrefixUnit.Deca));
        Assert.AreEqual(21.653E-2, baseValue.Convert(PrefixUnit.None, PrefixUnit.Hecto));
        Assert.AreEqual(21.653E-3, baseValue.Convert(PrefixUnit.None, PrefixUnit.Kilo));
        Assert.AreEqual(21.652999999999996E-6, baseValue.Convert(PrefixUnit.None, PrefixUnit.Mega));
        Assert.AreEqual(21.653E-9, baseValue.Convert(PrefixUnit.None, PrefixUnit.Giga));
        Assert.AreEqual(21.652999999999996E-12, baseValue.Convert(PrefixUnit.None, PrefixUnit.Tera));
        Assert.AreEqual(21.652999999999996E-15, baseValue.Convert(PrefixUnit.None, PrefixUnit.Peta));
        Assert.AreEqual(21.652999999999996E-18, baseValue.Convert(PrefixUnit.None, PrefixUnit.Exa));
    }
}