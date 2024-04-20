using DndServer.Domain.Characters.Skill;
using DndServer.Domain.Shared.Enums;

namespace DndServer.Domain.Characters.Race;

public class RaceTemplate
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public SystemEnum System { get; set; }
    public int AuthorId { get; set; }
    public int? WorldId { get; set; }
    public virtual ICollection<SkillTemplate> SkillTemplate { get; set; }

    public RaceTemplate(string name, string description, SystemEnum system, int authorId,
        int? worldId)
    {
        Name = name;
        Description = description;
        AuthorId = authorId;
        System = system;
        WorldId = worldId;
        SkillTemplate = new List<SkillTemplate>();
    }
}