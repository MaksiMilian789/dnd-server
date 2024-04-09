using DndServer.Domain.Character.Inventory;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DndServer.Infrastructure.Persistence.Configurations.Character.Inventory;

public class ObjectTemplateConfiguration : IEntityTypeConfiguration<ObjectTemplate>
{
    public void Configure(EntityTypeBuilder<ObjectTemplate> builder) =>
        builder.HasKey(x => x.Id);
}