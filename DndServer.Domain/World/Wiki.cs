namespace DndServer.Domain.World;

public class Wiki
{
    public int Id { get; set; }
    public World World { get; set; }
    public string Name { get; set; }
    public ICollection<WikiPage> WikiPage { get; set; }

    public Wiki(int id, World world, string name)
    {
        Id = id;
        World = world;
        Name = name;
        WikiPage = new List<WikiPage>();
    }
}