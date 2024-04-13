using DndServer.Application.Characters.Interfaces;
using DndServer.Application.Characters.Models;
using DndServer.Application.Interfaces.Characters.Race;

namespace DndServer.Application.Characters.Services;

public class RaceService : IRaceService
{
    private readonly IRaceTemplateRepository _raceTemplateRepository;

    public RaceService(IRaceTemplateRepository raceTemplateRepository)
    {
        _raceTemplateRepository = raceTemplateRepository;
    }

    public Task<List<RaceDto>> GetRaces(string login)
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
                WorldId = val.WorldId
            };
            listDto.Add(dto);
        }

        return Task.FromResult(listDto);
    }
}