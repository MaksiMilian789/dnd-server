using DndServer.Domain.Shared;
using DndServer.Domain.Shared.Enums;

namespace DndServer.Domain.Character.Inventory;

public class ObjectTemplate : ObjectInstance
{
    public int AuthorId { get; set; }
    public int? WorldId { get; set; }

    public ObjectTemplate(int id, string name, string description, Damage damage, AttackTypesEnum attackType,
        int? distance, SystemEnum system, int authorId, int? worldId) : base(id, name, description, damage, attackType,
        distance, system)
    {
        AuthorId = authorId;
        WorldId = worldId;
    }
}