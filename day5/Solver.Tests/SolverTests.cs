namespace SolverTests;

public class SolverTests
{
    private Solver _solver;

    [SetUp]
    public void Setup()
    {
        string[] input = @"    [D]    
[N] [C]    
[Z] [M] [P]
 1   2   3 

move 1 from 2 to 1
move 3 from 1 to 3
move 2 from 2 to 1
move 1 from 1 to 2".Split("\n");
        _solver = new Solver(input);
    }

    [Test]
    public void TestSolve1()
    {
        // Act
        string result = _solver.SolvePart1();

        // Assert
        Assert.That(result, Is.EqualTo("CMZ"));
    }

    [Test]
    public void TestSolve2()
    {
        // Act
        string result = _solver.SolvePart2();

        // Assert
        Assert.That(result, Is.EqualTo("MCD"));
    }
}
