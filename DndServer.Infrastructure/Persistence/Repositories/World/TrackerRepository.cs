using DndServer.Application.Interfaces.World;
using DndServer.Domain.World;

namespace DndServer.Infrastructure.Persistence.Repositories.World;

internal sealed class TrackerRepository : GenericRepository<Tracker>, ITrackerRepository
{
    private readonly DataContext _context;

    public TrackerRepository(DataContext context) : base(context)
    {
        _context = context;
    }
}