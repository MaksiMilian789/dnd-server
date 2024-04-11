using DndServer.Application.Interfaces.User;

namespace DndServer.Infrastructure.Persistence.Repositories.User;

internal sealed class UserRepository : GenericRepository<Domain.User.User>, IUserRepository
{
    private readonly DataContext _context;

    public UserRepository(DataContext context) : base(context)
    {
        _context = context;
    }
}