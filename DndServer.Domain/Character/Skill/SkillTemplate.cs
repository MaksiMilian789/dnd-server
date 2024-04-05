using DndServer.Domain.Shared.Enums;

namespace DndServer.Domain.Character.Skill;

public class SkillTemplate<T> : SkillInstance<T>
{
    public int AuthorId { get; set; }
    public int? WorldId { get; set; }

    public SkillTemplate(int id, string name, string description, ActionTypesEnum actionType, SkillTypesEnum skillType,
        T value, int? distance, bool passive, int recharge, int charges, SystemEnum system, int authorId,
        int? worldId) : base(id, name,
        description, actionType, skillType, value, distance, passive, recharge, charges, system)
    {
        AuthorId = authorId;
        WorldId = worldId;
    }
}