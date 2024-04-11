using DndServer.Application.Interfaces.Character.Background;
using DndServer.Domain.Character.Background;

namespace DndServer.Infrastructure.Persistence.Repositories.Character.Background;

internal sealed class BackgroundTemplateRepository : GenericRepository<BackgroundTemplate>,
    IBackgroundTemplateRepository
{
    private readonly DataContext _context;

    public BackgroundTemplateRepository(DataContext context) : base(context)
    {
        _context = context;
    }
}