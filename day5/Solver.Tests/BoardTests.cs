namespace Solver.Tests;

public class BoardTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void TestParse()
    {
        // Arrange
        string text = @"    [D]    
[N] [C]    
[Z] [M] [P]
 1   2   3 

move 1 from 2 to 1
move 3 from 1 to 3
move 2 from 2 to 1
move 1 from 1 to 2
";
        string[] lines = text.Split("\r\n");

        // Act
        Board board = Board.Parse(lines);

        // Assert
        Assert.That(board.Stacks.Count, Is.EqualTo(3));
        Assert.That(board.Stacks[0].Count, Is.EqualTo(2));
        Assert.That(board.Stacks[0].Pop(), Is.EqualTo('N'));
        Assert.That(board.Stacks[0].Pop(), Is.EqualTo('Z'));
        Assert.That(board.Stacks[2].Count, Is.EqualTo(1));
        Assert.That(board.Stacks[2].Pop(), Is.EqualTo('P'));
        Assert.That(board.Moves.Count, Is.EqualTo(4));
        Move expectedMove = new(count: 1, fromIndex: 1, toIndex: 0);
        Assert.That(board.Moves[0], Is.EqualTo(expectedMove));
    }

    [Test]
    public void TestApplyMove()
    {
        // Arrange
        string text = @"    [D]    
[N] [C]    
[Z] [M] [P]
 1   2   3 
";
        Board board = Board.Parse(text.Split("\r\n"));

        // Act
        board.ApplyMove(new Move(count: 2, fromIndex: 0, toIndex: 1));

        // Assert
        Assert.That(board.Stacks[1].Count, Is.EqualTo(5));
        Assert.That(board.Stacks[1].Pop(), Is.EqualTo('Z'));
        Assert.That(board.Stacks[1].Pop(), Is.EqualTo('N'));
        Assert.That(board.Stacks[1].Pop(), Is.EqualTo('D'));
    }

    [Test]
    public void TestApplyMove9001()
    {
        // Arrange
        string text = @"    [D]    
[N] [C]    
[Z] [M] [P]
 1   2   3 
";
        Board board = Board.Parse(text.Split("\r\n"));

        // Act
        board.ApplyMove9001(new Move(count: 2, fromIndex: 0, toIndex: 1));

        // Assert
        Assert.That(board.Stacks[1].Count, Is.EqualTo(5));
        Assert.That(board.Stacks[1].Pop(), Is.EqualTo('N'));
        Assert.That(board.Stacks[1].Pop(), Is.EqualTo('Z'));
        Assert.That(board.Stacks[1].Pop(), Is.EqualTo('D'));
    }
}
