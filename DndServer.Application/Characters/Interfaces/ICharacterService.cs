using DndServer.Application.Characters.Models;

namespace DndServer.Application.Characters.Interfaces;

public interface ICharacterService
{
    public Task<List<ShortCharacterDto>> GetShortListCharacters(string login);
    public Task<List<CharacterInfoDto>> GetClasses(string login);
    public Task<List<CharacterInfoDto>> GetRaces(string login);
    public Task<List<CharacterInfoDto>> GetBackgrounds(string login);
}