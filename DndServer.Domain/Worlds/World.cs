using DndServer.Domain.Shared;

namespace DndServer.Domain.Worlds;

public class World
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public bool Deleted { get; set; }
    public int? ImageId { get; set; }
    public virtual Image? Image { get; set; }
    public virtual ICollection<WorldLinks> WorldLinks { get; set; }
    public virtual Tracker Tracker { get; set; } = null!;
    public int TrackerKey { get; set; }
    public virtual ICollection<Wiki> Wiki { get; set; }

    public World(string name, string description)
    {
        Name = name;
        Description = description;
        WorldLinks = new List<WorldLinks>();
        Wiki = new List<Wiki>();
    }
}