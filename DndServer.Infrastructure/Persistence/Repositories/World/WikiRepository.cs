using DndServer.Application.Interfaces.World;
using DndServer.Domain.World;

namespace DndServer.Infrastructure.Persistence.Repositories.World;

internal sealed class WikiRepository : GenericRepository<Wiki>, IWikiRepository
{
    private readonly DataContext _context;

    public WikiRepository(DataContext context) : base(context)
    {
        _context = context;
    }
}