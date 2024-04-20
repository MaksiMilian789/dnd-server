using DndServer.Application.Characters.Interfaces;
using DndServer.Application.Characters.Models;
using DndServer.Application.Interfaces.Characters.Race;
using DndServer.Application.Interfaces.Characters.Skill;
using DndServer.Domain.Characters.Race;
using DndServer.Domain.Characters.Skill;

namespace DndServer.Application.Characters.Services;

public class RaceService : IRaceService
{
    private readonly IRaceTemplateRepository _raceTemplateRepository;
    private readonly ISkillTemplateRepository _skillTemplateRepository;

    public RaceService(IRaceTemplateRepository raceTemplateRepository,
        ISkillTemplateRepository skillTemplateRepository)
    {
        _raceTemplateRepository = raceTemplateRepository;
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
                Id = val.Id,
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
        race.SkillTemplate = (ICollection<SkillTemplate>)skillTemplates;
        _raceTemplateRepository.Create(race);

        return Task.CompletedTask;
    }
}