public class Range
{
    public int Start { get; }
    public int End { get; }

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
