using DndServer.Application.Characters.Interfaces;
using DndServer.Application.Characters.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DndServer.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class CharacterController : ControllerBase
{
    private readonly ICharacterService _characterService;
    private readonly IBackgroundService _backgroundService;
    private readonly IRaceService _raceService;
    private readonly IClassService _classService;

    public CharacterController(
        ICharacterService characterService, IBackgroundService backgroundService, IRaceService raceService,
        IClassService classService)
    {
        _characterService = characterService;
        _backgroundService = backgroundService;
        _raceService = raceService;
        _classService = classService;
    }

    /// <summary>
    ///     Список персонажей пользователя
    /// </summary>
    [HttpGet("getListCharacters")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<List<ShortCharacterDto>>> GetListCharacters(string login) =>
        await _characterService.GetShortListCharacters(login);

    /// <summary>
    ///     Список шаблонов классов
    /// </summary>
    [HttpGet("GetClasses")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<List<ClassDto>>> GetClasses(string login) =>
        await _classService.GetClasses(login);

    /// <summary>
    ///     Список шаблонов рас
    /// </summary>
    [HttpGet("GetRaces")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<List<RaceDto>>> GetRaces(string login) =>
        await _raceService.GetRaces(login);


    /// <summary>
    ///     Список шаблонов предысторий
    /// </summary>
    [HttpGet("GetBackgrounds")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<List<BackgroundDto>>> GetBackgrounds(string login) =>
        await _backgroundService.GetBackgrounds(login);

    private static ProblemDetails CreateFailResponse(string title) => new() { Title = title };
}