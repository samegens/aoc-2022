namespace SolverTests;

public class DirectoryTests
{
    [Test]
    public void TestRecursiveSize()
    {
        // Arrange
        AoC.Directory root = AoC.Directory.CreateRoot();
        root.AddFile("a", 1);
        root.AddFile("b", 2);
        AoC.Directory sub = new("sub", root);
        root.AddSubdirectory(sub);
        sub.AddFile("a", 3);
        sub.AddFile("b", 4);

        // Act
        long actual = root.RecursiveSize;

        // Assert
        Assert.That(actual, Is.EqualTo(10));
    }
}