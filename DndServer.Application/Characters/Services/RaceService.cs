using DndServer.Application.Characters.Interfaces;
using DndServer.Application.Characters.Models;
using DndServer.Application.Interfaces.Characters.Race;
using DndServer.Application.Interfaces.Characters.Skill;
using DndServer.Application.Shared;
using DndServer.Domain.Characters.Race;

namespace DndServer.Application.Characters.Services;

public class RaceService : IRaceService
{
    private readonly IRaceTemplateRepository _raceTemplateRepository;
    private readonly ISkillInstanceRepository _skillInstanceRepository;
    private readonly ISkillTemplateRepository _skillTemplateRepository;

    public RaceService(IRaceTemplateRepository raceTemplateRepository, ISkillInstanceRepository skillInstanceRepository,
        ISkillTemplateRepository skillTemplateRepository)
    {
        _raceTemplateRepository = raceTemplateRepository;
        _skillInstanceRepository = skillInstanceRepository;
        _skillTemplateRepository = skillTemplateRepository;
    }

    public Task<List<RaceDto>> GetRaces()
    {
        var listTemplates = _raceTemplateRepository.Get();
        var listDto = new List<RaceDto>();
        foreach (var val in listTemplates)
        {
            var dto = new RaceDto
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

    public Task CreateRaceTemplate(RaceCreateDto dto)
    {
        var race = new RaceTemplate(dto.Name, dto.Description, dto.System, dto.AuthorId, dto.WorldId);
        var skillTemplates = _skillTemplateRepository.Get(x => dto.SkillIds.Contains(x.Id));
        var skillInstances = SkillsModelCreator.CreateSkillsInstances(skillTemplates, _skillInstanceRepository);
        race.SkillInstance = skillInstances;
        _raceTemplateRepository.Create(race);

        return Task.CompletedTask;
    }
}