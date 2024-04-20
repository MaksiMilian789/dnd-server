using DndServer.Domain.Characters.Skill;
using DndServer.Domain.Shared;
using DndServer.Domain.Shared.Enums;

namespace DndServer.Domain.Characters.Inventory;

public class ObjectInstance
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public Damage Damage { get; set; } = null!;
    public AttackTypesEnum AttackType { get; set; }
    public int? Distance { get; set; }
    public SystemEnum System { get; set; }
    public virtual ICollection<SkillInstance> SkillInstance { get; set; }
    public virtual ICollection<Character> Character { get; set; }

    public ObjectInstance(string name, string description, AttackTypesEnum attackType,
        int? distance, SystemEnum system)
    {
        Name = name;
        Description = description;
        AttackType = attackType;
        Distance = distance;
        System = system;
        SkillInstance = new List<SkillInstance>();
        Character = new List<Character>();
    }
}