using DndServer.Domain.Character.Skill;
using DndServer.Domain.Shared.Enums;

namespace DndServer.Domain.Character.Race;

public class RaceInstance
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public SystemEnum System { get; set; }
    public ICollection<SkillInstance> SkillInstance { get; set; }
    public ICollection<Character> Character { get; set; }

    public RaceInstance(int id, string name, string description, SystemEnum system)
    {
        Id = id;
        Name = name;
        Description = description;
        System = system;
        SkillInstance = new List<SkillInstance>();
        Character = new List<Character>();
    }
}