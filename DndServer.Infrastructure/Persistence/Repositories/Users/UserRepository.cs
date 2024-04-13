using DndServer.Application.Interfaces.Users;
using DndServer.Domain.Users;

namespace DndServer.Infrastructure.Persistence.Repositories.Users;

internal sealed class UserRepository : GenericRepository<User>, IUserRepository
{
    private readonly DataContext _context;

    public UserRepository(DataContext context) : base(context)
    {
        _context = context;
    }
}