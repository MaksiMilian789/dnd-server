using DndServer.Domain.Characters.Skill;
using DndServer.Domain.Shared.Enums;

namespace DndServer.Application.Characters.Models;

public class ClassDto
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public string Description { get; set; } = "";
    public SystemEnum System { get; set; }
    public int? WorldId { get; set; }
    public List<SkillTemplate> Skills { get; set; } = new();
}