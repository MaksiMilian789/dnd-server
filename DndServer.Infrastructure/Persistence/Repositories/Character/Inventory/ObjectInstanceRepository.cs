using DndServer.Application.Interfaces.Character.Inventory;
using DndServer.Domain.Character.Inventory;

namespace DndServer.Infrastructure.Persistence.Repositories.Character.Inventory;

internal sealed class ObjectInstanceRepository : GenericRepository<ObjectInstance>, IObjectInstanceRepository
{
    private readonly DataContext _context;

    public ObjectInstanceRepository(DataContext context) : base(context)
    {
        _context = context;
    }
}