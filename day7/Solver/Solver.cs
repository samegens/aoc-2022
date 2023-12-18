namespace AoC;

public class Solver
{
    private readonly string[] _lines;

    public Solver(string[] lines)
    {
        _lines = lines;
    }

    public long SolvePart1()
    {
        return new TerminalOutputParser()
            .Parse(_lines)
            .GetDirectoriesRecursively()
            .Select(d => d.RecursiveSize)
            .Where(s => s <= 100000)
            .Sum();
    }

    public long SolvePart2()
    {
        const long FileSystemSize = 70000000;
        const long MinFreeSpaceRequired = 30000000;
        Directory root = new TerminalOutputParser().Parse(_lines);
        long unusedSpace = FileSystemSize - root.RecursiveSize;
        return root.GetDirectoriesRecursively()
            .Select(d => d.RecursiveSize)
            .Where(s => unusedSpace + s >= MinFreeSpaceRequired)
            .Min();
    }
}