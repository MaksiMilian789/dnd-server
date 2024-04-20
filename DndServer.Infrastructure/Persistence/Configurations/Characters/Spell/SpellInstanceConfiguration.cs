using DndServer.Domain.Characters.Spell;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DndServer.Infrastructure.Persistence.Configurations.Characters.Spell;

public class SpellInstanceConfiguration : IEntityTypeConfiguration<SpellInstance>
{
    public void Configure(EntityTypeBuilder<SpellInstance> builder)
    {
        builder.HasKey(x => x.Id);
        builder.ComplexProperty(x => x.Damage, b => { b.ComplexProperty(z => z.DamageRoll); });
        builder.ComplexProperty(x => x.ActionTime);
        builder.ComplexProperty(x => x.Components);
    }
}