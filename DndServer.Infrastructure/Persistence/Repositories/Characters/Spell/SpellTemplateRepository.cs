using DndServer.Application.Interfaces.Characters.Spell;
using DndServer.Domain.Characters.Spell;

namespace DndServer.Infrastructure.Persistence.Repositories.Characters.Spell;

internal sealed class SpellTemplateRepository : GenericRepository<SpellTemplate>, ISpellTemplateRepository
{
    private readonly DataContext _context;

    public SpellTemplateRepository(DataContext context) : base(context)
    {
        _context = context;
    }
}