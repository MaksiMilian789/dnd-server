using DndServer.Domain.Character.Skill;
using DndServer.Domain.Shared;
using DndServer.Domain.Shared.Enums;

namespace DndServer.Domain.Character.Inventory;

public class ObjectInstance
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public Damage Damage { get; set; }
    public AttackTypesEnum AttackType { get; set; }
    public int? Distance { get; set; }
    public SystemEnum System { get; set; }
    public ICollection<SkillInstance> SkillInstance { get; set; }
    public ICollection<Character> Character { get; set; }

    public ObjectInstance(int id, string name, string description, Damage damage, AttackTypesEnum attackType,
        int? distance, SystemEnum system)
    {
        Id = id;
        Name = name;
        Description = description;
        Damage = damage;
        AttackType = attackType;
        Distance = distance;
        System = system;
        SkillInstance = new List<SkillInstance>();
        Character = new List<Character>();
    }
}