namespace AoC;

public class Solver
{
    private string[] _lines;

    public Solver(string[] lines)
    {
        _lines = lines;
    }

    public string SolvePart1()
    {
        Board board = Board.Parse(_lines);
        foreach (Move move in board.Moves)
        {
            board.ApplyMove(move);
        }

        return string.Concat(board.Stacks.Select(s => s.Peek()));
    }

    public string SolvePart2()
    {
        Board board = Board.Parse(_lines);
        foreach (Move move in board.Moves)
        {
            board.ApplyMove9001(move);
        }

        return string.Concat(board.Stacks.Select(s => s.Peek()));
    }
}