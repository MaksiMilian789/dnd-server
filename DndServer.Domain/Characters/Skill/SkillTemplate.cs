using DndServer.Domain.Characters.Background;
using DndServer.Domain.Characters.Class;
using DndServer.Domain.Characters.Condition;
using DndServer.Domain.Characters.Inventory;
using DndServer.Domain.Characters.Race;
using DndServer.Domain.Characters.Spell;
using DndServer.Domain.Shared.Enums;

namespace DndServer.Domain.Characters.Skill;

public class SkillTemplate
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public ActionTypesEnum ActionType { get; set; }
    public SkillTypesEnum SkillType { get; set; }
    public SkillValue Value { get; set; } = null!;
    public int? Distance { get; set; }
    public bool Passive { get; set; }
    public RechargeEnum Recharge { get; set; }
    public int Charges { get; set; }
    public bool Hidden { get; set; } = false;
    public SystemEnum System { get; set; }
    public int AuthorId { get; set; }
    public int? WorldId { get; set; }
    public virtual ICollection<BackgroundTemplate> BackgroundTemplate { get; set; }
    public virtual ICollection<ClassTemplate> ClassTemplate { get; set; }
    public virtual ICollection<ObjectTemplate> ObjectTemplate { get; set; }
    public virtual ICollection<RaceTemplate> RaceTemplate { get; set; }
    public virtual ICollection<SpellTemplate> SpellTemplate { get; set; }
    public virtual ICollection<Conditions> Condition { get; set; }

    public SkillTemplate(string name, string description, ActionTypesEnum actionType, SkillTypesEnum skillType,
        int? distance, bool passive, RechargeEnum recharge, int charges, SystemEnum system, int authorId,
        int? worldId)
    {
        Name = name;
        Description = description;
        ActionType = actionType;
        SkillType = skillType;
        Distance = distance;
        Passive = passive;
        Charges = charges;
        Recharge = recharge;
        System = system;
        AuthorId = authorId;
        WorldId = worldId;
        BackgroundTemplate = new List<BackgroundTemplate>();
        ClassTemplate = new List<ClassTemplate>();
        ObjectTemplate = new List<ObjectTemplate>();
        RaceTemplate = new List<RaceTemplate>();
        SpellTemplate = new List<SpellTemplate>();
        Condition = new List<Conditions>();
    }
}