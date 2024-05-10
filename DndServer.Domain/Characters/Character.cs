using DndServer.Domain.Characters.Background;
using DndServer.Domain.Characters.Class;
using DndServer.Domain.Characters.Condition;
using DndServer.Domain.Characters.Inventory;
using DndServer.Domain.Characters.Notes;
using DndServer.Domain.Characters.Race;
using DndServer.Domain.Characters.Skill;
using DndServer.Domain.Characters.Spell;
using DndServer.Domain.Shared;
using DndServer.Domain.Shared.Enums;
using DndServer.Domain.Users;

namespace DndServer.Domain.Characters;

public class Character
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Level { get; set; }
    public int Age { get; set; }
    public int Hp { get; set; }
    public int AddHp { get; set; }
    public int MaxAttachments { get; set; }
    public List<SpellSlot> SpellSlots { get; set; } = new();
    public List<EnergySlot> EnergySlots { get; set; } = new();
    public GenderEnum Gender { get; set; }
    public IdeologyEnum Ideology { get; set; }
    public SystemEnum System { get; set; }
    public Characteristics Characteristics { get; set; } = null!;
    public virtual ClassInstance ClassInstance { get; set; } = null!;
    public int ClassInstanceId { get; set; }
    public virtual RaceInstance RaceInstance { get; set; } = null!;
    public int RaceInstanceId { get; set; }
    public virtual BackgroundInstance BackgroundInstance { get; set; } = null!;
    public int BackgroundInstanceId { get; set; }
    public virtual User User { get; set; } = null!;
    public int UserId { get; set; }
    public int? ImageId { get; set; }
    public virtual Image? Image { get; set; }
    public virtual ICollection<Conditions> Conditions { get; set; }
    public virtual ICollection<ObjectInstance> ObjectInstance { get; set; }
    public virtual ICollection<Note> Note { get; set; }
    public virtual ICollection<SkillInstance> SkillInstance { get; set; }
    public virtual ICollection<SpellInstance> SpellInstance { get; set; }
    public bool Deleted { get; set; }

    public Character(string name, int level, int age, GenderEnum gender, IdeologyEnum ideology,
        SystemEnum system)
    {
        Name = name;
        Level = level;
        Age = age;
        Gender = gender;
        Ideology = ideology;
        Conditions = new List<Conditions>();
        ObjectInstance = new List<ObjectInstance>();
        Note = new List<Note>();
        SkillInstance = new List<SkillInstance>();
        SpellInstance = new List<SpellInstance>();
    }

    public Character(string name, int level, int age, GenderEnum gender, IdeologyEnum ideology,
        SystemEnum system, Characteristics characteristics)
    {
        Name = name;
        Level = level;
        Age = age;
        Gender = gender;
        Ideology = ideology;
        Conditions = new List<Conditions>();
        ObjectInstance = new List<ObjectInstance>();
        Note = new List<Note>();
        SkillInstance = new List<SkillInstance>();
        SpellInstance = new List<SpellInstance>();
        Characteristics = characteristics;
        SpellSlots = new List<SpellSlot>();
        EnergySlots = new List<EnergySlot>();
    }
}