using DndServer.Domain.Shared.Enums;

namespace DndServer.Domain.Shared;

public class Resistance
{
    public int? Flat { get; set; }
    public DamageTypeEnum DamageType { get; set; }

    public Resistance(int? flat)
    {
        Flat = flat;
    }
}