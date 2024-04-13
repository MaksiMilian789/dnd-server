using DndServer.Application.Characters.Models;

namespace DndServer.Application.Characters.Interfaces;

public interface IClassService
{
    public Task<List<ClassDto>> GetClasses();
    public Task CreateClassTemplate(ClassCreateDto dto);
}