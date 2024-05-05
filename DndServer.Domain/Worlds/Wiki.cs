namespace DndServer.Domain.Worlds;

public class Wiki
{
    public int Id { get; set; }
    public virtual World World { get; set; } = null!;
    public int WorldId { get; set; }
    public string Name { get; set; }
    public virtual ICollection<WikiPage> WikiPage { get; set; }

    public Wiki(string name)
    {
        Name = name;
        WikiPage = new List<WikiPage>();
    }
}