using DndServer.Application.Characters.Models;
using DndServer.Application.Characters.Models.Create;

namespace DndServer.Application.Characters.Interfaces;

public interface ISpellService
{
    public Task<List<SpellDto>> GetSpells();
    public Task CreateSpellTemplate(SpellCreateDto dto);
}