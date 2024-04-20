using DndServer.Application.Characters.Models;
using DndServer.Application.Characters.Models.Create;

namespace DndServer.Application.Characters.Interfaces;

public interface ISkillService
{
    public Task<List<SkillDto>> GetSkills();
    public Task CreateSkillTemplate(SkillCreateDto dto);
}