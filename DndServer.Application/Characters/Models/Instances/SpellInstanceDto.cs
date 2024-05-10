using DndServer.Domain.Shared;
using DndServer.Domain.Shared.Enums;

namespace DndServer.Application.Characters.Models.Instances;

public class SpellInstanceDto
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public string Description { get; set; } = "";
    public MagicSchoolEnum MagicSchool { get; set; }
    public bool HasDamage { get; set; }
    public int Level { get; set; }
    public int Distance { get; set; }
    public ActionTypesEnum ActionType { get; set; }
    public Damage Damage { get; set; } = null!;
    public ActionTime ActionTime { get; set; } = null!;
    public List<SpellComponents> Components { get; set; } = null!;
    public SystemEnum System { get; set; }
    public List<SkillInstanceDto> SkillInstances { get; set; } = new();
}