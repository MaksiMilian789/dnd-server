using DndServer.Application.Characters.Interfaces;
using DndServer.Application.Characters.Models;
using DndServer.Application.Characters.Models.Create;
using DndServer.Application.Interfaces;
using DndServer.Application.Interfaces.Characters.Background;
using DndServer.Application.Interfaces.Characters.Skill;
using DndServer.Application.Shared;
using DndServer.Domain.Characters.Background;

namespace DndServer.Application.Characters.Services;

public class BackgroundService : IBackgroundService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IBackgroundTemplateRepository _backgroundTemplateRepository;
    private readonly ISkillTemplateRepository _skillTemplateRepository;

    public BackgroundService(IBackgroundTemplateRepository backgroundTemplateRepository,
        ISkillTemplateRepository skillTemplateRepository, IUnitOfWork unitOfWork)
    {
        _backgroundTemplateRepository = backgroundTemplateRepository;
        _skillTemplateRepository = skillTemplateRepository;
        _unitOfWork = unitOfWork;
    }

    public Task<List<BackgroundDto>> GetBackgrounds()
    {
        var listTemplates = _backgroundTemplateRepository.Get();
        var listDto = new List<BackgroundDto>();
        foreach (var val in listTemplates)
        {
            var skills = SkillUtilsService.CreateSkillsTemplatesDto(val.SkillTemplate);
            var dto = new BackgroundDto
            {
                Id = val.Id,
                Name = val.Name,
                Description = val.Description,
                System = val.System,
                WorldId = val.WorldId,
                AuthorId = val.AuthorId,
                SkillInstances = skills
            };
            listDto.Add(dto);
        }

        _unitOfWork.SaveChanges();

        return Task.FromResult(listDto);
    }

    public Task CreateBackgroundTemplate(BackgroundCreateDto dto)
    {
        var background = new BackgroundTemplate(dto.Name, dto.Description, dto.System, dto.AuthorId, dto.WorldId);

        var skillTemplates = _skillTemplateRepository.Get(x => dto.SkillIds.Contains(x.Id));
        var skills = SkillUtilsService.CreateSkillsTemplateFromTemplate(skillTemplates);
        foreach (var skill in skills)
        {
            background.SkillTemplate.Add(skill);
        }

        _backgroundTemplateRepository.Create(background);

        _unitOfWork.SaveChanges();
        return Task.CompletedTask;
    }
}