namespace DndServer.Domain.Shared;

public class Damage
{
    public int Flat { get; set; }
    public DiceRolls DamageRoll { get; set; }
    public DamageType Type { get; set; }
    public bool Heal { get; set; }

    public Damage(int flat, DiceRolls damageRoll, DamageType type, bool heal)
    {
        Flat = flat;
        DamageRoll = damageRoll;
        Type = type;
        Heal = heal;
    }
}