class Program
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
