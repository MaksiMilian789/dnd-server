namespace DndServer.Domain.World;

public class World
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    public World(int id, string name, string description)
    {
        Id = id;
        Name = name;
        Description = description;
    }
}