using DndServer.Application.Interfaces.Character.Spell;
using DndServer.Domain.Character.Spell;

namespace DndServer.Infrastructure.Persistence.Repositories.Character.Spell;

internal sealed class SpellInstanceRepository : GenericRepository<SpellInstance>, ISpellInstanceRepository
{
    private readonly DataContext _context;

    public SpellInstanceRepository(DataContext context) : base(context)
    {
        _context = context;
    }
}