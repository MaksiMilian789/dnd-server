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

    public CharacterController(ICharacterService characterService)
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
    ///     Добавление состояния
    /// </summary>
    [HttpPut("addCondition")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesDefaultResponseType]
    public async Task AddCondition(int id, int conditionId)
    {
        await _characterService.AddCondition(id, conditionId);
    }

    /// <summary>
    ///     Добавление заклинания
    /// </summary>
    [HttpPut("addSpell")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesDefaultResponseType]
    public async Task AddSpell(int id, int spellId)
    {
        await _characterService.AddSpell(id, spellId);
    }

    /// <summary>
    ///     Добавление предмета в инвентарь
    /// </summary>
    [HttpPut("addObject")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesDefaultResponseType]
    public async Task AddObject(int id, int objectId)
    {
        await _characterService.AddObject(id, objectId);
    }

    /// <summary>
    ///     Сохранение заметки
    /// </summary>
    [HttpPut("note")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesDefaultResponseType]
    public async Task SaveNote(int id, string header, string text, int? imageId, int? noteId)
    {
        await _characterService.SaveNote(id, header, text, imageId, noteId);
    }

    /// <summary>
    ///     Изменение информации о персонаже
    /// </summary>
    [HttpPut("editInfo")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesDefaultResponseType]
    public async Task EditInfo(int id, string name, int level, int age, int? imageId)
    {
        await _characterService.EditCharInfo(id, name, level, age, imageId);
    }

    /// <summary>
    ///     Toggle способность
    /// </summary>
    [HttpPut("toggleSkill")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesDefaultResponseType]
    public async Task ToggleSkill(int id, int skillId, bool active, int changeCharges)
    {
        await _characterService.ToggleSkill(id, skillId, active, changeCharges);
    }

    /// <summary>
    ///     Обновление зарядов способности
    /// </summary>
    [HttpPut("resetSkillCharges")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesDefaultResponseType]
    public async Task ResetSkillCharges(int id, int skillId)
    {
        await _characterService.ResetSkillCharges(id, skillId);
    }

    /// <summary>
    ///     Экипировка предмета
    /// </summary>
    [HttpPut("equipObject")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesDefaultResponseType]
    public async Task EquipObject(int id, int objectId, bool equip)
    {
        await _characterService.EquipObject(id, objectId, equip);
    }
}