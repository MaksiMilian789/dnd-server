using DndServer.Application.Interfaces.Characters.Background;
using DndServer.Domain.Characters.Background;

namespace DndServer.Infrastructure.Persistence.Repositories.Characters.Background;

internal sealed class BackgroundTemplateRepository : GenericRepository<BackgroundTemplate>,
    IBackgroundTemplateRepository
{
    private readonly DataContext _context;

    public BackgroundTemplateRepository(DataContext context) : base(context)
    {
        _context = context;
    }

    public void Save() =>
        _context.SaveChangesAsync();
}