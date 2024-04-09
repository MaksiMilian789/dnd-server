using DndServer.Domain.Character.Skill;
using DndServer.Domain.Shared.Enums;

namespace DndServer.Domain.Character.Background;

public class BackgroundTemplate : BackgroundInstance
{
    public int AuthorId { get; set; }
    public int? WorldId { get; set; }
    public ICollection<SkillTemplate> SkillTemplate { get; set; }

    public BackgroundTemplate(int id, string name, string description, SystemEnum system, int authorId,
        int? worldId) : base(
        id, name, description, system)
    {
        AuthorId = authorId;
        WorldId = worldId;
        SkillTemplate = new List<SkillTemplate>();
    }
}