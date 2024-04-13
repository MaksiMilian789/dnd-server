namespace DndServer.Domain.Worlds;

public class TrackerUnit
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double Initiative { get; set; }
    public string? Color { get; set; }
    public string? Icon { get; set; }
    public Tracker Tracker { get; set; } = null!;

    public TrackerUnit(string name, double initiative, string? color, string? icon)
    {
        Name = name;
        Initiative = initiative;
        Color = color;
        Icon = icon;
    }
}