using DndServer.Application.Characters.Models;

namespace DndServer.Application.Characters.Interfaces;

public interface ICharacterService
{
    public Task<List<ShortCharacterDto>> GetShortListCharacters(int userId);
    public Task CreateCharacter(CharacterCreateDto dto, int userId);
    public Task<CharacterDto> GetCharacter(int id);
}