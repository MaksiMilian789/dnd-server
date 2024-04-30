using DndServer.Application.Characters.Models;
using DndServer.Application.Characters.Models.Create;

namespace DndServer.Application.Characters.Interfaces;

public interface IConditionService
{
    public Task<List<ConditionDto>> GetConditions();
    public Task CreateCondition(ConditionCreateDto dto);
}