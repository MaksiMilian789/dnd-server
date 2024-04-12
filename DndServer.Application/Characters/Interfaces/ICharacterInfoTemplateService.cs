using DndServer.Application.Characters.Models;

namespace DndServer.Application.Characters.Interfaces;

public interface ICharacterInfoTemplateService<T>
{
    public Task<List<CharacterInfoDto>> GetListTemplate(string login);
}