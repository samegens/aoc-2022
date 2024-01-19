namespace SolverTests;

public class PointTests
{
    [Test]
    public void TestManhattanDistanceTo()
    {
        // Arrange
        Point p1 = new(5, 10);
        Point p2 = new(8, 5);

        // Act
        int manhattanDistance = p1.GetManhattanDistanceTo(p2);

        // Assert
        Assert.That(manhattanDistance, Is.EqualTo(8));
        Assert.That(manhattanDistance, Is.EqualTo(p2.GetManhattanDistanceTo(p1)));
    }
}