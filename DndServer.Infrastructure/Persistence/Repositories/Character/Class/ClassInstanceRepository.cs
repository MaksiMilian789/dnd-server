using DndServer.Application.Interfaces.Character.Class;
using DndServer.Domain.Character.Class;

namespace DndServer.Infrastructure.Persistence.Repositories.Character.Class;

internal sealed class ClassInstanceRepository : GenericRepository<ClassInstance>, IClassInstanceRepository
{
    private readonly DataContext _context;

    public ClassInstanceRepository(DataContext context) : base(context)
    {
        _context = context;
    }
}