using DndServer.Domain.Characters.Skill;
using DndServer.Domain.Shared;
using DndServer.Domain.Shared.Enums;

namespace DndServer.Domain.Characters.Spell;

public class SpellInstance
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int Level { get; set; }
    public int Distance { get; set; }
    public ActionTypesEnum ActionType { get; set; }
    public Damage Damage { get; set; } = null!;
    public ActionTime ActionTime { get; set; } = null!;
    public List<SpellComponents> Components { get; set; } = null!;
    public SystemEnum System { get; set; }
    public ICollection<SkillInstance> SkillInstance { get; set; }
    public ICollection<Character> Character { get; set; }

    public SpellInstance(int id, string name, string description, int level, int distance, ActionTypesEnum actionType,
        SystemEnum system)
    {
        Id = id;
        Name = name;
        Description = description;
        Level = level;
        Distance = distance;
        ActionType = actionType;
        System = system;
        SkillInstance = new List<SkillInstance>();
        Character = new List<Character>();
    }
}