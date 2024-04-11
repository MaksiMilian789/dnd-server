using DndServer.Application.Interfaces.World;

namespace DndServer.Infrastructure.Persistence.Repositories.World;

internal sealed class WorldRepository : GenericRepository<Domain.World.World>, IWorldRepository
{
    private readonly DataContext _context;

    public WorldRepository(DataContext context) : base(context)
    {
        _context = context;
    }
}