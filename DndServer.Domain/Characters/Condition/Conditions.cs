using DndServer.Domain.Characters.Skill;
using DndServer.Domain.Shared.Enums;

namespace DndServer.Domain.Characters.Condition;

public class Conditions
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int AuthorId { get; set; }
    public int? WorldId { get; set; }
    public SystemEnum System { get; set; }
    public virtual ICollection<SkillInstance> SkillInstance { get; set; }
    public virtual ICollection<Character> Character { get; set; }

    public Conditions(string name, string description, SystemEnum system, int authorId, int? worldId)
    {
        Name = name;
        Description = description;
        System = system;
        AuthorId = authorId;
        WorldId = worldId;
        Character = new List<Character>();
        SkillInstance = new List<SkillInstance>();
    }
}