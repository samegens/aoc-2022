namespace AoC;

internal class Program
{
    private static void Main(string[] args)
    {
        string[] lines = File.ReadAllLines("input.txt");
        Grid grid = new(lines);
        Console.WriteLine($"Part 1: {grid.GetNrVisibleTrees()}");
        Console.WriteLine($"Part 2: {grid.GetHighestScenicScore()}");
    }
}