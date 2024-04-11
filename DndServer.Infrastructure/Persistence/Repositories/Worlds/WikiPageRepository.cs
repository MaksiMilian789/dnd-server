using DndServer.Application.Interfaces.Worlds;
using DndServer.Domain.Worlds;

namespace DndServer.Infrastructure.Persistence.Repositories.Worlds;

internal sealed class WikiPageRepository : GenericRepository<WikiPage>, IWikiPageRepository
{
    private readonly DataContext _context;

    public WikiPageRepository(DataContext context) : base(context)
    {
        _context = context;
    }
}