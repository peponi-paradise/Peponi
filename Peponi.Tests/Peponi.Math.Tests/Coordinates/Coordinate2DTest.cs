using Peponi.Math.Coordinates;

namespace Peponi.Math.Tests.Coordinate;

#nullable disable

[TestClass]
public class Coordinate2DTest
{
    private CartesianCoordinate2D _coordinate;

    [TestInitialize]
    public void TestInitialize()
    {
        _coordinate = new(3, 4);
    }

    [TestMethod]
    public void ComponentsTest()
    {
        List<string> eventsReceived = new();

        _coordinate.PropertyChanged += (o, e) => eventsReceived.Add(e.PropertyName);

        _coordinate.X = 1;
        _coordinate.Y = 2;

        Assert.IsTrue(eventsReceived.Count() == 2);
        Assert.IsTrue(_coordinate.X == 1);
        Assert.IsTrue(_coordinate.Y == 2);
    }

    [TestMethod]
    public void ctorTest()
    {
        _coordinate = new();
        _coordinate = new(3, 4);
    }

    [TestMethod]
    public void DeconstructTest()
    {
        var (X, Y) = _coordinate;
        Assert.AreEqual((3d, 4d), (X, Y));
    }

    [TestMethod]
    public void GetDistanceFromOriginTest()
    {
        Assert.AreEqual(5, _coordinate.GetDistanceFromOrigin());
    }

    [TestMethod]
    public void ToStringTest()
    {
        Assert.AreEqual("3, 4", _coordinate.ToString());
    }
}