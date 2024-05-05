using DndServer.Application.Interfaces;
using DndServer.Application.Interfaces.Worlds;
using DndServer.Application.Worlds.Interfaces;
using DndServer.Application.Worlds.Models;
using DndServer.Domain.Worlds;

namespace DndServer.Application.Worlds.Services;

public class TrackerService : ITrackerService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ITrackerRepository _trackerRepository;
    private readonly ITrackerUnitRepository _trackerUnitRepository;

    public TrackerService(ITrackerRepository trackerRepository, ITrackerUnitRepository trackerUnitRepository,
        IUnitOfWork unitOfWork)
    {
        _trackerRepository = trackerRepository;
        _trackerUnitRepository = trackerUnitRepository;
        _unitOfWork = unitOfWork;
    }

    public Task<TrackerDto> GetTracker(int worldId)
    {
        var trackers = _trackerRepository.Get();
        var tracker = trackers.FirstOrDefault(x => x.World.Id == worldId);
        if (tracker == null)
        {
            throw new Exception();
        }

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
        var trackers = _trackerRepository.Get();
        var tracker = trackers.FirstOrDefault(x => x.World.Id == worldId);
        if (tracker == null)
        {
            throw new Exception();
        }

        foreach (var unit in tracker.TrackerUnits)
        {
            _trackerUnitRepository.Remove(unit);
        }

        var trackerUnits = new List<TrackerUnit>();
        foreach (var unit in trackerUnitsDto)
        {
            var newUnit = new TrackerUnit(unit.Name, unit.Initiative, unit.Color, unit.Icon);
            trackerUnits.Add(newUnit);
        }

        tracker.TrackerUnits = trackerUnits;
        _trackerRepository.Update(tracker);

        _unitOfWork.SaveChanges();
        return Task.CompletedTask;
    }
}