using DndServer.Application.Interfaces.Worlds;
using DndServer.Domain.Worlds;

namespace DndServer.Infrastructure.Persistence.Repositories.Worlds;

internal sealed class WorldRepository : GenericRepository<World>, IWorldRepository
{
    private readonly DataContext _context;

    public WorldRepository(DataContext context) : base(context)
    {
        _context = context;
    }
}