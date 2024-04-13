using DndServer.Application.Characters.Models;

namespace DndServer.Application.Characters.Interfaces;

public interface IBackgroundService
{
    public Task<List<BackgroundDto>> GetBackgrounds();
    public Task CreateBackgroundTemplate(BackgroundCreateDto dto);
}