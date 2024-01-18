namespace SolverTests;

public class SolverTests
{
    [Test]
    public void TestSolvePart1()
    {
        // Arrange
        string[] lines = @"R 4
U 4
L 3
D 1
R 4
D 1
L 5
R 2".Split("\n");
        Solver sut = new(lines);

        // Act
        int actual = sut.SolvePart1();

        // Assert
        Assert.That(actual, Is.EqualTo(13));
    }

    [Test]
    public void TestSolvePart2Short()
    {
        // Arrange
        string[] lines = @"R 4
U 4
L 3
D 1
R 4
D 1
L 5
R 2".Split("\n");
        Solver sut = new(lines);

        // Act
        int actual = sut.SolvePart2();

        // Assert
        Assert.That(actual, Is.EqualTo(1));
    }

    [Test]
    public void TestSolvePart2Long()
    {
        // Arrange
        string[] lines = @"R 5
U 8
L 8
D 3
R 17
D 10
L 25
U 20".Split("\n");
        Solver sut = new(lines);

        // Act
        int actual = sut.SolvePart2();

        // Assert
        Assert.That(actual, Is.EqualTo(36));
    }
}