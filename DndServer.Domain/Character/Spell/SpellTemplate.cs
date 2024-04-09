using DndServer.Domain.Character.Skill;
using DndServer.Domain.Shared.Enums;

namespace DndServer.Domain.Character.Spell;

public class SpellTemplate : SpellInstance
{
    public int AuthorId { get; set; }
    public int? WorldId { get; set; }
    public ICollection<SkillTemplate> SkillTemplate { get; set; }

    public SpellTemplate(int id, string name, string description, int level, int distance, ActionTypesEnum actionType,
        SystemEnum system, int authorId, int? worldId) : base(id, name, description, level, distance, actionType,
        system)
    {
        AuthorId = authorId;
        WorldId = worldId;
        SkillTemplate = new List<SkillTemplate>();
    }
}