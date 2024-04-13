using DndServer.Domain.Characters.Background;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DndServer.Infrastructure.Persistence.Configurations.Characters.Background;

public class BackgroundTemplateConfiguration : IEntityTypeConfiguration<BackgroundTemplate>
{
    public void Configure(EntityTypeBuilder<BackgroundTemplate> builder)
    {
    }
}