using DndServer.Application.Characters.Models;
using DndServer.Application.Characters.Models.Create;

namespace DndServer.Application.Characters.Interfaces;

public interface ICharacterService
{
    public Task<List<ShortCharacterDto>> GetShortListCharacters(int userId);
    public Task CreateCharacter(CharacterCreateDto dto, int userId);
    public Task<CharacterDto> GetCharacter(int id);
    public Task SetHpCharacter(int id, int hp, int addHp);
    public Task AddSkill(int id, int skillId);
    public Task AddCondition(int id, int conditionId);
}