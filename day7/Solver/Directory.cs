namespace AoC;

public class Directory
{
    public List<Directory> Subdirectories { get; } = new();

    public Dictionary<string, int> FileSizes { get; } = new();

    public Directory? Parent { get; private set; }

    public bool IsRoot => Parent == null;

    public string Name { get; private set; }

    public Directory(string name, Directory? parent)
    {
        Name = name;
        Parent = parent;
    }

    public static Directory CreateRoot()
    {
        return new Directory("/", null);
    }

    public void AddFile(string name, int size)
    {
        FileSizes[name] = size;
    }

    public void AddSubdirectory(Directory subdirectory)
    {
        Subdirectories.Add(subdirectory);
        subdirectory.Parent = this;
    }

    public IEnumerable<Directory> GetDirectoriesRecursively()
    {
        yield return this;
        foreach (Directory subdir in Subdirectories)
        {
            foreach (Directory dir in subdir.GetDirectoriesRecursively())
            {
                yield return dir;
            }
        }
    }

    public long RecursiveSize => FileSizes.Values.Sum() + Subdirectories.Select(d => d.RecursiveSize).Sum();
}