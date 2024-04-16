using DndServer.Application.Interfaces.Worlds;
using DndServer.Application.Worlds.Interfaces;
using DndServer.Application.Worlds.Models;
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

    public Task<WorldDto> GetWorlds(int worldId)
    {
        var world = _worldRepository.Get(x => x.WorldLinks.Any(x => x.Id == worldId)).FirstOrDefault();
        if (world == null) throw new Exception();

        var worldDto = new WorldDto
        {
            Id = world.Id,
            Name = world.Name,
            Description = world.Description,
            Tracker = world.Tracker,
            Wiki = world.Wiki
        };

        return Task.FromResult(worldDto);
    }
}