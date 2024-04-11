using DndServer.Application.Interfaces.Characters;
using DndServer.Domain.Characters;

namespace DndServer.Infrastructure.Persistence.Repositories.Characters;

internal sealed class CharacterRepository : GenericRepository<Character>, ICharacterRepository
{
    private readonly DataContext _context;

    public CharacterRepository(DataContext context) : base(context)
    {
        _context = context;
    }
}