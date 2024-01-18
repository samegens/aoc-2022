using NLog;

namespace AoC;

public class Solver
{
    private static readonly Logger Log = LogManager.GetCurrentClassLogger();
    private readonly string[] _lines;

    public Solver(string[] lines)
    {
        _lines = lines;
    }

    public int SolvePart1()
    {
        return Solve(2);
    }

    public int SolvePart2()
    {
        return Solve(10);
    }

    private int Solve(int nrKnots)
    {
        Log.Debug($"nrKnots = {nrKnots}");
        IEnumerable<Instruction> instructions = _lines.Select(Instruction.FromLine);
        List<Point> knots = new();
        for (int i = 0; i < nrKnots; i++)
        {
            knots.Add(new Point(0, 0));
        }
        Rope rope = new(knots);

        HashSet<Point> visitedPoints = new()
        {
            new Point(0, 0)
        };

        foreach (Instruction instruction in instructions)
        {
            Log.Debug(instruction);
            for (int step = 0; step < instruction.NrSteps; step++)
            {
                Log.Trace($"{step + 1} from {instruction.NrSteps}");
                rope.MoveHead(instruction.Direction);
                visitedPoints.Add(rope.Tail);
            }
        }

        return visitedPoints.Count;
    }
}