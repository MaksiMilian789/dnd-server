using DndServer.Domain.Shared.Enums;

namespace DndServer.Application.Characters.Models.Instances;

public class BackgroundInstanceDto
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public string Description { get; set; } = "";
    public SystemEnum System { get; set; }
    public List<SkillInstanceDto> SkillInstances { get; set; } = new();
}