using DndServer.Application.Interfaces.Character.Background;
using DndServer.Domain.Character.Background;

namespace DndServer.Infrastructure.Persistence.Repositories.Character.Background;

internal sealed class BackgroundInstanceRepository : GenericRepository<BackgroundInstance>,
    IBackgroundInstanceRepository
{
    private readonly DataContext _context;

    public BackgroundInstanceRepository(DataContext context) : base(context)
    {
        _context = context;
    }
}