namespace DndServer.Domain.Shared;

public class ActionTime
{
    public int Time { get; set; }
    public bool Concentrate { get; set; }

    public ActionTime(int time, bool concentrate)
    {
        Time = time;
        Concentrate = concentrate;
    }
}