using DndServer.Application.Interfaces;
using DndServer.Application.Interfaces.Worlds;
using DndServer.Application.Worlds.Interfaces;
using DndServer.Application.Worlds.Models;
using DndServer.Domain.Shared.Enums;
using DndServer.Domain.Worlds;

namespace DndServer.Application.Worlds.Services;

public class WorldService : IWorldService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IWorldRepository _worldRepository;
    private readonly IWorldLinksRepository _worldLinksRepository;

    public WorldService(IWorldRepository worldRepository, IWorldLinksRepository worldLinksRepository,
        IUnitOfWork unitOfWork)
    {
        _worldRepository = worldRepository;
        _worldLinksRepository = worldLinksRepository;
        _unitOfWork = unitOfWork;
    }

    public Task CreateWorld(WorldCreateDto dto, int userId)
    {
        var world = new World(dto.Name, dto.Description)
        {
            ImageId = dto.ImageId
        };
        var newWiki = new Wiki(world.Name + " Вики");
        var newTracker = new Tracker(world);

        world.Wiki = newWiki;
        world.Tracker = newTracker;

        var newWorldLink = new WorldLinks(RoleEnum.Master)
        {
            UserId = userId,
            World = world
        };
        _worldLinksRepository.Create(newWorldLink);

        _unitOfWork.SaveChanges();
        return Task.CompletedTask;
    }

    public Task EditWorld(WorldDto dto)
    {
        var world = _worldRepository.Get(x => x.Id == dto.Id).FirstOrDefault();
        if (world == null)
        {
            throw new Exception();
        }

        _worldRepository.Attach(world);

        world.Description = dto.Description;
        world.Name = dto.Name;
        world.ImageId = dto.ImageId;

        _worldRepository.Update(world);
        _unitOfWork.SaveChanges();
        return Task.CompletedTask;
    }

    public Task<List<ShortWorldDto>> GetWorlds(int userId, RoleEnum? role)
    {
        var worlds = _worldRepository.Get();
        var userWorlds =
            worlds.Where(x => x.WorldLinks.Any(y => y.UserId == userId && (role == null || y.Role == role)));
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
        if (world == null)
        {
            throw new Exception();
        }

        var worldDto = new WorldDto
        {
            Id = world.Id,
            Name = world.Name,
            Description = world.Description,
            TrackerId = world.Tracker.Id,
            ImageId = world.ImageId,
            WikiId = world.Wiki.Id
        };

        return Task.FromResult(worldDto);
    }
}