using DndServer.Application.Interfaces.Characters.Skill;
using DndServer.Domain.Characters.Skill;

namespace DndServer.Application.Shared;

public static class SkillsModelCreator
{
    public static ICollection<SkillInstance> CreateSkillsInstances(IEnumerable<SkillTemplate> templates,
        ISkillInstanceRepository skillInstanceRepository)
    {
        var skillInstances = new List<SkillInstance>();
        foreach (var skillTemplate in templates)
        {
            var skill = new SkillInstance(skillTemplate.Name, skillTemplate.Description, skillTemplate.ActionType,
                skillTemplate.SkillType, skillTemplate.Distance, skillTemplate.Passive, skillTemplate.Recharge,
                skillTemplate.Charges, skillTemplate.System);
            skillInstanceRepository.Create(skill);
            skillInstances.Add(skill);
        }

        return skillInstances;
    }
}