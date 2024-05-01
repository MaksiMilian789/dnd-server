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

    /*public void UpdateBackgroundSkill(IEnumerable<SkillTemplate> skillTemplates, BackgroundTemplate backgroundTemplate)
    {
        foreach (var skillTemplate in skillTemplates)
        {
            _context.Attach(skillTemplate);
            skillTemplate.BackgroundTemplate.Add(backgroundTemplate);

            _context.Update(skillTemplate);
        }
    }*/
}