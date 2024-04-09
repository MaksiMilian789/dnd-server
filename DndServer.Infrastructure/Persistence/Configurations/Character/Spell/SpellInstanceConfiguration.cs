using DndServer.Domain.Character.Spell;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DndServer.Infrastructure.Persistence.Configurations.Character.Spell;

public class SpellInstanceConfiguration : IEntityTypeConfiguration<SpellInstance>
{
    public void Configure(EntityTypeBuilder<SpellInstance> builder) =>
        builder.HasKey(x => x.Id);
}