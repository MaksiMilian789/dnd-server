using DndServer.Application.Interfaces.World;
using DndServer.Domain.World;

namespace DndServer.Infrastructure.Persistence.Repositories.World;

internal sealed class WikiPageRepository : GenericRepository<WikiPage>, IWikiPageRepository
{
    private readonly DataContext _context;

    public WikiPageRepository(DataContext context) : base(context)
    {
        _context = context;
    }
}