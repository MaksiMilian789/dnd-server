using DndServer.Domain.Characters.Skill;
using DndServer.Domain.Shared.Enums;

namespace DndServer.Domain.Characters.Inventory;

public class ObjectTemplate : ObjectInstance
{
    public int AuthorId { get; set; }
    public int? WorldId { get; set; }
    public ICollection<SkillTemplate> SkillTemplate { get; set; }

    public ObjectTemplate(int id, string name, string description, AttackTypesEnum attackType,
        int? distance, SystemEnum system, int authorId, int? worldId) : base(id, name, description, attackType,
        distance, system)
    {
        AuthorId = authorId;
        WorldId = worldId;
        SkillTemplate = new List<SkillTemplate>();
    }
}