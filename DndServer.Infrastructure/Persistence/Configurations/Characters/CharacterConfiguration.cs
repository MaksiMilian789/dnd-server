using DndServer.Domain.Characters;
using DndServer.Domain.Characters.Spell;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Newtonsoft.Json;

namespace DndServer.Infrastructure.Persistence.Configurations.Characters;

public class CharacterConfiguration : IEntityTypeConfiguration<Character>
{
    public void Configure(EntityTypeBuilder<Character> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasMany(x => x.Conditions).WithMany(x => x.Character);
        builder.HasMany(x => x.ObjectInstance).WithMany(x => x.Character);
        builder.HasMany(x => x.Note).WithMany(x => x.Character);
        builder.HasMany(x => x.SkillInstance).WithMany(x => x.Character);
        builder.HasMany(x => x.SpellInstance).WithMany(x => x.Character);
        builder.ComplexProperty(x => x.Characteristics);
        builder.Property(x => x.SpellSlots)
            .HasConversion(new ValueConverter<List<SpellSlot>, string>(
                v => JsonConvert.SerializeObject(v),
                v => JsonConvert.DeserializeObject<List<SpellSlot>>(v)));
        builder.Property(x => x.EnergySlots)
            .HasConversion(new ValueConverter<List<EnergySlot>, string>(
                v => JsonConvert.SerializeObject(v),
                v => JsonConvert.DeserializeObject<List<EnergySlot>>(v)));
    }
}