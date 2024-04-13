namespace DndServer.Domain.Shared;

public class PerLevel
{
    public int Flat { get; set; }
    public int Dynamic { get; set; }

    public PerLevel(int flat, int dynamic)
    {
        Flat = flat;
        Dynamic = dynamic;
    }
}