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
    public async Task<ActionResult<List<ShortCharacterDto>>> GetListCharacters(string login)
    {
        var charList = await _characterService.GetShortListCharacters(login);
        return charList;
    }

    private static ProblemDetails CreateFailResponse(string title) => new() { Title = title };
}