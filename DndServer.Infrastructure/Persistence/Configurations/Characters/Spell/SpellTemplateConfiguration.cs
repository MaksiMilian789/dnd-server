using DndServer.Domain.Characters.Spell;
using DndServer.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Newtonsoft.Json;

namespace DndServer.Infrastructure.Persistence.Configurations.Characters.Spell;

public class SpellTemplateConfiguration : IEntityTypeConfiguration<SpellTemplate>
{
    public void Configure(EntityTypeBuilder<SpellTemplate> builder)
    {
        builder.HasKey(x => x.Id);
        builder.ComplexProperty(x => x.Damage, b => { b.ComplexProperty(z => z.DamageRoll); });
        builder.ComplexProperty(x => x.ActionTime);
        builder.Property(x => x.Components)
            .HasConversion(new ValueConverter<List<SpellComponents>, string>(
                v => JsonConvert.SerializeObject(v),
                v => JsonConvert.DeserializeObject<List<SpellComponents>>(v)));
    }
}