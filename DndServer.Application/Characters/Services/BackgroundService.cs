using DndServer.Application.Characters.Interfaces;
using DndServer.Application.Characters.Models;
using DndServer.Application.Interfaces.Characters.Background;
using DndServer.Application.Interfaces.Characters.Skill;
using DndServer.Application.Shared;
using DndServer.Domain.Characters.Background;

namespace DndServer.Application.Characters.Services;

public class BackgroundService : IBackgroundService
{
    private readonly IBackgroundTemplateRepository _backgroundTemplateRepository;
    private readonly ISkillInstanceRepository _skillInstanceRepository;
    private readonly ISkillTemplateRepository _skillTemplateRepository;

    public BackgroundService(IBackgroundTemplateRepository backgroundTemplateRepository,
        ISkillInstanceRepository skillInstanceRepository, ISkillTemplateRepository skillTemplateRepository)
    {
        _backgroundTemplateRepository = backgroundTemplateRepository;
        _skillInstanceRepository = skillInstanceRepository;
        _skillTemplateRepository = skillTemplateRepository;
    }

    public Task<List<BackgroundDto>> GetBackgrounds()
    {
        var listTemplates = _backgroundTemplateRepository.Get();
        var listDto = new List<BackgroundDto>();
        foreach (var val in listTemplates)
        {
            var dto = new BackgroundDto
            {
                Name = val.Name,
                Description = val.Description,
                System = val.System,
                WorldId = val.WorldId,
                Skills = val.SkillTemplate.ToList()
            };
            listDto.Add(dto);
        }

        return Task.FromResult(listDto);
    }

    public Task CreateBackgroundTemplate(BackgroundCreateDto dto)
    {
        var background = new BackgroundTemplate(dto.Name, dto.Description, dto.System, dto.AuthorId, dto.WorldId);
        var skillTemplates = _skillTemplateRepository.Get(x => dto.SkillIds.Contains(x.Id));
        var skillInstances = SkillsModelCreator.CreateSkillsInstances(skillTemplates, _skillInstanceRepository);
        background.SkillInstance = skillInstances;
        _backgroundTemplateRepository.Create(background);

        return Task.CompletedTask;
    }
}