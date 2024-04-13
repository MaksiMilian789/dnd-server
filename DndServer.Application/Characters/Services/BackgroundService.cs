using DndServer.Application.Characters.Interfaces;
using DndServer.Application.Characters.Models;
using DndServer.Application.Interfaces.Characters.Background;

namespace DndServer.Application.Characters.Services;

public class BackgroundService : IBackgroundService
{
    private readonly IBackgroundTemplateRepository _backgroundTemplateRepository;

    public BackgroundService(IBackgroundTemplateRepository backgroundTemplateRepository)
    {
        _backgroundTemplateRepository = backgroundTemplateRepository;
    }

    public Task<List<BackgroundDto>> GetBackgrounds(string login)
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
                WorldId = val.WorldId
            };
            listDto.Add(dto);
        }

        return Task.FromResult(listDto);
    }
}