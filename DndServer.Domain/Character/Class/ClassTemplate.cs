using DndServer.Domain.Shared.Enums;

namespace DndServer.Domain.Character.Class;

public class ClassTemplate : ClassInstance
{
    public int AuthorId { get; set; }
    public int? WorldId { get; set; }

    public ClassTemplate(int id, string name, string description, SystemEnum system, int authorId, int? worldId) : base(
        id, name, description, system)
    {
        AuthorId = authorId;
        WorldId = worldId;
    }
}