using DndServer.Application.Characters.Interfaces;
using DndServer.Application.Characters.Models;
using DndServer.Application.Characters.Models.Create;
using DndServer.Application.Characters.Models.Instances;
using DndServer.Application.Interfaces;
using DndServer.Application.Interfaces.Characters;
using DndServer.Application.Interfaces.Characters.Background;
using DndServer.Application.Interfaces.Characters.Class;
using DndServer.Application.Interfaces.Characters.Race;
using DndServer.Application.Interfaces.Characters.Skill;
using DndServer.Application.Interfaces.Users;
using DndServer.Application.Shared;
using DndServer.Domain.Characters;
using DndServer.Domain.Characters.Background;
using DndServer.Domain.Characters.Class;
using DndServer.Domain.Characters.Race;
using DndServer.Domain.Characters.Skill;

namespace DndServer.Application.Characters.Services;

public class CharacterService : ICharacterService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICharacterRepository _characterRepository;
    private readonly IClassTemplateRepository _classTemplateRepository;
    private readonly IRaceTemplateRepository _raceTemplateRepository;
    private readonly IBackgroundTemplateRepository _backgroundTemplateRepository;
    private readonly IUserRepository _userRepository;
    private readonly ISkillTemplateRepository _skillTemplateRepository;
    private readonly ISkillInstanceRepository _skillInstanceRepository;

    public CharacterService(ICharacterRepository characterRepository, IClassTemplateRepository classTemplateRepository,
        IRaceTemplateRepository raceTemplateRepository, IBackgroundTemplateRepository backgroundTemplateRepository,
        IUserRepository userRepository, IUnitOfWork unitOfWork, ISkillTemplateRepository skillTemplateRepository,
        ISkillInstanceRepository skillInstanceRepository)
    {
        _characterRepository = characterRepository;
        _classTemplateRepository = classTemplateRepository;
        _raceTemplateRepository = raceTemplateRepository;
        _backgroundTemplateRepository = backgroundTemplateRepository;
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
        _skillTemplateRepository = skillTemplateRepository;
        _skillInstanceRepository = skillInstanceRepository;
    }

    public Task<List<ShortCharacterDto>> GetShortListCharacters(int userId)
    {
        var charList = _characterRepository.Get().Where(x => x.User.Id == userId);
        var shortList = charList.Select(character =>
        {
            var classInstance = character.ClassInstance;
            return new ShortCharacterDto
            {
                Id = character.Id,
                Name = character.Name,
                Level = character.Level,
                ClassName = classInstance.Name,
                System = character.System
            };
        }).ToList();

        return Task.FromResult(shortList);
    }

    public Task<CharacterDto> GetCharacter(int id)
    {
        var character = _characterRepository.Get(x => x.Id == id).FirstOrDefault();
        if (character == null)
        {
            throw new Exception();
        }

        var conditions = new List<ConditionDto>();
        foreach (var item in character.Conditions)
        {
            var dto = new ConditionDto
            {
                Id = item.Id,
                Name = item.Name,
                Description = item.Description
            };
            conditions.Add(dto);
        }

        var objectInstances = new List<ObjectInstanceDto>();
        foreach (var item in character.ObjectInstance)
        {
            var dto = new ObjectInstanceDto
            {
                Id = item.Id,
                Name = item.Name,
                Description = item.Description,
                Damage = item.Damage,
                AttackType = item.AttackType,
                Distance = item.Distance,
                ImageId = item.ImageId,
                Quantity = item.Quantity,
                System = item.System,
                SkillInstances = SkillUtilsService.CreateSkillsInstancesDto(item.SkillInstance)
            };
            objectInstances.Add(dto);
        }

        var notes = new List<NoteDto>();
        foreach (var item in character.Note)
        {
            var dto = new NoteDto
            {
                Id = item.Id,
                Header = item.Header,
                Text = item.Text
            };
            notes.Add(dto);
        }

        var skillInstances = new List<SkillInstanceDto>();
        foreach (var item in character.SkillInstance)
        {
            var dto = new SkillInstanceDto
            {
                Id = item.Id,
                Name = item.Name,
                Description = item.Description,
                ActionType = item.ActionType,
                SkillType = item.SkillType,
                Value = item.Value,
                Distance = item.Distance,
                Passive = item.Passive,
                Recharge = item.Recharge,
                Charges = item.Charges,
                System = item.System
            };
            skillInstances.Add(dto);
        }

        var spellInstances = new List<SpellInstanceDto>();
        foreach (var item in character.SpellInstance)
        {
            var dto = new SpellInstanceDto
            {
                Id = item.Id,
                Name = item.Name,
                Description = item.Description,
                Level = item.Level,
                Distance = item.Distance,
                ActionType = item.ActionType,
                Damage = item.Damage,
                ActionTime = item.ActionTime,
                Components = item.Components,
                System = item.System,
                SkillInstances = SkillUtilsService.CreateSkillsInstancesDto(item.SkillInstance)
            };
            spellInstances.Add(dto);
        }

        var characterDto = new CharacterDto
        {
            Id = character.Id,
            Name = character.Name,
            Level = character.Level,
            Age = character.Age,
            Hp = character.Hp,
            AddHp = character.AddHp,
            ImageId = character.ImageId,
            SpellSlots = character.SpellSlots,
            EnergySlots = character.EnergySlots,
            Gender = character.Gender,
            Ideology = character.Ideology,
            System = character.System,
            Characteristics = character.Characteristics,
            ClassInstance = new ClassInstanceDto
            {
                Id = character.ClassInstance.Id,
                Name = character.ClassInstance.Name,
                Description = character.ClassInstance.Description,
                System = character.ClassInstance.System,
                SkillInstances = SkillUtilsService.CreateSkillsInstancesDto(character.ClassInstance.SkillInstance)
            },
            RaceInstance = new RaceInstanceDto
            {
                Id = character.RaceInstance.Id,
                Name = character.RaceInstance.Name,
                Description = character.RaceInstance.Description,
                System = character.RaceInstance.System,
                SkillInstances = SkillUtilsService.CreateSkillsInstancesDto(character.RaceInstance.SkillInstance)
            },
            BackgroundInstance = new BackgroundInstanceDto
            {
                Id = character.BackgroundInstance.Id,
                Name = character.BackgroundInstance.Name,
                Description = character.BackgroundInstance.Description,
                System = character.BackgroundInstance.System,
                SkillInstances = SkillUtilsService.CreateSkillsInstancesDto(character.BackgroundInstance.SkillInstance)
            },
            Conditions = conditions,
            ObjectInstance = objectInstances,
            Note = notes,
            SkillInstance = skillInstances,
            SpellInstance = spellInstances
        };

        return Task.FromResult(characterDto);
    }

    public Task CreateCharacter(CharacterCreateDto dto, int userId)
    {
        var character = new Character(dto.Name, dto.Level, dto.Age, dto.Gender, dto.Ideology, dto.System,
            dto.Characteristics);

        if (dto.ImageId != null)
        {
            character.ImageId = (int)dto.ImageId;
        }

        var classTemplate = _classTemplateRepository.Get(x => x.Id == dto.ClassId).FirstOrDefault();
        var raceTemplate = _raceTemplateRepository.Get(x => x.Id == dto.RaceId).FirstOrDefault();
        var backgroundTemplate = _backgroundTemplateRepository.Get(x => x.Id == dto.BackgroundId).FirstOrDefault();

        if (classTemplate == null || raceTemplate == null || backgroundTemplate == null)
        {
            throw new Exception();
        }

        var classInstance = new ClassInstance(classTemplate.Name, classTemplate.Description, classTemplate.System)
        {
            SkillInstance = SkillUtilsService.CreateSkillsInstancesFromTemplate(classTemplate.SkillTemplate)
        };

        var raceInstance = new RaceInstance(raceTemplate.Name, raceTemplate.Description, raceTemplate.System)
        {
            SkillInstance = SkillUtilsService.CreateSkillsInstancesFromTemplate(raceTemplate.SkillTemplate)
        };

        var backgroundInstance = new BackgroundInstance(backgroundTemplate.Name, backgroundTemplate.Description,
            backgroundTemplate.System)
        {
            SkillInstance = SkillUtilsService.CreateSkillsInstancesFromTemplate(backgroundTemplate.SkillTemplate)
        };

        character.ClassInstance = classInstance;
        character.RaceInstance = raceInstance;
        character.BackgroundInstance = backgroundInstance;

        var user = _userRepository.Get(x => x.Id == userId).FirstOrDefault();
        character.UserId = user!.Id;
        _characterRepository.Create(character);

        _unitOfWork.SaveChanges();
        return Task.CompletedTask;
    }

    public Task SetHpCharacter(int id, int hp, int addHp)
    {
        var character = _characterRepository.Get(x => x.Id == id).FirstOrDefault();
        if (character == null)
        {
            throw new Exception();
        }

        character.Hp = hp;
        character.AddHp = addHp;
        _characterRepository.Update(character);
        _unitOfWork.SaveChanges();
        return Task.CompletedTask;
    }

    public Task AddSkill(int id, int skillId)
    {
        var character = _characterRepository.Get(x => x.Id == id).FirstOrDefault();
        if (character == null)
        {
            throw new Exception();
        }

        _characterRepository.Attach(character);

        var skillTemplate = _skillTemplateRepository.Get(x => x.Id == skillId).FirstOrDefault();
        if (skillTemplate == null)
        {
            throw new Exception();
        }

        var instance = SkillUtilsService.CreateSkillsInstancesFromTemplate(new List<SkillTemplate> { skillTemplate })
            .FirstOrDefault();

        if (instance != null)
        {
            character.SkillInstance.Add(instance);
        }

        _characterRepository.Update(character);
        _unitOfWork.SaveChanges();
        return Task.CompletedTask;
    }
}