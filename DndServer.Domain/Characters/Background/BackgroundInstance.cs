using DndServer.Domain.Characters.Skill;
using DndServer.Domain.Shared.Enums;

namespace DndServer.Domain.Characters.Background;

public class BackgroundInstance
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public SystemEnum System { get; set; }
    public ICollection<SkillInstance> SkillInstance { get; set; }
    public ICollection<Character> Character { get; set; }

    public BackgroundInstance(int id, string name, string description, SystemEnum system)
    {
        Id = id;
        Name = name;
        Description = description;
        System = system;
        SkillInstance = new List<SkillInstance>();
        Character = new List<Character>();
    }
}