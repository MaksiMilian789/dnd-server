using DndServer.Application.Interfaces.Worlds;
using DndServer.Application.Worlds.Interfaces;
using DndServer.Application.Worlds.Models;
using DndServer.Domain.Worlds;

namespace DndServer.Application.Worlds.Services;

public class TrackerService : ITrackerService
{
    private readonly ITrackerRepository _trackerRepository;
    private readonly ITrackerUnitRepository _trackerUnitRepository;

    public TrackerService(ITrackerRepository trackerRepository, ITrackerUnitRepository trackerUnitRepository)
    {
        _trackerRepository = trackerRepository;
        _trackerUnitRepository = trackerUnitRepository;
    }

    public Task<TrackerDto> GetTracker(int worldId)
    {
        var tracker = _trackerRepository.Get(x => x.World.Id == worldId).FirstOrDefault();
        if (tracker == null) throw new Exception();

        var units = tracker.TrackerUnits.Select(unit => new TrackerUnitDto
            { Name = unit.Name, Initiative = unit.Initiative, Color = unit.Color, Icon = unit.Icon }).ToList();

        var trackerDto = new TrackerDto(units)
        {
            Id = tracker.Id
        };
        return Task.FromResult(trackerDto);
    }

    public Task SetTracker(int worldId, List<TrackerUnitDto> trackerUnitsDto)
    {
        var tracker = _trackerRepository.Get(x => x.World.Id == worldId).FirstOrDefault();
        if (tracker == null) throw new Exception();

        foreach (var unit in tracker.TrackerUnits) _trackerUnitRepository.Remove(unit);

        var trackerUnits = new List<TrackerUnit>();
        foreach (var unit in trackerUnitsDto)
        {
            var newUnit = new TrackerUnit(unit.Name, unit.Initiative, unit.Color, unit.Icon);
            trackerUnits.Add(newUnit);
        }

        tracker.TrackerUnits = trackerUnits;
        _trackerRepository.Update(tracker);
        return Task.CompletedTask;
    }
}