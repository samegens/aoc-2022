public class ElfPair
{
    public Range First { get; set; }
    public Range Second { get; set; }

    public ElfPair(Range first, Range second)
    {
        First = first;
        Second = second;
    }

    public static ElfPair Parse(string line)
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
