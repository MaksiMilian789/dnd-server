using DndServer.Application.Interfaces.Characters.Skill;
using DndServer.Domain.Characters.Skill;

namespace DndServer.Infrastructure.Persistence.Repositories.Characters.Skill;

internal sealed class SkillTemplateRepository : GenericRepository<SkillTemplate>, ISkillTemplateRepository
{
    private readonly DataContext _context;

    public SkillTemplateRepository(DataContext context) : base(context)
    {
        _context = context;
    }
}