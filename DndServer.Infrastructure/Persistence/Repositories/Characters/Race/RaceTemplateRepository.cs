using DndServer.Application.Interfaces.Characters.Race;
using DndServer.Domain.Characters.Race;

namespace DndServer.Infrastructure.Persistence.Repositories.Characters.Race;

internal sealed class RaceTemplateRepository : GenericRepository<RaceTemplate>, IRaceTemplateRepository
{
    private readonly DataContext _context;

    public RaceTemplateRepository(DataContext context) : base(context)
    {
        _context = context;
    }
}