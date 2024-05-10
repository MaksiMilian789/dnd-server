using DndServer.Application.Characters.Interfaces;
using DndServer.Application.Characters.Models;
using DndServer.Application.Characters.Models.Create;
using DndServer.Application.Interfaces;
using DndServer.Application.Interfaces.Characters.Skill;
using DndServer.Application.Interfaces.Characters.Spell;
using DndServer.Application.Shared;
using DndServer.Domain.Characters.Spell;

namespace DndServer.Application.Characters.Services;

public class SpellService : ISpellService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ISpellTemplateRepository _spellTemplateRepository;
    private readonly ISkillTemplateRepository _skillTemplateRepository;

    public SpellService(IUnitOfWork unitOfWork,
        ISkillTemplateRepository skillTemplateRepository, ISpellTemplateRepository spellTemplateRepository)
    {
        _unitOfWork = unitOfWork;
        _skillTemplateRepository = skillTemplateRepository;
        _spellTemplateRepository = spellTemplateRepository;
    }

    public Task<List<SpellDto>> GetSpells()
    {
        var objects = _spellTemplateRepository.Get();
        var listDto = new List<SpellDto>();
        foreach (var val in objects)
        {
            var skills = SkillUtilsService.CreateSkillsTemplatesDto(val.SkillTemplate);
            var dto = new SpellDto
            {
                Id = val.Id,
                Name = val.Name,
                Description = val.Description,
                MagicSchool = val.MagicSchool,
                HasDamage = val.HasDamage,
                Level = val.Level,
                Distance = val.Distance,
                ActionType = val.ActionType,
                Damage = val.Damage,
                ActionTime = val.ActionTime,
                Components = val.Components,
                System = val.System,
                WorldId = val.WorldId,
                AuthorId = val.AuthorId,
                SkillInstances = skills
            };
            listDto.Add(dto);
        }

        _unitOfWork.SaveChanges();
        return Task.FromResult(listDto);
    }

    public Task CreateSpellTemplate(SpellCreateDto dto)
    {
        var spellTemplate = new SpellTemplate(dto.Name, dto.Description, dto.Level, dto.Distance, dto.ActionType,
            dto.MagicSchool, dto.HasDamage, dto.System, dto.AuthorId, dto.WorldId)
        {
            Damage = dto.Damage,
            ActionTime = dto.ActionTime,
            Components = dto.Components
        };

        var skillTemplates = _skillTemplateRepository.Get(x => dto.SkillIds.Contains(x.Id));
        var skills = SkillUtilsService.CreateSkillsTemplateFromTemplate(skillTemplates);
        foreach (var skill in skills)
        {
            spellTemplate.SkillTemplate.Add(skill);
        }

        _spellTemplateRepository.Create(spellTemplate);

        _unitOfWork.SaveChanges();
        return Task.CompletedTask;
    }
}