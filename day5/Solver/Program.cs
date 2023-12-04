

class Program
{
    private static void Main(string[] args)
    {
        string[] lines = File.ReadAllLines("input.txt");
        SolvePart1(lines);
        SolvePart2(lines);
    }

    private static void SolvePart1(string[] lines)
    {
        Board board = Board.Parse(lines);
        foreach (Move move in board.Moves)
        {
            board.ApplyMove(move);
        }

        string topCrates = string.Concat(board.Stacks.Select(s => s.Peek()));
        Console.WriteLine($"Part 1: {topCrates}");
    }

    private static void SolvePart2(string[] lines)
    {
        Board board = Board.Parse(lines);
        foreach (Move move in board.Moves)
        {
            board.ApplyMove9001(move);
        }

        string topCrates = string.Concat(board.Stacks.Select(s => s.Peek()));
        Console.WriteLine($"Part 2: {topCrates}");
    }
}
