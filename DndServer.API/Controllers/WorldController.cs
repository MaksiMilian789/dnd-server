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

    public WorldController(IWorldService worldService)
    {
        _worldService = worldService;
    }

    /// <summary>
    ///     Список миров пользователя
    /// </summary>
    [HttpGet("getListWorlds")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<List<ShortWorldDto>>> GetListCharacters(int userId, RoleEnum role) =>
        await _worldService.GetWorlds(userId, role);

    /// <summary>
    ///     Создание мира
    /// </summary>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesDefaultResponseType]
    public async Task CreateCharacter([FromBody] WorldCreateDto dto, int userId) =>
        await _worldService.CreateWorld(dto, userId);
}