using DndServer.Application.Characters.Interfaces;
using DndServer.Application.Characters.Models;
using DndServer.Application.Interfaces;
using DndServer.Application.Interfaces.Characters.Race;
using DndServer.Application.Interfaces.Characters.Skill;
using DndServer.Application.Shared;
using DndServer.Domain.Characters.Race;

namespace DndServer.Application.Characters.Services;

public class RaceService : IRaceService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IRaceTemplateRepository _raceTemplateRepository;
    private readonly ISkillTemplateRepository _skillTemplateRepository;

    public RaceService(IRaceTemplateRepository raceTemplateRepository,
        ISkillTemplateRepository skillTemplateRepository, IUnitOfWork unitOfWork)
    {
        _raceTemplateRepository = raceTemplateRepository;
        _skillTemplateRepository = skillTemplateRepository;
        _unitOfWork = unitOfWork;
    }

    public Task<List<RaceDto>> GetRaces()
    {
        var listTemplates = _raceTemplateRepository.Get();
        var listDto = new List<RaceDto>();
        foreach (var val in listTemplates)
        {
            var skills = SkillUtilsService.CreateSkillsTemplatesDto(val.SkillTemplate);
            var dto = new RaceDto
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

        return Task.FromResult(listDto);
    }

    public Task CreateRaceTemplate(RaceCreateDto dto)
    {
        var race = new RaceTemplate(dto.Name, dto.Description, dto.System, dto.AuthorId, dto.WorldId);
        _raceTemplateRepository.Create(race);

        var skillTemplates = _skillTemplateRepository.Get(x => dto.SkillIds.Contains(x.Id));
        foreach (var skillTemplate in skillTemplates)
        {
            skillTemplate.RaceTemplate.Add(race);
            _skillTemplateRepository.Update(skillTemplate);
        }

        _unitOfWork.SaveChanges();
        return Task.CompletedTask;
    }
}