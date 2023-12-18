namespace AoC;

public abstract class TerminalInstruction
{
    public abstract Directory Execute(Directory directory);

}

public class CdInstruction : TerminalInstruction
{
    public string DirectoryName { get; private set; }

    public CdInstruction(string directoryName)
    {
        DirectoryName = directoryName;
    }

    public override Directory Execute(Directory directory)
    {
        if (DirectoryName == "..")
        {
            return directory.Parent!;
        }

        return directory
            .Subdirectories.Where(d => d.Name == DirectoryName)
            .Single();
    }
}

public class NoneInstruction : TerminalInstruction
{
    public override Directory Execute(Directory directory)
    {
        return directory;
    }
}

public class AddDirInstruction : TerminalInstruction
{
    public string DirectoryName { get; private set; }

    public AddDirInstruction(string directoryName)
    {
        DirectoryName = directoryName;
    }

    public override Directory Execute(Directory directory)
    {
        Directory subdirectory = new(DirectoryName, directory);
        directory.AddSubdirectory(subdirectory);
        return directory;
    }
}

