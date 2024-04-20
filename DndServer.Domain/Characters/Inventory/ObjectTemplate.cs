using DndServer.Domain.Characters.Skill;
using DndServer.Domain.Shared;
using DndServer.Domain.Shared.Enums;

namespace DndServer.Domain.Characters.Inventory;

public class ObjectTemplate
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public Damage Damage { get; set; } = null!;
    public AttackTypesEnum AttackType { get; set; }
    public int? Distance { get; set; }
    public SystemEnum System { get; set; }
    public int AuthorId { get; set; }
    public int? WorldId { get; set; }
    public virtual ICollection<SkillTemplate> SkillTemplate { get; set; }

    public ObjectTemplate(string name, string description, AttackTypesEnum attackType,
        int? distance, SystemEnum system, int authorId, int? worldId)
    {
        Name = name;
        Description = description;
        AttackType = attackType;
        Distance = distance;
        System = system;
        AuthorId = authorId;
        WorldId = worldId;
        SkillTemplate = new List<SkillTemplate>();
    }
}