using DndServer.Domain.Characters.Skill;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DndServer.Infrastructure.Persistence.Configurations.Characters.Skill;

public class SkillTemplateConfiguration : IEntityTypeConfiguration<SkillTemplate>
{
    public void Configure(EntityTypeBuilder<SkillTemplate> builder)
    {
        builder.HasMany(x => x.BackgroundTemplate).WithMany(x => x.SkillTemplate);
        builder.HasMany(x => x.RaceTemplate).WithMany(x => x.SkillTemplate);
        builder.HasMany(x => x.SpellTemplate).WithMany(x => x.SkillTemplate);
        builder.HasMany(x => x.ObjectTemplate).WithMany(x => x.SkillTemplate);
        builder.HasMany(x => x.ClassTemplate).WithMany(x => x.SkillTemplate);
    }
}