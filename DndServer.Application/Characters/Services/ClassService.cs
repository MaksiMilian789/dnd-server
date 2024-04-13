using DndServer.Application.Characters.Interfaces;
using DndServer.Application.Characters.Models;
using DndServer.Application.Interfaces.Characters.Class;
using DndServer.Application.Interfaces.Characters.Skill;
using DndServer.Application.Shared;
using DndServer.Domain.Characters.Class;

namespace DndServer.Application.Characters.Services;

public class ClassService : IClassService
{
    private readonly IClassTemplateRepository _classTemplateRepository;
    private readonly ISkillInstanceRepository _skillInstanceRepository;
    private readonly ISkillTemplateRepository _skillTemplateRepository;

    public ClassService(IClassTemplateRepository classTemplateRepository,
        ISkillInstanceRepository skillInstanceRepository, ISkillTemplateRepository skillTemplateRepository)
    {
        _classTemplateRepository = classTemplateRepository;
        _skillInstanceRepository = skillInstanceRepository;
        _skillTemplateRepository = skillTemplateRepository;
    }

    public Task<List<ClassDto>> GetClasses(string login)
    {
        var listTemplates = _classTemplateRepository.Get();
        var listDto = new List<ClassDto>();
        foreach (var val in listTemplates)
        {
            var dto = new ClassDto
            {
                Name = val.Name,
                Description = val.Description,
                System = val.System,
                WorldId = val.WorldId
            };
            listDto.Add(dto);
        }

        return Task.FromResult(listDto);
    }

    public Task CreateClassTemplate(ClassCreateDto dto)
    {
        var classTemplate = new ClassTemplate(dto.Name, dto.Description, dto.System, dto.AuthorId, dto.WorldId);
        var skillTemplates = _skillTemplateRepository.Get(x => dto.SkillIds.Contains(x.Id));
        var skillInstances = SkillsModelCreator.CreateSkillsInstances(skillTemplates, _skillInstanceRepository);
        classTemplate.SkillInstance = skillInstances;
        _classTemplateRepository.Create(classTemplate);

        return Task.CompletedTask;
    }
}