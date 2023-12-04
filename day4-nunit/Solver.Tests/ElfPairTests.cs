namespace Solver.Tests;

public class ElfPairTests
{
    [Test]
    public void TestParse()
    {
        // Arrange
        string text = "2-4,6-8";

        // Act
        ElfPair elfPair = ElfPair.Parse(text);

        // Assert
        Assert.That(elfPair.First.Start, Is.EqualTo(2));
        Assert.That(elfPair.First.End, Is.EqualTo(4));
        Assert.That(elfPair.Second.Start, Is.EqualTo(6));
        Assert.That(elfPair.Second.End, Is.EqualTo(8));
    }
}