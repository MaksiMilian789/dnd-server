using DndServer.Application.Characters.Interfaces;
using DndServer.Application.Characters.Models;
using DndServer.Application.Interfaces.Characters;
using DndServer.Application.Interfaces.Characters.Background;
using DndServer.Application.Interfaces.Characters.Class;
using DndServer.Application.Interfaces.Characters.Inventory;
using DndServer.Application.Interfaces.Characters.Race;
using DndServer.Application.Interfaces.Characters.Skill;
using DndServer.Application.Interfaces.Characters.Spell;
using DndServer.Domain.Characters.Background;
using DndServer.Domain.Characters.Class;
using DndServer.Domain.Characters.Race;

namespace DndServer.Application.Characters.Services;

public class CharacterService : ICharacterService
{
    private readonly ICharacterRepository _characterRepository;
    private readonly IClassTemplateRepository _classTemplateRepository;
    private readonly IRaceTemplateRepository _raceTemplateRepository;
    private readonly IBackgroundTemplateRepository _backgroundTemplateRepository;
    private readonly IObjectTemplateRepository _objectTemplateRepository;
    private readonly ISpellTemplateRepository _spellTemplateRepository;
    private readonly ISkillTemplateRepository _skillTemplateRepository;

    public CharacterService(ICharacterRepository characterRepository, IClassTemplateRepository classTemplateRepository,
        IRaceTemplateRepository raceTemplateRepository, IBackgroundTemplateRepository backgroundTemplateRepository,
        IObjectTemplateRepository objectTemplateRepository, ISpellTemplateRepository spellTemplateRepository,
        ISkillTemplateRepository skillTemplateRepository)
    {
        _characterRepository = characterRepository;
        _classTemplateRepository = classTemplateRepository;
        _raceTemplateRepository = raceTemplateRepository;
        _backgroundTemplateRepository = backgroundTemplateRepository;
        _objectTemplateRepository = objectTemplateRepository;
        _spellTemplateRepository = spellTemplateRepository;
        _skillTemplateRepository = skillTemplateRepository;
    }

    public Task<List<ShortCharacterDto>> GetShortListCharacters(string login)
    {
        var charList = _characterRepository.Get();
        var shortList = charList.Select(character =>
            new ShortCharacterDto
                { Name = character.Name, Level = character.Level, ClassName = character.ClassInstance.Name }).ToList();

        return Task.FromResult(shortList);
    }

    public Task<List<CharacterInfoDto>> GetClasses(string login)
    {
        var service = new CharacterInfoTemplateService<ClassTemplate>(_classTemplateRepository);
        return service.GetListTemplate(login);
    }

    public Task<List<CharacterInfoDto>> GetRaces(string login)
    {
        var service = new CharacterInfoTemplateService<RaceTemplate>(_raceTemplateRepository);
        return service.GetListTemplate(login);
    }

    public Task<List<CharacterInfoDto>> GetBackgrounds(string login)
    {
        var service = new CharacterInfoTemplateService<BackgroundTemplate>(_backgroundTemplateRepository);
        return service.GetListTemplate(login);
    }
}