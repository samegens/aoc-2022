namespace SolverTests;

public class InstructionTests
{
    [TestCase("R 4", Direction.Right, 4)]
    [TestCase("D 5", Direction.Down, 5)]
    [TestCase("L 6", Direction.Left, 6)]
    [TestCase("U 42", Direction.Up, 42)]
    public void TestFromLine(string line, Direction expectedDirection, int expectedNrSteps)
    {
        // Arrange

        // Act
        Instruction instruction = Instruction.FromLine(line);

        // Assert
        Assert.That(instruction.Direction, Is.EqualTo(expectedDirection));
        Assert.That(instruction.NrSteps, Is.EqualTo(expectedNrSteps));
    }
}