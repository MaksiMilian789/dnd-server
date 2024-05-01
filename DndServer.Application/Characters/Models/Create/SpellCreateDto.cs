using DndServer.Domain.Shared;
using DndServer.Domain.Shared.Enums;

namespace DndServer.Application.Characters.Models.Create;

public class SpellCreateDto
{
    public string Name { get; set; } = "";
    public string Description { get; set; } = "";
    public int Level { get; set; }
    public int Distance { get; set; }
    public ActionTypesEnum ActionType { get; set; }
    public Damage Damage { get; set; } = null!;
    public ActionTime ActionTime { get; set; } = null!;
    public List<SpellComponents> Components { get; set; } = null!;
    public SystemEnum System { get; set; }
    public int AuthorId { get; set; }
    public List<int> SkillIds { get; set; } = new();
    public int? WorldId { get; set; }
}