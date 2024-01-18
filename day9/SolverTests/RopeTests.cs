namespace SolverTests;

public class RopeTests
{
    // Head and tail are on the same position.
    [TestCase(0, 0, 0, 0, Direction.Right, 1, 0, 0, 0)]
    [TestCase(0, 0, 0, 0, Direction.Down, 0, 1, 0, 0)]
    [TestCase(0, 0, 0, 0, Direction.Left, -1, 0, 0, 0)]
    [TestCase(0, 0, 0, 0, Direction.Up, 0, -1, 0, 0)]

    // Head is one step to a direction and steps in the same direction.
    [TestCase(1, 0, 0, 0, Direction.Right, 2, 0, 1, 0)]
    [TestCase(0, 1, 0, 0, Direction.Down, 0, 2, 0, 1)]
    [TestCase(-1, 0, 0, 0, Direction.Left, -2, 0, -1, 0)]
    [TestCase(0, -1, 0, 0, Direction.Up, 0, -2, 0, -1)]

    // Head is diagonal and steps one step further.
    [TestCase(1, -1, 0, 0, Direction.Up, 1, -2, 1, -1)]
    [TestCase(1, -1, 0, 0, Direction.Up, 1, -2, 1, -1)]
    [TestCase(1, 1, 0, 0, Direction.Right, 2, 1, 1, 1)]
    [TestCase(1, 1, 0, 0, Direction.Down, 1, 2, 1, 1)]
    [TestCase(-1, 1, 0, 0, Direction.Down, -1, 2, -1, 1)]
    [TestCase(-1, 1, 0, 0, Direction.Left, -2, 1, -1, 1)]
    [TestCase(-1, -1, 0, 0, Direction.Left, -2, -1, -1, -1)]
    [TestCase(-1, -1, 0, 0, Direction.Up, -1, -2, -1, -1)]
    public void TestMoveHead(int startXHead, int startYHead, int startXTail, int startYTail, Direction direction,
                             int endXHead, int endYHead, int endXTail, int endYTail)
    {
        // Arrange
        List<Point> knots = new()
        {
            new Point(startXHead, startYHead),
            new Point(startXTail, startYTail)
        };
        Rope sut = new(knots);

        // Act
        sut.MoveHead(direction);

        // Assert
        Assert.That(sut.Head, Is.EqualTo(new Point(endXHead, endYHead)));
        Assert.That(sut.Tail, Is.EqualTo(new Point(endXTail, endYTail)));
    }
}