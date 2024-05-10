using DndServer.Application.Characters.Models;
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
                skillTemplate.Charges, skillTemplate.System, false)
            {
                Value = skillTemplate.Value
            };
            skillInstances.Add(skill);
        }

        return skillInstances;
    }

    public static ICollection<SkillTemplate> CreateSkillsTemplateFromTemplate(IEnumerable<SkillTemplate> templates,
        bool hidden = true)
    {
        var skillTemplates = new List<SkillTemplate>();
        foreach (var skillTemplate in templates)
        {
            var skill = new SkillTemplate(skillTemplate.Name, skillTemplate.Description, skillTemplate.ActionType,
                skillTemplate.SkillType, skillTemplate.Distance, skillTemplate.Passive, skillTemplate.Recharge,
                skillTemplate.Charges, skillTemplate.System, skillTemplate.AuthorId, skillTemplate.WorldId)
            {
                Value = skillTemplate.Value,
                Hidden = hidden
            };
            skillTemplates.Add(skill);
        }

        return skillTemplates;
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
                System = instance.System,
                Activated = instance.Activated
            };
            skillInstancesDto.Add(skill);
        }

        return skillInstancesDto;
    }

    public static List<SkillDto> CreateSkillsTemplatesDto(IEnumerable<SkillTemplate> templates)
    {
        var skillTemplatesDto = new List<SkillDto>();
        foreach (var template in templates)
        {
            var skill = new SkillDto
            {
                Id = template.Id,
                Name = template.Name,
                Description = template.Description,
                ActionType = template.ActionType,
                SkillType = template.SkillType,
                Value = template.Value,
                Distance = template.Distance,
                Passive = template.Passive,
                Recharge = template.Recharge,
                Charges = template.Charges,
                System = template.System,
                AuthorId = template.AuthorId,
                WorldId = template.WorldId
            };
            skillTemplatesDto.Add(skill);
        }

        return skillTemplatesDto;
    }
}