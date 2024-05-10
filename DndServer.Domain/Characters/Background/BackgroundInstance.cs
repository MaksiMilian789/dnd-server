using DndServer.Domain.Characters.Skill;
using DndServer.Domain.Shared.Enums;

namespace DndServer.Domain.Characters.Background;

public class BackgroundInstance
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public bool Deleted { get; set; }
    public SystemEnum System { get; set; }
    public virtual ICollection<SkillInstance> SkillInstance { get; set; }
    public virtual ICollection<Character> Character { get; set; }

    public BackgroundInstance(string name, string description, SystemEnum system)
    {
        Name = name;
        Description = description;
        System = system;
        SkillInstance = new List<SkillInstance>();
        Character = new List<Character>();
    }
}