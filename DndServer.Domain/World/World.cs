namespace DndServer.Domain.World;

public class World
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public ICollection<WorldLinks> WorldLinks { get; set; }
    public Tracker Tracker { get; set; } = null!;
    public int TrackerKey { get; set; }
    public Wiki Wiki { get; set; } = null!;
    public int WikiKey { get; set; }

    public World(int id, string name, string description)
    {
        Id = id;
        Name = name;
        Description = description;
        WorldLinks = new List<WorldLinks>();
    }
}