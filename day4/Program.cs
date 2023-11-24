class Range
{
    int Start { get; }
    int End { get; }

    public Range(int start, int end)
    {
        Start = start;
        End = end;
    }

    public bool Contains(Range other)
    {
        return Start <= other.Start && End >= other.End;
    }

    public bool Overlaps(Range other)
    {
        return Start <= other.End && End >= other.Start;
    }
}

internal class ElfPair
{
    public Range First { get; set; }
    public Range Second { get; set; }

    public ElfPair(Range first, Range second)
    {
        First = first;
        Second = second;
    }

    internal static ElfPair Parse(string line)
    {
        // Parse lines like
        // 2-4,6-8
        string[] parts = line.Split(',');
        string[] firstParts = parts[0].Split('-');
        string[] secondParts = parts[1].Split('-');
        Range first = new(int.Parse(firstParts[0]), int.Parse(firstParts[1]));
        Range second = new(int.Parse(secondParts[0]), int.Parse(secondParts[1]));
        return new ElfPair(first, second);
    }
}

internal class Program
{
    private static void Main(string[] args)
    {
        string[] lines = File.ReadAllLines("input.txt");
        List<ElfPair> elfPairs = ParseLines(lines);
        SolvePart1(elfPairs);
        SolvePart2(elfPairs);
    }

    private static List<ElfPair> ParseLines(string[] lines)
    {
        // into ElfPair objects
        List<ElfPair> elfPairs = new();
        foreach (string line in lines)
        {
            elfPairs.Add(ElfPair.Parse(line));
        }
        return elfPairs;
    }

    private static void SolvePart1(List<ElfPair> elfPairs)
    {
        int containedCount = 0;
        foreach (ElfPair pair in elfPairs)
        {
            if (pair.First.Contains(pair.Second) || pair.Second.Contains(pair.First))
            {
                containedCount++;
            }
        }

        Console.WriteLine($"Part 1: {containedCount}");
    }

    private static void SolvePart2(List<ElfPair> elfPairs)
    {
        int containedCount = 0;
        foreach (ElfPair pair in elfPairs)
        {
            if (pair.First.Overlaps(pair.Second))
            {
                containedCount++;
            }
        }

        Console.WriteLine($"Part 2: {containedCount}");
    }
}
