namespace SolverTests;

public class SolverTests
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
    private static readonly Solver _sut = new(Lines);

    [Test]
    public void TestSolvePart1()
    {
        // Act
        long actual = _sut.SolvePart1();

        // Assert
        Assert.That(actual, Is.EqualTo(95437));
    }

    [Test]
    public void TestSolvePart2()
    {
        // Act
        long actual = _sut.SolvePart2();

        // Assert
        Assert.That(actual, Is.EqualTo(24933642));
    }
}