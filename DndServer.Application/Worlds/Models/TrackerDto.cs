namespace DndServer.Application.Worlds.Models;

public class TrackerDto
{
    public int Id { get; set; }
    public List<TrackerUnitDto> TrackerUnitDto { get; set; }

    public TrackerDto(List<TrackerUnitDto> trackerUnitDto)
    {
        TrackerUnitDto = trackerUnitDto;
    }
}