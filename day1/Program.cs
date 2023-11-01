string[] lines = File.ReadAllLines("input.txt");
List<int> caloriesPerElf = new List<int>();

// We start with reading the calories of the first elf, so there should already be
// an entry in the list.
int currentElfIndex = 0;
caloriesPerElf.Add(0);
foreach (string line in lines)
{
    // An empty line means we're done with the current elf.
    // Prepare for the next elf. It's not an issue if this elf doesn't get any
    // calories, since we will only be looking at the top caleries anyway.
    if (line.Length == 0)
    {
        currentElfIndex++;
        caloriesPerElf.Add(0);
    }
    else
    {
        int calories = int.Parse(line);
        caloriesPerElf[currentElfIndex] += calories;
    }
}

caloriesPerElf.Sort();
// Default sort will sort ascending, so we need to retrieve the last entry when we
// need to know the highest calories.
int answer = caloriesPerElf.Last();
Console.WriteLine($"Part 1: {answer}");

int len = caloriesPerElf.Count;
answer = caloriesPerElf[len - 1] + caloriesPerElf[len - 2] + caloriesPerElf[len - 3];
Console.WriteLine($"Part 2: {answer}");
