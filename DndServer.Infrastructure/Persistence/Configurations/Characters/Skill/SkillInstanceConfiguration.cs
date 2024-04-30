using DndServer.Domain.Characters.Skill;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DndServer.Infrastructure.Persistence.Configurations.Characters.Skill;

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