using DndServer.Application.Interfaces.Worlds;
using DndServer.Domain.Worlds;

namespace DndServer.Infrastructure.Persistence.Repositories.Worlds;

internal sealed class TrackerUnitRepository : GenericRepository<TrackerUnit>, ITrackerUnitRepository
{
    private readonly DataContext _context;

    public TrackerUnitRepository(DataContext context) : base(context)
    {
        _context = context;
    }
}