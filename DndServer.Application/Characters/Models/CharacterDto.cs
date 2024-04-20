using DndServer.Application.Characters.Models.Instances;
using DndServer.Domain.Characters;
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
    public ClassInstanceDto ClassInstance { get; set; } = null!;
    public RaceInstanceDto RaceInstance { get; set; } = null!;
    public BackgroundInstanceDto BackgroundInstance { get; set; } = null!;
    public ICollection<ConditionDto> Conditions { get; set; } = new List<ConditionDto>();
    public ICollection<ObjectInstanceDto> ObjectInstance { get; set; } = new List<ObjectInstanceDto>();
    public ICollection<NoteDto> Note { get; set; } = new List<NoteDto>();
    public ICollection<SkillInstanceDto> SkillInstance { get; set; } = new List<SkillInstanceDto>();
    public ICollection<SpellInstanceDto> SpellInstance { get; set; } = new List<SpellInstanceDto>();
}