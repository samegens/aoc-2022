

using System.Text;

namespace AoC;

public class State
{
    public const int CrtWidth = 40;
    public const int CrtHeight = 6;
    public const char LitPixel = '#';
    public const char DarkPixel = '.';

    public int X { get; private set; } = 1;

    public int CurrentCycle { get; private set; } = 1;

    public char[,] Crt { get; } = new char[40, 6];

    // Remembers what the state of X was at the _start_ of each cycle.
    public Dictionary<int, int> History { get; } = new Dictionary<int, int>()
    {
        [1] = 1
    };

    public void ExecuteNoop()
    {
        DrawPixel();
        CurrentCycle++;
        History[CurrentCycle] = X;
    }

    private void DrawPixel()
    {
        int x = (CurrentCycle - 1) % CrtWidth;

        int y = (CurrentCycle - 1) / CrtWidth;
        if (y >= CrtHeight)
        {
            return;
        }

        char pixel = IsXInSprite(x) ? LitPixel : DarkPixel;
        Crt[x, y] = pixel;
    }

    private bool IsXInSprite(int x)
    {
        return x >= X - 1 && x <= X + 1;
    }

    public void ExecuteAdd(int v)
    {
        DrawPixel();
        CurrentCycle++;
        History[CurrentCycle] = X;
        DrawPixel();
        CurrentCycle++;
        X += v;
        History[CurrentCycle] = X;
    }

    public void PrintHistory()
    {
        for (int i = 1; i < CurrentCycle; i++)
        {
            Console.WriteLine($"{i}: {History[i]}");
        }
    }

    public string GetCrt()
    {
        StringBuilder sb = new();
        for (int y = 0; y < CrtHeight; y++)
        {
            for (int x = 0; x < CrtWidth; x++)
            {
                sb.Append(Crt[x, y]);
            }
            sb.AppendLine();
        }
        return sb.ToString();
    }

    public int GetSignalStrengthAt(int cycle) => cycle * History[cycle];
}
