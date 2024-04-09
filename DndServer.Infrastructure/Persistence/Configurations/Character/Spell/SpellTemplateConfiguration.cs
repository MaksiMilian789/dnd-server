using DndServer.Domain.Character.Spell;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DndServer.Infrastructure.Persistence.Configurations.Character.Spell;

public class SpellTemplateConfiguration : IEntityTypeConfiguration<SpellTemplate>
{
    public void Configure(EntityTypeBuilder<SpellTemplate> builder) =>
        builder.HasKey(x => x.Id);
}