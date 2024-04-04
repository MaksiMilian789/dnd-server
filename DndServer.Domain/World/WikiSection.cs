namespace DndServer.Domain.World;

public class WikiSection
{
    public int Id { get; set; }
    public int WorldId { get; set; }
    public string Name { get; set; }

    public WikiSection(int id, int worldId, string name)
    {
        Id = id;
        WorldId = worldId;
        Name = name;
    }
}