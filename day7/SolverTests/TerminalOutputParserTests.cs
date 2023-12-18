namespace SolverTests;

public class TerminalOutputParserTests
{
    private static readonly string[] Lines = @"$ cd /
$ ls
dir a
14848514 b.txt
8504156 c.dat
dir d
$ cd a
$ ls
dir e
29116 f
2557 g
62596 h.lst
$ cd e
$ ls
584 i
$ cd ..
$ cd ..
$ cd d
$ ls
4060174 j
8033020 d.log
5626152 d.ext
7214296 k".Split('\n');

    [Test]
    public void TestParse()
    {
        // Arrange
        TerminalOutputParser parser = new();

        // Act
        AoC.Directory actual = parser.Parse(Lines);

        // Assert
        Assert.That(actual.Name, Is.EqualTo("/"));
        Assert.That(actual.FileSizes.Count, Is.EqualTo(2));
        Assert.That(actual.FileSizes["b.txt"], Is.EqualTo(14848514));
        Assert.That(actual.Subdirectories.Count(), Is.EqualTo(2));
        AoC.Directory subdir = actual.Subdirectories.First();
        Assert.That(subdir.Name, Is.EqualTo("a"));
        Assert.That(subdir.FileSizes.Count, Is.EqualTo(3));
        Assert.That(subdir.FileSizes["f"], Is.EqualTo(29116));
        Assert.That(subdir.Subdirectories.Count, Is.EqualTo(1));
    }
}