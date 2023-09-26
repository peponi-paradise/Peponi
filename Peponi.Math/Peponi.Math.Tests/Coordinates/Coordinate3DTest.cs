using Peponi.Math.Coordinates;
using Peponi.Math.Extensions;

namespace Peponi.Math.Tests.Coordinate;

#nullable disable

[TestClass]
public class Coordinate3DTest
{
    private CartesianCoordinate3D _coordinate;

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

        _coordinate.X = 1;
        _coordinate.Y = 2;
        _coordinate.Z = 3;

        Assert.IsTrue(eventsReceived.Count() == 3);
        Assert.IsTrue(_coordinate.X == 1);
        Assert.IsTrue(_coordinate.Y == 2);
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
        var (X, Y, Z) = _coordinate;
        Assert.AreEqual((3d, 4d, 5d), (X, Y, Z));
    }

    [TestMethod]
    public void GetDistanceFromOriginTest()
    {
        Assert.AreEqual(7.071068, _coordinate.GetDistanceFromOrigin().Round(6));
    }

    [TestMethod]
    public void ToStringTest()
    {
        Assert.AreEqual("3, 4, 5", _coordinate.ToString());
    }
}