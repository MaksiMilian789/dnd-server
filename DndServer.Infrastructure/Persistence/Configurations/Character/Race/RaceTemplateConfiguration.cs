using DndServer.Domain.Character.Race;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DndServer.Infrastructure.Persistence.Configurations.Character.Race;

public class RaceTemplateConfiguration : IEntityTypeConfiguration<RaceTemplate>
{
    public void Configure(EntityTypeBuilder<RaceTemplate> builder)
    {
    }
}