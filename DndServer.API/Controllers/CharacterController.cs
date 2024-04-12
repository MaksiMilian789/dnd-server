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

    public CharacterController(
        ICharacterService characterService)
    {
        _characterService = characterService;
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
    public async Task<ActionResult<List<CharacterInfoDto>>> GetClasses(string login) =>
        await _characterService.GetClasses(login);

    /// <summary>
    ///     Список шаблонов рас
    /// </summary>
    [HttpGet("GetRaces")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<List<CharacterInfoDto>>> GetRaces(string login) =>
        await _characterService.GetRaces(login);


    /// <summary>
    ///     Список шаблонов предысторий
    /// </summary>
    [HttpGet("GetBackgrounds")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<List<CharacterInfoDto>>> GetBackgrounds(string login) =>
        await _characterService.GetBackgrounds(login);

    private static ProblemDetails CreateFailResponse(string title) => new() { Title = title };
}