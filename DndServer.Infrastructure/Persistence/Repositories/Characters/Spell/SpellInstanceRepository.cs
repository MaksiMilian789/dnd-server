using DndServer.Application.Interfaces.Characters.Spell;
using DndServer.Domain.Characters.Spell;

namespace DndServer.Infrastructure.Persistence.Repositories.Characters.Spell;

internal sealed class SpellInstanceRepository : GenericRepository<SpellInstance>, ISpellInstanceRepository
{
    private readonly DataContext _context;

    public SpellInstanceRepository(DataContext context) : base(context)
    {
        _context = context;
    }
}