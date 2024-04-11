using DndServer.Domain.Characters.Race;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DndServer.Infrastructure.Persistence.Configurations.Characters.Race;

public class RaceTemplateConfiguration : IEntityTypeConfiguration<RaceTemplate>
{
    public void Configure(EntityTypeBuilder<RaceTemplate> builder)
    {
    }
}