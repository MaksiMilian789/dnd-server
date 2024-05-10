namespace DndServer.Application.Worlds.Models;

public class WorldCreateDto
{
    public string Name { get; set; } = "";
    public string Description { get; set; } = "";
    public int? ImageId { get; set; }
}