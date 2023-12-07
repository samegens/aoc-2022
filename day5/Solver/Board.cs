namespace AoC;

public class Board
{
    public List<Stack<char>> Stacks { get; } = new();
    public List<Move> Moves { get; } = new();

    public static Board Parse(string[] lines)
    {
        Board board = new();

        (int lineIndex, List<Stack<char>> stacks) = ParseStack(lines);
        board.Stacks.AddRange(stacks);

        IEnumerable<Move> moves = ParseMoves(lines.Skip(lineIndex + 1));
        board.Moves.AddRange(moves);

        return board;
    }

    private static IEnumerable<Move> ParseMoves(IEnumerable<string> lines)
    {
        return lines.Where(l => !string.IsNullOrEmpty(l.Trim()))
            .Select(Move.Parse);
    }

    private static (int emptyLineIndex, List<Stack<char>> stacks) ParseStack(string[] lines)
    {
        // Example:
        //    [D]    
        //[N] [C]    
        //[Z] [M] [P]
        // 1   2   3 
        //
        //move 1 from 2 to 1
        //...

        int emptyLineIndex = FindEmptyLineIndex(lines);
        // We have to skip the line with stack numbers to get to the last stack line.
        int lineIndex = emptyLineIndex - 2;
        // We're now located on the last line of the stacks.
        // So we can use the length of this line to see how many stacks we have.
        string line = lines[lineIndex];
        const int nrCharsPerStack = 4; // [X]_
        // Because the last stack is missing the trailing space, we have to virtually
        // add it first.
        int nrStacks = (line.Length + 1) / nrCharsPerStack;

        List<Stack<char>> stacks = CreateStacks(nrStacks);
        for (; lineIndex >= 0; lineIndex--)
        {
            line = lines[lineIndex];
            for (int stackIndex = 0; stackIndex < nrStacks; stackIndex++)
            {
                char ch = line[1 + stackIndex * nrCharsPerStack];
                if (ch != ' ')
                {
                    stacks[stackIndex].Push(ch);
                }
            }
        }

        return (emptyLineIndex, stacks);
    }

    private static List<Stack<char>> CreateStacks(int nrStacks)
    {
        List<Stack<char>> stacks = new(nrStacks);
        for (int i = 0; i < nrStacks; i++)
        {
            stacks.Add(new Stack<char>());
        }
        return stacks;
    }

    private static int FindEmptyLineIndex(string[] lines)
    {
        int lineIndex = 0;
        while (!string.IsNullOrEmpty(lines[lineIndex].Trim()))
        {
            lineIndex++;
        }
        return lineIndex;
    }

    public void ApplyMove(Move move)
    {
        for (int i = 0; i < move.Count; i++)
        {
            char ch = Stacks[move.FromIndex].Pop();
            Stacks[move.ToIndex].Push(ch);
        }
    }

    public void ApplyMove9001(Move move)
    {
        Stack<char> helpStack = new();
        for (int i = 0; i < move.Count; i++)
        {
            char ch = Stacks[move.FromIndex].Pop();
            helpStack.Push(ch);
        }

        for (int i = 0; i < move.Count; i++)
        {
            char ch = helpStack.Pop();
            Stacks[move.ToIndex].Push(ch);
        }
    }
}
