using DndServer.Domain.Character.Spell;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DndServer.Infrastructure.Persistence.Configurations.Character.Spell;

public class SpellInstanceConfiguration : IEntityTypeConfiguration<SpellInstance>
{
    public void Configure(EntityTypeBuilder<SpellInstance> builder)
    {
        builder.HasKey(x => x.Id);
        builder.ComplexProperty(x => x.Damage, b =>
        {
            b.ComplexProperty(z => z.DamageRoll);
            b.ComplexProperty(z => z.Type);
        });
        builder.ComplexProperty(x => x.ActionTime);
        builder.ComplexProperty(x => x.Components);
    }
}