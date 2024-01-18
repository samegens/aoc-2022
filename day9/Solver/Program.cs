namespace AoC;

using NLog;

internal class Program
{
    private static readonly Logger Log = LogManager.GetCurrentClassLogger();

    private static void Main(string[] args)
    {
        Log.Debug("Main start");

        string[] lines = File.ReadAllLines("input.txt");
        Solver solver = new(lines);
        Log.Info($"Part 1: {solver.SolvePart1()}");
        Log.Info($"Part 2: {solver.SolvePart2()}");

        Log.Debug("Main end");
    }
}