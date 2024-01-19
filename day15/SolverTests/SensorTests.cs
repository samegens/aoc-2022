namespace SolverTests;

public class SensorTests
{
    [Test]
    public void TestParse()
    {
        // Arrange
        string line = "Sensor at x=2, y=18: closest beacon is at x=-2, y=15";

        // Act
        Sensor sensor = Sensor.Parse(line);

        // Assert
        Assert.That(sensor.Location, Is.EqualTo(new Point(2, 18)));
        Assert.That(sensor.NearestBeaconLocation, Is.EqualTo(new Point(-2, 15)));
    }

    [Test]
    public void TestManhattanRadius()
    {
        // Arrange
        string line = "Sensor at x=2, y=18: closest beacon is at x=-2, y=15";
        Sensor sut = Sensor.Parse(line);

        // Act
        int manhattanRadius = sut.ManhattanRadius;

        // Assert
        Assert.That(manhattanRadius, Is.EqualTo(7));
    }

    [TestCase(0, 0, 1, 0, 0, true)]
    [TestCase(0, 0, 1, 0, 1, true)]
    [TestCase(0, 0, 1, 0, -1, true)]
    [TestCase(0, 0, 1, 0, 2, false)]
    [TestCase(0, 0, 1, 0, -2, false)]
    public void TestOverlapsY(int sensorX, int sensorY, int nearestBeaconX, int nearestBeaconY, int y, bool expected)
    {
        // Arrange
        Sensor sut = new(new Point(sensorX, sensorY), new Point(nearestBeaconX, nearestBeaconY));

        // Act
        bool actual = sut.OverlapsY(y);

        // Assert
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void TestEdgePoints()
    {
        // Arrange
        Sensor sut = new(new Point(0, 0), new Point(0, 1));

        // Act
        List<Point> edgePoints = sut.EdgePoints.ToList();

        // Assert
        List<Point> expected = new()
        {
            new Point(0, 2),
            new Point(1, 1),
            new Point(2, 0),
            new Point(1, -1),
            new Point(0, -2),
            new Point(-1, -1),
            new Point(-2, 0),
            new Point(-1, 1)
        };
        Assert.That(edgePoints, Is.EqualTo(expected));
    }

    [TestCase(0, 0, false)]
    [TestCase(0, 1, false)]
    [TestCase(0, 2, true)]
    [TestCase(0, 3, false)]
    public void TestIsPointOnEdge(int x, int y, bool expected)
    {
        // Arrange
        Sensor sut = new(new Point(0, 0), new Point(1, 0));

        // Act
        bool actual = sut.IsPointOnEdge(new Point(x, y));

        // Assert
        Assert.That(actual, Is.EqualTo(expected));
    }

    [TestCase(0, 0, true)]
    [TestCase(0, 1, true)]
    [TestCase(0, 2, false)]
    [TestCase(0, 3, false)]
    public void TestIsCovering(int x, int y, bool expected)
    {
        // Arrange
        Sensor sut = new(new Point(0, 0), new Point(1, 0));

        // Act
        bool actual = sut.IsCovering(new Point(x, y));

        // Assert
        Assert.That(actual, Is.EqualTo(expected));
    }
}
