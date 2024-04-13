using DndServer.Domain.Characters.Inventory;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DndServer.Infrastructure.Persistence.Configurations.Characters.Inventory;

public class ObjectTemplateConfiguration : IEntityTypeConfiguration<ObjectTemplate>
{
    public void Configure(EntityTypeBuilder<ObjectTemplate> builder)
    {
    }
}