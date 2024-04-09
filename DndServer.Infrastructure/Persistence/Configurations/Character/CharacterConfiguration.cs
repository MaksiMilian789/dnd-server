using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DndServer.Infrastructure.Persistence.Configurations.Character;

public class CharacterConfiguration : IEntityTypeConfiguration<Domain.Character.Character>
{
    public void Configure(EntityTypeBuilder<Domain.Character.Character> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasMany(x => x.Conditions).WithMany(x => x.Character);
        builder.HasMany(x => x.ObjectInstance).WithMany(x => x.Character);
        builder.HasMany(x => x.Note).WithMany(x => x.Character);
        builder.HasMany(x => x.SkillInstance).WithMany(x => x.Character);
        builder.HasMany(x => x.SpellInstance).WithMany(x => x.Character);
    }
}