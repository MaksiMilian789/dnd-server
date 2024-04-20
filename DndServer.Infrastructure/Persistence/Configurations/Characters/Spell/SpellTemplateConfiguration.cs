using DndServer.Domain.Characters.Spell;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DndServer.Infrastructure.Persistence.Configurations.Characters.Spell;

public class SpellTemplateConfiguration : IEntityTypeConfiguration<SpellTemplate>
{
    public void Configure(EntityTypeBuilder<SpellTemplate> builder)
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