using DndServer.Domain.Characters.Skill;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DndServer.Infrastructure.Persistence.Configurations.Characters.Skill;

public class SkillTemplateConfiguration : IEntityTypeConfiguration<SkillTemplate>
{
    public void Configure(EntityTypeBuilder<SkillTemplate> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasMany(x => x.BackgroundTemplate).WithMany(x => x.SkillTemplate);
        builder.HasMany(x => x.RaceTemplate).WithMany(x => x.SkillTemplate);
        builder.HasMany(x => x.SpellTemplate).WithMany(x => x.SkillTemplate);
        builder.HasMany(x => x.ObjectTemplate).WithMany(x => x.SkillTemplate);
        builder.HasMany(x => x.ClassTemplate).WithMany(x => x.SkillTemplate);
        builder.HasMany(x => x.Condition).WithMany(x => x.SkillTemplate);
        builder.ComplexProperty(x => x.ActionTime);
        builder.ComplexProperty(x => x.Value);

        builder.ComplexProperty(x => x.Value, a =>
        {
            a.ComplexProperty(y => y.Damage, b => { b.ComplexProperty(z => z.DamageRoll); });
            a.ComplexProperty(y => y.AttackBonus,
                b => { b.ComplexProperty(z => z.Damage, b => { b.ComplexProperty(z => z.DamageRoll); }); });
            a.ComplexProperty(y => y.Effect);
            a.ComplexProperty(y => y.Resistance, b => { b.ComplexProperty(z => z.DamageType); });
            a.ComplexProperty(y => y.TypeVision);
            a.ComplexProperty(y => y.PerLevel);
        });
    }
}