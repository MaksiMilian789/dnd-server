using DndServer.Application.Interfaces.Worlds;
using DndServer.Domain.Worlds;

namespace DndServer.Infrastructure.Persistence.Repositories.Worlds;

internal sealed class WorldLinksRepository : GenericRepository<WorldLinks>, IWorldLinksRepository
{
    private readonly DataContext _context;

    public WorldLinksRepository(DataContext context) : base(context)
    {
        _context = context;
    }
}