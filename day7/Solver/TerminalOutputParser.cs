namespace AoC;

public class TerminalOutputParser
{
    public Directory Parse(string[] lines)
    {
        Directory root = Directory.CreateRoot();
        // We know the first directory will create the directory,
        // we already did that, so we skip that first command.
        Directory currentDir = root;
        foreach (string line in lines.Skip(1))
        {
            TerminalInstruction instruction = ParseInstruction(line);
            currentDir = instruction.Execute(currentDir);
        }

        return root;
    }

    private TerminalInstruction ParseInstruction(string line)
    {
        if (line.StartsWith('$'))
        {
            return ParseCommand(line);
        }

        return ParseLsOutput(line);
    }

    private TerminalInstruction ParseCommand(string commandLine)
    {
        // Example:
        // $ cd e
        string[] parts = commandLine.Split(' ');
        string command = parts[1];
        switch (command)
        {
            case "cd":
                return new CdInstruction(parts[2]);
            case "ls":
                // Since we parse the output differently, we don't do
                // anything useful on an 'ls'.
                return new NoneInstruction();
            default:
                throw new Exception($"Unknown command {command}");
        }
    }

    private TerminalInstruction ParseLsOutput(string line)
    {
        // Examples:
        // dir a
        // 14848514 b.txt
        string[] parts = line.Split(' ');
        if (parts[0] == "dir")
        {
            return new AddDirInstruction(parts[1]);
        }

        string fileName = parts[1];
        int size = int.Parse(parts[0]);
        return new AddFileInstruction(fileName, size);
    }
}

public class AddFileInstruction : TerminalInstruction
{
    public string FileName { get; private set; }
    public int Size { get; private set; }

    public AddFileInstruction(string fileName, int size)
    {
        FileName = fileName;
        Size = size;
    }

    public override Directory Execute(Directory directory)
    {
        directory.AddFile(FileName, Size);
        return directory;
    }
}
