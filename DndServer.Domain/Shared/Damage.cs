using DndServer.Domain.Shared.Enums;

namespace DndServer.Domain.Shared;

public class Damage
{
    public int Flat { get; set; }
    public DiceRolls DamageRoll { get; set; } = null!;
    public DamageTypeEnum DamageType { get; set; }
    public bool Heal { get; set; }

    public Damage(int flat, bool heal)
    {
        Flat = flat;
        Heal = heal;
    }
}