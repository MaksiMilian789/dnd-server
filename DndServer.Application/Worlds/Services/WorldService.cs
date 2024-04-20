using DndServer.Application.Interfaces.Users;
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
    private readonly IUserRepository _userRepository;

    public WorldService(IWorldRepository worldRepository, IWorldLinksRepository worldLinksRepository,
        IWikiRepository wikiRepository, ITrackerRepository trackerRepository, IUserRepository userRepository)
    {
        _worldRepository = worldRepository;
        _worldLinksRepository = worldLinksRepository;
        _wikiRepository = wikiRepository;
        _trackerRepository = trackerRepository;
        _userRepository = userRepository;
    }

    public Task CreateWorld(WorldCreateDto dto, int userId)
    {
        var world = new World(dto.Name, dto.Description);
        var newWiki = new Wiki(world.Name + " Вики");
        var newTracker = new Tracker(world);

        world.Wiki = newWiki;
        world.Tracker = newTracker;

        var newWorldLink = new WorldLinks(RoleEnum.Master)
        {
            UserId = _userRepository.Get(x => x.Id == userId).FirstOrDefault()!.Id,
            World = world
        };
        _worldLinksRepository.Create(newWorldLink);

        return Task.CompletedTask;
    }

    public Task<List<ShortWorldDto>> GetWorlds(int userId, RoleEnum role)
    {
        var worlds = _worldRepository.Get();
        var userWorlds = worlds.Where(x => x.WorldLinks.Any(y => y.UserId == userId && y.Role == role));
        var worldsDto = new List<ShortWorldDto>();
        foreach (var world in userWorlds)
        {
            var worldDto = new ShortWorldDto
            {
                Id = world.Id,
                Name = world.Name,
                Description = world.Description
            };
            worldsDto.Add(worldDto);
        }

        return Task.FromResult(worldsDto);
    }

    public Task<WorldDto> GetWorld(int worldId)
    {
        var worlds = _worldRepository.Get();
        var world = worlds.FirstOrDefault(x => x.WorldLinks.Any(y => y.Id == worldId));
        if (world == null) throw new Exception();

        var worldDto = new WorldDto
        {
            Id = world.Id,
            Name = world.Name,
            Description = world.Description,
            TrackerId = world.Tracker.Id,
            WikiId = world.Wiki.Id
        };

        return Task.FromResult(worldDto);
    }
}