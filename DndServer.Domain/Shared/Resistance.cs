namespace DndServer.Domain.Shared;

public class Resistance
{
    public int? Flat { get; set; }
    public DamageType DamageType { get; set; }

    public Resistance(int? flat, DamageType damageType)
    {
        Flat = flat;
        DamageType = damageType;
    }
}