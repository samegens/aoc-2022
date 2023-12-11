namespace AoC;

public class Solver
{
    public int SolvePart1(string line)
    {
        DatastreamBuffer datastreamBuffer = new(line, 4);
        return datastreamBuffer.GetNrCharsForMarker();
    }

    public int SolvePart2(string line)
    {
        DatastreamBuffer datastreamBuffer = new(line, 14);
        return datastreamBuffer.GetNrCharsForMarker();
    }
}