namespace DndServer.Domain.World;

public class World
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public ICollection<WorldLinks> WorldLinks { get; set; }
    public Tracker Tracker { get; set; }
    public Wiki Wiki { get; set; }

    public World(int id, string name, string description, Tracker tracker, Wiki wiki)
    {
        Id = id;
        Name = name;
        Description = description;
        Tracker = tracker;
        Wiki = wiki;
        WorldLinks = new List<WorldLinks>();
    }
}