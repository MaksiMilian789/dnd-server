using DndServer.Domain.Shared;
using DndServer.Domain.Shared.Enums;

namespace DndServer.Domain.Character.Spell;

public class SpellTemplate : SpellInstance
{
    public int AuthorId { get; set; }
    public int? WorldId { get; set; }

    public SpellTemplate(int id, string name, string description, int level, int distance, ActionTypesEnum actionType,
        Damage damage, ActionTime actionTime, List<SpellComponents> components, SystemEnum system, int authorId,
        int? worldId) : base(id, name, description, level, distance, actionType, damage, actionTime, components, system)
    {
        AuthorId = authorId;
        WorldId = worldId;
    }
}