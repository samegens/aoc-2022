namespace SolverTests;

public class MoveTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void TestParse()
    {
        // Arrange
        string text = "move 1 from 2 to 3";

        // Act
        Move move = Move.Parse(text);

        // Assert
        Move expectedMove = new(count: 1, fromIndex: 1, toIndex: 2);
        Assert.That(move, Is.EqualTo(expectedMove));
    }
}
