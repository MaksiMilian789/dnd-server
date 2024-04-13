﻿using DndServer.Application.Characters.Interfaces;
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
    ///     Создание персонажа
    /// </summary>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesDefaultResponseType]
    public async Task CreateCharacter([FromBody] CharacterCreateDto dto) =>
        await _characterService.CreateCharacter(dto);

    /// <summary>
    ///     Список шаблонов классов
    /// </summary>
    [HttpGet("getClasses")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<List<ClassDto>>> GetClasses(string login) =>
        await _classService.GetClasses(login);

    /// <summary>
    ///     Создание шаблона класса
    /// </summary>
    [HttpPost("class")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesDefaultResponseType]
    public async Task CreateClass([FromBody] ClassCreateDto dto) =>
        await _classService.CreateClassTemplate(dto);

    /// <summary>
    ///     Список шаблонов рас
    /// </summary>
    [HttpGet("getRaces")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<List<RaceDto>>> GetRaces(string login) =>
        await _raceService.GetRaces(login);

    /// <summary>
    ///     Создание шаблона предыстории
    /// </summary>
    [HttpPost("race")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesDefaultResponseType]
    public async Task CreateRace([FromBody] RaceCreateDto dto) =>
        await _raceService.CreateRaceTemplate(dto);

    /// <summary>
    ///     Список шаблонов предысторий
    /// </summary>
    [HttpGet("getBackgrounds")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<List<BackgroundDto>>> GetBackgrounds(string login) =>
        await _backgroundService.GetBackgrounds(login);

    /// <summary>
    ///     Создание шаблона предыстории
    /// </summary>
    [HttpPost("background")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesDefaultResponseType]
    public async Task CreateBackground([FromBody] BackgroundCreateDto dto) =>
        await _backgroundService.CreateBackgroundTemplate(dto);
}