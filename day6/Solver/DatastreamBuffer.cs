namespace AoC;

public class DatastreamBuffer
{
    private readonly string _characters;
    private readonly int _windowSize;

    public DatastreamBuffer(string line, int windowSize)
    {
        _characters = line;
        _windowSize = windowSize;
    }

    public string GetWindowAt(int index)
    {
        return _characters.Substring(index, _windowSize);
    }

    /// <summary>
    /// Returns the 1-based index of the character that completes the marker.
    /// </summary>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public int GetNrCharsForMarker()
    {
        for (int index = 0; index < _characters.Length - 4; index++)
        {
            string window = GetWindowAt(index);
            HashSet<char> uniqueChars = new(window);
            if (uniqueChars.Count == _windowSize)
            {
                return index + _windowSize;
            }
        }

        throw new Exception("Marker not found");
    }
}