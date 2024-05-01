using DndServer.Application.Characters.Interfaces;
using DndServer.Application.Characters.Models;
using DndServer.Application.Characters.Models.Create;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DndServer.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class WorkshopController : ControllerBase
{
    private readonly IBackgroundService _backgroundService;
    private readonly IRaceService _raceService;
    private readonly IClassService _classService;
    private readonly ISkillService _skillService;
    private readonly IConditionService _conditionService;
    private readonly IObjectService _objectService;

    public WorkshopController(IBackgroundService backgroundService, IRaceService raceService,
        IClassService classService, ISkillService skillService, IConditionService conditionService,
        IObjectService objectService)
    {
        _backgroundService = backgroundService;
        _raceService = raceService;
        _classService = classService;
        _skillService = skillService;
        _conditionService = conditionService;
        _objectService = objectService;
    }

    /// <summary>
    ///     Список шаблонов состояний
    /// </summary>
    [HttpGet("getConditions")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<List<ConditionDto>>> GetConditions()
    {
        return await _conditionService.GetConditions();
    }

    /// <summary>
    ///     Создание шаблона состояния
    /// </summary>
    [HttpPost("condition")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesDefaultResponseType]
    public async Task CreateCondition([FromBody] ConditionCreateDto condition)
    {
        await _conditionService.CreateCondition(condition);
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

    /// <summary>
    ///     Список шаблонов предметов
    /// </summary>
    [HttpGet("getObjects")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<List<ObjectDto>>> GetObjects()
    {
        return await _objectService.GetObjects();
    }

    /// <summary>
    ///     Создание шаблона предмета
    /// </summary>
    [HttpPost("object")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesDefaultResponseType]
    public async Task CreateObject([FromBody] ObjectCreateDto objectDto)
    {
        await _objectService.CreateObjectTemplate(objectDto);
    }
}