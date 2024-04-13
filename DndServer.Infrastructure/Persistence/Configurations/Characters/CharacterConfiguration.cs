using DndServer.Domain.Characters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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
    }
}