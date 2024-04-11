using DndServer.Application.Interfaces.Characters.Class;
using DndServer.Domain.Characters.Class;

namespace DndServer.Infrastructure.Persistence.Repositories.Characters.Class;

internal sealed class ClassTemplateRepository : GenericRepository<ClassTemplate>, IClassTemplateRepository
{
    private readonly DataContext _context;

    public ClassTemplateRepository(DataContext context) : base(context)
    {
        _context = context;
    }
}