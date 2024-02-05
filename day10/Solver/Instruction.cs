namespace AoC;

public abstract class Instruction
{
    public abstract void ExecuteOn(State state);

    public static Instruction Parse(string line)
    {
        if (line.StartsWith("addx"))
        {
            string[] parts = line.Split(' ');
            int v = int.Parse(parts[1]);
            return new AddInstruction(v);
        }
        return new NoopInstruction();
    }
}

public class NoopInstruction : Instruction
{
    public override void ExecuteOn(State state)
    {
        state.ExecuteNoop();
    }
}

public class AddInstruction : Instruction
{
    public int V { get; }

    public AddInstruction(int v)
    {
        V = v;
    }

    public override void ExecuteOn(State state)
    {
        state.ExecuteAdd(V);
    }
}
