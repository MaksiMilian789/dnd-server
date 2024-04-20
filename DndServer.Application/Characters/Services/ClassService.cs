using DndServer.Application.Characters.Interfaces;
using DndServer.Application.Characters.Models;
using DndServer.Application.Interfaces.Characters.Class;
using DndServer.Application.Interfaces.Characters.Skill;
using DndServer.Domain.Characters.Class;
using DndServer.Domain.Characters.Skill;

namespace DndServer.Application.Characters.Services;

public class ClassService : IClassService
{
    private readonly IClassTemplateRepository _classTemplateRepository;
    private readonly ISkillTemplateRepository _skillTemplateRepository;

    public ClassService(IClassTemplateRepository classTemplateRepository,
        ISkillTemplateRepository skillTemplateRepository)
    {
        _classTemplateRepository = classTemplateRepository;
        _skillTemplateRepository = skillTemplateRepository;
    }

    public Task<List<ClassDto>> GetClasses()
    {
        var listTemplates = _classTemplateRepository.Get();
        var listDto = new List<ClassDto>();
        foreach (var val in listTemplates)
        {
            var dto = new ClassDto
            {
                Id = val.Id,
                Name = val.Name,
                Description = val.Description,
                System = val.System,
                WorldId = val.WorldId,
                Skills = val.SkillTemplate.ToList()
            };
            listDto.Add(dto);
        }

        return Task.FromResult(listDto);
    }

    public Task CreateClassTemplate(ClassCreateDto dto)
    {
        var classTemplate = new ClassTemplate(dto.Name, dto.Description, dto.System, dto.AuthorId, dto.WorldId);
        var skillTemplates = _skillTemplateRepository.Get(x => dto.SkillIds.Contains(x.Id));
        classTemplate.SkillTemplate = (ICollection<SkillTemplate>)skillTemplates;
        _classTemplateRepository.Create(classTemplate);

        return Task.CompletedTask;
    }
}