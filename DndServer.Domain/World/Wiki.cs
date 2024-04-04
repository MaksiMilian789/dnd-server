namespace DndServer.Domain.World;

public class Wiki
{
    public int Id { get; set; }
    public int WorldId { get; set; }
    public string Name { get; set; }

    public Wiki(int id, int worldId, string name)
    {
        Id = id;
        WorldId = worldId;
        Name = name;
    }
}