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
    public int? Distance { get; set; }
    public bool Passive { get; set; }
    public int Recharge { get; set; }
    public int Charges { get; set; }
    public SystemEnum System { get; set; }

    public SkillInstance(int id, string name, string description, ActionTypesEnum actionType, SkillTypesEnum skillType,
        T value, int? distance, bool passive, int recharge, int charges, SystemEnum system)
    {
        Id = id;
        Name = name;
        Description = description;
        ActionType = actionType;
        SkillType = skillType;
        Value = value;
        Distance = distance;
        Passive = passive;
        Recharge = recharge;
        Charges = charges;
        System = system;
    }
}