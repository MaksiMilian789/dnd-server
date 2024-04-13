using DndServer.Application.Interfaces.Worlds;
using DndServer.Domain.Worlds;

namespace DndServer.Infrastructure.Persistence.Repositories.Worlds;

internal sealed class TrackerRepository : GenericRepository<Tracker>, ITrackerRepository
{
    private readonly DataContext _context;

    public TrackerRepository(DataContext context) : base(context)
    {
        _context = context;
    }
}