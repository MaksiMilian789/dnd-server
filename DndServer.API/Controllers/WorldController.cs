using DndServer.Application.Worlds.Interfaces;
using DndServer.Application.Worlds.Models;
using DndServer.Domain.Shared.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DndServer.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class WorldController : ControllerBase
{
    private readonly IWorldService _worldService;
    private readonly ITrackerService _trackerService;

    public WorldController(IWorldService worldService, ITrackerService trackerService)
    {
        _worldService = worldService;
        _trackerService = trackerService;
    }

    /// <summary>
    ///     Список миров пользователя
    /// </summary>
    [HttpGet("getListWorlds")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<List<ShortWorldDto>>> GetListWorlds(int userId, RoleEnum? role)
    {
        return await _worldService.GetWorlds(userId, role);
    }

    /// <summary>
    ///     Мир
    /// </summary>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<WorldDto>> GetWorld(int id)
    {
        return await _worldService.GetWorld(id);
    }

    /// <summary>
    ///     Создание мира
    /// </summary>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesDefaultResponseType]
    public async Task CreateWorld([FromBody] WorldCreateDto dto, int userId)
    {
        await _worldService.CreateWorld(dto, userId);
    }

    /// <summary>
    ///     Редактирование мира
    /// </summary>
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesDefaultResponseType]
    public async Task EditWorld([FromBody] WorldDto dto)
    {
        await _worldService.EditWorld(dto);
    }

    /// <summary>
    ///     Получить трекер
    /// </summary>
    [HttpGet("getTracker")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<TrackerDto>> GetTracker(int worldId)
    {
        return await _trackerService.GetTracker(worldId);
    }

    /// <summary>
    ///     Сохранить трекер
    /// </summary>
    [HttpPut("setTracker")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesDefaultResponseType]
    public async Task SetTracker(int worldId, [FromBody] List<TrackerUnitDto> list)
    {
        await _trackerService.SetTracker(worldId, list);
    }

    /// <summary>
    ///     Создать раздел вики
    /// </summary>
    [HttpPost("wikiPart")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesDefaultResponseType]
    public async Task AddWikiPart(string name, int worldId)
    {
        await _worldService.AddWikiPart(name, worldId);
    }

    /// <summary>
    ///     Добавить страницу вики
    /// </summary>
    [HttpPut("wikiPage")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesDefaultResponseType]
    public async Task SaveWikiPage(string header, string text, int? imageId, int? pageId, int wikiId)
    {
        await _worldService.SaveWikiPage(header, text, imageId, pageId, wikiId);
    }

    /// <summary>
    ///     Получить роли
    /// </summary>
    [HttpGet("getUserRoles")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<List<UserRoleDto>>> GetUserRoles(int worldId)
    {
        return await _worldService.GetUserRoles(worldId);
    }

    /// <summary>
    ///     Сохранить роли
    /// </summary>
    [HttpPut("setUserRoles")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesDefaultResponseType]
    public async Task SetUserRoles(int worldId, [FromBody] List<UserRoleDto> roles)
    {
        await _worldService.SetUserRoles(worldId, roles);
    }
}