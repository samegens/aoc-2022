namespace SolverTests;

public class InstructionTests
{
    [Test]
    public void TestParseNoop()
    {
        // Arrange
        string line = "noop";

        // Act
        Instruction instruction = Instruction.Parse(line);

        // Assert
        Assert.That(instruction, Is.InstanceOf(typeof(NoopInstruction)));
    }

    [Test]
    public void TestParseAdd()
    {
        // Arrange
        string line = "addx -11";

        // Act
        Instruction instruction = Instruction.Parse(line);

        // Assert
        Assert.That(instruction, Is.InstanceOf(typeof(AddInstruction)));
        AddInstruction add = (AddInstruction)instruction;
        Assert.That(add.V, Is.EqualTo(-11));
    }
}