using DndServer.Application.Interfaces.Character.Skill;
using DndServer.Domain.Character.Skill;

namespace DndServer.Infrastructure.Persistence.Repositories.Character.Skill;

internal sealed class SkillInstanceRepository : GenericRepository<SkillInstance>, ISkillInstanceRepository
{
    private readonly DataContext _context;

    public SkillInstanceRepository(DataContext context) : base(context)
    {
        _context = context;
    }
}