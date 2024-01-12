namespace AoC;

public class Grid
{
    private readonly byte[,] _cells;
    private readonly bool[,] _isCellVisible;

    public int Width { get; }

    public int Height { get; }

    public byte this[int x, int y] => _cells[x, y];


    public Grid(string[] lines)
    {
        Width = lines[0].Length;
        Height = lines.Length;

        _cells = new byte[Width, Height];
        _isCellVisible = new bool[Width, Height];
        ForEachPosition((x, y) => _cells[x, y] = CharNumberToByte(lines[y][x]));
    }

    /// <summary>
    /// Applies an action (lamda) to each position in the grid.
    /// </summary>
    public void ForEachPosition(Action<int, int> action)
    {
        for (int y = 0; y < Height; y++)
        {
            for (int x = 0; x < Width; x++)
            {
                action(x, y);
            }
        }
    }

    /// <summary>
    /// Returns a sequence (IEnumerable) with the positions of each cell.
    /// </summary>
    public IEnumerable<(int x, int y)> Positions
    {
        get
        {
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    yield return (x, y);
                }
            }
        }
    }

    public int GetNrVisibleTrees()
    {
        SetIsVisibleForHorizontalDirection(dx: 1);
        SetIsVisibleForHorizontalDirection(dx: -1);
        SetIsVisibleForVerticalDirection(dy: 1);
        SetIsVisibleForVerticalDirection(dy: -1);
        return GetNrVisibleCells();
    }

    public int GetScenicScoreFor(int x, int y)
    {
        byte treeHeight = _cells[x, y];
        return GetViewingDistanceFor(x, y, dx: 1, dy: 0, treeHeight) *
            GetViewingDistanceFor(x, y, dx: 0, dy: 1, treeHeight) *
            GetViewingDistanceFor(x, y, dx: -1, dy: 0, treeHeight) *
            GetViewingDistanceFor(x, y, dx: 0, dy: -1, treeHeight);
    }

    private int GetViewingDistanceFor(int x, int y, int dx, int dy, byte treeHeight)
    {
        x += dx;
        y += dy;
        if (x < 0 || x >= Width || y < 0 || y >= Height)
        {
            return 0;
        }

        byte treeHeightHere = _cells[x, y];
        if (treeHeightHere >= treeHeight)
        {
            return 1;
        }

        return 1 + GetViewingDistanceFor(x, y, dx, dy, treeHeight);
    }

    public int GetHighestScenicScore()
    {
        return Positions.Select(pos => GetScenicScoreFor(pos.x, pos.y)).Max();
    }

    private static byte CharNumberToByte(char ch)
    {
        return (byte)(ch - '0');
    }

    private void SetIsVisibleForHorizontalDirection(int dx)
    {
        int startX = dx > 0 ? 0 : Width - 1;
        for (int y = 0; y < Height; y++)
        {
            int maxSoFar = int.MinValue;
            for (int x = startX; x >= 0 && x < Width; x += dx)
            {
                if (_cells[x, y] > maxSoFar)
                {
                    _isCellVisible[x, y] = true;
                    maxSoFar = _cells[x, y];
                }
            }
        }
    }

    private void SetIsVisibleForVerticalDirection(int dy)
    {
        int startY = dy > 0 ? 0 : Height - 1;
        for (int x = 0; x < Width; x++)
        {
            int maxSoFar = int.MinValue;
            for (int y = startY; y >= 0 && y < Height; y += dy)
            {
                if (_cells[x, y] > maxSoFar)
                {
                    _isCellVisible[x, y] = true;
                    maxSoFar = _cells[x, y];
                }
            }
        }
    }

    private int GetNrVisibleCells()
    {
        return Positions.Where(pos => _isCellVisible[pos.x, pos.y]).Count();
    }
}
