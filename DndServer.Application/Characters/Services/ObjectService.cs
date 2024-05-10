using DndServer.Application.Characters.Interfaces;
using DndServer.Application.Characters.Models;
using DndServer.Application.Characters.Models.Create;
using DndServer.Application.Interfaces;
using DndServer.Application.Interfaces.Characters.Inventory;
using DndServer.Application.Interfaces.Characters.Skill;
using DndServer.Application.Shared;
using DndServer.Domain.Characters.Inventory;

namespace DndServer.Application.Characters.Services;

public class ObjectService : IObjectService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IObjectTemplateRepository _objectTemplateRepository;
    private readonly ISkillTemplateRepository _skillTemplateRepository;

    public ObjectService(IUnitOfWork unitOfWork, IObjectTemplateRepository objectTemplateRepository,
        ISkillTemplateRepository skillTemplateRepository)
    {
        _unitOfWork = unitOfWork;
        _objectTemplateRepository = objectTemplateRepository;
        _skillTemplateRepository = skillTemplateRepository;
    }

    public Task<List<ObjectDto>> GetObjects()
    {
        var objects = _objectTemplateRepository.Get();
        var listDto = new List<ObjectDto>();
        foreach (var objectTemplate in objects)
        {
            var skills = SkillUtilsService.CreateSkillsTemplatesDto(objectTemplate.SkillTemplate);
            var dto = new ObjectDto
            {
                Id = objectTemplate.Id,
                Name = objectTemplate.Name,
                Description = objectTemplate.Description,
                Damage = objectTemplate.Damage,
                AttackType = objectTemplate.AttackType,
                Attachment = objectTemplate.Attachment,
                Rare = objectTemplate.Rare,
                Type = objectTemplate.Type,
                MainCharacteristic = objectTemplate.MainCharacteristic,
                ImageId = objectTemplate.ImageId,
                Distance = objectTemplate.Distance,
                System = objectTemplate.System,
                WorldId = objectTemplate.WorldId,
                AuthorId = objectTemplate.AuthorId,
                SkillInstances = skills
            };
            listDto.Add(dto);
        }

        _unitOfWork.SaveChanges();
        return Task.FromResult(listDto);
    }

    public Task CreateObjectTemplate(ObjectCreateDto dto)
    {
        var objectTemplate = new ObjectTemplate(dto.Name, dto.Description, dto.AttackType, dto.Attachment, dto.Rare,
            dto.Type, dto.MainCharacteristic, dto.Distance, dto.ImageId, dto.System, dto.AuthorId, dto.WorldId)
        {
            Damage = dto.Damage
        };

        var skillTemplates = _skillTemplateRepository.Get(x => dto.SkillIds.Contains(x.Id));
        var skills = SkillUtilsService.CreateSkillsTemplateFromTemplate(skillTemplates);
        foreach (var skill in skills)
        {
            objectTemplate.SkillTemplate.Add(skill);
        }

        _objectTemplateRepository.Create(objectTemplate);

        _unitOfWork.SaveChanges();
        return Task.CompletedTask;
    }
}