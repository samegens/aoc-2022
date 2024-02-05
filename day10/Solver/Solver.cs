namespace AoC;

public class Solver
{
    public string[] Lines { get; }

    public Solver(string[] lines)
    {
        Lines = lines;
    }

    public int SolvePart1()
    {
        IEnumerable<Instruction> instructions = Lines.Select(Instruction.Parse);
        State state = new();
        foreach (Instruction instruction in instructions)
        {
            instruction.ExecuteOn(state);
        }

        return state.GetSignalStrengthAt(20) +
               state.GetSignalStrengthAt(60) +
               state.GetSignalStrengthAt(100) +
               state.GetSignalStrengthAt(140) +
               state.GetSignalStrengthAt(180) +
               state.GetSignalStrengthAt(220);
    }

    public string SolvePart2()
    {
        IEnumerable<Instruction> instructions = Lines.Select(Instruction.Parse);
        State state = new();
        foreach (Instruction instruction in instructions)
        {
            instruction.ExecuteOn(state);
        }

        return state.GetCrt();
    }
}
