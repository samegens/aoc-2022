public class Move
{
    public int Count { get; private set; }

    /// <summary>
    /// 0-based index of the source stack.
    /// </summary>
    /// <remarks>
    /// Note that this is different from the puzzle description.
    /// This is done so we can directly access the proper stack without
    /// the need to transform from 1-based to 0-based all the time.
    /// </remarks>
    public int FromIndex { get; private set; }

    /// <summary>
    /// 0-based index of the destination stack.
    /// </summary>
    public int ToIndex { get; private set; }

    public Move(int count, int fromIndex, int toIndex)
    {
        Count = count;
        FromIndex = fromIndex;
        ToIndex = toIndex;
    }

    public static Move Parse(string line)
    {
        // Example:
        //move 1 from 2 to 1
        string[] parts = line.Split(" ");
        int count = int.Parse(parts[1]);

        // Transfrom from 1-based to 0-based because that's what Move requires.
        int fromIndex = int.Parse(parts[3]) - 1;
        int toIndex = int.Parse(parts[5]) - 1;

        return new Move(count, fromIndex, toIndex);
    }

    public override bool Equals(object? obj)
    {
        // If the passed object is null or the types are not the same, they are not equal
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }

        var other = (Move)obj;

        // Check if all the properties are equal
        return Count == other.Count &&
            FromIndex == other.FromIndex &&
            ToIndex == other.ToIndex;
    }

    public override int GetHashCode() => (Count, FromIndex, ToIndex).GetHashCode();
}
