namespace DndServer.Domain.Shared;

public class Resistance
{
    public int? Flat { get; set; }
    public DamageType DamageType { get; set; } = null!;

    public Resistance(int? flat)
    {
        Flat = flat;
    }
}