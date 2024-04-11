using DndServer.Application.Interfaces.Character.Skill;
using DndServer.Domain.Character.Skill;

namespace DndServer.Infrastructure.Persistence.Repositories.Character.Skill;

internal sealed class SkillTemplateRepository : GenericRepository<SkillTemplate>, ISkillTemplateRepository
{
    private readonly DataContext _context;

    public SkillTemplateRepository(DataContext context) : base(context)
    {
        _context = context;
    }
}