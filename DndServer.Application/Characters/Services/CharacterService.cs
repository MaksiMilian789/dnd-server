using DndServer.Application.Characters.Interfaces;
using DndServer.Application.Characters.Models;
using DndServer.Application.Interfaces.Characters;
using DndServer.Application.Interfaces.Characters.Background;
using DndServer.Application.Interfaces.Characters.Class;
using DndServer.Application.Interfaces.Characters.Race;
using DndServer.Application.Interfaces.Characters.Skill;
using DndServer.Domain.Characters;
using DndServer.Domain.Characters.Skill;

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
        var character = new Character(dto.Name, dto.Level, dto.Age, dto.Gender, dto.Ideology, dto.System);

        var classInstance = _classTemplateRepository.Get(x => x.Id == dto.ClassId).FirstOrDefault();
        var raceInstance = _raceTemplateRepository.Get(x => x.Id == dto.RaceId).FirstOrDefault();
        var backgroundInstance = _backgroundTemplateRepository.Get(x => x.Id == dto.BackgroundId).FirstOrDefault();

        if (classInstance == null || raceInstance == null || backgroundInstance == null) throw new Exception();
        classInstance.SkillInstance = CreateSkillsInstances(classInstance.SkillTemplate);
        raceInstance.SkillInstance = CreateSkillsInstances(raceInstance.SkillTemplate);
        backgroundInstance.SkillInstance = CreateSkillsInstances(backgroundInstance.SkillTemplate);

        _classInstanceRepository.Create(classInstance);
        _raceInstanceRepository.Create(raceInstance);
        _backgroundInstanceRepository.Create(backgroundInstance);

        character.ClassInstance = classInstance;
        character.RaceInstance = raceInstance;
        character.BackgroundInstance = backgroundInstance;
        _characterRepository.Create(character);

        return Task.CompletedTask;
    }

    private ICollection<SkillInstance> CreateSkillsInstances(IEnumerable<SkillTemplate> instance)
    {
        var skillInstances = new List<SkillInstance>();
        foreach (var skillTemplate in instance)
        {
            var skill = new SkillInstance(skillTemplate.Name, skillTemplate.Description, skillTemplate.ActionType,
                skillTemplate.SkillType, skillTemplate.Distance, skillTemplate.Passive, skillTemplate.Recharge,
                skillTemplate.Charges, skillTemplate.System);
            _skillInstanceRepository.Create(skill);
            skillInstances.Add(skill);
        }

        return skillInstances;
    }
}