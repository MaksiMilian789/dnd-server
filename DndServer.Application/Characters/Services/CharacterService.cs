using DndServer.Application.Characters.Interfaces;
using DndServer.Application.Characters.Models;
using DndServer.Application.Interfaces.Characters;

namespace DndServer.Application.Characters.Services;

public class CharacterService : ICharacterService
{
    private readonly ICharacterRepository _characterRepository;

    public CharacterService(ICharacterRepository characterRepository)
    {
        _characterRepository = characterRepository;
    }

    public Task<List<ShortCharacterDto>> GetShortListCharacters(string login)
    {
        var charList = _characterRepository.Get();
        var shortList = charList.Select(character =>
            new ShortCharacterDto(character.Name, character.ClassInstance.Name, character.Level)).ToList();

        return Task.FromResult(shortList);
    }
}