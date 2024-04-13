using DndServer.Application.Interfaces.Characters.Skill;
using DndServer.Domain.Characters.Skill;

namespace DndServer.Infrastructure.Persistence.Repositories.Characters.Skill;

internal sealed class SkillInstanceRepository : GenericRepository<SkillInstance>, ISkillInstanceRepository
{
    private readonly DataContext _context;

    public SkillInstanceRepository(DataContext context) : base(context)
    {
        _context = context;
    }
}