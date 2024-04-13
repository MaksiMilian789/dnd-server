using DndServer.Application.Characters.Models;

namespace DndServer.Application.Characters.Interfaces;

public interface ICharacterService
{
    public Task<List<ShortCharacterDto>> GetShortListCharacters(string login);
    public Task CreateCharacter(CharacterCreateDto dto);
}