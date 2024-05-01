using DndServer.Application.Characters.Models;
using DndServer.Application.Characters.Models.Create;

namespace DndServer.Application.Characters.Interfaces;

public interface IClassService
{
    public Task<List<ClassDto>> GetClasses();
    public Task CreateClassTemplate(ClassCreateDto dto);
}