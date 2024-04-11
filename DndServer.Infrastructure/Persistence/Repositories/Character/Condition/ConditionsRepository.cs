using DndServer.Application.Interfaces.Character.Condition;
using DndServer.Domain.Character.Condition;

namespace DndServer.Infrastructure.Persistence.Repositories.Character.Condition;

internal sealed class ConditionsRepository : GenericRepository<Conditions>, IConditionsRepository
{
    private readonly DataContext _context;

    public ConditionsRepository(DataContext context) : base(context)
    {
        _context = context;
    }
}