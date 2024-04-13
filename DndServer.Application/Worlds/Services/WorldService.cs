using DndServer.Application.Interfaces.Worlds;
using DndServer.Application.Worlds.Interfaces;
using DndServer.Application.Worlds.Models;
using DndServer.Domain.Shared.Enums;
using DndServer.Domain.Worlds;

namespace DndServer.Application.Worlds.Services;

public class WorldService : IWorldService
{
    private readonly IWorldRepository _worldRepository;
    private readonly IWorldLinksRepository _worldLinksRepository;
    private readonly IWikiRepository _wikiRepository;
    private readonly ITrackerRepository _trackerRepository;

    public WorldService(IWorldRepository worldRepository, IWorldLinksRepository worldLinksRepository,
        IWikiRepository wikiRepository, ITrackerRepository trackerRepository)
    {
        _worldRepository = worldRepository;
        _worldLinksRepository = worldLinksRepository;
        _wikiRepository = wikiRepository;
        _trackerRepository = trackerRepository;
    }

    public Task<List<ShortWorldDto>> GetWorlds(int userId, RoleEnum role)
    {
        var worldsList = _worldRepository.Get(x => x.WorldLinks.Any(x => x.User.Id == userId && x.Role == role));
        var shortList = new List<ShortWorldDto>();
        foreach (var world in worldsList)
        {
            var worldDto = new ShortWorldDto
            {
                Id = world.Id,
                Name = world.Name,
                Description = world.Description
            };
            shortList.Add(worldDto);
        }

        return Task.FromResult(shortList);
    }


    public Task CreateWorld(WorldCreateDto dto, int userId)
    {
        var world = new World(dto.Name, dto.Description);
        var newWiki = new Wiki(world.Name + " Вики");
        var newTracker = new Tracker(world);

        world.Wiki = newWiki;
        world.Tracker = newTracker;

        _wikiRepository.Create(newWiki);
        _trackerRepository.Create(newTracker);
        _worldRepository.Create(world);

        return Task.CompletedTask;
    }
}