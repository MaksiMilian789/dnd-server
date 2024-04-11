using DndServer.Application.Interfaces.Character.Class;
using DndServer.Domain.Character.Class;

namespace DndServer.Infrastructure.Persistence.Repositories.Character.Class;

internal sealed class ClassTemplateRepository : GenericRepository<ClassTemplate>, IClassTemplateRepository
{
    private readonly DataContext _context;

    public ClassTemplateRepository(DataContext context) : base(context)
    {
        _context = context;
    }
}