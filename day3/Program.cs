

internal class Program
{
    private static void Main(string[] args)
    {
        string[] lines = File.ReadAllLines("input.txt");
        SolvePart1(lines);
        SolvePart2(lines);
    }

    private static void SolvePart1(string[] lines)
    {
        int totalPriority = 0;

        foreach (string line in lines)
        {
            int len = line.Length;
            HashSet<char> rucksack1Items = new(line[..(len / 2)]);
            HashSet<char> rucksack2Items = new(line[(len / 2)..]);
            char commonItem = rucksack1Items.Intersect(rucksack2Items).Single();
            int prio = GetPriority(commonItem);
            totalPriority += prio;
        }

        Console.WriteLine($"Part 1: {totalPriority}");
    }

    private static void SolvePart2(string[] lines)
    {
        int totalPriority = 0;
        for (int i = 0; i < lines.Length / 3; i++)
        {
            var rucksack1Items = new HashSet<char>(lines[i * 3]);
            var rucksack2Items = new HashSet<char>(lines[i * 3 + 1]);
            var rucksack3Items = new HashSet<char>(lines[i * 3 + 2]);
            char commonItem = rucksack1Items.Intersect(rucksack2Items).Intersect(rucksack3Items).Single();
            totalPriority += GetPriority(commonItem);
        }

        Console.WriteLine($"Part 2: {totalPriority}");
    }

    private static int GetPriority(char rucksackItem)
    {
        if (rucksackItem >= 'a' && rucksackItem <= 'z')
        {
            return rucksackItem - 'a' + 1;
        }

        return rucksackItem - 'A' + 27;
    }
}