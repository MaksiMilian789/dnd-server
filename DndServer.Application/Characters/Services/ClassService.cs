using DndServer.Application.Characters.Interfaces;
using DndServer.Application.Characters.Models;
using DndServer.Application.Characters.Models.Create;
using DndServer.Application.Interfaces;
using DndServer.Application.Interfaces.Characters.Class;
using DndServer.Application.Interfaces.Characters.Skill;
using DndServer.Application.Shared;
using DndServer.Domain.Characters.Class;

namespace DndServer.Application.Characters.Services;

public class ClassService : IClassService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IClassTemplateRepository _classTemplateRepository;
    private readonly ISkillTemplateRepository _skillTemplateRepository;

    public ClassService(IClassTemplateRepository classTemplateRepository,
        ISkillTemplateRepository skillTemplateRepository, IUnitOfWork unitOfWork)
    {
        _classTemplateRepository = classTemplateRepository;
        _skillTemplateRepository = skillTemplateRepository;
        _unitOfWork = unitOfWork;
    }

    public Task<List<ClassDto>> GetClasses()
    {
        var listTemplates = _classTemplateRepository.Get();
        var listDto = new List<ClassDto>();
        foreach (var val in listTemplates)
        {
            var skills = SkillUtilsService.CreateSkillsTemplatesDto(val.SkillTemplate);
            var dto = new ClassDto
            {
                Id = val.Id,
                Name = val.Name,
                Description = val.Description,
                System = val.System,
                WorldId = val.WorldId,
                AuthorId = val.AuthorId,
                Skills = skills
            };
            listDto.Add(dto);
        }

        return Task.FromResult(listDto);
    }

    public Task CreateClassTemplate(ClassCreateDto dto)
    {
        var classTemplate = new ClassTemplate(dto.Name, dto.Description, dto.System, dto.AuthorId, dto.WorldId);
        _classTemplateRepository.Create(classTemplate);

        var skillTemplates = _skillTemplateRepository.Get(x => dto.SkillIds.Contains(x.Id));
        foreach (var skillTemplate in skillTemplates)
        {
            skillTemplate.ClassTemplate.Add(classTemplate);
            _skillTemplateRepository.Update(skillTemplate);
        }

        _unitOfWork.SaveChanges();
        return Task.CompletedTask;
    }
}