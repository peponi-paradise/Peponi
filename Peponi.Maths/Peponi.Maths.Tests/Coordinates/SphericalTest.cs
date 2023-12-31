﻿using Peponi.Maths.Coordinates;

namespace Peponi.Maths.Tests.Coordinate;

#nullable disable

[TestClass]
public class SphericalTest
{
    private SphericalCoordinate<double> _coordinate;

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
        _coordinate.Phi = 3;

        Assert.IsTrue(eventsReceived.Count() == 3);
        Assert.IsTrue(_coordinate.R == 1);
        Assert.IsTrue(_coordinate.Theta == 2);
        Assert.IsTrue(_coordinate.Phi == 3);
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
        var (R, Theta, Phi) = _coordinate;
        Assert.AreEqual((3d, 4d, 5d), (R, Theta, Phi));
    }

    [TestMethod]
    public void GetDistanceFromOriginTest()
    {
        Assert.AreEqual(3, _coordinate.GetDistanceFromOrigin());
    }

    [TestMethod]
    public void ToStringTest()
    {
        Assert.AreEqual("3, 4, 5", _coordinate.ToString());
    }
}