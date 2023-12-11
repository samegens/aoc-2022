namespace SolverTests;

public class SolverTests
{
    [Test]
    public void TestSolvePart1()
    {
        // Arrange
        Solver solver = new();
        string line = @"mjqjpqmgbljsphdztnvjfqwrcgsmlb";

        // Act
        int result = solver.SolvePart1(line);

        // Assert
        Assert.That(result, Is.EqualTo(7));
    }

    [Test]
    public void TestSolvePart2()
    {
        // Arrange
        Solver solver = new();
        string line = @"mjqjpqmgbljsphdztnvjfqwrcgsmlb";

        // Act
        int result = solver.SolvePart2(line);

        // Assert
        Assert.That(result, Is.EqualTo(19));
    }
}