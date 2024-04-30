using DndServer.Application.Characters.Interfaces;
using DndServer.Application.Characters.Models;
using DndServer.Application.Characters.Models.Create;
using DndServer.Application.Interfaces;
using DndServer.Application.Interfaces.Characters.Condition;
using DndServer.Application.Interfaces.Characters.Skill;
using DndServer.Application.Shared;
using DndServer.Domain.Characters.Condition;

namespace DndServer.Application.Characters.Services;

public class ConditionService : IConditionService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IConditionsRepository _conditionsRepository;
    private readonly ISkillTemplateRepository _skillTemplateRepository;

    public ConditionService(IConditionsRepository conditionsRepository,
        ISkillTemplateRepository skillTemplateRepository, IUnitOfWork unitOfWork)
    {
        _conditionsRepository = conditionsRepository;
        _skillTemplateRepository = skillTemplateRepository;
        _unitOfWork = unitOfWork;
    }

    public Task<List<ConditionDto>> GetConditions()
    {
        var listTemplates = _conditionsRepository.Get();
        var listDto = new List<ConditionDto>();
        foreach (var val in listTemplates)
        {
            var skills = SkillUtilsService.CreateSkillsTemplatesDto(val.SkillTemplate);
            var dto = new ConditionDto
            {
                Id = val.Id,
                Name = val.Name,
                Description = val.Description,
                System = val.System,
                WorldId = val.WorldId,
                AuthorId = val.AuthorId,
                Skills = skills
            };
            listDto.Add(dto);
        }

        _unitOfWork.SaveChanges();

        return Task.FromResult(listDto);
    }

    public Task CreateCondition(ConditionCreateDto dto)
    {
        var condition = new Conditions(dto.Name, dto.Description, dto.System, dto.AuthorId, dto.WorldId);

        var skillTemplates = _skillTemplateRepository.Get(x => dto.SkillIds.Contains(x.Id));
        var skills = SkillUtilsService.CreateSkillsTemplateFromTemplate(skillTemplates);
        foreach (var skill in skills)
        {
            condition.SkillTemplate.Add(skill);
        }

        _conditionsRepository.Create(condition);

        _unitOfWork.SaveChanges();
        return Task.CompletedTask;
    }
}