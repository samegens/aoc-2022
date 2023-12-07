namespace Solver.Tests;

public class RangeTests
{
    [Test]
    public void TestContains()
    {
        // Arrange
        Range range1 = new(start: 1, end: 5);
        Range range2 = new(start: 2, end: 4);

        // Act
        bool result = range1.Contains(range2);

        // Assert
        Assert.That(result, Is.True);
    }

    [TestCase(1, 5, 2, 4, true)]
    [TestCase(1, 5, 1, 5, true)]
    [TestCase(1, 5, 2, 6, false)]
    [TestCase(2, 4, 1, 5, false)]
    [TestCase(1, 3, 5, 6, false)]
    public void TestContainsWithTestCase(int range1Start, int range1End,
        int range2Start, int range2End, bool expectedResult)
    {
        // Arrange
        Range range1 = new(start: range1Start, end: range1End);
        Range range2 = new(start: range2Start, end: range2End);

        // Act
        bool result = range1.Contains(range2);

        // Assert
        Assert.That(result, Is.EqualTo(expectedResult));
    }

    [TestCase(1, 5, 2, 4, true)]
    [TestCase(1, 5, 1, 5, true)]
    [TestCase(1, 5, 2, 6, true)]
    [TestCase(2, 4, 1, 5, true)]
    [TestCase(1, 3, 5, 6, false)]
    public void TestOverlaps(int range1Start, int range1End, int range2Start, int range2End, bool expectedResult)
    {
        // Arrange
        Range range1 = new(start: range1Start, end: range1End);
        Range range2 = new(start: range2Start, end: range2End);

        // Act
        bool result = range1.Overlaps(range2);

        // Assert
        Assert.That(result, Is.EqualTo(expectedResult));
    }
}