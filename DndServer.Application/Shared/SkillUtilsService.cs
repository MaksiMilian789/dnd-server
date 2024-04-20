using DndServer.Application.Characters.Models.Instances;
using DndServer.Domain.Characters.Skill;

namespace DndServer.Application.Shared;

public static class SkillUtilsService
{
    public static ICollection<SkillInstance> CreateSkillsInstancesFromTemplate(IEnumerable<SkillTemplate> templates)
    {
        var skillInstances = new List<SkillInstance>();
        foreach (var skillTemplate in templates)
        {
            var skill = new SkillInstance(skillTemplate.Name, skillTemplate.Description, skillTemplate.ActionType,
                skillTemplate.SkillType, skillTemplate.Distance, skillTemplate.Passive, skillTemplate.Recharge,
                skillTemplate.Charges, skillTemplate.System);
            skillInstances.Add(skill);
        }

        return skillInstances;
    }

    public static List<SkillInstanceDto> CreateSkillsInstancesDto(IEnumerable<SkillInstance> instances)
    {
        var skillInstancesDto = new List<SkillInstanceDto>();
        foreach (var instance in instances)
        {
            var skill = new SkillInstanceDto
            {
                Id = instance.Id,
                Name = instance.Name,
                Description = instance.Description,
                ActionType = instance.ActionType,
                SkillType = instance.SkillType,
                Value = instance.Value,
                Distance = instance.Distance,
                Passive = instance.Passive,
                Recharge = instance.Recharge,
                Charges = instance.Charges,
                System = instance.System
            };
            skillInstancesDto.Add(skill);
        }

        return skillInstancesDto;
    }
}