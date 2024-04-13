using DndServer.Application.Interfaces.Characters.Inventory;
using DndServer.Domain.Characters.Inventory;

namespace DndServer.Infrastructure.Persistence.Repositories.Characters.Inventory;

internal sealed class ObjectInstanceRepository : GenericRepository<ObjectInstance>, IObjectInstanceRepository
{
    private readonly DataContext _context;

    public ObjectInstanceRepository(DataContext context) : base(context)
    {
        _context = context;
    }
}