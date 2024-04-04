using DndServer.Domain.Shared.Enums;

namespace DndServer.Domain.Character.Skill;

public class SkillInstance<T>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public ActionTypesEnum ActionType { get; set; }
    public SkillTypesEnum SkillType { get; set; }
    public T Value { get; set; }
    public int Id { get; set; }
    public int Id { get; set; }
    public int Id { get; set; }
    public int Id { get; set; }
}