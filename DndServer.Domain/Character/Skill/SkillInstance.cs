using DndServer.Domain.Character.Background;
using DndServer.Domain.Character.Class;
using DndServer.Domain.Character.Inventory;
using DndServer.Domain.Character.Race;
using DndServer.Domain.Character.Spell;
using DndServer.Domain.Shared.Enums;

namespace DndServer.Domain.Character.Skill;

public class SkillInstance
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public ActionTypesEnum ActionType { get; set; }
    public SkillTypesEnum SkillType { get; set; }
    public SkillValue Value { get; set; }
    public int? Distance { get; set; }
    public bool Passive { get; set; }
    public int Recharge { get; set; }
    public int Charges { get; set; }
    public SystemEnum System { get; set; }
    public ICollection<Character> Character { get; set; }
    public ICollection<BackgroundInstance> BackgroundInstance { get; set; }
    public ICollection<ClassInstance> ClassInstance { get; set; }
    public ICollection<ObjectInstance> ObjectInstance { get; set; }
    public ICollection<RaceInstance> RaceInstance { get; set; }
    public ICollection<SpellInstance> SpellInstance { get; set; }

    public SkillInstance(int id, string name, string description, ActionTypesEnum actionType, SkillTypesEnum skillType,
        SkillValue value, int? distance, bool passive, int recharge, int charges, SystemEnum system)
    {
        Id = id;
        Name = name;
        Description = description;
        ActionType = actionType;
        SkillType = skillType;
        Value = value;
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