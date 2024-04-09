using DndServer.Domain.Character.Background;
using DndServer.Domain.Character.Class;
using DndServer.Domain.Character.Condition;
using DndServer.Domain.Character.Inventory;
using DndServer.Domain.Character.Race;
using DndServer.Domain.Character.Skill;
using DndServer.Domain.Character.Spell;
using DndServer.Domain.Shared.Enums;

namespace DndServer.Domain.Character;

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
    public User.User User { get; set; } = null!;
    public ICollection<Conditions> Conditions { get; set; }
    public ICollection<ObjectInstance> ObjectInstance { get; set; }
    public ICollection<Note.Note> Note { get; set; }
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
        Note = new List<Note.Note>();
        SkillInstance = new List<SkillInstance>();
        SpellInstance = new List<SpellInstance>();
    }
}