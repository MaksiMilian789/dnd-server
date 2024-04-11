using DndServer.Application.Interfaces.Characters.Race;
using DndServer.Domain.Characters.Race;

namespace DndServer.Infrastructure.Persistence.Repositories.Characters.Race;

internal sealed class RaceInstanceRepository : GenericRepository<RaceInstance>, IRaceInstanceRepository
{
    private readonly DataContext _context;

    public RaceInstanceRepository(DataContext context) : base(context)
    {
        _context = context;
    }
}