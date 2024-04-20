namespace DndServer.Domain.Worlds;

public class Tracker
{
    public int Id { get; set; }
    public virtual World World { get; set; } = null!;
    public virtual ICollection<TrackerUnit> TrackerUnits { get; set; }

    public Tracker()
    {
        TrackerUnits = new List<TrackerUnit>();
    }

    public Tracker(World world)
    {
        World = world;
        TrackerUnits = new List<TrackerUnit>();
    }
}