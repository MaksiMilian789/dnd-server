using DndServer.Application.Characters.Interfaces;
using DndServer.Application.Characters.Models;
using DndServer.Application.Characters.Models.Create;
using DndServer.Application.Interfaces;
using DndServer.Application.Interfaces.Characters.Skill;
using DndServer.Domain.Characters.Skill;

namespace DndServer.Application.Characters.Services;

public class SkillService : ISkillService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ISkillTemplateRepository _skillTemplateRepository;

    public SkillService(ISkillTemplateRepository skillTemplateRepository, IUnitOfWork unitOfWork)
    {
        _skillTemplateRepository = skillTemplateRepository;
        _unitOfWork = unitOfWork;
    }

    public Task<List<SkillDto>> GetSkills()
    {
        var skills = _skillTemplateRepository.Get();
        var skillsDto = new List<SkillDto>();
        foreach (var skill in skills)
        {
            var skillDto = new SkillDto
            {
                Id = skill.Id,
                Name = skill.Name,
                Description = skill.Description,
                ActionType = skill.ActionType,
                SkillType = skill.SkillType,
                Value = skill.Value,
                Distance = skill.Distance,
                Passive = skill.Passive,
                Recharge = skill.Recharge,
                Charges = skill.Charges,
                Hidden = skill.Hidden,
                System = skill.System,
                AuthorId = skill.AuthorId,
                WorldId = skill.WorldId
            };
            skillsDto.Add(skillDto);
        }

        _unitOfWork.SaveChanges();
        return Task.FromResult(skillsDto);
    }

    public Task CreateSkillTemplate(SkillCreateDto dto)
    {
        var skillTemplate = new SkillTemplate(dto.Name, dto.Description, dto.ActionType, dto.SkillType, dto.Distance,
            dto.Passive, dto.Recharge, dto.Charges, dto.System, dto.AuthorId, dto.WorldId)
        {
            Value = dto.Value
        };
        _skillTemplateRepository.Create(skillTemplate);

        _unitOfWork.SaveChanges();
        return Task.CompletedTask;
    }
}