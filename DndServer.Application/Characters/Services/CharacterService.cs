using DndServer.Application.Characters.Interfaces;
using DndServer.Application.Characters.Models;
using DndServer.Application.Interfaces.Characters;
using DndServer.Application.Interfaces.Characters.Background;
using DndServer.Application.Interfaces.Characters.Class;
using DndServer.Application.Interfaces.Characters.Race;
using DndServer.Application.Interfaces.Characters.Skill;
using DndServer.Application.Shared;
using DndServer.Domain.Characters;

namespace DndServer.Application.Characters.Services;

public class CharacterService : ICharacterService
{
    private readonly ICharacterRepository _characterRepository;
    private readonly IClassInstanceRepository _classInstanceRepository;
    private readonly IClassTemplateRepository _classTemplateRepository;
    private readonly IRaceInstanceRepository _raceInstanceRepository;
    private readonly IRaceTemplateRepository _raceTemplateRepository;
    private readonly IBackgroundInstanceRepository _backgroundInstanceRepository;
    private readonly IBackgroundTemplateRepository _backgroundTemplateRepository;
    private readonly ISkillInstanceRepository _skillInstanceRepository;

    public CharacterService(ICharacterRepository characterRepository, IClassInstanceRepository classInstanceRepository,
        IClassTemplateRepository classTemplateRepository, IRaceInstanceRepository raceInstanceRepository,
        IRaceTemplateRepository raceTemplateRepository, IBackgroundInstanceRepository backgroundInstanceRepository,
        IBackgroundTemplateRepository backgroundTemplateRepository, ISkillInstanceRepository skillInstanceRepository)
    {
        _characterRepository = characterRepository;
        _classInstanceRepository = classInstanceRepository;
        _classTemplateRepository = classTemplateRepository;
        _raceInstanceRepository = raceInstanceRepository;
        _raceTemplateRepository = raceTemplateRepository;
        _backgroundInstanceRepository = backgroundInstanceRepository;
        _backgroundTemplateRepository = backgroundTemplateRepository;
        _skillInstanceRepository = skillInstanceRepository;
    }

    public Task<List<ShortCharacterDto>> GetShortListCharacters(string login)
    {
        var charList = _characterRepository.Get();
        var shortList = charList.Select(character =>
            new ShortCharacterDto
                { Name = character.Name, Level = character.Level, ClassName = character.ClassInstance.Name }).ToList();

        return Task.FromResult(shortList);
    }

    public Task CreateCharacter(CharacterCreateDto dto)
    {
        var character = new Character(dto.Name, dto.Level, dto.Age, dto.Gender, dto.Ideology, dto.System,
            dto.Characteristics);

        var classInstance = _classTemplateRepository.Get(x => x.Id == dto.ClassId).FirstOrDefault();
        var raceInstance = _raceTemplateRepository.Get(x => x.Id == dto.RaceId).FirstOrDefault();
        var backgroundInstance = _backgroundTemplateRepository.Get(x => x.Id == dto.BackgroundId).FirstOrDefault();

        if (classInstance == null || raceInstance == null || backgroundInstance == null) throw new Exception();
        classInstance.SkillInstance =
            SkillsModelCreator.CreateSkillsInstances(classInstance.SkillTemplate, _skillInstanceRepository);
        raceInstance.SkillInstance =
            SkillsModelCreator.CreateSkillsInstances(raceInstance.SkillTemplate, _skillInstanceRepository);
        backgroundInstance.SkillInstance =
            SkillsModelCreator.CreateSkillsInstances(backgroundInstance.SkillTemplate, _skillInstanceRepository);

        _classInstanceRepository.Create(classInstance);
        _raceInstanceRepository.Create(raceInstance);
        _backgroundInstanceRepository.Create(backgroundInstance);

        character.ClassInstance = classInstance;
        character.RaceInstance = raceInstance;
        character.BackgroundInstance = backgroundInstance;
        _characterRepository.Create(character);

        return Task.CompletedTask;
    }

    public Task<CharacterDto> GetCharacter(int id)
    {
        var character = _characterRepository.Get(x => x.Id == id).FirstOrDefault();
        if (character == null) throw new Exception();

        var characterDto = new CharacterDto
        {
            Id = character.Id,
            Name = character.Name,
            Level = character.Level,
            Age = character.Age,
            Gender = character.Gender,
            Ideology = character.Ideology,
            System = character.System,
            Characteristics = character.Characteristics,
            ClassInstance = character.ClassInstance,
            RaceInstance = character.RaceInstance,
            BackgroundInstance = character.BackgroundInstance,
            Conditions = character.Conditions,
            ObjectInstance = character.ObjectInstance,
            Note = character.Note,
            SkillInstance = character.SkillInstance,
            SpellInstance = character.SpellInstance
        };

        return Task.FromResult(characterDto);
    }
}