using DndServer.Domain.Shared.Enums;

namespace DndServer.Domain.Shared;

public class AttackBonus
{
    public AttackTypesEnum Type { get; set; }
    public int AccuracyBonus { get; set; }
    public Damage Damage { get; set; } = null!;
    public bool Advantage { get; set; }
    public bool DisAdvantage { get; set; }

    public AttackBonus(AttackTypesEnum type, int accuracyBonus, bool advantage, bool disAdvantage)
    {
        Type = type;
        AccuracyBonus = accuracyBonus;
        Advantage = advantage;
        DisAdvantage = disAdvantage;
    }
}