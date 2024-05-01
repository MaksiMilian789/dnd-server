using DndServer.Domain.Characters.Skill;
using DndServer.Domain.Shared;
using DndServer.Domain.Shared.Enums;

namespace DndServer.Domain.Characters.Spell;

public class SpellTemplate
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public MagicSchoolEnum MagicSchool { get; set; }
    public bool HasDamage { get; set; }
    public int Level { get; set; }
    public int Distance { get; set; }
    public ActionTypesEnum ActionType { get; set; }
    public Damage Damage { get; set; } = null!;
    public ActionTime ActionTime { get; set; } = null!;
    public List<SpellComponents> Components { get; set; } = null!;
    public SystemEnum System { get; set; }
    public int AuthorId { get; set; }
    public int? WorldId { get; set; }
    public virtual ICollection<SkillTemplate> SkillTemplate { get; set; }

    public SpellTemplate(string name, string description, int level, int distance, ActionTypesEnum actionType,
        MagicSchoolEnum magicSchool, bool hasDamage, SystemEnum system, int authorId, int? worldId)
    {
        Name = name;
        Description = description;
        MagicSchool = magicSchool;
        HasDamage = hasDamage;
        Level = level;
        Distance = distance;
        ActionType = actionType;
        System = system;
        AuthorId = authorId;
        WorldId = worldId;
        SkillTemplate = new List<SkillTemplate>();
    }
}