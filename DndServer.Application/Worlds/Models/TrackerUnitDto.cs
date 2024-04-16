namespace DndServer.Application.Worlds.Models;

public class TrackerUnitDto
{
    public string Name { get; set; } = "";
    public double Initiative { get; set; }
    public string? Color { get; set; }
    public string? Icon { get; set; }
}