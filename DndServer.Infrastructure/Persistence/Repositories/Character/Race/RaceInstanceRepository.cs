using DndServer.Application.Interfaces.Character.Race;
using DndServer.Domain.Character.Race;

namespace DndServer.Infrastructure.Persistence.Repositories.Character.Race;

internal sealed class RaceInstanceRepository : GenericRepository<RaceInstance>, IRaceInstanceRepository
{
    private readonly DataContext _context;

    public RaceInstanceRepository(DataContext context) : base(context)
    {
        _context = context;
    }
}