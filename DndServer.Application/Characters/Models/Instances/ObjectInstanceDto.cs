using DndServer.Domain.Shared;
using DndServer.Domain.Shared.Enums;

namespace DndServer.Application.Characters.Models.Instances;

public class ObjectInstanceDto
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public string Description { get; set; } = "";
    public Damage Damage { get; set; } = null!;
    public AttackTypesEnum AttackType { get; set; }
    public int Quantity { get; set; }
    public int ImageId { get; set; }
    public int? Distance { get; set; }
    public SystemEnum System { get; set; }
    public List<SkillInstanceDto> SkillInstances { get; set; } = new();
}