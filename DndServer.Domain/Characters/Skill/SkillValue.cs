using DndServer.Domain.Shared;
using DndServer.Domain.Shared.Enums;

namespace DndServer.Domain.Characters.Skill;

public class SkillValue
{
    public SkillTypesEnum Type { get; set; }
    public Resistance Resistance { get; set; } = null!;
    public TypeVision TypeVision { get; set; } = null!;
    public Effect Effect { get; set; } = null!;
    public Damage Damage { get; set; } = null!;
    public AttackBonus AttackBonus { get; set; } = null!;
    public PerLevel PerLevel { get; set; } = null!;
}