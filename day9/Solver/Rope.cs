using System.Text;
using NLog;

namespace AoC;

public class Rope
{
    private static readonly Logger Log = LogManager.GetCurrentClassLogger();

    public List<Point> Knots { get; }

    public Point Head => Knots.First();

    public Point Tail => Knots.Last();

    public Rope(List<Point> knots)
    {
        Knots = knots;
    }

    public void MoveHead(Direction direction)
    {
        Point delta = Instruction.DirectionMovements[direction];
        Knots[0] = Knots[0].Move(delta);
        for (int i = 1; i < Knots.Count; i++)
        {
            UpdateKnot(i);
        }

        Log.Trace(this);
    }

    public override string ToString()
    {
        const int extraSpacing = 2;
        // Always include (0, 0) so we can show the start position.
        int minX = Math.Min(0, Knots.Min(k => k.X)) - extraSpacing;
        int maxX = Math.Max(0, Knots.Max(k => k.X)) + extraSpacing;
        int minY = Math.Min(0, Knots.Min(k => k.Y)) - extraSpacing;
        int maxY = Math.Max(0, Knots.Max(k => k.Y)) + extraSpacing;

        StringBuilder sb = new($"{Knots.Count} knots:");
        sb.AppendLine();
        for (int y = minY; y <= maxY; y++)
        {
            for (int x = minX; x <= maxX; x++)
            {
                char ch = GetCharAt(x, y);
                sb.Append(ch);
            }
            sb.AppendLine();
        }

        return sb.ToString();
    }

    private char GetCharAt(int x, int y)
    {
        Point p = new(x, y);
        int index = Knots.IndexOf(p);

        if (index == 0)
        {
            return 'H';
        }

        if (index == Knots.Count - 1)
        {
            return 'T';
        }

        if (index > 0)
        {
            return (char)('0' + index);
        }

        if (x == 0 && y == 0)
        {
            return 's';
        }

        return '.';
    }

    private void UpdateKnot(int knotIndex)
    {
        Point knot = Knots[knotIndex];
        Point predecessor = Knots[knotIndex - 1];

        int dX = predecessor.X - knot.X;
        int dY = predecessor.Y - knot.Y;

        if (Math.Abs(dX) >= 2 || Math.Abs(dY) >= 2)
        {
            knot.X += Math.Sign(dX);
            knot.Y += Math.Sign(dY);
            Knots[knotIndex] = knot;
        }
    }
}