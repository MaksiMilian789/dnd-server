using DndServer.Domain.Characters.Spell;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DndServer.Infrastructure.Persistence.Configurations.Characters.Spell;

public class SpellTemplateConfiguration : IEntityTypeConfiguration<SpellTemplate>
{
    public void Configure(EntityTypeBuilder<SpellTemplate> builder)
    {
    }
}