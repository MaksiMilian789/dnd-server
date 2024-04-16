using DndServer.Domain.Worlds;

namespace DndServer.Application.Worlds.Models;

public class WorldDto
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public string Description { get; set; } = "";
    public Tracker Tracker { get; set; } = null!;
    public Wiki Wiki { get; set; } = null!;
}