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
    private readonly IWikiRepository _wikiRepository;
    private readonly IWikiPageRepository _wikiPageRepository;

    public WorldService(IWorldRepository worldRepository, IWorldLinksRepository worldLinksRepository,
        IUnitOfWork unitOfWork, IWikiRepository wikiRepository, IWikiPageRepository wikiPageRepository)
    {
        _worldRepository = worldRepository;
        _worldLinksRepository = worldLinksRepository;
        _unitOfWork = unitOfWork;
        _wikiRepository = wikiRepository;
        _wikiPageRepository = wikiPageRepository;
    }

    public Task CreateWorld(WorldCreateDto dto, int userId)
    {
        var world = new World(dto.Name, dto.Description)
        {
            ImageId = dto.ImageId
        };
        var newTracker = new Tracker(world);

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

    public Task AddWikiPart(string name, int worldId)
    {
        var world = _worldRepository.Get(x => x.Id == worldId).FirstOrDefault();
        if (world == null)
        {
            throw new Exception();
        }

        _worldRepository.Attach(world);

        var wiki = new Wiki(name);
        world.Wiki.Add(wiki);

        _worldRepository.Update(world);
        _unitOfWork.SaveChanges();
        return Task.CompletedTask;
    }

    public Task SaveWikiPage(string header, string text, int? imageId, int? pageId, int wikiId)
    {
        var wiki = _wikiRepository.Get(x => x.Id == wikiId).FirstOrDefault();
        if (wiki == null)
        {
            throw new Exception();
        }

        _wikiRepository.Attach(wiki);

        if (pageId == null)
        {
            var newPage = new WikiPage(header, text)
            {
                ImageId = imageId
            };
            wiki.WikiPage.Add(newPage);
        }
        else
        {
            var page = _wikiPageRepository.Get(x => x.Id == pageId).FirstOrDefault();
            if (page == null)
            {
                throw new Exception();
            }

            _wikiPageRepository.Attach(page);

            page.Header = header;
            page.Text = text;
            page.ImageId = imageId;

            wiki.WikiPage.Remove(wiki.WikiPage.FirstOrDefault(x => x.Id == pageId) ??
                                 throw new InvalidOperationException());
            wiki.WikiPage.Add(page);
        }

        _wikiRepository.Update(wiki);
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

        var wikiList = new List<WikiDto>();
        foreach (var wiki in world.Wiki)
        {
            var wikiPageList = new List<WikiPageDto>();
            foreach (var page in wiki.WikiPage)
            {
                var wikiPage = new WikiPageDto
                {
                    Id = page.Id,
                    Header = page.Header,
                    Text = page.Text,
                    ImageId = page.ImageId
                };
                wikiPageList.Add(wikiPage);
            }

            var wikiItem = new WikiDto
            {
                Id = wiki.Id,
                Name = wiki.Name,
                Pages = wikiPageList
            };
            wikiList.Add(wikiItem);
        }

        var worldDto = new WorldDto
        {
            Id = world.Id,
            Name = world.Name,
            Description = world.Description,
            TrackerId = world.Tracker.Id,
            ImageId = world.ImageId,
            Wiki = wikiList
        };

        return Task.FromResult(worldDto);
    }
}