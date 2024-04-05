using DndServer.Domain.Shared.Enums;

namespace DndServer.Domain.Shared;

public class AttackBonus
{
    public AttackTypesEnum Type { get; set; }
    public int AccuracyBonus { get; set; }
    public Damage Damage { get; set; }
    public bool Advantage { get; set; }
    public bool DisAdvantage { get; set; }

    public AttackBonus(AttackTypesEnum type, int accuracyBonus, Damage damage, bool advantage, bool disAdvantage)
    {
        Type = type;
        AccuracyBonus = accuracyBonus;
        Damage = damage;
        Advantage = advantage;
        DisAdvantage = disAdvantage;
    }
}