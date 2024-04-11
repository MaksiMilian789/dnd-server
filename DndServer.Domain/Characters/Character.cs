using DndServer.Domain.Characters.Background;
using DndServer.Domain.Characters.Class;
using DndServer.Domain.Characters.Condition;
using DndServer.Domain.Characters.Inventory;
using DndServer.Domain.Characters.Notes;
using DndServer.Domain.Characters.Race;
using DndServer.Domain.Characters.Skill;
using DndServer.Domain.Characters.Spell;
using DndServer.Domain.Shared.Enums;
using DndServer.Domain.Users;

namespace DndServer.Domain.Characters;

public class Character
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Level { get; set; }
    public int Age { get; set; }
    public int Speed { get; set; }
    public GenderEnum Gender { get; set; }
    public IdeologyEnum Ideology { get; set; }
    public SystemEnum System { get; set; }
    public Characteristics Characteristics { get; set; } = null!;
    public ClassInstance ClassInstance { get; set; } = null!;
    public RaceInstance RaceInstance { get; set; } = null!;
    public BackgroundInstance BackgroundInstance { get; set; } = null!;
    public User User { get; set; } = null!;
    public ICollection<Conditions> Conditions { get; set; }
    public ICollection<ObjectInstance> ObjectInstance { get; set; }
    public ICollection<Note> Note { get; set; }
    public ICollection<SkillInstance> SkillInstance { get; set; }
    public ICollection<SpellInstance> SpellInstance { get; set; }

    public Character(int id, string name, int level, int age, int speed, GenderEnum gender, IdeologyEnum ideology,
        SystemEnum system)
    {
        Id = id;
        Name = name;
        Level = level;
        Age = age;
        Speed = speed;
        Gender = gender;
        Ideology = ideology;
        Conditions = new List<Conditions>();
        ObjectInstance = new List<ObjectInstance>();
        Note = new List<Note>();
        SkillInstance = new List<SkillInstance>();
        SpellInstance = new List<SpellInstance>();
    }
}