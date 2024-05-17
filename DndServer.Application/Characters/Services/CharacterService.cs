using DndServer.Application.Characters.Interfaces;
using DndServer.Application.Characters.Models;
using DndServer.Application.Characters.Models.Create;
using DndServer.Application.Characters.Models.Instances;
using DndServer.Application.Interfaces;
using DndServer.Application.Interfaces.Characters;
using DndServer.Application.Interfaces.Characters.Background;
using DndServer.Application.Interfaces.Characters.Class;
using DndServer.Application.Interfaces.Characters.Condition;
using DndServer.Application.Interfaces.Characters.Inventory;
using DndServer.Application.Interfaces.Characters.Notes;
using DndServer.Application.Interfaces.Characters.Race;
using DndServer.Application.Interfaces.Characters.Skill;
using DndServer.Application.Interfaces.Characters.Spell;
using DndServer.Application.Interfaces.Users;
using DndServer.Application.Shared;
using DndServer.Domain.Characters;
using DndServer.Domain.Characters.Background;
using DndServer.Domain.Characters.Class;
using DndServer.Domain.Characters.Inventory;
using DndServer.Domain.Characters.Notes;
using DndServer.Domain.Characters.Race;
using DndServer.Domain.Characters.Skill;
using DndServer.Domain.Characters.Spell;

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
    private readonly IConditionsRepository _conditionsRepository;
    private readonly ISpellTemplateRepository _spellTemplateRepository;
    private readonly ISpellInstanceRepository _spellInstanceRepository;
    private readonly IObjectTemplateRepository _objectTemplateRepository;
    private readonly IObjectInstanceRepository _objectInstanceRepository;
    private readonly INoteRepository _noteRepository;

    public CharacterService(ICharacterRepository characterRepository, IClassTemplateRepository classTemplateRepository,
        IRaceTemplateRepository raceTemplateRepository, IBackgroundTemplateRepository backgroundTemplateRepository,
        IUserRepository userRepository, IUnitOfWork unitOfWork, ISkillTemplateRepository skillTemplateRepository,
        ISkillInstanceRepository skillInstanceRepository, IConditionsRepository conditionsRepository,
        ISpellTemplateRepository spellTemplateRepository, ISpellInstanceRepository spellInstanceRepository,
        IObjectTemplateRepository objectTemplateRepository, IObjectInstanceRepository objectInstanceRepository,
        INoteRepository noteRepository)
    {
        _characterRepository = characterRepository;
        _classTemplateRepository = classTemplateRepository;
        _raceTemplateRepository = raceTemplateRepository;
        _backgroundTemplateRepository = backgroundTemplateRepository;
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
        _skillTemplateRepository = skillTemplateRepository;
        _skillInstanceRepository = skillInstanceRepository;
        _conditionsRepository = conditionsRepository;
        _spellTemplateRepository = spellTemplateRepository;
        _spellInstanceRepository = spellInstanceRepository;
        _objectTemplateRepository = objectTemplateRepository;
        _objectInstanceRepository = objectInstanceRepository;
        _noteRepository = noteRepository;
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
                Attachment = item.Attachment,
                Type = item.Type,
                Equipped = item.Equipped,
                Rare = item.Rare,
                MainCharacteristic = item.MainCharacteristic,
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
                Text = item.Text,
                ImageId = item.ImageId
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
                ActionTime = item.ActionTime,
                Distance = item.Distance,
                Passive = item.Passive,
                Recharge = item.Recharge,
                Charges = item.Charges,
                CurrentCharges = item.CurrentCharges,
                System = item.System,
                Activated = item.Activated
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
                MagicSchool = item.MagicSchool,
                HasDamage = item.HasDamage,
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
            MaxAttachments = character.MaxAttachments,
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

        foreach (var skillId in dto.SkillIds)
        {
            var skillTemplate = _skillTemplateRepository.Get(x => x.Id == skillId).FirstOrDefault();
            if (skillTemplate == null)
            {
                throw new Exception();
            }

            var instance = SkillUtilsService
                .CreateSkillsInstancesFromTemplate(new List<SkillTemplate> { skillTemplate })
                .FirstOrDefault();

            if (instance != null)
            {
                character.SkillInstance.Add(instance);
            }
        }

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


    public Task AddCondition(int id, int conditionId)
    {
        var character = _characterRepository.Get(x => x.Id == id).FirstOrDefault();
        if (character == null)
        {
            throw new Exception();
        }

        _characterRepository.Attach(character);

        var condition = _conditionsRepository.Get(x => x.Id == conditionId).FirstOrDefault();
        if (condition == null)
        {
            throw new Exception();
        }

        _conditionsRepository.Attach(condition);

        character.Conditions.Add(condition);
        _characterRepository.Update(character);
        _unitOfWork.SaveChanges();
        return Task.CompletedTask;
    }

    public Task AddObject(int id, int objectId)
    {
        var character = _characterRepository.Get(x => x.Id == id).FirstOrDefault();
        if (character == null)
        {
            throw new Exception();
        }

        _characterRepository.Attach(character);

        var objectTemplate = _objectTemplateRepository.Get(x => x.Id == objectId).FirstOrDefault();
        if (objectTemplate == null)
        {
            throw new Exception();
        }

        var objectInstance = new ObjectInstance(objectTemplate.Name, objectTemplate.Description,
            objectTemplate.AttackType, objectTemplate.Attachment, objectTemplate.Rare, objectTemplate.Type,
            objectTemplate.MainCharacteristic, false, objectTemplate.Distance, 1, objectTemplate.ImageId,
            objectTemplate.System)
        {
            Damage = objectTemplate.Damage
        };

        var skillInstances = SkillUtilsService.CreateSkillsInstancesFromTemplate(objectTemplate.SkillTemplate);
        objectInstance.SkillInstance = skillInstances;

        character.ObjectInstance.Add(objectInstance);
        _characterRepository.Update(character);
        _unitOfWork.SaveChanges();
        return Task.CompletedTask;
    }

    public Task AddSpell(int id, int spellId)
    {
        var character = _characterRepository.Get(x => x.Id == id).FirstOrDefault();
        if (character == null)
        {
            throw new Exception();
        }

        _characterRepository.Attach(character);

        var spellTemplate = _spellTemplateRepository.Get(x => x.Id == spellId).FirstOrDefault();
        if (spellTemplate == null)
        {
            throw new Exception();
        }

        var spellInstance = new SpellInstance(spellTemplate.Name, spellTemplate.Description, spellTemplate.Level,
            spellTemplate.Distance, spellTemplate.ActionType, spellTemplate.MagicSchool, spellTemplate.HasDamage,
            spellTemplate.System)
        {
            Damage = spellTemplate.Damage,
            ActionTime = spellTemplate.ActionTime,
            Components = spellTemplate.Components
        };

        var skillInstances = SkillUtilsService.CreateSkillsInstancesFromTemplate(spellTemplate.SkillTemplate);
        spellInstance.SkillInstance = skillInstances;

        character.SpellInstance.Add(spellInstance);
        _characterRepository.Update(character);
        _unitOfWork.SaveChanges();
        return Task.CompletedTask;
    }

    public Task SaveNote(int id, string header, string text, int? imageId, int? noteId)
    {
        var character = _characterRepository.Get(x => x.Id == id).FirstOrDefault();
        if (character == null)
        {
            throw new Exception();
        }

        _characterRepository.Attach(character);

        if (noteId == null)
        {
            var newNote = new Note(header, text)
            {
                ImageId = imageId
            };
            character.Note.Add(newNote);
        }
        else
        {
            var note = _noteRepository.Get(x => x.Id == noteId).FirstOrDefault();
            if (note == null)
            {
                throw new Exception();
            }

            _noteRepository.Attach(note);

            note.Header = header;
            note.Text = text;
            note.ImageId = imageId;

            character.Note.Remove(character.Note.FirstOrDefault(x => x.Id == noteId) ??
                                  throw new InvalidOperationException());
            character.Note.Add(note);
        }

        _characterRepository.Update(character);
        _unitOfWork.SaveChanges();
        return Task.CompletedTask;
    }

    public Task EquipObject(int id, int objectId, bool equip)
    {
        var character = _characterRepository.Get(x => x.Id == id).FirstOrDefault();
        if (character == null)
        {
            throw new Exception();
        }

        _characterRepository.Attach(character);

        foreach (var objectInstance in character.ObjectInstance)
        {
            if (objectInstance.Id == objectId)
            {
                objectInstance.Equipped = equip;
            }
        }

        _characterRepository.Update(character);
        _unitOfWork.SaveChanges();
        return Task.CompletedTask;
    }

    public Task EditCharInfo(int id, string name, int level, int age, int? imageId)
    {
        var character = _characterRepository.Get(x => x.Id == id).FirstOrDefault();
        if (character == null)
        {
            throw new Exception();
        }

        _characterRepository.Attach(character);

        character.Name = name;
        character.Level = level;
        character.Age = age;
        character.ImageId = imageId;

        _characterRepository.Update(character);
        _unitOfWork.SaveChanges();
        return Task.CompletedTask;
    }

    public Task ResetSkillCharges(int id, int skillId)
    {
        var character = _characterRepository.Get(x => x.Id == id).FirstOrDefault();
        if (character == null)
        {
            throw new Exception();
        }

        _characterRepository.Attach(character);

        foreach (var skill in character.SkillInstance)
        {
            if (skill.Id == skillId)
            {
                skill.CurrentCharges = skill.Charges;
            }
        }

        foreach (var objectInstance in character.ObjectInstance)
        {
            foreach (var skill in objectInstance.SkillInstance)
            {
                if (skill.Id == skillId)
                {
                    skill.CurrentCharges = skill.Charges;
                }
            }
        }

        foreach (var spellInstance in character.SpellInstance)
        {
            foreach (var skill in spellInstance.SkillInstance)
            {
                if (skill.Id == skillId)
                {
                    skill.CurrentCharges = skill.Charges;
                }
            }
        }

        foreach (var skill in character.ClassInstance.SkillInstance)
        {
            if (skill.Id == skillId)
            {
                skill.CurrentCharges = skill.Charges;
            }
        }

        foreach (var skill in character.BackgroundInstance.SkillInstance)
        {
            if (skill.Id == skillId)
            {
                skill.CurrentCharges = skill.Charges;
            }
        }

        foreach (var skill in character.RaceInstance.SkillInstance)
        {
            if (skill.Id == skillId)
            {
                skill.CurrentCharges = skill.Charges;
            }
        }

        _characterRepository.Update(character);
        _unitOfWork.SaveChanges();
        return Task.CompletedTask;
    }

    public Task ToggleSkill(int id, int skillId, bool active, int changeCharges)
    {
        var character = _characterRepository.Get(x => x.Id == id).FirstOrDefault();
        if (character == null)
        {
            throw new Exception();
        }

        _characterRepository.Attach(character);

        foreach (var skill in character.SkillInstance)
        {
            if (skill.Id == skillId)
            {
                skill.Activated = active;
                skill.CurrentCharges += changeCharges;
            }
        }

        foreach (var objectInstance in character.ObjectInstance)
        {
            foreach (var skill in objectInstance.SkillInstance)
            {
                if (skill.Id == skillId)
                {
                    skill.Activated = active;
                    skill.CurrentCharges += changeCharges;
                }
            }
        }

        foreach (var spellInstance in character.SpellInstance)
        {
            foreach (var skill in spellInstance.SkillInstance)
            {
                if (skill.Id == skillId)
                {
                    skill.Activated = active;
                    skill.CurrentCharges += changeCharges;
                }
            }
        }

        foreach (var skill in character.ClassInstance.SkillInstance)
        {
            if (skill.Id == skillId)
            {
                skill.Activated = active;
                skill.CurrentCharges += changeCharges;
            }
        }

        foreach (var skill in character.BackgroundInstance.SkillInstance)
        {
            if (skill.Id == skillId)
            {
                skill.Activated = active;
                skill.CurrentCharges += changeCharges;
            }
        }

        foreach (var skill in character.RaceInstance.SkillInstance)
        {
            if (skill.Id == skillId)
            {
                skill.Activated = active;
                skill.CurrentCharges += changeCharges;
            }
        }

        _characterRepository.Update(character);
        _unitOfWork.SaveChanges();
        return Task.CompletedTask;
    }
}