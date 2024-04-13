using DndServer.Application.Interfaces.Characters.Inventory;
using DndServer.Domain.Characters.Inventory;

namespace DndServer.Infrastructure.Persistence.Repositories.Characters.Inventory;

internal sealed class ObjectTemplateRepository : GenericRepository<ObjectTemplate>, IObjectTemplateRepository
{
    private readonly DataContext _context;

    public ObjectTemplateRepository(DataContext context) : base(context)
    {
        _context = context;
    }
}