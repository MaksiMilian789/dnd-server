using DndServer.Application.Worlds.Models;

namespace DndServer.Application.Worlds.Interfaces;

public interface ITrackerService
{
    public Task<TrackerDto> GetTracker(int worldId);
    public Task SetTracker(int worldId, List<TrackerUnitDto> trackerUnits);
}