using DndServer.Application.Characters.Interfaces;
using DndServer.Application.Characters.Models;
using DndServer.Application.Interfaces;

namespace DndServer.Application.Characters.Services;

public class CharacterInfoTemplateService<T> : ICharacterInfoTemplateService<T>
{
    private readonly IGenericRepository<T> _repository;

    public CharacterInfoTemplateService(IGenericRepository<T> repository)
    {
        _repository = repository;
    }

    public Task<List<CharacterInfoDto>> GetListTemplate(string login)
    {
        var listTemplates = _repository.Get();
        var listDto = new List<CharacterInfoDto>();
        foreach (var val in listTemplates)
        {
            var value = val as CharacterInfoDto;
            var dto = new CharacterInfoDto
            {
                Name = value!.Name,
                Description = value.Description,
                System = value.System,
                WorldId = value.WorldId
            };
            listDto.Add(dto);
        }

        return Task.FromResult(listDto);
    }
}