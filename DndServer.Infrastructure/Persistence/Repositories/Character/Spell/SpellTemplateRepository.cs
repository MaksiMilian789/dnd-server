using DndServer.Application.Interfaces.Character.Spell;
using DndServer.Domain.Character.Spell;

namespace DndServer.Infrastructure.Persistence.Repositories.Character.Spell;

internal sealed class SpellTemplateRepository : GenericRepository<SpellTemplate>, ISpellTemplateRepository
{
    private readonly DataContext _context;

    public SpellTemplateRepository(DataContext context) : base(context)
    {
        _context = context;
    }
}