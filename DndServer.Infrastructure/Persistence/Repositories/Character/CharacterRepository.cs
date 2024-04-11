using DndServer.Application.Interfaces.Character;

namespace DndServer.Infrastructure.Persistence.Repositories.Character;

internal sealed class CharacterRepository : GenericRepository<Domain.Character.Character>, ICharacterRepository
{
    private readonly DataContext _context;

    public CharacterRepository(DataContext context) : base(context)
    {
        _context = context;
    }
}