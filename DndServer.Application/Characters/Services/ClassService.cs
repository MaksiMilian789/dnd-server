using DndServer.Application.Characters.Interfaces;
using DndServer.Application.Characters.Models;
using DndServer.Application.Interfaces.Characters.Class;

namespace DndServer.Application.Characters.Services;

public class ClassService : IClassService
{
    private readonly IClassTemplateRepository _classTemplateRepository;

    public ClassService(IClassTemplateRepository classTemplateRepository)
    {
        _classTemplateRepository = classTemplateRepository;
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
}