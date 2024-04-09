using DndServer.Domain.Character.Background;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DndServer.Infrastructure.Persistence.Configurations.Character.Background;

public class BackgroundTemplateConfiguration : IEntityTypeConfiguration<BackgroundTemplate>
{
    public void Configure(EntityTypeBuilder<BackgroundTemplate> builder)
    {
    }
}