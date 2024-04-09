using DndServer.Domain.Shared;

namespace DndServer.Domain.Character.Skill;

public class SkillValue
{
    public Resistance? Resistance { get; set; }
    public TypeVision? TypeVision { get; set; }
    public Effect? Effect { get; set; }
    public Damage? Damage { get; set; }
    public AttackBonus? AttackBonus { get; set; }
    public PerLevel? PerLevel { get; set; }
}