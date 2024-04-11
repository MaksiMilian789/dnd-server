using DndServer.Application.Interfaces.Worlds;
using DndServer.Domain.Worlds;

namespace DndServer.Infrastructure.Persistence.Repositories.Worlds;

internal sealed class WikiRepository : GenericRepository<Wiki>, IWikiRepository
{
    private readonly DataContext _context;

    public WikiRepository(DataContext context) : base(context)
    {
        _context = context;
    }
}