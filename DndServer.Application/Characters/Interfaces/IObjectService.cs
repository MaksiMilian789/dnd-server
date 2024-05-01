using DndServer.Application.Characters.Models;
using DndServer.Application.Characters.Models.Create;

namespace DndServer.Application.Characters.Interfaces;

public interface IObjectService
{
    public Task<List<ObjectDto>> GetObjects();
    public Task CreateObjectTemplate(ObjectCreateDto dto);
}