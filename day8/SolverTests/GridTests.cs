namespace SolverTests;

public class GridTests
{
    private static readonly string[] Lines = @"30373
25512
65332
33549
35390".Split("\r\n");

    [TestCase(0, 0, 3)]
    [TestCase(4, 4, 0)]
    [TestCase(2, 2, 3)]
    public void TestIndexer(int x, int y, byte expected)
    {
        // Arrange
        Grid sut = new(Lines);

        // Act
        byte actual = sut[x, y];

        // Assert
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void TestGetNrVisibleTrees()
    {
        // Arrange
        Grid sut = new(Lines);

        // Act
        int actual = sut.GetNrVisibleTrees();

        // Assert
        Assert.That(actual, Is.EqualTo(21));
    }

    [TestCase(2, 1, 4)]
    [TestCase(2, 3, 8)]
    public void TestGetScenicScoreFor(int x, int y, int expected)
    {
        // Arrange
        Grid sut = new(Lines);

        // Act
        int actual = sut.GetScenicScoreFor(x, y);

        // Assert
        Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void TestGetHighestScenicScore()
    {
        // Arrange
        Grid sut = new(Lines);

        // Act
        int actual = sut.GetHighestScenicScore();

        // Assert
        Assert.That(actual, Is.EqualTo(8));
    }
}