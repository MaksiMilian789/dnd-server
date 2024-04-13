namespace DndServer.Domain.Shared;

public class ActionTime
{
    public TimeSpan Time { get; set; }
    public bool Concentrate { get; set; }

    public ActionTime(TimeSpan time, bool concentrate)
    {
        Time = time;
        Concentrate = concentrate;
    }
}