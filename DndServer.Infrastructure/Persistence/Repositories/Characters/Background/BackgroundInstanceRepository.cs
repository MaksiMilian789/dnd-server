using DndServer.Application.Interfaces.Characters.Background;
using DndServer.Domain.Characters.Background;

namespace DndServer.Infrastructure.Persistence.Repositories.Characters.Background;

internal sealed class BackgroundInstanceRepository : GenericRepository<BackgroundInstance>,
    IBackgroundInstanceRepository
{
    private readonly DataContext _context;

    public BackgroundInstanceRepository(DataContext context) : base(context)
    {
        _context = context;
    }
}