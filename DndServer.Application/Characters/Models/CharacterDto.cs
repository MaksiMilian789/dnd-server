using DndServer.Domain.Characters;
using DndServer.Domain.Characters.Background;
using DndServer.Domain.Characters.Class;
using DndServer.Domain.Characters.Condition;
using DndServer.Domain.Characters.Inventory;
using DndServer.Domain.Characters.Notes;
using DndServer.Domain.Characters.Race;
using DndServer.Domain.Characters.Skill;
using DndServer.Domain.Characters.Spell;
using DndServer.Domain.Shared.Enums;

namespace DndServer.Application.Characters.Models;

public class CharacterDto
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public int Level { get; set; }
    public int Age { get; set; }
    public GenderEnum Gender { get; set; }
    public IdeologyEnum Ideology { get; set; }
    public SystemEnum System { get; set; }
    public Characteristics Characteristics { get; set; } = null!;
    public ClassInstance ClassInstance { get; set; } = null!;
    public RaceInstance RaceInstance { get; set; } = null!;
    public BackgroundInstance BackgroundInstance { get; set; } = null!;
    public ICollection<Conditions> Conditions { get; set; } = new List<Conditions>();
    public ICollection<ObjectInstance> ObjectInstance { get; set; } = new List<ObjectInstance>();
    public ICollection<Note> Note { get; set; } = new List<Note>();
    public ICollection<SkillInstance> SkillInstance { get; set; } = new List<SkillInstance>();
    public ICollection<SpellInstance> SpellInstance { get; set; } = new List<SpellInstance>();
}