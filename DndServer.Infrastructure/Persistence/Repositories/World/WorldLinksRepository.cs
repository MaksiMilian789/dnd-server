using DndServer.Application.Interfaces.World;
using DndServer.Domain.World;

namespace DndServer.Infrastructure.Persistence.Repositories.World;

internal sealed class WorldLinksRepository : GenericRepository<WorldLinks>, IWorldLinksRepository
{
    private readonly DataContext _context;

    public WorldLinksRepository(DataContext context) : base(context)
    {
        _context = context;
    }
}