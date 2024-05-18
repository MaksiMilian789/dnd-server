using DndServer.Application.Interfaces.Worlds;
using DndServer.Domain.Worlds;
using Microsoft.EntityFrameworkCore;

namespace DndServer.Infrastructure.Persistence.Repositories.Worlds;

internal sealed class WorldLinksRepository : GenericRepository<WorldLinks>, IWorldLinksRepository
{
    private readonly DataContext _context;
    private readonly DbSet<WorldLinks> _dbSet;

    public WorldLinksRepository(DataContext context) : base(context)
    {
        _context = context;
        _dbSet = context.Set<WorldLinks>();
    }

    public IEnumerable<WorldLinks> GetWithoutTracking()
    {
        return _dbSet.AsNoTracking().AsEnumerable().ToList();
    }
}