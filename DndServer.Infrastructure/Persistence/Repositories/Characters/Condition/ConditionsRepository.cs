using DndServer.Application.Interfaces.Characters.Condition;
using DndServer.Domain.Characters.Condition;

namespace DndServer.Infrastructure.Persistence.Repositories.Characters.Condition;

internal sealed class ConditionsRepository : GenericRepository<Conditions>, IConditionsRepository
{
    private readonly DataContext _context;

    public ConditionsRepository(DataContext context) : base(context)
    {
        _context = context;
    }
}