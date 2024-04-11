using DndServer.Application.Interfaces.Character.Inventory;
using DndServer.Domain.Character.Inventory;

namespace DndServer.Infrastructure.Persistence.Repositories.Character.Inventory;

internal sealed class ObjectTemplateRepository : GenericRepository<ObjectTemplate>, IObjectTemplateRepository
{
    private readonly DataContext _context;

    public ObjectTemplateRepository(DataContext context) : base(context)
    {
        _context = context;
    }
}