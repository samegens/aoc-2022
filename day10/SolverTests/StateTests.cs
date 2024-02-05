namespace SolverTests;

public class StateTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void TestNoop()
    {
        // Arrange
        State state = new();
        Instruction noop = new NoopInstruction();

        // Act
        noop.ExecuteOn(state);

        // Assert
        Assert.That(state.X, Is.EqualTo(1));
        Assert.That(state.CurrentCycle, Is.EqualTo(2));
        Assert.That(state.History.Count, Is.EqualTo(2));
        Assert.That(state.History[1], Is.EqualTo(1));
        Assert.That(state.History[2], Is.EqualTo(1));
    }

    [Test]
    public void TestAdd()
    {
        // Arrange
        State state = new();
        Instruction add = new AddInstruction(41);

        // Act
        add.ExecuteOn(state);

        // Assert
        Assert.That(state.X, Is.EqualTo(42));
        Assert.That(state.CurrentCycle, Is.EqualTo(3));
        Assert.That(state.History.Count, Is.EqualTo(3));
        Assert.That(state.History[1], Is.EqualTo(1));
        Assert.That(state.History[2], Is.EqualTo(1));
        Assert.That(state.History[3], Is.EqualTo(42));
    }

    [Test]
    public void TestMultiple()
    {
        // Arrange
        string[] lines = @"noop
addx 3
addx -5".Split('\n');
        IEnumerable<Instruction> instructions = lines.Select(Instruction.Parse);
        State state = new();

        // Act
        foreach (Instruction instruction in instructions)
        {
            instruction.ExecuteOn(state);
        }

        // Assert
        Assert.That(state.History[1], Is.EqualTo(1));
        Assert.That(state.History[2], Is.EqualTo(1));
        Assert.That(state.History[3], Is.EqualTo(1));
        Assert.That(state.History[4], Is.EqualTo(4));
        Assert.That(state.History[5], Is.EqualTo(4));
        Assert.That(state.History[6], Is.EqualTo(-1));
    }
}