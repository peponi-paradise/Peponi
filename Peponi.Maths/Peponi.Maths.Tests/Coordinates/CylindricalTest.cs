using Peponi.Maths.Coordinates;
using Peponi.Maths.Extensions;

namespace Peponi.Maths.Tests.Coordinate;

#nullable disable

[TestClass]
public class CylindricalTest
{
    private CylindricalCoordinate<int> _coordinate;

    [TestInitialize]
    public void TestInitialize()
    {
        _coordinate = new(3, 4, 5);
    }

    [TestMethod]
    public void ComponentsTest()
    {
        List<string> eventsReceived = new();

        _coordinate.PropertyChanged += (o, e) => eventsReceived.Add(e.PropertyName);

        _coordinate.R = 1;
        _coordinate.Theta = 2;
        _coordinate.Z = 3;

        Assert.IsTrue(eventsReceived.Count() == 3);
        Assert.IsTrue(_coordinate.R == 1);
        Assert.IsTrue(_coordinate.Theta == 2);
        Assert.IsTrue(_coordinate.Z == 3);
    }

    [TestMethod]
    public void ctorTest()
    {
        _coordinate = new();
        _coordinate = new(3, 4, 5);
    }

    [TestMethod]
    public void DeconstructTest()
    {
        var (R, Theta, Z) = _coordinate;
        Assert.AreEqual((3, 4, 5), (R, Theta, Z));
    }

    [TestMethod]
    public void GetDistanceFromOriginTest()
    {
        Assert.AreEqual(5.830952, _coordinate.GetDistanceFromOrigin().Round(6));
    }

    [TestMethod]
    public void ToStringTest()
    {
        Assert.AreEqual("3, 4, 5", _coordinate.ToString());
    }
}