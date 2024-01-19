namespace AoC;

internal class Program
{
    private static void Main(string[] args)
    {
        string[] lines = File.ReadAllLines("input.txt");
        Solver solver = new(lines);
        Console.WriteLine($"Part 1: {solver.SolvePart1(2000000)}");
        Console.WriteLine($"Part 2: {solver.SolvePart2(4000000)}");
    }
}
