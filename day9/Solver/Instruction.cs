
namespace AoC;

public enum Direction
{
    Right,
    Down,
    Left,
    Up
}

public class Instruction
{
    public static readonly Dictionary<Direction, Point> DirectionMovements = new()
    {
        [Direction.Right] = new Point(1, 0),
        [Direction.Down] = new Point(0, 1),
        [Direction.Left] = new Point(-1, 0),
        [Direction.Up] = new Point(0, -1),
    };

    public Direction Direction { get; }

    public int NrSteps { get; }

    public Instruction(Direction direction, int nrSteps)
    {
        Direction = direction;
        NrSteps = nrSteps;
    }

    public static Instruction FromLine(string line)
    {
        string[] parts = line.Split(' ');

        char directionChar = parts[0][0];
        Direction direction = directionChar switch
        {
            'R' => Direction.Right,
            'D' => Direction.Down,
            'L' => Direction.Left,
            'U' => Direction.Up,
            _ => throw new Exception($"Invalid direction char {directionChar}")
        };

        int nrSteps = int.Parse(parts[1]);

        return new Instruction(direction, nrSteps);
    }

    public override string ToString()
    {
        return $"{NrSteps}*{Direction}";
    }
}