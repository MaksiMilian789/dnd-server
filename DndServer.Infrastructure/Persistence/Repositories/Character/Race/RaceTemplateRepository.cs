using DndServer.Application.Interfaces.Character.Race;
using DndServer.Domain.Character.Race;

namespace DndServer.Infrastructure.Persistence.Repositories.Character.Race;

internal sealed class RaceTemplateRepository : GenericRepository<RaceTemplate>, IRaceTemplateRepository
{
    private readonly DataContext _context;

    public RaceTemplateRepository(DataContext context) : base(context)
    {
        _context = context;
    }
}