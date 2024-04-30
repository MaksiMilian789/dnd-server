using DndServer.Application.Characters.Interfaces;
using DndServer.Application.Characters.Models;
using DndServer.Application.Characters.Models.Create;
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
    private readonly ISkillService _skillService;

    public CharacterController(
        ICharacterService characterService, IBackgroundService backgroundService, IRaceService raceService,
        IClassService classService, ISkillService skillService)
    {
        _characterService = characterService;
        _backgroundService = backgroundService;
        _raceService = raceService;
        _classService = classService;
        _skillService = skillService;
    }

    /// <summary>
    ///     Список персонажей пользователя
    /// </summary>
    [HttpGet("getListCharacters")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<List<ShortCharacterDto>>> GetListCharacters(int id)
    {
        return await _characterService.GetShortListCharacters(id);
    }

    /// <summary>
    ///     Персонаж
    /// </summary>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<CharacterDto>> GetCharacter(int id)
    {
        return await _characterService.GetCharacter(id);
    }

    /// <summary>
    ///     Создание персонажа
    /// </summary>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesDefaultResponseType]
    public async Task CreateCharacter([FromBody] CharacterCreateDto character, int userId)
    {
        await _characterService.CreateCharacter(character, userId);
    }

    /// <summary>
    ///     Изменение HP
    /// </summary>
    [HttpPut("hp")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesDefaultResponseType]
    public async Task ChangeHp(int id, int hp, int addHp)
    {
        await _characterService.SetHpCharacter(id, hp, addHp);
    }

    /// <summary>
    ///     Добавление скилла
    /// </summary>
    [HttpPut("addSkill")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesDefaultResponseType]
    public async Task AddSkill(int id, int skillId)
    {
        await _characterService.AddSkill(id, skillId);
    }

    /// <summary>
    ///     Список шаблонов классов
    /// </summary>
    [HttpGet("getClasses")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<List<ClassDto>>> GetClasses()
    {
        return await _classService.GetClasses();
    }

    /// <summary>
    ///     Создание шаблона класса
    /// </summary>
    [HttpPost("class")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesDefaultResponseType]
    public async Task CreateClass([FromBody] ClassCreateDto classs)
    {
        await _classService.CreateClassTemplate(classs);
    }

    /// <summary>
    ///     Список шаблонов рас
    /// </summary>
    [HttpGet("getRaces")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<List<RaceDto>>> GetRaces()
    {
        return await _raceService.GetRaces();
    }

    /// <summary>
    ///     Создание шаблона расы
    /// </summary>
    [HttpPost("race")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesDefaultResponseType]
    public async Task CreateRace([FromBody] RaceCreateDto race)
    {
        await _raceService.CreateRaceTemplate(race);
    }

    /// <summary>
    ///     Список шаблонов предысторий
    /// </summary>
    [HttpGet("getBackgrounds")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<List<BackgroundDto>>> GetBackgrounds()
    {
        return await _backgroundService.GetBackgrounds();
    }

    /// <summary>
    ///     Создание шаблона предыстории
    /// </summary>
    [HttpPost("background")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesDefaultResponseType]
    public async Task CreateBackground([FromBody] BackgroundCreateDto background)
    {
        await _backgroundService.CreateBackgroundTemplate(background);
    }


    /// <summary>
    ///     Список шаблонов skill
    /// </summary>
    [HttpGet("getSkills")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<List<SkillDto>>> GetSkills()
    {
        return await _skillService.GetSkills();
    }

    /// <summary>
    ///     Создание шаблона skill
    /// </summary>
    [HttpPost("skill")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesDefaultResponseType]
    public async Task CreateSkill([FromBody] SkillCreateDto skill)
    {
        await _skillService.CreateSkillTemplate(skill);
    }
}