using DndServer.Domain.Character.Skill;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DndServer.Infrastructure.Persistence.Configurations.Character.Skill;

public class SkillInstanceConfiguration : IEntityTypeConfiguration<SkillInstance>
{
    public void Configure(EntityTypeBuilder<SkillInstance> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasMany(x => x.SpellInstance).WithMany(x => x.SkillInstance);
        builder.HasMany(x => x.BackgroundInstance).WithMany(x => x.SkillInstance);
        builder.HasMany(x => x.ClassInstance).WithMany(x => x.SkillInstance);
        builder.HasMany(x => x.RaceInstance).WithMany(x => x.SkillInstance);
        builder.HasMany(x => x.ObjectInstance).WithMany(x => x.SkillInstance);
    }
}