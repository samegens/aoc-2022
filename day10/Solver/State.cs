namespace AoC;

public class State
{
    public int X { get; private set; } = 1;
    public int CurrentCycle { get; private set; } = 1;

    // Remembers what the state of X was at the _start_ of each cycle.
    public Dictionary<int, int> History { get; } = new Dictionary<int, int>()
    {
        [1] = 1
    };

    public void ExecuteNoop()
    {
        CurrentCycle++;
        History[CurrentCycle] = X;
    }

    public void ExecuteAdd(int v)
    {
        CurrentCycle++;
        History[CurrentCycle] = X;
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
    public int GetSignalStrengthAt(int cycle) => cycle * History[cycle];
}
