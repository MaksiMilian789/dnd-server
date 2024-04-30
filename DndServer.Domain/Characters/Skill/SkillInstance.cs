using DndServer.Domain.Characters.Background;
using DndServer.Domain.Characters.Class;
using DndServer.Domain.Characters.Inventory;
using DndServer.Domain.Characters.Race;
using DndServer.Domain.Characters.Spell;
using DndServer.Domain.Shared.Enums;

namespace DndServer.Domain.Characters.Skill;

public class SkillInstance
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public ActionTypesEnum ActionType { get; set; }
    public SkillTypesEnum SkillType { get; set; }
    public SkillValue Value { get; set; } = null!;
    public int? Distance { get; set; }
    public bool Passive { get; set; }
    public int Recharge { get; set; }
    public int Charges { get; set; }
    public SystemEnum System { get; set; }
    public virtual ICollection<Character> Character { get; set; }
    public virtual ICollection<BackgroundInstance> BackgroundInstance { get; set; }
    public virtual ICollection<ClassInstance> ClassInstance { get; set; }
    public virtual ICollection<ObjectInstance> ObjectInstance { get; set; }
    public virtual ICollection<RaceInstance> RaceInstance { get; set; }
    public virtual ICollection<SpellInstance> SpellInstance { get; set; }

    public SkillInstance(string name, string description, ActionTypesEnum actionType, SkillTypesEnum skillType,
        int? distance, bool passive, int recharge, int charges, SystemEnum system)
    {
        Name = name;
        Description = description;
        ActionType = actionType;
        SkillType = skillType;
        Distance = distance;
        Passive = passive;
        Recharge = recharge;
        Charges = charges;
        System = system;
        Character = new List<Character>();
        BackgroundInstance = new List<BackgroundInstance>();
        ClassInstance = new List<ClassInstance>();
        ObjectInstance = new List<ObjectInstance>();
        RaceInstance = new List<RaceInstance>();
        SpellInstance = new List<SpellInstance>();
    }
}