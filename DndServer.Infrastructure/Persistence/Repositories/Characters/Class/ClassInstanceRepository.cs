using DndServer.Application.Interfaces.Characters.Class;
using DndServer.Domain.Characters.Class;

namespace DndServer.Infrastructure.Persistence.Repositories.Characters.Class;

internal sealed class ClassInstanceRepository : GenericRepository<ClassInstance>, IClassInstanceRepository
{
    private readonly DataContext _context;

    public ClassInstanceRepository(DataContext context) : base(context)
    {
        _context = context;
    }
}